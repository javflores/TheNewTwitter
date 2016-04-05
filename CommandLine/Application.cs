using System;
using System.Collections.Generic;
using System.Linq;
using TheNewTwitter;
using TheNewTwitter.Commands;
using TheNewTwitter.Model;


namespace CommandLine
{
    class Application
    {
        static void Main(string[] args)
        {
            var client = InitializeClient();

            ExecuteApplication(client);
        }

        static Client InitializeClient()
        {
            var allCommands = new List<ICommand>
            {
                new PostingCommand(),
                new ReadingCommand(),
                new FollowingCommand(),
                new WallCommand(),
                new NoCommand()
            };
            var users = new Users();
            var client = new Client(allCommands, users);
            return client;
        }

        static void ExecuteApplication(Client client)
        {
            DisplayWelcomeMessage();

            while (true)
            {
                var userAction = Console.ReadLine();
                var result = client.Process(userAction);
                DisplayUserActionResult(result);
            }
        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to The New Twitter!");
            Console.WriteLine("___________________________");
            Console.WriteLine("You can...");
            Console.WriteLine("Posting: Publish messages to a personal timeline. Run: User -> Message");
            Console.WriteLine("Reading: View a personal timeline. Run: User");
            Console.WriteLine("Following: Subscribe to user’s timeline. Run: User follows OtherUser");
            Console.WriteLine("Wall: View an aggregated list of all subscriptions. Example: User wall");
            Console.WriteLine("___________________________");
            Console.Write("\n");
        }

        static void DisplayUserActionResult(IList<string> result)
        {
            result.ToList().ForEach(Console.WriteLine);
            Console.Write("\n");
        }
    }
}
