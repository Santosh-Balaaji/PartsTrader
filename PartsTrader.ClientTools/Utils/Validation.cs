using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartsTrader.ClientTools.Utils
{
    public class Validation
    {
        public static Boolean ValidatePartNumber(string partNumber)
        {

            var partInformation = partNumber.Split('-');
            var partId = partInformation[0];
            var partCode = partInformation[1];

            Boolean partIdValidation = partId.All(char.IsDigit) && partId.Length.Equals(4);
            Boolean partCodeValidation = partCode.All(char.IsLetterOrDigit) && partCode.Length >= 4;

            if (partInformation.Length == 2)
            {
                if (partIdValidation && partCodeValidation)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}