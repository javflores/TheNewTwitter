﻿using System.Collections.Generic;

namespace TheNewTwitter.Commands
{
    public class NoCommand : ICommand
    {
        public bool CanExecute(string action)
        {
            return true;
        }

        public IList<string> Execute(string action, IEnumerable<User> users)
        {
            return new List<string>();
        }
    }
}