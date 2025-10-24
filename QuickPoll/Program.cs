using QuickPoll.ApplicationService.DTOs;
using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.ApplicationService.Services;
using QuickPoll.Domain.Contracts;
using QuickPoll.Domain.Contracts.Reposotories;
using QuickPoll.Domain.Contracts.Services;
using QuickPoll.Domain.Entities;
using QuickPoll.Domain.Enum;
using QuickPoll.Framwork;
using QuickPoll.Infrastructure.Repositories;
using QuickPoll.InfraStructure;
using Spectre.Console;


namespace QuickPoll
{
    public class Program
    {
        public static User? _currentuser = null;

        static void Main(string[] args)
        {
            using var _dbContext = new AppDbContext();

            IUserRepository userRepo = new UserRepository(_dbContext);
            IUserService userService = new UserService(userRepo);

            IPollRepository pollRepo = new PollRepository(_dbContext);
            IQuestionRepository questionRepo = new QuestionRepository(_dbContext);
            IChoiceRepository choiceRepo = new ChoiceRepository(_dbContext);
            IUnitOfWork unitOfWork = new UnitOfWork(_dbContext);

            IPollOperationService pollOperation = new PollOperationService(
                pollRepo,
                questionRepo,
                choiceRepo,
                userRepo,
                unitOfWork 
            );
            IChoiceService choiceService = new ChoiceService(choiceRepo);




            
            MainMenu(userService, pollOperation, choiceService);
        }

        static void MainMenu(IUserService userService, IPollOperationService pollOperation, IChoiceService choiceService)
        {
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(
                    new FigletText("Quick Poll").Centered().Color(Color.Blue));
                AnsiConsole.MarkupLine("[yellow]1[/]) Login");
                AnsiConsole.MarkupLine("[red]2[/]) Exit");

                var op = Console.ReadLine();
                if (op == "1")
                {
                    var username = AnsiConsole.Ask<string>("Enter Username:");
                    var password = AnsiConsole.Ask<string>("Enter Password:");

                    var result = userService.Login(username, password);

                    //if (!result.IsAuthenticate)
                    //{
                    //    AnsiConsole.MarkupLine("[red]Login failed![/]");
                    //    continue;
                    //}

                    _currentuser = result;
                    if (result.Role == Role.Admin)
                        AdminPanel(pollOperation, choiceService);
                    else
                        UserPanel(pollOperation);
                }
                else if (op == "2")
                    break;
            }
        }

        static void AdminPanel(IPollOperationService pollService, IChoiceService choiceService)
        {
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[yellow]1[/]) Add Poll");
                AnsiConsole.MarkupLine("[yellow]2[/]) Delete Poll");
                AnsiConsole.MarkupLine("[yellow]3[/]) View Scores");
                AnsiConsole.MarkupLine("[yellow]4[/]) Back");
                var op = Console.ReadLine();

