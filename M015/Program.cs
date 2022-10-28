namespace M015;

internal class Program
{
	public delegate void Introduction(string name); //Delegate: custom type that can hold any number of method pointers, which then can be executed at the same time

	static void Main(string[] args)
	{
		Introduction intro; //Delegate variable
		intro = new Introduction(IntroductionEN); //Creation of the delegate object with a method pointer
		intro("Max"); //Execute delegate with <Name>(<Parameter>)

		intro += IntroductionDE; //Append method with a method pointer
		intro("Max"); //Execute all methods sequentially

		intro -= IntroductionEN; //Disconnect a method
		intro -= IntroductionEN; //Removing a method thats not attached to the delegate does nothing
		intro -= IntroductionEN;
		intro -= IntroductionEN;
		intro("Max");

		intro -= IntroductionDE; //If the last method gets removed, the delegate becomes null
		intro("Max"); //Exception

		if (intro is not null) //Do a null check before executing the delegate
		{
			intro("Max");
		}

		intro.Invoke("Max"); //Do the same thing as intro(...)
		intro?.Invoke("Max"); //? before a dot is a short null check (method does not get executed if the variable is null)

		intro = null; //Clear a delegate

		foreach (Delegate dg in intro.GetInvocationList()) //Gets all methods attached to the delegate
		{
			Console.WriteLine(dg.Method.Name); //look into dg.Method
		}
	}

	static void IntroductionEN(string name)
	{
		Console.WriteLine($"Hello my name is {name}");
	}

	static void IntroductionDE(string name)
	{
		Console.WriteLine($"Hallo mein Name ist {name}");
	}
}