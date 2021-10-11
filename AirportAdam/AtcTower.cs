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
            return new StringBuilder($"Aircraft has been registered. Flightnumber: {aircraft.FlightNumber}").ToString();
        }

        public Aircraft? FindAircraft(string flightNumber)
        {
            return aircraftList.Find(x => x.FlightNumber == flightNumber);
        }

        public string RequestForTakeoff (string flightNumber)
        {
            if (FindAircraft(flightNumber) == null)
            {
                return new StringBuilder($"Not Allowed. Flightnumber does not exist.").ToString();
            }
            else if (FindAircraft(flightNumber).Status != Aircraft.AircraftStatus.TakeoffToBeRequested)
            {
                return new StringBuilder($"Not allowed. Current status must be TakeoffToBeRequested. Not {FindAircraft(flightNumber).Status}").ToString();
            }
            else if (Runways.Exists(x => x.IsClear != true))
            {
                return new StringBuilder($"No clear runway availlable at the moment.").ToString();
            }
            else
            {
                FindAircraft(flightNumber).Status = Aircraft.AircraftStatus.TakeoffApproved;
                FindAircraft(flightNumber).AssignedRunway = SearchClearRunway();
                FindAircraft(flightNumber).AssignedRunway.IsClear = false;

                return new StringBuilder($"Takeoff allowed - Assigned runway: {FindAircraft(flightNumber).AssignedRunway.RunwayCode}").ToString();
            }      
        }

        public IEnumerator AircraftSummary()
        {
            foreach (Aircraft aircraft in aircraftList)
            {
                yield return aircraft.GiveDetails();
            }
        }

        public IEnumerator<string> RunwaySummary()      //DIT IS DE FUNCTIE WAAR IK OP VAST ZIT
        {
            List<string> details = new();
            foreach (Runway runway in Runways)
            {
                details.Add(runway.GiveDetails());
            }
            foreach (string x in details)
            {
                yield return x;
            }
        }

        public Runway? SearchClearRunway()
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
                if (asciiNr >= 58 && asciiNr > 65)
                {
                    continue;
                }
                flightNumber += (char)asciiNr;
            } while (flightNumber.Length < 6);

            return flightNumber;
        }


    }
}
