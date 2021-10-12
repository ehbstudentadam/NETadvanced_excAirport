using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportAdam
{
    public class AtcTower
    {
        private List<Aircraft> aircraftList = new();
        public List<Runway> Runways {  get; set; } = new List<Runway>();



        public string RegisterAircraft(Aircraft aircraft)
        { 
            aircraft.FlightNumber = RandomFilghtNumberGenerator();
            aircraft.Status = Aircraft.AircraftStatus.TakeoffToBeRequested;
            this.aircraftList.Add(aircraft);
            return new StringBuilder().AppendLine($"Aircraft has been registered. Flightnumber: {aircraft.FlightNumber}").ToString();
        }

        public Aircraft? FindAircraft(string flightNumber)
        {
            return aircraftList.Find(x => x.FlightNumber == flightNumber);
        }

        public string RequestForTakeoff (string flightNumber)
        {
            if (FindAircraft(flightNumber) == null)
            {
                return new StringBuilder().AppendLine($"Not Allowed. Flightnumber does not exist.").ToString();
            }
            else if (FindAircraft(flightNumber).Status != Aircraft.AircraftStatus.TakeoffToBeRequested)
            {
                return new StringBuilder().AppendLine($"Not allowed. Current status must be TakeoffToBeRequested. Not {FindAircraft(flightNumber).Status}.").ToString();
            }
            else if (Runways.Exists(x => x.IsClear != true))
            {
                return new StringBuilder().AppendLine($"No clear runway availlable at the moment.").ToString();
            }
            else
            {
                FindAircraft(flightNumber).Status = Aircraft.AircraftStatus.TakeoffApproved;
                FindAircraft(flightNumber).AssignedRunway = SearchClearRunway();
                FindAircraft(flightNumber).AssignedRunway.IsClear = false;

                return new StringBuilder().AppendLine($"Takeoff allowed - Assigned runway: {FindAircraft(flightNumber).AssignedRunway.RunwayCode}").ToString();
            }      
        }

        public string AircraftSummary()
        {
            StringBuilder x = new StringBuilder().AppendLine("Aircraft Summary:");
            foreach (Aircraft a in aircraftList)
            {
                x.AppendLine(a.GiveDetails());
            }
            return x.ToString();
        }

        public string RunwaySummary()
        {
            StringBuilder x = new StringBuilder().AppendLine("Runway Summary:");
            foreach (Runway r in Runways)
            {
                x.AppendLine(r.GiveDetails());
            }
            return x.ToString();
        }

        private Runway? SearchClearRunway()
        {
            return Runways.Find(x => x.IsClear == true);
        }

        private string RandomFilghtNumberGenerator()
        {
            string flightNumber = string.Empty;
            Random random = new Random();
            do
            {
                int asciiNr = random.Next(48, 91);
                if (asciiNr >= 58 && asciiNr < 65)
                {
                    continue;
                }
                flightNumber += (char)asciiNr;
            } while (flightNumber.Length < 6);

            return flightNumber;
        }


    }
}
