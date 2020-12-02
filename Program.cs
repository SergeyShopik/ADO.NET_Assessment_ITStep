using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            IFlightDAO flightDAO = new SQLFlightDAO();
            Flight flight =
                new Flight("Monako", 805, "business jet", new DateTime(2020, 1, 15, 23, 0, 0), "tuesday");

            flightDAO.InsertFlight(flight);

            string day = "sunday";
            int flightNum = flightDAO.GetFlightsPerDay("sunday");
            Console.WriteLine($"Number of flights on {day}: {flightNum}");
        }
    }
}
