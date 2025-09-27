/*1) Describe the problem generics address. 
Generics solve the problem of code duplication and type safety by allowing developers to write reusable methods and classes that work with any type of data.

2) How would you create a list of strings, using the generic List class?
List<string> listOfStrings = new List<string>(); 

3) How many generic type parameters does the Dictionary class have?
Dictionary<TKey, TValue> has two generics type parameters.

4) False. When a generic class has multiple type parameters, they must all match.

6) What method is used to add items to a List object?
List<T> .Add(T item) method. This is a prebuilt method of the List class.
e.g: List<string> names = new List<string>();
     names.Add("Kimi");

7) Name two methods that cause items to be removed from a List. (I'll mention more so I can remember later)
.Remove(item)           Removes the first matching item.
.RemoveAt(index)        Removes the item at a specific index.
.RemoveAll(predicate)   Remove all items that match the condition.
.Clear()                Removes all items from the list.

8) How do you indicate that a class has a generic type parameter?
You use angle brackets <> after the class name with a type parameter inside (usually T).

9) False. Generic classes can only have one generic type parameter.

10) True. Generic type constraints limit what can be used for the generic type.

11) True. Constraints let you use the methods of the thing you are constraining to. */



/*Practice Exercise
Task 1: Define a generic class called MyStack<T> with the following requirements:
1) Use Stack<T> internally to store the data.
2) Implement a Count() method that returns the number of elements in the stack.
3) Implement a Pop() method that returns and removes the top element of the stack.
4) Implement a Push(T obj) method that adds an element to the stack.
Finally, create an instance of MyStack<int>, push two integers into it, and print out the current number of elements in the stack. */
public class MyStack<T>
{
    private Stack<T> stack = new Stack<T>();
    public int Count()
    {
        return stack.Count();
    }
    public T Pop()
    {
        return stack.Pop();
    }
    public void Push(T obj)
    {
        stack.Push(obj);
    }
}
public class  Program
{
    public void main()
    {
        MyStack<int> stack = new MyStack<int>(); // This can be simplify (target-typed) => MyStack<int> stack = new(); the compiler can infer the type from the left side.
        stack.Push(10);
        stack.Push(20);
        Console.WriteLine($"Current Number of elements: {stack.Count()}");
    }
}


/*Task 2: Create a generic repository pattern in C# with the following requirements:
1) Define a generic interface IGenericRepository<T> where T : class.
    - The interface should declare the following methods:
        Add(T item)
        Remove(T item)
        Save()
        IEnumerable<T> GetAll()
        T GetById(int id) */
public interface IGenericRepository<T> where T : class // Interfaces don't use access modifiers like public or private!
{
    int Add(T item);            // I returned int to indicate success or failure of the operation. I could have used void too.
    int Remove(T item);         // I returned int to indicate success or failure of the operation. I could have used void too.
    void Save();                 // I returned int to indicate success or failure of the operation. I could have used void too.
    IEnumerable<T> GetAll();
    T GetById(int id);
}


/* 2) Implement a class GenericRepository<T> that inherits from IGenericRepository<T>.
    - Use a private List<T> field to store the data.
    - In the constructor, initialize the list as a new empty List<T>.
    - Provide method implementations for Add, Remove, GetAll, GetById.No actual implementation is needed for Save. */

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private List<T> list = new();

    public int Add(T item)
    {
        list.Add(item);
        return 1; // Indicating success
    }
    public int Remove(T item) // remove() return a bool indicating whether the item was successfully removed or not.
    {
        return list.Remove(item) ? 1 : 0;
    }
    public void Save()
    {
        // No actual implementation needed for Save.
    }
    public IEnumerable<T> GetAll()
    {
        return list;
    }
    public T GetById(int id) // Imagine a list of objects of type T (Department: id, Name)
    {
        foreach (var item in list)
        {
            if (item.id == id)
            {
                return item;
            }
        }
        return null;
    }
}