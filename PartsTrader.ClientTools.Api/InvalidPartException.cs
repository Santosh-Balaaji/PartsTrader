using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartsTrader.ClientTools.Api
{
    public class InvalidPartException: Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPartException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidPartException(string message) : base(message)
        {}
    }
}