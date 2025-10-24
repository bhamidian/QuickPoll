using QuickPoll.ApplicationService.DTOs;
using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.Domain.Contracts;
using QuickPoll.Domain.Contracts.Reposotories;
using QuickPoll.Domain.Contracts.Services;
using QuickPoll.Domain.Entities;
using QuickPoll.Infrastructure.Repositories;

namespace QuickPoll.ApplicationService.Services
{
    public class PollOperationService : IPollOperationService
    {
        private readonly IPollRepository _pollRepository;
        private readonly IChoiceRepository _choiceRepository;
        private readonly IUserRepository _userRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;


        public PollOperationService(
            IPollRepository pollRepository,
            IQuestionRepository questionRepository,
            IChoiceRepository choiceRepository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _pollRepository = pollRepository;
            _questionRepository = questionRepository; 
            _choiceRepository = choiceRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }


        public ResultDTO? Delete(int id)
        {
            try
            {
                var poll = _pollRepository.GetPollEntityById(id);

                if (poll == null)
                    return new ResultDTO { IsCorrect = false, Message = "Poll not found." };

                if (poll.NormalUsers != null && poll.NormalUsers.Any())
                    return new ResultDTO
                    {
                        IsCorrect = false,
                        Message = " Cannot delete this poll because users have already participated."
                    };

                _pollRepository.Delete(id);
                _unitOfWork.SaveUnitOfWork();

                return new ResultDTO { IsCorrect = true, Message = "Poll successfully deleted!" };
            }
            catch (Exception ex)
            {
                return new ResultDTO { IsCorrect = false, Message = $"Error: {ex.Message}" };
            }
        }


        public List<GetPollDTO> GetAll()
        {
            var polls = _pollRepository.GetAll();

            return polls.Select(p => new GetPollDTO
            {
                Id = p.Id,
                Subject = p.Subject,
                TotalParticipants = p.NormalUsers?.Count ?? 0,

                Questions = p.Questions.Select(q => new GetQuestionsDTO
                {
                    Id = q.Id,
                    Description = q.Description
                }).ToList(),

                Users = p.NormalUsers.Cast<User>().ToList(),

                QuestionsDisplay = string.Join(", ", p.Questions.Select(q => q.Description)),
                UsersDisplay = string.Join(", ", p.NormalUsers.Select(u => u.UserName))
            }).ToList();
        }




        public void CreatePoll(CreatePollDTO pollDTO)
        {
            var poll = new Poll
            {
                Subject = pollDTO.Subject,
                AdminId = pollDTO.AdminId
            };

            _unitOfWork.Polls.Add(poll);

            foreach (var questionDTO in pollDTO.Questions)
            {
                if (questionDTO.Choices.Count != 4)
                    throw new ArgumentException("Each question must have exactly 4 choices.");

                var choices = questionDTO.Choices
                    .Select(c => _unitOfWork.Choices.CreateChoice(c))
                    .ToList();

                var question = _unitOfWork.Questions.Create(questionDTO, choices);
                question.Poll = poll; 
            }

            _unitOfWork.SaveUnitOfWork();
        }

        public GetPollDTO? GetPollById(int id)
        {
            return _pollRepository.GetPollById(id)
                ?? throw new Exception("Poll not found!");
        }

        public void TakePoll(int pollId, string username, List<int> inputs)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username must be provided.");

            var poll = _pollRepository.GetPollEntityById(pollId)
                       ?? throw new Exception("Poll not found.");

            var user = _userRepository.GetUserByUsername(username)
                       ?? throw new Exception("User not found.");

            if (user is not NormalUser normalUser)
                throw new Exception("Only normal users can participate in a poll.");

            if (poll.NormalUsers.Any(u => u.Id == normalUser.Id))
                throw new Exception("You have already participated in this poll.");

            for (int i = 0; i < poll.Questions.Count; i++)
            {
                var question = poll.Questions[i];
                var selectedChoiceId = inputs[i];

                var selectedChoice = question.Choices.FirstOrDefault(c => c.Id == selectedChoiceId)
                                      ?? throw new Exception($"Invalid choice for question {i + 1}");

                selectedChoice.NormalUsers.Add(normalUser);
            }

            poll.NormalUsers.Add(normalUser);
            _unitOfWork.SaveUnitOfWork();
        }



        public Poll GetPollEntityById(int id)
        {
            var poll = _pollRepository.GetPollEntityById(id);
            if (poll is null)
                throw new Exception("no poll found!");
            return poll;
        }
        public PollScoresDTO GetScores(int pollId)
        {
            var poll = _pollRepository.GetPollEntityById(pollId);
            if (poll == null)
                throw new Exception("Poll not found.");

            var dto = new PollScoresDTO
            {
                PollId = poll.Id,
                Subject = poll.Subject,
                TotalParticipants = poll.NormalUsers?.Count ?? 0,
                Questions = poll.Questions.Select(q =>
                {
                    var totalVotesForQuestion = q.Choices.Sum(c => c.NormalUsers.Count);

                    return new QuestionScoresDTO
                    {
                        Description = q.Description,
                        Choices = q.Choices.Select(c =>
                        {
                            var votes = c.NormalUsers.Count;
                            var percent = totalVotesForQuestion == 0 ? 0 :
                                (int)Math.Round((votes * 100.0) / totalVotesForQuestion);

                            return new ChoiceScoreDTO
                            {
                                Description = c.Name,
                                Votes = votes,
                                Percent = percent,
                                ChartBar = new string('|', percent / 5) 
                            };
                        }).OrderByDescending(x => x.Votes).ToList()
                    };
                }).ToList()
            };

            return dto;
        }


    }
}
