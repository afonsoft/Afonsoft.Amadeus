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
            //https://developers.amadeus.com/self-service
            Console.WriteLine("Test Amadeus!");

            Configuration config = Amadeus.Builder("b5xf3fHrjc9clfQp8euNA59QiOaTn6c8", "o9nVf3UuePnsAs2T", new Afonsoft.Logger.LoggerProvider<Program>().CreateLogger());
            try
            {
                
                config.SetHostname("test");
                config.CustomAppId = "AFONSOFT";
                config.CustomAppVersion = "V1";

                config.LogLevel = LogLevel.Information;

                Amadeus amadeus = config.Build();

                if (amadeus != null)
                {
                    config.Logger.LogInformation("Airlines#Get");
                    var airlines = amadeus.ReferenceData.Airlines.Get(Params.With("airlineCodes", "G3"));

                    if (airlines != null)
                    {

                        //https://test.api.amadeus.com/v1/shopping/flight-offers?origin=NYC&destination=MAD&departureDate=2019-07-25&returnDate=2019-07-31&adults=1&nonStop=false&currency=BRL&max=200

                        config.Logger.LogInformation("FlightOffers#Get");
                        var flightOffers = amadeus.Shopping.FlightOffers.Get(Params
                                                                .With("origin", "NYC")
                                                                .And("destination", "MAD")
                                                                .And("currency", "BRL")
                                                                .And("oneWay", "false")
                                                                .And("viewBy", "DATE")
                                                                .And("departureDate", "2019-07-25")
                                                                .And("returnDate", "2019-07-31")
                                                                .And("adults", "1")
                                                                .And("max", "200"));


                        if (flightOffers != null)
                        {

                            config.Logger.LogInformation("ReferenceData#Urls#CheckinLinks#Get");
                            var checkin = amadeus.ReferenceData.Urls.CheckinLinks.Get(Params.With("airlineCode", "G3").And("language", "pt"));

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