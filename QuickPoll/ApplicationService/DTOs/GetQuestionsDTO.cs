namespace QuickPoll.ApplicationService.DTOs
{
    public class GetQuestionsDTO
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<GetChoicesDTO> Choices { get; set; } = new();
    }
}
