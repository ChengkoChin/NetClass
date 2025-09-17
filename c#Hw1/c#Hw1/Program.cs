/*01 Introduction to C# and Data Types – Questions (Byte, short, int, long)
1. What type would you choose for the following “numbers”?
 - A person’s telephone number
   int 

 - A person’s height
   float (double is too much precision, decimal places, for height)

 - A person’s age
   Byte since people can't live that long "yet"

 - A person’s gender (Male, Female, Prefer Not To Answer)
   String

 - A person’s salary
   Decimal (I learned this data type is associated with financial calculations; double is too much precision; float has rounding errors)

 - A book’s ISBN
   String (ISBN-10 and ISBN-13 have dashes and letters), If only numbers were used, a long would be appropriate

 - A book’s price
   Decimal (Same reason as prevous answer)

 - A book’s shipping weight
   Float

 - A country’s population
   Int (I don't need decimal points, and world population can fit in int so it should be fine for the population in a country)

 - The number of stars in the universe
   Long (it's the biggest int based data type; int is too small, and the decimals are useless in this case)

 - The number of employees in each of the small or medium businesses in the United Kingdom (up to about 50,000 employees per business) 
   Ushort (max value is 65,535), but it might scale so I could use int to be safe.


2. What are the differences between value type and reference type variables? What is boxing and unboxing?
   Value types (such as int, bool, double, char, and byte) store the actual data directly, and when passed to a method, a copy of that data is made—so changes inside the method don’t affect the original. 
   Reference types (like objects, arrays, and string) store a reference to the data, meaning when passed to a method, the reference is copied and both variables point to the same object in memory, allowing 
   changes to affect the original. While value types are typically stored on the stack when used as local variables, they can also reside on the heap if they’re part of a reference type object. Reference types
   have their reference stored on the stack, but the actual object is allocated on the heap.

   Boxing is the process of converting a value type to a reference type by wrapping it in an object, which involves allocating memory on the heap. 
   Unboxing is the reverse process, extracting the value type from the object.
    

3. What is meant by the terms managed resource and unmanaged resource in .NET? (Used what material from class and reasearch)
   Managed resources are those that the .NET runtime (CLR) automatically handles, including memory allocation and garbage collection, type safety, exception handling, security, and JIT compilation.
   Unmanaged resources are resources that the .NET runtime does not manage directly, such as file handles, database connections, and network sockets. These resources require explicit management by the developer,
   typically through implementing the IDisposable interface and using the Dispose method to release them when they are no longer needed.


4. What is the purpose of the Garbage Collector in .NET?
   The Garbage Collector (GC) handles the automatic memory management. It tracks and frees up memory occupied by objects that are no longer used or referenced in the application, preventing memory leaks and optimizing memory usage. */


/* 02 Controlling Flow and Converting Types – Questions
1. What happens when you divide an int variable by 0?
   It throws a DivideByZeroException at runtime.

2. What happens when you divide a double variable by 0?
   It results in positive or negative infinity (Infinity or -Infinity) depending on the sign of the numerator, or NaN (Not a Number) if the numerator is also zero.

3. What happens when you overflow an int variable (assign a value beyond its range)?
   It wraps around to the opposite end of the range without throwing an exception, unless the operation is performed in a checked() context, which would then throw an OverflowException.

4. What is the difference between x = y++; and x = ++y;?
   x = y++; assigns the current value of y to x, then increments y by 1 (post-increment).
   x = ++y; increments y by 1 first, then assigns the new value of y to x (pre-increment).

5. What is the difference between break, continue, and return when used inside a loop statement?
   break exits the loop entirely, stopping all iterations.
   continue skips the current iteration and moves to the next iteration of the loop.
   return exits the entire method and returns control to the calling method, and can also return a value if specified.

6. What are the three parts of a for statement and which of them are required?
    - Initialization: executed once at the beginning of the loop (e.g., int i = 0).
    - Condition: evaluated before each iteration; if true, the loop continues; if false, the loop ends (e.g., i < 10).
    - Iteration: executed at the end of each iteration, typically used to update the loop variable (e.g., i++).
    None of these parts are strictly required; you can omit any or all of them, but you must include the semicolons.

7. What is the difference between the = and == operators?
   = is the assignment operator, used to assign a value to a variable
   == is the equality operator, used to compare two values for equality

8. Does the following statement compile? for ( ; true; ) ;
   Yes, it compiles. This is an infinite loop because the condition is always true

9. What interface must an object implement to be enumerated by the foreach statement?
   The object must implement the IEnumerable interface to be enumerated. If I understood it correctly, it's used behind the scenes. Without it foreach wouldn't work.  */

/*03Coding：
1. How can we find the minimum and maximum values, as well as the number of bytes, for the following data types: 
sbyte, byte, short, ushort, int, uint, long, ulong, float, double, and decimal? */
public class Program
{
    public static void Main(string[] args)
    {
        // DataTypeInfo.TypeIn();  //Part 1

        // FizzBuzz.FB();          //Part 2

        // Part 3
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        int[] result = TwoSum.TS(nums, target);
        Console.WriteLine($"Indices: {result[0]}, {result[1]}");
    }
}
public class DataTypeInfo
{
    public static void TypeIn()
    {
        Console.WriteLine($"sbyte -> Min: {sbyte.MinValue} -> Max: {sbyte.MaxValue} -> Size: {sizeof(sbyte)} Bytes.\n");
        Console.WriteLine($"byte -> Min: {byte.MinValue} -> Max: {byte.MaxValue} -> Size: {sizeof(byte)} Bytes.\n");
        Console.WriteLine($"short -> Min: {short.MinValue} -> Max: {short.MaxValue} -> Size: {sizeof(short)} Bytes.\n");
        Console.WriteLine($"ushort -> Min: {ushort.MinValue} -> Max: {ushort.MaxValue} -> Size: {sizeof(ushort)} Bytes.\n");
        Console.WriteLine($"int -> Min: {int.MinValue}  -> Max: {int.MaxValue}  -> Size: {sizeof(int)} Bytes.\n");
        Console.WriteLine($"uint -> Min: {uint.MinValue} -> Max: {uint.MaxValue} -> Size: {sizeof(uint)} Bytes.\n");
        Console.WriteLine($"long -> Min: {long.MinValue} -> Max: {long.MaxValue} -> Size: {sizeof(long)} Bytes.\n");
        Console.WriteLine($"ulong -> Min: {ulong.MinValue} -> Max: {ulong.MaxValue} -> Size: {sizeof(ulong)} Bytes.\n");
        Console.WriteLine($"float -> Min: {float.MinValue} -> Max: {float.MaxValue} -> Size: {sizeof(float)} Bytes.\n");
        Console.WriteLine($"double -> Min: {double.MinValue} -> Max: {double.MaxValue} -> Size: {sizeof(double)} Bytes.\n");
        Console.WriteLine($"decimal -> Min: {decimal.MinValue} -> Max: {decimal.MaxValue} -> Size: {sizeof(decimal)} Bytes.\n");
    }
}


/*2. Write a method in C# called FizzBuzz that takes an integer num and prints numbers from 1 up to num, but:
 - Print Fizz if the number is divisible by 3.
 - Print Buzz if the number is divisible by 5.
 - Print FizzBuzz if the number is divisible by both 3 and 5.
 - Otherwise, print the number itself. */

public class FizzBuzz
{
    public static void FB()
    {
        int? num = null;
        while (true) {
            Console.Write("Enter a number: ");
            num = int.TryParse(Console.ReadLine(), out int n) ? n : null;
            if (num == null || num <= 0)
            {
                Console.WriteLine("Invalid Input. Try again.");
            }
            else { break; }
        }
        for (int i = 1; i < num + 1; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.Write("FizzBuzz ");
            } else if (i % 3 == 0)
            {
                Console.Write("Fizz ");
            } else if (i % 5 == 0)
            {
                Console.Write("Buzz ");
            }
            else
            {
                Console.Write(i + " ");
            }
        }

    }
}


/* 3. What will happen if this code executes?
int max = 500;
for (byte i = 0; i < max; i++)
{
    Console.WriteLine(i);
} 

It will cause an infinite loop because the byte variable 'i' will overflow after reaching its maximum value of 255,
wrapping around to 0 and continuing the loop indefinitely since 'i < max' will always be true */



/* 4. Two Sum
 Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
 - You may assume that each input would have exactly one solution.
 - You may not use the same element twice.
 - You can return the answer in any order. */
public class TwoSum
{
    public static int[] TS(int[] nums, int target)
    {
        Dictionary<int, int> seen = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (seen.ContainsKey(complement))
            {
                return new int[] { seen[complement], i };
            }
            if (!seen.ContainsKey(nums[i]))
            {
                seen[nums[i]] = i;
            }
        }
        // How C# lets you intentionally raise an exception when something goes wrong or violates your program’s expectations. I can't name it; there are common exceptions.
        throw new InvalidOperationException("No se encontró ninguna solución para TwoSum.");
    }
}