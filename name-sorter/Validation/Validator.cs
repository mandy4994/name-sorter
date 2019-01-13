using Microsoft.Extensions.Logging;
using NameSorter.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.App
{
    public class Validator : IValidator
    {
        private readonly ILogger<Validator> _logger;

        public Validator(ILogger<Validator> logger)
        {
            _logger = logger;
        }
        public bool ValidateArgs(string[] args)
        {
            if (args.Length != 1)
            {
                _logger.LogError("Arguements not valid");
                return false;
            }
            return true;
        }

        public bool ValidateNames(IList<string> listOfNames)
        {
            /*
             A name must have at least 1 given name and may have up to 3 given names.
             That means there should be at least 2 words in a name (a Given Name and a Last Name)
             and at most 4 words in a name (3 Given names and 1 Last Name)
             */
            bool valid = true;
            foreach(var name in listOfNames)
            {
                var nameArray = name.Split(' ');
                if(nameArray.Length < 2 || nameArray.Length > 4)
                {
                    _logger.LogWarning(Content.NameNotValid(name));
                    valid = false;
                }
            }
            return valid;
        }
    }
}
