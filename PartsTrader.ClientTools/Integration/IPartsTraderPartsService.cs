using PartsTrader.ClientTools.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartsTrader.ClientTools.Integration
{
    public interface IPartsTraderPartsService
    {
        IEnumerable<PartSummary> FindAllCompatibleParts(string partNumber);
    }
}