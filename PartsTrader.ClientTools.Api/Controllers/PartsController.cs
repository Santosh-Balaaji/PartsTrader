using PartsTrader.ClientTools.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PartsTrader.ClientTools.Utils;
using PartsTrader.ClientTools.Service;
using PartsTrader.ClientTools.Integration;

namespace PartsTrader.ClientTools.Api.Controllers
{
    public class PartsController : ApiController
    {
        private static IEnumerable<PartSummary> _partsList, _exclusionList;
        IPartsTraderPartsService partService;
        private readonly string exclusionURL = "D:/learnings/PartsTrader/PartsTrader.ClientTools/PartsTrader.ClientTools/Exclusions.json";
        private readonly string partsLookupURL = "D:/learnings/PartsTrader/PartsTrader.ClientTools/PartsTrader.ClientTools/PartsLookup.json";
        public PartsController()
        {
           _partsList = JsonContext.GetPartsData(partsLookupURL);
           _exclusionList = JsonContext.GetPartsData(exclusionURL);
           partService = new PartsTraderPartsService(_partsList, _exclusionList);
        }
        // GET: api/Parts
        public IEnumerable<PartSummary> GetAllParts()
        {
            return _partsList;
        }

        // GET: api/Parts/1111-Invoice
        public IEnumerable<PartSummary> GetParts(string partNumber)
        {
            if (Validation.ValidatePartNumber(partNumber))
                return partService.FindAllCompatibleParts(partNumber);
            else
                throw new InvalidPartException("Invalid Part Number");
        }
       
    }
}
