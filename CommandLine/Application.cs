using System;
using System.Collections.Generic;
using System.Linq;
using TheNewTwitter;
using TheNewTwitter.Commands;
using TheNewTwitter.Model;

namespace CommandLine
{
    public class Application
    {
        public static void Main(string[] args)
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
            while (true)
            {
                var userAction = Console.ReadLine();
                var result = client.Process(userAction);
                DisplayUserActionResult(result);
            }
        }

        static void DisplayUserActionResult(IList<string> result)
        {
            result.ToList().ForEach(Console.WriteLine);
        }
    }
}
