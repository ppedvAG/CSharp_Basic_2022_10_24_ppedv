using System.Collections;
using System.Text;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;

		Human h = new Human();
		h.Salary = 3000;
		h.Job = "Software Engineer";
		//h.Payout(); //Payout implementation through the interface

		IWork work = h;
		work.Payout(); //call the explicit implementations

		IParttimeWork pWork = h;
		pWork.Payout();

		//IEnumerable: Basic interface of all collections in C#, we can use Linq functions due to this interface
		int[] x = new int[5];
		List<int> y = new();
		Dictionary<int, int> z = new();

		Test2(x);
		Test2(y);
		Test2(z);
	}

	public void Test(ICloneable c)
	{
		c.Clone();
	}

	public static void Test2(IEnumerable e)
	{

	}
}

public interface IWork //Interfaces start with an I by convention
{
	static int WorkHours = 40; //Create a static field which I can access with IWork.WorkHours

	int Salary { get; set; }

	string Job { get; set; } //Properties will be inherited

	void Payout(); //Methods without a body like in abstract classes

	public void Test()
	{
		//Bad practice
	}
}

public interface IParttimeWork : IWork //We can also inherit interfaces of each other
{
	new static int WorkHours = 20;

	new void Payout();
}

public class Human : IWork, IParttimeWork //Inherit interface like a class
{
	public int Salary { get; set; }

	public string Job { get; set; }

	void IWork.Payout()
	{
		Console.WriteLine($"This employee has earned a salary of {Salary}€ for the job {Job}. He works {IWork.WorkHours} hours per week.");
	}

	void IParttimeWork.Payout()
	{
		Console.WriteLine($"This employee has earned a salary of {Salary / 2}€ for the job {Job}. He works {IParttimeWork.WorkHours} hours per week.");
	}
}