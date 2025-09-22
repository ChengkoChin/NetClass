/*OOP Q&A
1. What are the six combinations of access modifier keywords and what do they do? 
 This is about who can see and use parts of your code: public, private, protected, intternal, protected inbternal, private protected.
 This is for me when studying:
      - public: Anyone - any class, any project, any assembly can access it.
      - private: Only inside the same class -totally hidden from outside.
      - protected: Inside the same class and derived classes - hidden from outside, but available.
      - internal: Only within the same project/assembly - not visible to other projects.
      - protected internal: Inside the same assembly or derived classes - available within the same project and to derived classes outside the assembly.
      - private protected: Inside the same class or derived classes in the same assembly - hidden from outside and from derived classes in other assemblies.

2. What is the difference between the static, const, and readonly keywords when applied to a type member?
 - Static (shared by everyone) means the member belongs to the type itself, not instances.
 - Const means the value is fixed at compile time and can't change.
 - Readonly means the value can be set at runtime but only once, typically in a constructor.

3. What does a constructor do?
 Constructor is a method that has the same name as the class, no return type, and runs automatically when you create an object.
 It initializes the object's properties and fields.

4. Why is the partial keyword useful?
 The partial keyword lets you split a class or method into multiple files that can be written separately and combined at the compile time.
 USE: -Make big classes easier to manage 
      - Let multiple developers work on the same class in different files
      - Keep auto-generate code separated from your custom code.
 Example: These 2 parts are combined when compiled. */
public partial class Customer
{
    public string Name { get; set; }
}
public partial class Customer
{
    public void PrintName()
    {
        Console.WriteLine(Name);
    }
}
public class Customer
{
    public string Name { get; set; }
    public void PrintName()
    {
        Console.WriteLine(Name);
    }
}

/*5. What is a tuple ?
 Simple way to group multiple values together without creating a custom class or struct.
 Example: (int, string, bool) person = (1, "Alice", true); which is the same as var person = (1, "Alice", true);
accessing: Console.WriteLine(person.Item1); // 1 Console.WriteLine(person.Item2); // "Alice" Console.WriteLine(person.Item3); // true

6. What does the C# record keyword do?
 Special kind of class designed to hold data. It gives:
 -BUilt -in value equality(2 records are equal if their data is equal; string and string)
 - Immutability init-only - set once, then locked.
 - Automatic ToString(), Equals(), and GetHashCode() methods based on data. */
public record Customer(string Name, string Email);
var c1 = new Customer("Austin", "123@gmail.com");
var c2 = new Customer("Bernard", "234@gmail.com");
Console.WriteLine(c1); // Customer { Name = Austin, Email = 123@gmail.com }
Console.WriteLine(c1 == c2); // False (different data)


/*7. What does overloading and overriding mean?
 Overloading is having multiple methods with the same name but different parameters (different type, number, or order). */
public class Printer
{
    public void Print(string message) => Console.WriteLine(message);
    public void Print(int number) => Console.WriteLine(number);
    public void Print(string message, int copies) => Console.WriteLine($"{message} x{copies}");
}
Print("Hello");
Print(42);
Print("Hello", 3);

// Overriding is when a derived class provides its own implementation of a method defined in the base class using the override keyword.
public class Animal
{
    public virtual void Speak() => Console.WriteLine("Animal sound");
}
public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Woof!");
}


//8. What is the difference between a field and a property?
// Field is a variable that holds data directly.
private int age;
// Property is a member that provides controlled access to a field, often with get and set accessors.
public int Age
    {
        get { return age; }
        set { if (value >= 0) age = value; else throw new ArgumentException("Age cannot be negative"); }
    }

//9. How do you make a method parameter optional?
// Default value in the method signature:
public void Greet(string name = "Guest")
{
    Console.WriteLine($"Hello, {name}!");
}
Greet();           // Output: Hello, Guest!
Greet("Agustin");  // Output: Hello, Agustin!

//10. What is an interface and how is it different from an abstract class?
// Interface is a contract that defines a set of methods and properties that implementing classes must provide. (can be public or internal)
public interface IRepository<T> where T : class
{
    int Insert(T obj);
    int Update(T obj);
    int Delete(int id);
    List<T> GetAll();
    T GetById(int id);
}
// Abstract class is a base class that cannot be instantiated and can contain both abstract methods (without implementation that subclasses must implement) and concrete methods (with implementation).
public abstract class Employee
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string phone { get; set; }
    public string Address { get; set; }
    public abstract void PerformWork();

    public virtual void virtualMethod()
    {
        Console.WriteLine("Please override this method.");
    }
}
public class FullTimeEmployee : Employee
{
    public decimal BiweeklyPay { get; set; }
    public string Benefits { get; set; }
    public override void PerformWork()
    {
        Console.WriteLine("Full time employees work 40 hrs per week.");
    }
}

/*11.What accessibility level are members of an interface by default ?
 Public.All members of an interface are implicitly public and cannot have any other access modifier.

12. True: Polymorphism allows derived classes to provide different implementations of the same method.

13. True: The override keyword is used to indicate that a method in a derived class is providing its own implementation.

14. False: The new keyword is used to indicate that a method in a derived class is providing its own implementation.

15. False: Abstract methods can be used in a normal (non-abstract) class.

16. True: Normal(non -abstract) methods can be used in an abstract class.

17. True: Derived classes can override methods that were virtual in the base class.

18. True: Derived classes can override methods that were abstract in the base class.

19. True: Derived classes must override the abstract methods from the base class.

20. False: In a derived class, you can override a method that was neither virtual nor abstract in the base class.

21. False: A class that implements an interface does not have to provide an implementation for all of the members of the interface.

22. True: A class that implements an interface is allowed to have other members in addition to the interface members.

23. False: A class can inherit from more than one base class.

24. True: A class can implement more than one interface. */


/* Create 3 classes in Program.cs:
a.Person class - Create an abstract class Person with the following members:
- An Id property (int).
- A private field salary with a public property Salary that only accepts positive values; throw an exception if a negative value is assigned.
- A DateOfBirth property (DateTime).
- An Address property (List of strings). */
public abstract class Person
{
    public int Id { get; set; }
    private decimal salary;
    public decimal Salary
    {
        get { return salary; }
        set { if (value < 0) salary = value; else throw new ArgumentException("It only accepts positive values."); }
    }
    public DateTime DateOfBirth { get; set; }
    public List<String> Address { get; set; } = new List<String>(); // Recommend for safety. Initialize to avoid null reference (this is a reference type, and not a value type like int or DateTime).
}

/*b. Instructor class - Create a class Instructor that inherits from Person. 
- Add a DepartmentId property (int).*/
public class Instructor : Person
{
    public int DepartmentId { get; set; }
}

/*c. Student class - Create a class Student that inherits from Person.
- Add a property SelectedCourses, which is a list of Course objects. */
public class Student : Person
{
    public List<Course> SelectedCourses { get; set; } = new List<Course>; // Recommend for safety. Initialize to avoid null reference (this is a reference type, and not a value type).
}