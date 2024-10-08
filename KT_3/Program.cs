using System;

public interface IAnimal
{
    string Name    
    {
        get;
        set; 
    }
    void MakeSound();
}

public class Dog : IAnimal
{
    public string Name
    {
        get;
        set;
    }

    public Dog(string name)
    {
        Name = name;
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} : Bork!");
    }
}

public class Cat : IAnimal
{
    public string Name
    {
        get;
        set;
    }

    public Cat(string name)
    {
        Name = name;
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} : Prrr!");
    }
}

public interface IShape
{
    double Area 
    { 
        get; 
    }
    double Perimeter 
    {
        get; 
    }
}

public class Circle : IShape
{
    public double Radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area => (Math.PI * Radius * Radius);
    public double Perimeter => (2 * Math.PI * Radius);
}

public class Rectangle : IShape
{
    public double Width;
    public double Height;

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Area => (Width * Height);
    public double Perimeter => (2 * (Width + Height));
}

public class Triangle : IShape
{
    public double SideA;
    public double SideB;
    public double SideC;
   

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double Area
    {
        get
        {
            double s = ((SideA + SideB + SideC) / 2);
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }
    }

    public double Perimeter => SideA + SideB + SideC;
}

public interface IComparable<T>
{
    int CompareTo(T other);
}

public class Student : IComparable<Student>
{
    public string Name;
    public int Age;
    public double Grade;

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public int CompareTo(Student other)
    {
        if (other == null) return 1;

        int nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
        if (nameComparison != 0) return nameComparison;

        if (Age != other.Age) return Age.CompareTo(other.Age);

        return Grade.CompareTo(other.Grade);
    }
}

public class Book : IComparable<Book>
{
    public string Title;
    public string Author;
    public double Price;

    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public int CompareTo(Book other)
    {
        if (other == null) return 1;

        int authorComparison = string.Compare(Author, other.Author, StringComparison.Ordinal);
        if (authorComparison != 0) return authorComparison;

        int titleComparison = string.Compare(Title, other.Title, StringComparison.Ordinal);
        if (titleComparison != 0) return titleComparison;

        return Price.CompareTo(other.Price);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IAnimal dog = new Dog("Butcher");
        IAnimal cat = new Cat("Barsik");

        dog.MakeSound();
        cat.MakeSound();

        //IShape circle = new Circle(5);
        //IShape rectangle = new Rectangle(4, 6);
        //IShape triangle = new Triangle(3, 4, 5);

        //Console.WriteLine($"Circle Area: {circle.Area}, Perimeter: {circle.Perimeter}");
        //Console.WriteLine($"Rectangle Area: {rectangle.Area}, Perimeter: {rectangle.Perimeter}");
        //Console.WriteLine($"Triangle Area: {triangle.Area}, Perimeter: {triangle.Perimeter}");

        ////Student student1 = new Student("Maks", 20, 4.5);
        ////Student student2 = new Student("Alexander", 22, 4.0);

        ////Console.WriteLine(student1.CompareTo(student2));

        ////Book book1 = new Book("Republic SHKID", "Belih, Panteleev", 7.99);
        ////Book book2 = new Book("Silmarillion", "J.R.R. Tolkien", 15.99);

        ////Console.WriteLine(book1.CompareTo(book2)); 
    }
}
