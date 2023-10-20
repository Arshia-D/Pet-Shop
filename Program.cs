using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Shop
{
    internal class Program
    {

        public enum Animal_Kind
        {
            Mammals,
            Fish,
            Amphibians,
            Reptiles,
            Birds,
            Invertebrates
        }
        public enum AgeStage
        {
            Young,
            MidAge,
            Old
        }

        public class Creature
        {
            public int Age { get; set; }
            public int MaxAge { get; set; }
            public virtual string Speak()
            {
                return "This creature makes no sound.";
            }
        }

        public class Animal : Creature
        {
            public Animal_Kind Kind { get; set; }
        }

        public interface IStock
        {
            decimal Price { get; set; }
            int Quantity { get; set; }
        }

        public class Pet : Animal, IStock
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }

            public override string Speak()
            {
                if (Kind == Animal_Kind.Mammals)
                {
                    return "This pet makes a sound like a mammal.";
                }
                else if (Kind == Animal_Kind.Fish)
                {
                    return "This pet makes a sound like a fish.";
                }
                else if (Kind == Animal_Kind.Amphibians)
                {
                    return "This pet makes a sound like an amphibian.";
                }
                else if (Kind == Animal_Kind.Reptiles)
                {
                    return "This pet makes a sound like a reptile.";
                }
                else if (Kind == Animal_Kind.Birds)
                {
                    return "This pet makes a sound like a bird.";
                }
                else if (Kind == Animal_Kind.Invertebrates)
                {
                    return "This pet makes no sound.";
                }
                else
                {
                    return base.Speak();
                }
            }

            public override string ToString()
            {
                return $"Name: {Name}, Age: {Age}, Max Age: {MaxAge}, Kind: {Kind}, Price: {Price:C}, Quantity: {Quantity}";
            }
        }
        public class PetShop
        {
            private Pet[] pets;
            private List<Pet> catalog;

            public PetShop()
            {               
                pets = new Pet[]
                {
            new Pet { Name = "Fluffy", Age = 2, MaxAge = 10, Kind = Animal_Kind.Mammals, Price = 50.0m, Quantity = 5 },
            new Pet { Name = "Goldie", Age = 1, MaxAge = 5, Kind = Animal_Kind.Fish, Price = 10.0m, Quantity = 10 },
            new Pet { Name = "Hoppy", Age = 3, MaxAge = 8, Kind = Animal_Kind.Amphibians, Price = 25.0m, Quantity = 3 },
            new Pet { Name = "Spike", Age = 4, MaxAge = 20, Kind = Animal_Kind.Reptiles, Price = 100.0m, Quantity = 2 },
            new Pet { Name = "Tweety", Age = 1, MaxAge = 3, Kind = Animal_Kind.Birds, Price = 15.0m, Quantity = 6 },
            new Pet { Name = "Slimy", Age = 1, MaxAge = 2, Kind = Animal_Kind.Invertebrates, Price = 5.0m, Quantity = 20 }
                };

                catalog = new List<Pet>(pets);
            }

            public void AddNewPet(Pet pet)
            {
                catalog.Add(pet);
            }

            public void SellPet(int index)
            {
                if (index < 0 || index >= catalog.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                catalog.RemoveAt(index);
            }

            public void ListPetsByKind(Animal_Kind kind)
            {
                var petsByKind = catalog.Where(p => p.Kind == kind);

                foreach (var pet in petsByKind)
                {
                    Console.WriteLine(pet.ToString());
                }
            }

            public void ListPetsByAge()
            {
                var petsByAge = catalog.OrderBy(p => p.Age);

                foreach (var pet in petsByAge)
                {
                    Console.WriteLine(pet.ToString());
                }
            }

            public void ListPetsByAgeStage(AgeStage stage)
            {
                Console.WriteLine($"List of pets in {stage} stage:");
                Console.WriteLine("---------------------------------");

                foreach (Pet pet in pets)
                {
                    int agePercentage = (int)Math.Floor(((double)pet.Age / (double)pet.MaxAge) * 100);

                    if (agePercentage < 20 && stage == AgeStage.Young)
                    {
                        Console.WriteLine(pet.ToString());
                    }
                    else if (agePercentage >= 20 && agePercentage <= 70 && stage == AgeStage.MidAge)
                    {
                        Console.WriteLine(pet.ToString());
                    }
                    else if (agePercentage > 70 && stage == AgeStage.Old)
                    {
                        Console.WriteLine(pet.ToString());
                    }
                }
            }
         

            public void ListPets()
            {
                foreach (Pet pet in pets)
                {
                    Console.WriteLine(pet.ToString());
                }
            }
        }

        class User_Part
        {
            static void Main(string[] args)
            {
                PetShop shop = new PetShop();

                Console.WriteLine("List of pets in the shop:");
                Console.WriteLine("-------------------------");
                shop.ListPets();
                Console.ReadKey();
            }
        }
    }
}

