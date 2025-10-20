namespace QuickPoll
{
    public class Program
    {
        static void Main(string[] args)
        {


        }

        static void MainMenu()
        {
            while(true)
            {
                Console.WriteLine("1.Login");
                Console.WriteLine("2.Exit");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":

                        break;
                }


            }

            
        }


        static void Login()
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

        }

        static int OptionSelector()
        {
            if(int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;

            }
            else
            {
                Console.WriteLine("Invalid Option!");
            }

            return 0;


        }
    }
}
