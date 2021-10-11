using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportAdam
{
    public class Runway
    {
        public string RunwayCode { get; set; }
        public bool IsClear { get; set; }

        public Runway (string runwaycode)
        {
            RunwayCode = runwaycode;
            IsClear = true;
        }


        public string GiveDetails()
        {
            string clearStatus = "Not clear";
            if (IsClear)
            {
                clearStatus = "Clear";
            }
            return new StringBuilder($"Runway code: {RunwayCode} / Status: {clearStatus}").ToString();
        }

        
    }
}
