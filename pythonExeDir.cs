using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FormeCastWeatherApp
{
    internal class pythonExeDir
    {
        private string pythonDir = System.IO.File.ReadAllText("../../../pythonExeDir.txt");

        public string getDirectory()
        {
            return this.pythonDir;
    }
    }

    
}
