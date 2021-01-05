using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ficheiros
{
    public class CarregarFicheiro

    {
        private System.IO.StreamReader _files; 

        public CarregarFicheiro(System.IO.StreamReader files)
        {
            _files = files;

        }

        public void Carregar()
        {
            int counter = 0;
            string line1;

            
            while ((line1 = _files.ReadLine()) != null)
            {
                System.Console.WriteLine(line1);
                counter++;
            }



            _files.Close();

            System.Console.WriteLine("There were {0} lines.", counter);

            System.Console.ReadLine();
        }
    }
}
