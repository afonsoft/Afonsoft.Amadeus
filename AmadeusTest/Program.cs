using Afonsoft.Amadeus;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace AmadeusTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ILoggerFactory loggerFactory = new LoggerFactory().AddConsole();

                //https://developers.amadeus.com/self-service
                Console.WriteLine("Test Amadeus!");
                Configuration config = Amadeus.Builder("b5xf3fHrjc9clfQp8euNA59QiOaTn6c8", "o9nVf3UuePnsAs2T");
                config.Host = "test.api.amadeus.com";
                config.CustomAppId = "AFONSOFT";
                config.CustomAppVersion = "V1";

                config.Logger = loggerFactory.CreateLogger<Program>();
                config.LogLevel = LogLevel.Debug;

                Amadeus amadeus = config.build();

                if (amadeus != null)
                {

                    var airlines = amadeus.referenceData.airlines.Get(Params.with("airlineCodes", "G3"));

                    if (airlines != null)
                    {

                        //https://test.api.amadeus.com/v1/shopping/flight-offers?origin=NYC&destination=MAD&departureDate=2019-07-25&returnDate=2019-07-31&adults=1&nonStop=false&currency=BRL&max=200

                        var flightOffers = amadeus.shopping.FlightOffers.Get(Params
                                                                .with("origin", "NYC")
                                                                .and("destination", "MAD")
                                                                .and("currency", "BRL")
                                                                .and("oneWay", "false")
                                                                .and("viewBy", "DATE")
                                                                .and("departureDate", "2019-07-25")
                                                                .and("returnDate", "2019-07-31")
                                                                .and("adults", "1")
                                                                .and("max", "200"));


                        if (flightOffers != null)
                        {

                            var checkin = amadeus.referenceData.urls.checkinLinks.Get(Params.with("airlineCode", "G3").and("language", "pt"));

                            if (checkin != null)
                            {
                                //Hoteis
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}