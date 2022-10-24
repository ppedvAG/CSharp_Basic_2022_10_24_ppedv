namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			//Array: A variable that can hold multiple values
			int[] numbers; //Array declaration with [] after the type (<Type>[])
			numbers = new int[10]; //Array with 10 fields (Indices 0-9)
			numbers[2] = 7; //Access field with [<Index>]
			Console.WriteLine(numbers[2]);

			int[] numbersDirect = new int[] { 1, 2, 3, 4, 5 }; //Direct initialisation, length automatically (5)
			int[] numbersDirectShorter = new[] { 1, 2, 3, 4, 5 }; //Shorter than above
			int[] numbersDirectShortest = { 1, 2, 3, 4, 5 }; //Shortest direct initialisation

			Console.WriteLine(numbers.Length); //Length of the array (10)

			Console.WriteLine(numbersDirect.Contains(4)); //true
			Console.WriteLine(numbersDirect.Contains(8)); //false

			int[,] twoDArray = new int[3, 3]; //Matrix (3x3): declaration with a comma in the brackets
			twoDArray[1, 1] = 4; //Access with two indizes
			Console.WriteLine(twoDArray[1, 1]);

			twoDArray = new[,]
			{
				{ 1, 2, 3 },
				{ 2, 3, 4 },
				{ 3, 4, 5 }
			}; //direct initialisation of a two dimensional array

			Console.WriteLine(twoDArray.Length); //9
			Console.WriteLine(twoDArray.Rank); //Amount of dimensions (2)
			Console.WriteLine(twoDArray.GetLength(0)); //Length of the first dimension (3)
			Console.WriteLine(twoDArray.GetLength(1)); //Length of the second dimension (3)
			#endregion

			#region Boolean Logic
			int num1 = 5;
			int num2 = 9;

			if (num1 == num2)
			{
				//...
			}

			//==, !=, <, >, <=, >=

			bool b1 = true;
			bool b2 = false;

			if (b1 && b2) //When both conditions are met
			{
				//...
			}

			if (b1 || b2) //When one condition is met
			{

			}

			if (b1 ^ b2) //When the conditions give different results
			{
				//b1 && !b2 || !b1 && b2
			}

			b1 = !b1;
			b1 ^= true; //flips the boolean always
			//App.MainWindow.Button.Boolean = !App.MainWindow.Button.Boolean;
			//App.MainWindow.Button.Boolean ^= true;

			if (!b1) //! to invert a boolean/condition
			{

			}

			if (b1)
			{

			}
			else
			{

			}

			if (b1)
			{

			}
			else if (b2)
			{

			}
			else
			{

			}

			/* else/if for the compiler
			if (b1)
			{

			}
			else
			{
				if (b2)
				{

				}
				else
				{

				}
			}
			*/

			if (b1) //If the code inside the if (or else) is only a single line, we can omit the brackets
				Console.WriteLine("b1");

			if (numbers.Contains(2))
			{

			}

			if (num1 != num2)
				Console.WriteLine("The numbers are not equal");
			else
				Console.WriteLine("The numbers are equal");

			//Ternary operator (?, :) ? is if, : is else
			//Always needs an else
			Console.WriteLine(num1 != num2 ? "The numbers are not equal" : "The numbers are equal");
			#endregion
		}
	}
}