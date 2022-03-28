using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryAssignment
{
    class Video : Media
    {
        public string Format { get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }

        public override void Display()
        {
            Console.WriteLine($"ID: {ID}, Title: {Title}, Format: {Format}, Length: {Length}, Region(s): {string.Join(", ", Regions)}");
        }
    }
}
