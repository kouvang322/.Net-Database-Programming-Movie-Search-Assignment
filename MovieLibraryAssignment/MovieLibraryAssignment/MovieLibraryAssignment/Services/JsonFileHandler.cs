using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryAssignment.Services
{
    public class JsonFileHandler : IFileHandler

    {

        private readonly ILogger<IFileHandler> _logger;

        public JsonFileHandler(ILogger<IFileHandler> logger)
        {
            _logger = logger;

        }

        public void Read(string json)
        {
            //string file = "MovieFile\\Movies.json";
            //string jsonFile = File.ReadAllText(file);

            Movie m = JsonConvert.DeserializeObject<Movie>(json);

        }

        public string Write()
        {
            Movie movie = new Movie();

            movie.ID = 1;
            movie.Title = "Toy Story";
            movie.Genres = "Adventure|Animation|Children|Comedy|Fantasy";

            string json = JsonConvert.SerializeObject(movie);

            Console.WriteLine(json);

            return json;

        }

        public void DisplayMenu()
        {
            string userChoice;

            do
            {
                // Ask user what they want to do
                Console.WriteLine();
                Console.WriteLine("1. Read Json");
                Console.WriteLine("2. Write to Json");
                Console.WriteLine("Enter any other key to exit.");
                //  user input
                userChoice = Console.ReadLine();
                _logger.LogInformation("User choice: {choice}", userChoice);

                if (userChoice == "1")
                    try
                    {
                        var json = Write();
                        Read(json);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                else if (userChoice == "2")
                {
                    Write();
                }

            } while (userChoice == "1" || userChoice == "2");

            _logger.LogInformation("Program was closed down.");
        }
    }
}