                switch (op)
                {
                    case "1": AddPoll(pollService); break;
                    case "2": DeletePoll(pollService); break;
                    case "3": Scores(pollService); break;
                    case "4": return;
                }
            }
        }

        static void UserPanel(IPollOperationService pollService)
        {
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[yellow]1[/]) List Polls");
                AnsiConsole.MarkupLine("[yellow]2[/]) Take a Poll");
                AnsiConsole.MarkupLine("[yellow]3[/]) Exit");
                var op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        var polls = pollService.GetAll();
                        foreach (var poll in polls)
                        {
                            Console.WriteLine(
                                $"| {poll.Id,-3} | {poll.Subject,-20} | {poll.TotalParticipants,-5} | " +
                                $"{poll.QuestionsDisplay,-40} | {poll.UsersDisplay,-30} |");
                        }
                        break;
                    case "2":
                        TakeAPoll(pollService);
                        break;
                    case "3":
                        return;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void AddPoll(IPollOperationService pollService)
        {
            try
            {
                var subject = AnsiConsole.Ask<string>("Enter poll subject:");

                int numQuestions = AnsiConsole.Ask<int>("How many questions?");
                var qList = new List<CreateQuestionDTO>();

                for (int i = 1; i <= numQuestions; i++)
                {
                    var desc = AnsiConsole.Ask<string>($"Question #{i}:");
                    var qDto = new CreateQuestionDTO { Description = desc, Choices = new List<CreateChoiceDTO>() };
                    for (int j = 1; j <= 4; j++)
                    {
                        var cname = AnsiConsole.Ask<string>($"Choice #{j}:");
                        qDto.Choices.Add(new CreateChoiceDTO { Name = cname });
                    }
                    qList.Add(qDto);
                }

                var pollDTO = new CreatePollDTO
                {
                    AdminId = _currentuser.Id,
                    Subject = subject,
                    Questions = qList
                };

                pollService.CreatePoll(pollDTO);
                AnsiConsole.MarkupLine("[green]Poll created successfully![/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            }
        }

        static void DeletePoll(IPollOperationService pollService)
        {
            try
            {
                var polls = pollService.GetAll();

                Console.WriteLine();
                Console.WriteLine($"{"ID",-3} {"Subject",-20} {"Participants",-12} {"Questions",-40} {"Users",-30}");
                Console.WriteLine(new string('-', 110));

                foreach (var p in polls)
                {
                    Console.WriteLine(
                        $"| {p.Id,-3} | {p.Subject,-20} | {p.TotalParticipants,-12} | {p.QuestionsDisplay,-40} | {p.UsersDisplay,-30} |");
                }

                Console.WriteLine();
                int id = AnsiConsole.Ask<int>("Enter Poll ID to delete:");

                var result = pollService.Delete(id);

                if (result == null)
                {
                    AnsiConsole.MarkupLine("[red]Unexpected error: result is null.[/]");
                    return;
                }

                if (result.IsCorrect)
                {
                    AnsiConsole.MarkupLine($"[green]{result.Message}[/]");
                }
                else
                {
                    AnsiConsole.MarkupLine($"[yellow]{result.Message}[/]");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            }
        }


        static void TakeAPoll(IPollOperationService pollService)
        {
            try
            {
                var polls = pollService.GetAll();
                Console.WriteLine("\nAvailable Polls:\n");
                Console.WriteLine($"{"ID",-3} {"Subject",-20} {"Participants",-12} {"Questions",-40} {"Users",-30}");
                Console.WriteLine(new string('-', 110));

                foreach (var pol in polls)
                {
                    Console.WriteLine(
                        $"| {pol.Id,-3} | {pol.Subject,-20} | {pol.TotalParticipants,-5} | " +
                        $"{pol.QuestionsDisplay,-40} | {pol.UsersDisplay,-30} |");
                }

                Console.WriteLine();
                int pollId = AnsiConsole.Ask<int>("Enter poll ID to take:");

                var poll = pollService.GetPollById(pollId);
                if (poll == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Poll not found!");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                var selectedChoices = new List<int>();

                foreach (var q in poll.Questions)
                {
                    Console.WriteLine($"\n{q.Description}");

                    for (int i = 0; i < q.Choices.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {q.Choices[i].Name}");
                    }

                    while (true)
                    {
                        int selected = AnsiConsole.Ask<int>("Select choice number (1–4): ");

                        if (selected >= 1 && selected <= q.Choices.Count)
                        {
                            selectedChoices.Add(q.Choices[selected - 1].Id);
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Please enter a valid option (1–4).");
                        Console.ResetColor();
                    }
                }

                pollService.TakePoll(pollId, _currentuser.UserName, selectedChoices);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYour votes have been recorded successfully!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey(intercept: true);
        }


        static void Scores(IPollOperationService pollService)
        {
            try
            {
                Console.Write("Enter poll ID to view results: ");
                if (!int.TryParse(Console.ReadLine(), out int pollId))
                {
                    Console.WriteLine("Invalid poll ID.");
                    Console.ReadKey();
                    return;
                }

                var scores = pollService.GetScores(pollId);
                if (scores == null)
                {
                    Console.WriteLine(" Poll not found.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine($"\n Results for poll: {scores.Subject}");
                Console.WriteLine($"Total participants: {scores.TotalParticipants}\n");

                foreach (var question in scores.Questions)
                {
                    Console.WriteLine($"Question: {question.Description}");
                    var totalVotes = question.Choices.Sum(c => c.Votes);

                    foreach (var c in question.Choices.OrderByDescending(x => x.Votes))
                    {
                        double percent = totalVotes == 0 ? 0 :
                            (c.Votes * 100.0 / totalVotes);
                        string graph = new string('|', (int)(percent / 5));

                        Console.WriteLine($"{c.Description,-25} {c.Votes,3} votes ({percent,5:F1}%) {graph}");
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }




    }
}
