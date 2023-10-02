using System;
using System.Collections.Generic;
using System.Text;

namespace URLShortener.Core.Exceptions
{
    public class SlugAlreadyExistException : Exception
    {
        public SlugAlreadyExistException(string slug)
            : base($"'{slug}' is already exist.")
        {
        }
    }
}
