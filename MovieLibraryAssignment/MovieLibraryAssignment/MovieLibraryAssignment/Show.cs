﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryAssignment
{
    class Show : Media
    {
        public int Season { get; set; }
        public int Episode { get; set; }
        public string[] Writers { get; set; }

        public override void Display()
        {
            Console.WriteLine($"ID: {ID}, Title: {Title}, Season: {Season}, Episode: {Episode}, Writer(s): {string.Join(", ", Writers)}");
        }

        public override string ToString()
        {
            return $"{Title}";
        }
    }
}
