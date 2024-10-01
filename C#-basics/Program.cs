namespace HelloAnimals;

class Program
{
    static void Main(string[] args)
    {
        
    }
}

public interface IAnimal
{
    string Name { get; set; }
    int Age { get; set; }
    void MakeNoice();
}

public abstract class Mammal(string name, int age, int daysPregnant) : IAnimal
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public int DaysPregnant { get; set; } = daysPregnant;

    public abstract void MakeNoice();
}

public abstract class Bird(string name, int age, int daysHatching) : IAnimal
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public int DaysHatching { get; set; } = daysHatching;

    public abstract void MakeNoice();
}

public class Dog(string name, int age, int daysPregnant, string breed) : Mammal(name, age, daysPregnant)
{
    public string Breed { get; set; } = breed;

    public override void MakeNoice() => Console.WriteLine("Woof");
}

public class Cow(string name, int age, int daysPregnant, bool fur) : Mammal(name, age, daysPregnant)
{
    public bool Fur { get; set; } = fur;

    public override void MakeNoice() => Console.WriteLine("Mooo");
}

public class Seagull(string name, int age, int daysHatching) : Bird(name, age, daysHatching)
{
    public override void MakeNoice() => Console.WriteLine("Iik iik");
}