using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportAdam
{
    public class Aircraft
    {
        public string? FlightNumber { get; set; }
        public Runway AssignedRunway {  get; set; }
        public AircraftStatus Status {  get; set; }


        public enum AircraftStatus
        { 
            TakeoffToBeRequested,
            TakeoffApproved,
            Airborne
        }

        public string Liftoff ()
        {
            if (Status == AircraftStatus.TakeoffApproved)
            {
                return new StringBuilder($"Flight {FlightNumber} has taken off on runway {AssignedRunway.RunwayCode}").ToString();
                Status = AircraftStatus.Airborne;
                AssignedRunway.IsClear = true;
                AssignedRunway = null;
            }
            else
            { 
                return new StringBuilder($"Takeoff not possible. Current status: {this.Status}").ToString();
            }

            

        }

        public string GiveDetails()
        {
            return new StringBuilder($"FlightNumber: {FlightNumber} / Status: {Status} / Assigned runway: {AssignedRunway}").ToString();
        }


    }
}
