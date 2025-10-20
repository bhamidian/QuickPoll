using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.Domain.Contracts.Reposotories;
using QuickPoll.Domain.Entities;
using QuickPoll.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Infrastructure.Repositories
{
    public class PollRepository : IPollRepository
    {
        private readonly AppDbContext _dbContext;
        public PollRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(CreatePollDTO pollDTO, CreateQuestionDTO questionDTO, CreateChoiceDTO choiceDTO)
        {
            try
            {
                var poll = _dbContext.Polls.Add(new Poll
                {
                    Subject = pollDTO.Subject,
                    Questions = (List<Question>)pollDTO.Questions.Select(q => new Question
                    {
                        QuestionNumber = questionDTO.QuestionNumber,
                        Description = questionDTO.Description,

                        Choices = (List<Choice>)questionDTO.Choices.Select(c => new Choice
                        {
                            ChoiceNumber = choiceDTO.ChoiceNumber,
                            IsCorrect = choiceDTO.IsCorrect,
                            Name = choiceDTO.Name
                        })

                    })
                });
            }

            catch (Exception ex)
            {
                throw new Exception("There was an error while updating data" + ex.Message);
            }
            
           



        }
    }
}
