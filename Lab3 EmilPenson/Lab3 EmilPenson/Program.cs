using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_EmilPenson
    //Emil Penson
    //2821,1km
{
    class Program
    {
        static string[] places = new string[] { "Stockholm", "Göteborg", "Oslo", "Luleå", "Helsinki", "Berlin", "Paris" };
        static double[] latitudes = new double[] { 59.3261917, 57.7010496, 59.8939529, 65.5867395, 60.11021, 52.5069312, 48.859 };
        static double[] longitudes = new double[] { 17.7018773, 11.6136602, 10.6450348, 22.0422998, 24.7385057, 13.1445521, 2.2069765 };
        static string[] cityRoute = new string[] { "Helsinki", "Luleå", "Oslo", "Paris" };


        static void Main(string[] args)
        {
            int mode = int.Parse(Console.ReadLine());
            switch (mode)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(GetDistanceKilometers(cityRoute));
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine(GetDistanceKilometers("Göteborg", "Luleå"));
                    Console.ReadKey();
                    break;
            }
        }
        private static double GetDistanceKilometers(double xAxis1, double xAxis2, double yAxis1, double yAxis2)
        {
            double distance = (2 * 6371) * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((DegreesIntoRadians(xAxis2) - DegreesIntoRadians(xAxis1)) / 2), 2) +
                 Math.Cos(DegreesIntoRadians(xAxis1)) * Math.Cos(DegreesIntoRadians(xAxis2)) *
                 Math.Pow(Math.Sin((DegreesIntoRadians(yAxis2) - DegreesIntoRadians(yAxis1)) / 2), 2)));
            return Math.Round(distance, 2);
        }
        private static double DegreesIntoRadians(double degrees)
        {
            double radian = degrees * (Math.PI / 180);
            return radian;
        }
        private static double GetDistanceKilometers(string[] cityRoute)
        {
            double distance = 0;
            for (int i = 0; i < cityRoute.Length - 1; i++)
            {
                distance += GetDistanceKilometers(cityRoute[i], cityRoute[i + 1]);
            }
            return distance;
        }
        private static double GetDistanceKilometers(string startCity, string endCity)
        {
            return GetDistanceKilometers
            (
                latitudes[Array.IndexOf(places, startCity)],
                latitudes[Array.IndexOf(places, endCity)],
                longitudes[Array.IndexOf(places, startCity)],
                longitudes[Array.IndexOf(places, endCity)]
            );
        }
    }

}
