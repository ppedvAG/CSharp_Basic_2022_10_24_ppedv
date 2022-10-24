namespace M005
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintAddition(2, 4); //Function call with the name of the function + parameters
			PrintAddition(10, 3);
			PrintAddition(6, 7);

			int x = Add(3, 8); //Take the result from the Add function and write it into a variable
			Console.WriteLine(Add(4, 2)); //Take the result from the Add function and put it into Console.WriteLine()

			//F12: Jump to definition
			Console.WriteLine(); //-> 17 overloads for all kinds of parameters (string, int, char, ...)

			Add(3, 4, 5);
			Add(4, 3); //2 integers -> int function
			Add(3.2, 3); //>= 1 double -> double function

			Add(3, 2, 1); //params has a lower priority in function overloading

			Subtract(3, 1); //Leave optional parameter at the set value
			Subtract(3, 1, 5); //Fill optional parameter with 5

			SubtractOrAdd(4, 1); //this function adds
			SubtractOrAdd(4, 1, false); //now it subtracts

			int sub;
			int add = SubAndAdd(3, 2, out sub); //connect the parameter to the sub field

			SubAndAdd(6, 2, out int subtract); //generates the variable inside the parameter list, same as above but shorter

			int result;
			if (int.TryParse("123", out result))
			{
				//Parsing has worked
			}

			//int res = 0;
			if (int.TryParse("123", out int res)) //its defined above
			{

			}
			Console.WriteLine(res); //res is useable here

			PrintEnum(Weekday.Wed); //Choose one of the given 7 values
		}

		static void PrintAddition(int n1, int n2) //Definition of the function with modifiers, return type, name, parameters and body
		{
			Console.WriteLine($"{n1} + {n2} = {n1 + n2}");
		}

		static int Add(int n1, int n2) //Function with return type
		{
			return n1 + n2; //Return result of the function
		}

		static int Add(int n1, int n2, int n3) //Function overloading: Functions with the same name as other functions can coexist as long as the parameters are different
		{
			return n1 + n2 + n3;
		}

		static double Add(double n1, double n2)
		{
			return n1 + n2;
		}

		static int Add(params int[] numbers) //With params the user can input any number of parameters, must be the last parameter
		{
			return numbers.Sum(); //Down here we can access numbers like a normal array
		}

		static int Subtract(int n1, int n2, int n3 = 0) //Optional parameters have a value that can be overridden by the user, if not then the default value will be used
		{
			return n1 - n2 - n3;
		}

		static int SubtractOrAdd(int n1, int n2, bool add = true) //Behavior of the function can be changed via the bool
		{
			//if (add)
			//	return n1 + n2;
			//else
			//	return n1 - n2;
			return add ? n1 + n2 : n1 - n2;
		}

		static int SubAndAdd(int n1, int n2, out int sub) //out: return multiple values
		{
			sub = n1 - n2; //set the value of the sub variable
			return n1 + n2;
		}

		static void PrintEnum(Weekday wd) //Force the user to input specific values
		{
			Console.WriteLine(wd);
			//if (wd == Weekday.Sun)
			return; //Quit the function / end the function right here
			Console.WriteLine(wd); //Unreachable code
		}
	}

	enum Weekday
	{
		Mon = 1, Tue, Wed, Thu = 10, Fri, Sat, Sun
	}
}