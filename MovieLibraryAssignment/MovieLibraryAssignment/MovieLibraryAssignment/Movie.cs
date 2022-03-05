using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryAssignment
{
    class Movie : Media
    {

        public Movie()
        {
        }
        public string[] Genres { get; set; }

        public override void Display()
        {

           Console.WriteLine($"ID: {ID}, Title: {Title}, Genre(s): {string.Join(", ", Genres)}");
           
        }
    }
}
