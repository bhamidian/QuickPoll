public class PollScoresDTO
{
    public int PollId { get; set; }
    public string Subject { get; set; }
    public int TotalParticipants { get; set; }
    public List<QuestionScoresDTO> Questions { get; set; }
}

public class QuestionScoresDTO
{
    public string Description { get; set; }
    public List<ChoiceScoreDTO> Choices { get; set; }
}

public class ChoiceScoreDTO
{
    public string Description { get; set; }
    public int Votes { get; set; }
    public int Percent { get; set; }
    public string ChartBar { get; set; } = "-";
}
