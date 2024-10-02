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

        IFeedAnimal feedDog = new FeedAnimal(dog1);
        var dogFeed = new FeedingService(feedDog);
        IFeedAnimal feedCow = new FeedAnimal(cow1);
        var cowFeed = new FeedingService(feedCow);
        IFeedAnimal feedSeagull = new FeedAnimal(seagull1);
        var seagullFeed = new FeedingService(feedSeagull);

        dogFeed.GiveFood();
        cowFeed.RemoveFood();
        seagullFeed.GiveFood();
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

public interface IFeedAnimal
{
    void StartFeeding();
    void StopFeeding();
}

public class FeedAnimal(IAnimal animal) : IFeedAnimal
{
    public void StartFeeding() => Console.WriteLine($"Feeding {animal.GetType().Name} {animal.Name}");
    public void StopFeeding() => Console.WriteLine($"Took away {animal.GetType().Name} {animal.Name}s food");
}

public class FeedingService(IFeedAnimal animal)
{
    private readonly IFeedAnimal _animal = animal;

    public void GiveFood() => _animal.StartFeeding();
    public void RemoveFood() => _animal.StopFeeding();
}



