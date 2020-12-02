using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1_ADO.NET
{
    public class Flight
    {
        public string Destination { get; set; }
        public int FlightNumber { get; set; }
        public string PlaneType { get; set; }
        public DateTime FlightTime { get; set; }
        public string FlightDay { get; set; }

        public Flight()
        {

        }
        public Flight(string dest, int flightNum, string planeType, DateTime flightTime, string flightDay)
        {
            Destination = dest;
            FlightNumber = flightNum;
            PlaneType = planeType;
            FlightTime = flightTime;
            FlightDay = flightDay;
        }

        public override string ToString()
        {
            return $"Flight info:\n" +
                   $"destination: {Destination}, number: {FlightNumber}, plane: {PlaneType}\n" +
                   $"time: {FlightTime}, day: {FlightDay}";
        }
    }
}
