namespace M002
{
	/// <summary>
	/// The Program class
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// The Main method
		/// </summary>
		/// <param name="args">The program args</param>
		static void Main(string[] args)
		{
			#region Variables
			//Variable: Field with a type that can hold a value
			int number; //Declaration
			number = 5; //Assignment
			//int: Whole number (no decimals)
			Console.WriteLine(number); //Output something on the console

			int numberWithAssignment = 5; //Join declaration and assignment
			Console.WriteLine(numberWithAssignment); //cw + Tab + Tab

			int numberTimesTwo = number * 2; //result from number above times 2
			Console.WriteLine(numberTimesTwo);

			/*
			 * Multiline		 
			 * comment
			 */

			string word = "Hello"; //String: Text with a maximum 4 billion characters, requires double quotes
			Console.WriteLine(word);

			char character = 'A'; //Char: can contain a single character, needs single quotes
			Console.WriteLine(character);

			double costDouble = 49.28; //Double: decimal number

			float costFloat = 49.28f; //Decimal numbers are double by default, with a F at the end we can convert it

			decimal costDecimal = 49.28m; //Useful for monetary values, with a M at the end we can convert it

			bool b = true; //Bool: true/false value
			b = false; //true or false
			#endregion

			#region Strings
			string combine = "The word is: " + word; //String concatination mit +
			Console.WriteLine(combine);

			string combineInt = "The number is " + number; //String concatination also possible with int (or other types)
			Console.WriteLine(combineInt);

			string abstand = "The values are: " + word + ", " + number + ", " + b;
			Console.WriteLine(abstand);

			//String interpolation: with a $-sign in front of the string, write code in the string
			string interpolated = $"The values are: {word}, {number * 2}, {b}";
			Console.WriteLine(interpolated);

			Console.WriteLine($"The values are: {word}, {number * 2}, {b}"); //Direct output without an extra variable

			//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
			Console.WriteLine("Newline \n Newline"); //\n for newline

			Console.WriteLine("Tab \t Tab"); //\t for a tab

			Console.WriteLine("C:\\Users\\lk3"); //Double backlash for a single backslash

			//Verbatim string: Takes everything as written in the string, ignores escape sequences
			string verbatim = @"\n\t\\";
			Console.WriteLine(verbatim);

			string newline = @"Newline
Newline"; //If I want to write a newline I have to type an actual newline
			Console.WriteLine(newline);

			string path = @"C:\Users\lk3\source\repos\CSharp_Basic_2022_10_24"; //Especially useful for paths
			Console.WriteLine(path);
			#endregion

			#region Input
			string strInput = Console.ReadLine(); //Console.ReadLine() to wait for an input of the user, program stops until enter is pressed
			Console.WriteLine(strInput);

			int intInput = int.Parse(Console.ReadLine()); //int.Parse: Converts a string into an integer
			Console.WriteLine(intInput * 5);

			double doubleInput = double.Parse(Console.ReadLine()); //parse also exists in double
			Console.WriteLine(doubleInput);

			char inputChar = Console.ReadKey().KeyChar; //Take only a single character from the user, do not wait for enter
			Console.WriteLine(inputChar);

			int x = Convert.ToInt32(Console.ReadLine()); //Convert instead of parse (old)
			Console.WriteLine(x * 5);
			#endregion

			//Ctrl + K, Ctrl + C: Comment out selected lines
			//Ctrl + K, Ctrl + U: Comment in selected lines

			#region Conversion
			int n = 26;
			double implicitConversion = n; //Implicit conversion, works automatically

			//Explicit conversion (Cast, Typecast, Casting)
			double d = 35.82;
			int i = (int) d; //Force conversion with a cast, (int) in front
			float f = (float) d; //Force conversion, double is larger than float

			string s = d.ToString(); //Converts any value to a string
			double c = double.Parse(s); //Convert the string back to double
			#endregion

			#region Arithmetics
			int num1 = 4;
			int num2 = 9;

			Console.WriteLine(num1 + num2); //Result will be written to the console, original values don't change

			num1 = num1 + num2; //Write the result into num1
			num1 += num2; //Same as above but shorter

			Console.WriteLine(num1 % num2); //Gives the remainder of the division
			num1 %= num2;
			Console.WriteLine(num1 % 2); //Check if a number is even

			num1++; //Adds one to the number
			num1--; //Subtracts one from the number

			double num3 = 38.3285672938;
			//These functions don't edit the original value
			Math.Ceiling(num3); //Rounds up
			Math.Floor(num3); //Rounds down
			Math.Round(num3); //Rounds to the next number, rounds to the next even number if the number is in the middle (.5)
			Math.Round(4.5); //4
			Math.Round(5.5); //6

			Math.Round(num3, 2); //Round to X digits

			Console.WriteLine(8 / 5); //integer division: Only gives a whole value (1 instead of 1.6)
			Console.WriteLine(8.0 / 5); //Force decimal division by converting one number to a decimal number
			Console.WriteLine(8d / 5);
			Console.WriteLine(8f / 5);
			Console.WriteLine((double) num1 / num2); //Convert a variable to a double
			#endregion
		}
	}
}