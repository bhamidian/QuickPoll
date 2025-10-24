using QuickPoll.ApplicationService.DTOs;
using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.Domain.Contracts.Reposotories;
using QuickPoll.Domain.Entities;
using QuickPoll.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickPoll.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _dbContext;
        public QuestionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Question Create(CreateQuestionDTO questionDTO, List<Choice> choices)
        {
            if (questionDTO == null)
                throw new ArgumentNullException(nameof(questionDTO));

            if (choices == null || choices.Count != 4)
                throw new ArgumentException("Each question must have exactly 4 choices.");

            try
            {
                var question = new Question
                {
                    Description = questionDTO.Description,
                    PollId = questionDTO.Id,  
                    Choices = choices
                };

                _dbContext.Questions.Add(question);
                return question; 
            }
            catch (Exception ex)
            {
                throw new Exception("A problem occurred while creating a question.", ex);
            }
        }
    }
}
