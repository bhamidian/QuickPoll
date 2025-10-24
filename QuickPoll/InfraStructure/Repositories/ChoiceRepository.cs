using QuickPoll.ApplicationService.DTOs;
using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.Domain.Contracts.Reposotories;
using QuickPoll.Domain.Entities;
using QuickPoll.InfraStructure;

namespace QuickPoll.Infrastructure.Repositories
{
    public class ChoiceRepository : IChoiceRepository
    {
        private readonly AppDbContext _dbContext;
        public ChoiceRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public Choice CreateChoice(CreateChoiceDTO choiceDTO)
        {
            try
            {
                if (IsChoiceExist(choiceDTO.Name))
                {
                    throw new Exception("choice exist!");
                }
                var choice = new Choice
                {
                    Name = choiceDTO.Name,

                };
                _dbContext.Choices.Add(choice);

                return choice;





            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }






        }
        public bool IsChoiceExist(string name)
        {
            return _dbContext.Choices.Any(c => c.Name == name);
        }


    }
}
