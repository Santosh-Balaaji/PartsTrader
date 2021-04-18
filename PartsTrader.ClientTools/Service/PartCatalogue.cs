using PartsTrader.ClientTools.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartsTrader.ClientTools.Service
{
    public class PartCatalogue : IPartCatalogue
    {
        public IEnumerable<PartSummary> GetCompatibleParts(string partNumber)
        {
            throw new Exception();
        }

    }
}