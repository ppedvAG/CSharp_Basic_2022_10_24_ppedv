using System.Net;

namespace M004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Loops
			int a = 0;
			int b = 10;
			while (a < b) //While: Runs while the condition is true, checks at the end of each loop if the condition is still true
			{
				Console.WriteLine("while: " + a);
				if (a == 5)
					break; //Break: Ends the loop (in nested loops it jumps out of the inner loop)
				a++;
			}

			int c = 0;
			int d = 10;
			do //Gets executed at least once, even if the condition is false in the beginning
			{
				c++;
				if (c == 5)
					continue; //Continue: Skip the rest of the loop and go back to the head/foot
				Console.WriteLine("do-while: " + c);
			}
			while (c < d);

			//while (true) { } //Endless loop

			//while (true)
			//{
			//	if (c == 5)
			//		break;
			//}

			//for + Tab + Tab
			for (int i = 0; i < 10; i++) //Similar to while, but with an integrated counter
			{
				Console.WriteLine("for: " + i);
			}

			//forr + Tab + Tab
			for (int i = 9; i >= 0; i--) //Reverse for loop
			{
				Console.WriteLine("forr: " + i);
			}

			//for (;;) { } //Endless loop

			//for (int i = 0; ; i++) { } //Endless loop with a counter

			for (int i = 0, j = 1; i < 20; i++, j *= 2) //Multiple counter variables
			{
				Console.WriteLine($"2^{i}={j}");
			}

			for (int i = 0; i < 10; i++) //For loop also doesn't need brackets when it only has a single line
				Console.WriteLine("Test");

			int[] numbers = { 3, 421, 4532, 123, 7, 231, 213 };
			for (int i = 0; i < numbers.Length; i++) //Iterate an array using a for loop with the index
			{
				Console.WriteLine(numbers[i]); //Access the elements in the array with the given index (i)
			}

			//foreach + Tab + Tab
			foreach (int item in numbers) //Iterates over the array but cannot access a position thats not in the array
				Console.WriteLine(item);
			#endregion

			#region Enums
			string today = "Monday";
			if (today == "monday")
			{
				//Error prone
			}

			Weekday weekday = Weekday.Mon; //Variable of the enum type
			if (weekday == Weekday.Sun)
			{
				//Not error prone (a comparison of fixed values)
			}

			int x = 2; //Each enum value has an integer behind it
			Weekday cast = (Weekday) x; //cast int to Weekday

			string day = "Mon";
			Weekday currentDay = Enum.Parse<Weekday>(day); //Parse a string to an enum value (also works with numbers: "Mon" or 0)

			string input = Console.ReadLine();
			Console.WriteLine(Enum.Parse<Weekday>(input)); //Parse user input to an enum value

			Weekday[] days = Enum.GetValues<Weekday>(); //Gather all values from an enum into an array
			foreach (Weekday wd in days) //Iterate over all enum values
				Console.WriteLine(wd);
			#endregion

			#region Switch
			int z = 5;
			switch (z) //if-else tree with switch
			{
				case 1: //if
					Console.WriteLine("z is 1");
					break; //break at the end of each case
				case 2: //if else
					Console.WriteLine("z is 2");
					break;
				case 5: //if else
					Console.WriteLine("z is 5");
					break;
				default: //else
					Console.WriteLine("z is another number");
					break; //break also at default
			}

			switch (weekday)
			{
				case Weekday.Mon: //Mon to Fri will be combined since there are no breaks in between
				case Weekday.Tue:
				case Weekday.Wed:
				case Weekday.Thu:
				case Weekday.Fri:
					Console.WriteLine("The day is a weekday");
					break;
				case Weekday.Sat:
				case Weekday.Sun:
					Console.WriteLine("The day is the weekend");
					break;
				//omit default
			}

			//switch with boolean logic
			switch (weekday)
			{
				case >= Weekday.Mon and <= Weekday.Fri: //and/or instead of &&/||
					Console.WriteLine("Weekday");
					break;
				case Weekday.Sat or Weekday.Sun:
					Console.WriteLine("Weekend");
					break;
			}
			#endregion
		}
	}

	enum Weekday
	{
		Mon = 1, Tue, Wed, Thu = 10, Fri, Sat, Sun //Default values of enums can be changed, enum values afterwards will be numerated in ascending order
	}
}