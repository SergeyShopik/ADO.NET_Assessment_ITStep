using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Assessment1_ADO.NET
{
    public class SQLFlightDAO : SQLAbstactDAO, IFlightDAO
    {
        public const string DELETE_FLIGHT = "DELETE FROM Flight WHERE flightID = @id";
        public const string SELECT_ALL_FLIGHTS = "SELECT * FROM Flight";
        public const string SELECT_FLIGHT = "SELECT * FROM Flight WHERE flightID = @id";
        public const string SELECT_FLIGHTS_PER_DAY = "SELECT COUNT(*) FROM Flight WHERE flightDay = @day";
        public const string INSERT_FLIGHT =
        "INSERT INTO Flight(destination, flightNumber, planeType, flightTime, flightDay) " +
            "VALUES(@destination, @flightNumber, @planeType, @flightTime, @flightDay)";
        private const string UPDATE_FLIGHT =
        "UPDATE Flight SET destination = @destination, flightNumber = @flightNumber, planeType = @planeType," +
            "flightTime = @flightTime, flightDay = @flightDay WHERE flightID = @id";

        public void DeleteFlight(int id)
        {
            SqlConnection connection = (SqlConnection)GetConnection();
            SqlCommand cmd = new SqlCommand(DELETE_FLIGHT, connection);

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.Value = id;
            idParam.Direction = ParameterDirection.Input;
            idParam.SqlDbType = SqlDbType.Int;

            cmd.Parameters.Add(idParam);
            cmd.ExecuteNonQuery();
            ReleaseConnection(connection);
        }

        public IList<Flight> GetAllFlights()
        {
            IList<Flight> list = new List<Flight>();

            SqlConnection connection = (SqlConnection)GetConnection();
            SqlCommand cmd = new SqlCommand(SELECT_ALL_FLIGHTS, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    Flight flight = new Flight();

                    flight.Destination = (string)reader["destination"];
                    flight.FlightNumber = (int)reader["flightNumber"];
                    if(!reader.IsDBNull(3))
                    {
                        flight.PlaneType = (string)reader["planeType"];
                    }
                    flight.FlightTime = (DateTime)reader["flightTime"];
                    flight.FlightDay = (string)reader["flightDay"];

                    list.Add(flight);
                }
            }
            return list;
        }

        public Flight GetFlight(int id)
        {
            SqlConnection connection = (SqlConnection)GetConnection();
            SqlCommand cmd = new SqlCommand(SELECT_FLIGHT, connection);

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.Value = id;
            idParam.Direction = ParameterDirection.Input;
            idParam.SqlDbType = SqlDbType.Int;

            cmd.Parameters.Add(idParam);

            SqlDataReader reader = cmd.ExecuteReader();
            Flight flight = new Flight();

            if(reader.HasRows)
            {
                reader.Read();

                flight.Destination = reader.GetString(1);
                flight.FlightNumber = reader.GetInt32(2);
                flight.PlaneType = reader.GetString(3);
                flight.FlightTime = reader.GetDateTime(4);
                flight.FlightDay = reader.GetString(5);
            }

            ReleaseConnection(connection);

            return flight;
        }

        public int GetFlightsPerDay(string day)
        {
            SqlConnection connection = (SqlConnection)GetConnection();
            SqlCommand cmd = new SqlCommand(SELECT_FLIGHTS_PER_DAY, connection);

            SqlParameter dayParam = new SqlParameter();
            dayParam.ParameterName = "@day";
            dayParam.Value = day;
            dayParam.Direction = ParameterDirection.Input;
            dayParam.SqlDbType = SqlDbType.NVarChar;

            cmd.Parameters.Add(dayParam);

            int flightsNum = (int)cmd.ExecuteScalar();

            ReleaseConnection(connection);

            return flightsNum;
        }

        public void InsertFlight(Flight flight)
        {
            SqlConnection connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand(INSERT_FLIGHT, connection);

            SqlParameter destinationParam = new SqlParameter();
            destinationParam.Value = flight.Destination;
            destinationParam.ParameterName = "@destination";
            destinationParam.SqlDbType = SqlDbType.NVarChar;
            destinationParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(destinationParam);

            SqlParameter flightNumParam = new SqlParameter();
            flightNumParam.Value = flight.FlightNumber;
            flightNumParam.ParameterName = "@flightNumber";
            flightNumParam.SqlDbType = SqlDbType.Int;
            flightNumParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(flightNumParam);

            SqlParameter planeTypeParam = new SqlParameter();
            planeTypeParam.Value = flight.PlaneType;
            planeTypeParam.ParameterName = "@planeType";
            planeTypeParam.SqlDbType = SqlDbType.NVarChar;
            planeTypeParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(planeTypeParam);

            SqlParameter flightTimeParam = new SqlParameter();
            flightTimeParam.Value = flight.FlightTime;
            flightTimeParam.ParameterName = "@flightTime";
            flightTimeParam.SqlDbType = SqlDbType.DateTime;
            flightTimeParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(flightTimeParam);

            SqlParameter flightDayParam = new SqlParameter();
            flightDayParam.Value = flight.FlightDay;
            flightDayParam.ParameterName = "@flightDay";
            flightDayParam.SqlDbType = SqlDbType.NVarChar;
            flightDayParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(flightDayParam);

            cmd.ExecuteNonQuery();

            ReleaseConnection(connection);
        }

        public void UpdateFlight(Flight flight, int id)
        {
            SqlConnection connection = (SqlConnection)GetConnection();
            SqlCommand cmd = new SqlCommand(UPDATE_FLIGHT, connection);

            SqlParameter destinationParam = new SqlParameter();
            destinationParam.Value = flight.Destination;
            destinationParam.ParameterName = "@name";
            destinationParam.SqlDbType = SqlDbType.NVarChar;
            destinationParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(destinationParam);

            SqlParameter flightNumParam = new SqlParameter();
            flightNumParam.Value = flight.FlightNumber;
            flightNumParam.ParameterName = "@flightNumber";
            flightNumParam.SqlDbType = SqlDbType.Int;
            flightNumParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(flightNumParam);

            SqlParameter planeTypeParam = new SqlParameter();
            planeTypeParam.Value = flight.PlaneType;
            planeTypeParam.ParameterName = "@planeType";
            planeTypeParam.SqlDbType = SqlDbType.NVarChar;
            planeTypeParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(planeTypeParam);

            SqlParameter flightTimeParam = new SqlParameter();
            flightTimeParam.Value = flight.FlightTime;
            flightTimeParam.ParameterName = "@flightTime";
            flightTimeParam.SqlDbType = SqlDbType.DateTime;
            flightTimeParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(flightTimeParam);

            SqlParameter flightDayParam = new SqlParameter();
            flightDayParam.Value = flight.FlightDay;
            flightDayParam.ParameterName = "@flightDay";
            flightDayParam.SqlDbType = SqlDbType.NVarChar;
            flightDayParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(flightDayParam);

            cmd.ExecuteNonQuery();

            ReleaseConnection(connection);
        }
    }
}
