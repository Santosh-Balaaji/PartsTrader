using Newtonsoft.Json;
using PartsTrader.ClientTools.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PartsTrader.ClientTools.Utils
{
    public class JsonContext
    {
        public static List<PartSummary> GetPartsData(string locationURL)
        {
            List<PartSummary> items = new List<PartSummary>();
            using (StreamReader r = new StreamReader(locationURL))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<PartSummary>>(json);

            }
            return items;
        }
    }
}