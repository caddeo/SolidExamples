using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidopgaver
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalHospital hospital = new AnimalHospital();
            hospital.AddAnimal(new Dog("Grimme"));
            
        }
    }
}
