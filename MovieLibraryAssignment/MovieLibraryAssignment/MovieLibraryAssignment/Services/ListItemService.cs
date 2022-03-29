using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieLibraryAssignment.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryAssignment
{
    public class ListItemService : IListItemService
    {

        private readonly ILogger<IListItemService> _logger;

        public ListItemService(ILogger<IListItemService> logger)
        {
            _logger = logger;
            //Read();
        }

        List<UInt64> movieIds = new List<UInt64>();
        List<string> movieTitles = new List<string>();
        List<string> movieGenres = new List<string>();


        // This method displays the options for the user
        // Options lead to other methods 
        public void DisplayMenu()
        {
            string userChoice;

            do
            {
                // Ask user what they want to do
                Console.WriteLine();
                Console.WriteLine("1. Search Title");
                Console.WriteLine("2. Display Movies");
                Console.WriteLine("3. Display Shows");
                Console.WriteLine("4. Display Videos");
                Console.WriteLine("Enter any other key to exit.");
                //  user input
                userChoice = Console.ReadLine();
                _logger.LogInformation("User choice: {choice}", userChoice);

                if (userChoice == "1")
                {
                    try
                    {
                        var searchResults = new SearchResultsService();

                        Console.WriteLine("What title do you want to search?:");
                        var searchString = Console.ReadLine();
                        var results = searchResults.SearchAllMedia(searchString);

                        results.ForEach(Console.WriteLine);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                
                if (userChoice == "2")
                {
                    MovieList movieList = new MovieList();
                    movieList.DisplayMovies();

                }

                if (userChoice == "3")
                {
                    ShowList showlist = new ShowList();
                    showlist.ReadShowFromFile();
                    showlist.DisplayShows();

                }

                else if (userChoice == "4")
                {
                    VideoList videolist = new VideoList();
                    videolist.ReadVideoFromFile();
                    videolist.DisplayVideos();

                }

            } while (userChoice == "1" || userChoice == "2" || userChoice == "3" || userChoice == "4");

            _logger.LogInformation("Program was closed down.");
        }
    }
}

#region
//
//        public void DisplayMenu()
//        {
//            string userChoice;

//            do
//            {
//                // Ask user what they want to do
//                Console.WriteLine();
//                Console.WriteLine("1. Display movies");
//                Console.WriteLine("2. Add movie");
//                Console.WriteLine("Enter any other key to exit.");
//                //  user input
//                userChoice = Console.ReadLine();
//                _logger.LogInformation("User choice: {choice}", userChoice);

//                if (userChoice == "1")
//                    try
//                    {
//                        List();
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex.Message);
//                        Console.WriteLine("Enter a number for for the # of movie(s) you want to display.");
//                    }

//                else if (userChoice == "2")
//                {
//                    Write();
//                }

//            } while (userChoice == "1" || userChoice == "2" || userChoice == "3");

//            _logger.LogInformation("Program was closed down.");
//        }

//        // This method reads in the data from the file
//        // Data is then put into three lists
//        public void Read()
//        {
//            string file = "MovieFile\\movies.csv";
//            StreamReader fileReader = new StreamReader(file);
//            string line = fileReader.ReadLine();

//            //read data from file
//            if (File.Exists(file))
//            {
//                // read data from file

//                try
//                {
//                    while (!fileReader.EndOfStream)
//                    {

//                        line = fileReader.ReadLine();
//                        int idx = line.IndexOf('"');

//                        if (idx == -1)
//                        {
//                            string[] movieInfo = line.Split(",");

//                            movieIds.Add(UInt64.Parse(movieInfo[0]));

//                            movieTitles.Add(movieInfo[1]);

//                            movieGenres.Add(movieInfo[2].Replace("|", ","));
//                        }
//                        else
//                        {
//                            movieIds.Add(UInt64.Parse(line.Substring(0, idx - 1)));

//                            line = line.Substring(idx + 1);

//                            idx = line.IndexOf('"');

//                            movieTitles.Add(line.Substring(0, idx + 2));

//                            movieGenres.Add(line.Replace("|", ", "));
//                        }
//                    }

//                    fileReader.Close();
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//            }
//            else
//            {
//                Console.WriteLine("File does not exist");
//            }
//        }

//        // This method asks the user how many movies they would like to display
//        // Displays the list depending on user's input
//        public void List()
//        {

//            Console.WriteLine($"There are {movieIds.Count} movies on the list");

//            Console.WriteLine("How many movies do you want to display?");
//            int userInput = Convert.ToInt32(Console.ReadLine());

//            _logger.LogInformation("User chose to display {number} movie(s)", userInput);

//            for (int i = 0; i < userInput; i++)
//            {
//                Console.WriteLine($"{movieIds[i]} " + $"{movieTitles[i]} " + $"{movieGenres[i]}");
//            }

//            _logger.Log(LogLevel.Information, "Movie list was printed");

//        }

//        // This method finds and assigns a newId for the movies
//        // User is asked to enter a new movie title
//        // User is then prompt to enter the genre for the new movie
//        // Data for the id, title, and genres are then formated and written to the list
//        public void Write()
//        {
//            try
//            {
//                StreamWriter fileWriter = new StreamWriter("MovieFile\\movies.csv", append: true);

//                movieIds.Reverse();

//                UInt64 newMovieId = movieIds[0] + 1;
//                //Log the new id
//                _logger.Log(LogLevel.Information, "New Id was created {ID}", newMovieId);

//                Console.Write("Enter new movie title. ");
//                string userEnteredNewMovieTitle = catchEmptyString();

//                _logger.Log(LogLevel.Information, "User entered {title} as new movie title.", userEnteredNewMovieTitle);

//                if (movieTitles.Contains(userEnteredNewMovieTitle))
//                {
//                    Console.WriteLine("Sorry! This movie already exist in the system.");
//                    Console.Write("Please enter a new movie title: ");
//                    _logger.LogError("Error. User entered existing movie title.");

//                    userEnteredNewMovieTitle = Console.ReadLine();
//                }
//                else
//                {
//                    Console.WriteLine("New movie name accepted.");
//                    _logger.LogInformation("Obtained new movie name: {name}", userEnteredNewMovieTitle);
//                }

//                List<string> addedMovieGenres = new List<string>();

//                string additionalGenres;

//                do
//                {
//                    Console.WriteLine("Enter a genre for the new movie.");
//                    string userEnteredNewMovieGenres = catchEmptyString();

//                    _logger.Log(LogLevel.Information, "{genre} was added as a genre.", userEnteredNewMovieGenres);


//                    Console.WriteLine("Any more genres you want to add to the new movie? (Y/N)");
//                    additionalGenres = ensureChoiceIsEitherYesOrNO();

//                    addedMovieGenres.Add(userEnteredNewMovieGenres);


//                } while (additionalGenres == "Y");

//                movieIds.Add(newMovieId);
//                movieTitles.Add(userEnteredNewMovieTitle);

//                // joined by commas if there are multiple genres to easily display the different genres
//                string multipleMovieGenres = string.Join(",", addedMovieGenres);

//                movieGenres.Add(multipleMovieGenres);

//                // joined by | to match genre data structure in file
//                string separateMovieGenres = string.Join("|", addedMovieGenres);

//                var entryRow = AddCorrectStringFormat(newMovieId, userEnteredNewMovieTitle, separateMovieGenres);

//                fileWriter.WriteLine(entryRow);


//                movieIds.Sort();

//                fileWriter.Flush();
//                fileWriter.Close();

//                _logger.LogInformation("Complete movie info was added to list.");

//            }
//            catch (Exception ex)
//            {
//                _logger.LogError("Something went wrong trying to write to the file. Exact message = " + ex.Message);
//            }

//        }

//        // This code is to prevent the user from entering nothing
//        public string catchEmptyString()
//        {
//            string userInput = Console.ReadLine();
//            while (userInput == "")
//            {
//                Console.WriteLine("You have entered nothing. Please enter it correct info.");
//                userInput = Console.ReadLine();
//            }
//            return userInput;
//        }

//        // This code ensured the user enters either yes or no
//        public string ensureChoiceIsEitherYesOrNO()
//        {
//            string userInput = Console.ReadLine().ToUpper();

//            while (!userInput.Equals("Y") && !userInput.Equals("N"))
//            {
//                Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
//                Console.WriteLine("Do you want to enter any more genres?");
//                userInput = Console.ReadLine().ToUpper();
//            }
//            return userInput;
//        }

//        // Formats information of the new movie into the correct string
//        public string AddCorrectStringFormat(UInt64 movieID, string movieTitle, string moviegenres)
//        {
//            return $"{ movieID }," + movieTitle + "," + moviegenres;
//        }

//    }
//}
#endregion