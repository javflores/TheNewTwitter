using System;
using System.Collections.Generic;
using System.Linq;
using TheNewTwitter;
using TheNewTwitter.Commands;


namespace CommandLine
{
    class Application
    {
        static void Main(string[] args)
        {
            var allCommands = new List<ICommand> { new PostingCommand(), new ReadingCommand(), new FollowingCommand(), new WallCommand(), new NoCommand() };
            var users = new Users();
            var client = new Client(allCommands, users);

            DisplayWelcomeMessage();

            while (true)
            {
                var userAction = Console.ReadLine();
                var result = client.Process(userAction);
                result.ToList().ForEach(Console.WriteLine);

                Console.Write("\n");
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
        }
    }
}
