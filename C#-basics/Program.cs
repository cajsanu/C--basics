namespace HelloAnimals;

class Program
{
    static void Main()
    {
        var animals = new List<IAnimal>();

        var dog1 = new Dog("Rufus", 3, true, "Labrador");
        var cow1 = new Cow("Helena", 10, true, true);
        var dog2 = new Dog("Mindy", 6, false, "Poodle");
        var seagull1 = new Seagull("Clinton", 2, 26.5);

        animals.Add(dog1);
        animals.Add(dog2);
        animals.Add(cow1);
        animals.Add(seagull1);

        foreach (var animal in animals)
        {
            Console.WriteLine($"{animal.Name} who is a {animal.GetType().Name} and says");
            // MakeNoice is return void which is not a value so it cannto be called inside i.e console.writeline bc
            // writeline expects a value to print
            animal.MakeNoice();
        }
    }
}

public interface IAnimal
{
    string Name { get; set; }
    int Age { get; set; }
    void MakeNoice();
}

public abstract class Mammal(string name, int age, bool friendly) : IAnimal
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public bool Friendly { get; set; } = friendly;

    public abstract void MakeNoice();
}

public abstract class Bird(string name, int age, double wingSpan) : IAnimal
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public double WingSpan { get; set; } = wingSpan;

    public abstract void MakeNoice();
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