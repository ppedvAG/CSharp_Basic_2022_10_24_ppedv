namespace M013;

internal class Program
{
	/// <summary>
	/// Throws up to 7 exceptions!
	/// </summary>
	/// <param name="args"></param>
	/// <exception cref="TestException"/> Describe which exceptions can occur in my method
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.UnhandledException += LogUnhandledExceptions; //Log all unhandled exceptions
		//throw new Exception("Test");

		try //Mark code -> right click -> Snippet -> Surround with -> try(f)
		{
			string input = Console.ReadLine(); //Mouse over method -> Exceptions shows us possible exceptions
			int x = int.Parse(input); //3 possible exceptions: ArgumentNullException, FormatException, OverflowException

			if (x == 0)
				throw new TestException("The number can't be 0", "Error"); //Throw any exception using the throw keyword
		}
		catch (FormatException e) //Input was not a number (letters)
		{
			Console.WriteLine("Input was not a number");
			Console.WriteLine(e.Message); //The message of the exception (Input string was not in a correct format)
			Console.WriteLine(e.StackTrace); //Where did our exception happen?
		}
		catch (OverflowException e) //Number is too small/big for Int32
		{
			Console.WriteLine($"The number was out of range. Valid range: {int.MinValue} to {int.MaxValue}");
			Console.WriteLine(e.Message);
			Console.WriteLine(e.StackTrace);
		}
		catch (TestException e) //Catch our own exception
		{
			Console.WriteLine(e.Message); //Message from above: The number can't be 0
			Console.WriteLine(e.Status);
			e.Test(); //Use test method from below
		}
		catch (Exception e) //Catch all other exceptions
		{
			Console.WriteLine($"Another error occurred: {e.Message}");
			throw; //Fatal error
		}
		finally //Code that always gets executed, even if there was no exception
		{
			Console.WriteLine("Parsing finished");
		}
	}

	private static void LogUnhandledExceptions(object sender, UnhandledExceptionEventArgs args)
	{
		Exception ex = args.ExceptionObject as Exception; //Grab the exception from the EventArgs
		File.WriteAllText("Log.txt", ex.Message + "\n" + ex.StackTrace);
	}
}

public class TestException : Exception //Exception must inherit from a Exception class
{
	public string Status { get; set; }

	public TestException(string? message, string status) : base(message) => Status = status;

	public void Test() => Console.WriteLine(Status);
}