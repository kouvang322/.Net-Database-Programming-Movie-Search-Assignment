using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryAssignment
{
    public class Movielist
    {
        List<Movie> movies = new List<Movie>();


        public void ReadMovieFromFile()
        {
            string file = "Media\\Movies-small.csv";
            StreamReader fileReader = new StreamReader(file);
            string line = fileReader.ReadLine();

            if (File.Exists(file))
            {
                // read data from file

                try
                {
                    while (!fileReader.EndOfStream)
                    {
                        Movie movie = new Movie();

                        line = fileReader.ReadLine();
                        int idx = line.IndexOf('"');

                        if (idx == -1)
                        {
                            string[] movieInfo = line.Split(",");

                            movie.ID = (int.Parse(movieInfo[0]));

                            movie.Title = (movieInfo[1]);

                            string genresSeparate = movieInfo[2];

                            movie.Genres = genresSeparate.Split("|");

                        }
                        else
                        {
                            movie.ID = (int.Parse(line.Substring(0, idx - 1)));

                            line = line.Substring(idx + 1);

                            idx = line.IndexOf('"');

                            movie.Title = (line.Substring(0, idx + 2));

                            string genreSeparate = line;

                            movie.Genres = genreSeparate.Split("|");
                        }

                        movies.Add(movie);
                    }

                    fileReader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }


        }

        public void DisplayMovies()
        {
            foreach (var movie in movies)
            {
                movie.Display();

            }
        }

    }

    //public void ReadMovieFromFile()
    //{
    //    // these would be global 
    //    List<Movie> movies = new List<Movie>();

    //    //loop
    //        {
    //        // read line from file
    //        // parse (id, title, genres)
    //        Movie movie = new Movie();
    //        movie.Id = id;
    //        movie.Title = title;
    //        movie.Genres[0] = dasdfasd;

    //        // save to movies list
    //        movies.Add(movie);
    //    }

    //    // could display here

}

//movies.Add(new Movie() { ID = 1, Title = "Toy Story(1995)", Genres = "Adventure, Animation, Children, Comedy, Fantasy" });

//movies.Add(new Movie() { ID = 2, Title = "Jumanji(1995)", Genres = "Adventure, Children, Fantasy" });
//movies.Add(new Movie() { ID = 3, Title = "Grumpier Old Men(1995)", Genres = "Comedy, Romance" });
//movies.Add(new Movie() { ID = 4, Title = "Waiting to Exhale(1995)", Genres = "Comedy, Drama, Romance" });
//movies.Add(new Movie() { ID = 5, Title = "Father of the Bride Part II(1995)", Genres = "Comedy" });
//movies.Add(new Movie() { ID = 6, Title = "Heat(1995)", Genres = "Action, Crime, Thriller" });
//movies.Add(new Movie() { ID = 7, Title = "Sabrina(1995)", Genres = "Comedy, Romance" });
//movies.Add(new Movie() { ID = 8, Title = "Tom and Huck(1995)", Genres = "Adventure, Children" });
//movies.Add(new Movie() { ID = 9, Title = "Sudden Death(1995)", Genres = "Action" });
//movies.Add(new Movie() { ID = 10, Title = "GoldenEye(1995)", Genres = "Adventure, Action, Thriller" });