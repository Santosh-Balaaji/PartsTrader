using PartsTrader.ClientTools.Data;
using System.Collections.Generic;

namespace PartsTrader.ClientTools.Service
{
    public interface IPartCatalogue
    {
        IEnumerable<PartSummary> GetCompatibleParts(string partNumber);
    }
}