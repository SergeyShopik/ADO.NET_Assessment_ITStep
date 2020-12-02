using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1_ADO.NET
{
    public interface IFlightDAO
    {
        IList<Flight> GetAllFlights();
        void InsertFlight(Flight flight);

        void DeleteFlight(int id);

        void UpdateFlight(Flight flight, int id);

        int GetFlightsPerDay(string day);

        Flight GetFlight(int id);
    }
}
