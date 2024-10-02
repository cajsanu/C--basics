namespace HelloAnimals;

class Program
{
    static void Main()
    {
        var caretakers = new List<Caretaker>();

        var dog1 = new Dog("Rufus", 3, true, "Labrador");
        var cow1 = new Cow("Helena", 10, true, true);
        var dog2 = new Dog("Mindy", 6, false, "Poodle");
        var seagull1 = new Seagull("Clinton", 2, 26.5);
        var cow2 = new Cow("Magdalena", 5, false, true);

        var service = new AnimalService();

        var caretaker1 = new Caretaker("Hildur", service);
        caretaker1.AnimalsToCareFor.Add(cow1);
        caretaker1.AnimalsToCareFor.Add(cow2);
        var caretaker2 = new Caretaker("Jeremiah", service);
        caretaker2.AnimalsToCareFor.Add(dog1);
        caretaker2.AnimalsToCareFor.Add(dog2);
        caretaker2.AnimalsToCareFor.Add(seagull1);

        caretakers.Add(caretaker1);
        caretakers.Add(caretaker2);

        foreach (var caretaker in caretakers)
        {
            Console.WriteLine($"Caretaker {caretaker.Name} is responsible for:");
            foreach (var animal in caretaker.AnimalsToCareFor)
            {
                caretaker.GiveFood(animal);
                Console.WriteLine($"{animal.Name} who is a {animal.GetType().Name} and says");
                // MakeNoice is return void which is not a value so it cannto be called inside i.e console.writeline bc
                // writeline expects a value to print
                animal.MakeNoice();
                caretaker.RemoveFood(animal);
            }
        }


    }
}

public interface IAnimal
{
    string Name { get; set; }
    int Age { get; set; }
    void MakeNoice();
}

public abstract class Animal(string name, int age) : IAnimal
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public abstract void MakeNoice();
}

public abstract class Mammal(string name, int age, bool friendly) : Animal(name, age)
{
    public bool Friendly { get; set; } = friendly;

}

public abstract class Bird(string name, int age, double wingSpan) : Animal(name, age)
{
    public double WingSpan { get; set; } = wingSpan;

}

public class Dog(string name, int age, bool friendly, string breed) : Mammal(name, age, friendly)
{
    public string Breed { get; set; } = breed;

    public override void MakeNoice() => Console.WriteLine("Woof");
}

public class Cow(string name, int age, bool friendly, bool fur) : Mammal(name, age, friendly)
{
    public bool Fur { get; set; } = fur;

    public override void MakeNoice() => Console.WriteLine("Mooo");
}

public class Seagull(string name, int age, double wingSpan) : Bird(name, age, wingSpan)
{
    public override void MakeNoice() => Console.WriteLine("Iik iik");
}


///////////

public interface IAnimalService
{
    void StartFeeding(IAnimal animal);
    void StopFeeding(IAnimal animal);
}

public class AnimalService : IAnimalService
{
    public void StartFeeding(IAnimal animal) => Console.WriteLine($"The caretaker is feeding {animal.GetType().Name} {animal.Name}");
    public void StopFeeding(IAnimal animal) => Console.WriteLine($"{animal.Name} has been fed and the food has been taken away");
}


////////

public enum Role
{
    Caretaker,
    Manager
}

public interface IPerson
{
    string Name { get; set; }
    Role Role { get; }
}

public class Caretaker(string name, IAnimalService service) : IPerson
{
    public string Name { get; set; } = name;
    public Role Role { get; } = Role.Caretaker;
    public List<IAnimal> AnimalsToCareFor { get; set; } = new List<IAnimal>();

    private readonly IAnimalService _service = service;

    public void GiveFood(IAnimal animal) => _service.StartFeeding(animal);
    public void RemoveFood(IAnimal animal) => _service.StopFeeding(animal);
}


