using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace solidopgaver
{


    public class AnimalHospital
    {
        private AnimalHospitalUtility _animalHospitalUtility;

        public AnimalHospital()
        {
            _animalHospitalUtility = new AnimalHospitalUtility();
        }

        public void AddAnimal(IAnimal animal)
        {
            _animalHospitalUtility.AddAnimal(animal);
        }
        public void NotIll(string name)
        {
            _animalHospitalUtility.RemoveAnimal(name);
        }
    }

    #region Interfaces
    public interface IRegisterPetUtility
    {
        void AddAnimal(IAnimal animal);
        void RegOwnerData(IAnimal animal, Owner owner);
    }

    public interface IRemovePetUtility
    {
        void RemoveAnimal(string name);
    }

    public interface IAnimal
    {
        string Name { get; set; }
        Owner Owner { get; set; }
    }

    #endregion

    #region Classes 
    public class AnimalHospitalUtility : IRegisterPetUtility, IRemovePetUtility
    {
        List<IAnimal> _sickAnimals = new List<IAnimal>();
        List<IAnimal> _notSickAnimals = new List<IAnimal>();

        public void AddAnimal(IAnimal animal)
        {
            _sickAnimals.Add(animal);
        }

        public void RegOwnerData(IAnimal animal, Owner owner)
        {
            var animals = _sickAnimals.Where(x => x.Owner == owner);

            foreach (IAnimal a in animals)
            {
                a.Owner = owner;
            }
        }

        public void RemoveAnimal(string name)
        {
            var animal = _sickAnimals.FirstOrDefault(t => t.Name == name);
            _sickAnimals.Remove(animal);
            _notSickAnimals.Add(animal);
        }
    }

    public class Dog : IAnimal
    {
        public string Name { get; set; }
        public Owner Owner { get; set; }

        public Dog(string name)
        {
            Name = name;
        }
    }

    public class Cat : IAnimal
    {
        public string Name { get; set; }
        public Owner Owner { get; set; }

        public Cat(string name)
        {
            Name = name;
        }
    }

    public class Owner
    {
        public string Name;
        public string Phone;
    }

    #endregion
}
