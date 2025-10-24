using QuickPoll.Domain.Entities;

namespace QuickPoll.ApplicationService.DTOs
{
    public class GetPollDTO
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public int TotalParticipants { get; set; }

        public List<GetQuestionsDTO> Questions { get; set; } = new();
        public List<User> Users { get; set; } = new();

        public string QuestionsDisplay { get; set; } = string.Empty;
        public string UsersDisplay { get; set; } = string.Empty;
    }
}
