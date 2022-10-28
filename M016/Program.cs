using System.Collections;
using System.Diagnostics;

namespace M016;

internal class Program
{
	static void Main(string[] args)
	{
		Wagon w1 = new();
		Wagon w2 = new();
		Console.WriteLine(w1 == w2);

		Train t = new();
		t++;
		t++;
		t++;
		t++;

		foreach (Wagon w in t)
		{

		}

		//Console.WriteLine(t[23]);
		//Console.WriteLine(t["Red"]);
		//t["Blue"] = new Wagon();
		//Console.WriteLine(t[5, "Red"]);

		System.Timers.Timer timer = new System.Timers.Timer();
		timer.Elapsed += (sender, args) => Console.WriteLine("The interval has passed");
		timer.Interval = 1000;
		timer.Start();

		Stopwatch sw = new Stopwatch();
		sw.Start();
		Thread.Sleep(1000);
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);

		Console.ReadKey();
	}
}

public class Train : IEnumerable
{
	private List<Wagon> Wagons = new();

	public IEnumerator GetEnumerator() => Wagons.GetEnumerator();

	public static Train operator ++(Train t)
	{
		t.Wagons.Add(new Wagon());
		return t;
	}

	public Wagon this[int i]
	{
		get => Wagons[i];
		set => Wagons[i] = value;
	}

	public Wagon this[string c]
	{
		get => Wagons.First(e => e.Color == c);
	}

	public Wagon this[int seats, string col]
	{
		get => Wagons.First(e => e.AmountSeats == seats && e.Color == col);
	}
}

public class Wagon
{
	public int AmountSeats;

	public string Color;

	public static bool operator ==(Wagon w1, Wagon w2) => (w1.AmountSeats == w2.AmountSeats) && (w1.Color == w2.Color);

	public static bool operator !=(Wagon w1, Wagon w2) => !(w1 == w2);
}