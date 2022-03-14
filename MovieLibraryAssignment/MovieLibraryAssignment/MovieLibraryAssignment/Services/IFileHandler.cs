using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryAssignment
{
    public interface IFileHandler
    {
        void DisplayMenu();

        public void Read(string json);

        public string Write();
    }
}
