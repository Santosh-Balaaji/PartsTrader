using PartsTrader.ClientTools.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartsTrader.ClientTools.Integration
{
    public class PartsTraderPartsService : IPartsTraderPartsService
    {
        private static IEnumerable<PartSummary> _partsList;
        private static IEnumerable<PartSummary> _exclusionList;
        public PartsTraderPartsService(IEnumerable<PartSummary> partsList, IEnumerable<PartSummary> exclusionList)
        {
            _partsList = partsList;
            _exclusionList = exclusionList;
        }
        public IEnumerable<PartSummary> FindAllCompatibleParts(string partNumber)
        {   
            var excludedParts = _exclusionList.Where(f => f.PartNumber == partNumber);
            var compatibleParts = _partsList.Where(f => f.PartNumber == partNumber);
            if (excludedParts.Count() > 0)
                return new List<PartSummary>();
            return compatibleParts;
        }
    }
}