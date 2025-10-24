using Microsoft.EntityFrameworkCore;
using QuickPoll.ApplicationService.DTOs;
using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.Domain.Contracts.Reposotories;
using QuickPoll.Domain.Entities;
using QuickPoll.InfraStructure;
using SkiaSharp;


namespace QuickPoll.Infrastructure.Repositories
{
    public class PollRepository : IPollRepository
    {
        private readonly AppDbContext _dbContext;
        public PollRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //public Poll Create(CreatePollDTO pollDTO)
        //{
        //    if (pollDTO == null)
        //        throw new ArgumentNullException(nameof(pollDTO));

        //    var poll = new Poll
        //    {
        //        AdminId = pollDTO.AdminId,
        //        Subject = pollDTO.Subject
        //    };

        //    _dbContext.Polls.Add(poll);
        //    return poll; 
        //}


        public void Delete(int id)
        {
            var poll = _dbContext.Polls.FirstOrDefault(p => p.Id == id);
  

            if (poll is null)
                throw new Exception("Poll not found!");

            if (poll.NormalUsers.Any())
                throw new InvalidOperationException("Cannot delete a poll with registered votes!");

            _dbContext.Polls.Remove(poll);
        }

        public List<Poll> GetAll()
        {
            return _dbContext.Polls
                .Include(p => p.Questions)
                .Include(p => p.NormalUsers)
                .ToList();
        }


        public void Add(Poll poll)
        {
            if (poll == null)
                throw new ArgumentNullException(nameof(poll));

            _dbContext.Polls.Add(poll);
        }

        public GetPollDTO? GetPollById(int id)
        {
            var poll = _dbContext.Polls
                .Include(p => p.Questions)
                    .ThenInclude(q => q.Choices)
                .FirstOrDefault(p => p.Id == id);

            if (poll == null)
                return null;

            return new GetPollDTO
            {
                Id = poll.Id,
                Subject = poll.Subject,
                Questions = poll.Questions.Select(q => new GetQuestionsDTO
                {
                    Description = q.Description, 
                    Choices = q.Choices.Select(c => new GetChoicesDTO
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList()
                }).ToList()
            };
        }

        public Poll? GetPollEntityById(int id)
        {
            return _dbContext.Polls
                .Include(p => p.Questions)
                    .ThenInclude(q => q.Choices)
                        .ThenInclude(c => c.NormalUsers)
                .Include(p => p.NormalUsers)
                .FirstOrDefault(p => p.Id == id);
        }


    }
}
