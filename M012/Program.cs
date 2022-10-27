using System.Diagnostics;
using System.Linq;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Simple Linq
		List<int> list = Enumerable.Range(1, 20).ToList(); //Creates a list from start with amount elements

		Console.WriteLine(list.Average());
		Console.WriteLine(list.Min());
		Console.WriteLine(list.Max());
		Console.WriteLine(list.Sum());

		Console.WriteLine(list.First()); //First element of the list, exception if no element was found
		Console.WriteLine(list.FirstOrDefault()); //First element of the list, null if no element was found

		Console.WriteLine(list.Last()); //Last element of the list, exception if no element was found
		Console.WriteLine(list.LastOrDefault()); //Last element of the list, null if no element was found

		//list.First(e => e % 25 == 0); //Exception
		//list.FirstOrDefault(e => e % 25 == 0); //Default value (0)
		#endregion

		List<Car> cars = new List<Car>
		{
			new Car(251, Brand.BMW),
			new Car(274, Brand.BMW),
			new Car(146, Brand.BMW),
			new Car(208, Brand.Audi),
			new Car(189, Brand.Audi),
			new Car(133, Brand.VW),
			new Car(253, Brand.VW),
			new Car(304, Brand.BMW),
			new Car(151, Brand.VW),
			new Car(250, Brand.VW),
			new Car(217, Brand.Audi),
			new Car(125, Brand.Audi)
		};

		#region Comparison of Linq notations
		//Find all BMWs with foreach
		List<Car> bmws = new();
		foreach (Car c in cars)
			if (c.Brand == Brand.BMW)
				bmws.Add(c);

		//Default-Linq: SQL-like syntax (old)
		List<Car> bmwSQL = (from c in cars
							where c.Brand == Brand.BMW
							select c).ToList();

		//Method chain
		List<Car> bmwLinq = cars.Where(c => c.Brand == Brand.BMW).ToList();
		#endregion

		//All cars that can go faster than 200km/h
		cars.Where(c => c.MaxV > 200);

		//All Audis that can go faster than 200km/h
		cars.Where(c => c.Brand == Brand.Audi && c.MaxV > 200);

		//All Brands in my list
		List<Brand> brands = cars.Select(c => c.Brand).ToList();

		//Every brand unique
		brands.Distinct();

		//Concatenate Linq functions
		cars.Select(c => c.Brand).Distinct();

		//The first car of each brand in the list
		cars.DistinctBy(c => c.Brand);

		//Order my list by velocity (slowest to fastest)
		cars.OrderBy(c => c.MaxV);

		//Order my list by velocity (fastest to slowest)
		cars.OrderByDescending(c => c.MaxV);

		//Order by brand, then by velocity
		cars.OrderBy(c => c.Brand).ThenBy(c => c.MaxV);

		cars.OrderBy(c => c.MaxV).First(); //The slowest car
		cars.OrderBy(c => c.MaxV).Last(); //The fastest car

		//The car with the biggest velocity (fastest car)
		cars.MaxBy(c => c.MaxV);

		//The car with the lowest velocity (slowest car)
		cars.MinBy(c => c.MaxV);

		//With Min() we get the lowest velocity instead of the car with lowest velocity
		cars.Min(c => c.MaxV);
		cars.Max(c => c.MaxV);

		//How many BMWs do we have?
		cars.Count(c => c.Brand == Brand.BMW); //4

		//The average velocity
		cars.Average(c => c.MaxV); //208.4166666

		//Are all of our cars going faster than 200km/h?
		cars.All(c => c.MaxV > 200);

		//Do we have any cars that are going faster than 300km/h?
		cars.Any(c => c.MaxV > 300);

		//Are there any elements in the list?
		cars.Any(); //cars.Count > 0

		#region Extension methods
		int x = 435982;
		Console.WriteLine(x.CrossSum());
		Console.WriteLine(432587.CrossSum()); //All ints in my project now have this extension method

		cars.Shuffle(); //Custom Linq function
		#endregion
	}
}

[DebuggerDisplay("Brand: {Brand}, MaxV: {MaxV} - {typeof(Car).FullName}")]
public class Car
{
	public int MaxV;

	public Brand Brand;

	public Car(int maxV, Brand brand)
	{
		MaxV = maxV;
		Brand = brand;
	}
}

public enum Brand
{
	Audi, BMW, VW
}