namespace M015;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		Action<int, int> action = Add; //Action: Method with void and up to 16 parameters
		action += Subtract; //Appending methods works just like with a delegate
		action(3, 4);
		action?.Invoke(4, 5);

		DoAction(4, 5, Add); //Change the behavior of this method without adjusting the code of the method
		DoAction(4, 5, Subtract); //Different actions as parameters
		DoAction(4, 5, action); //Put in an action variable

		Predicate<int> pred = CheckForZero; //Predicate: method with bool as the return value and exactly one parameter
		pred += CheckForOne;
		bool b = pred(0); //Predicate produces a return value (bool)
		bool b2 = pred(1); //Predicate only takes the last method for the return value
		bool? b3 = pred?.Invoke(1); //Here we need bool? (nullable boolean) because the Invoke method could return null if the predicate is null

		DoPredicate(0, CheckForZero);
		DoPredicate(1, CheckForOne);
		DoPredicate(1, pred);

		Func<int, int, double> func = Multiply; //Func: Method with a return value, the last generic defines the type of the return value
		func += Divide;
		double d = func(3, 4); //Here we also take the last result
		double? d2 = func?.Invoke(4, 2); //Here we also need a nullable double

		DoFunc(3, 2, Multiply);
		DoFunc(3, 4, Divide);
		DoFunc(3, 1, func);

		func += delegate (int x, int y) { return x + y; };
		func += (int x, int y) => { return x + y; };
		func += (x, y) => { return x - y; };
		func += (x, y) => (double) x / y;

		DoAction(4, 3, (x, y) => Console.WriteLine(x + y)); //Anonymous action
		DoPredicate(4, e => e == 0); //Anonymous predicate
		DoFunc(5, 2, (x, y) => x * y); //Anonymous function

		List<int> x = new();
		x.ForEach(x => Console.WriteLine(x)); //Action
		x.Find(x => x % 2 == 0); //Predicate
		x.Where(x => x % 2 == 0); //Func
	}

	private static void Add(int arg1, int arg2) => Console.WriteLine(arg1 + arg2);

	private static void Subtract(int arg1, int arg2) => Console.WriteLine(arg1 - arg2);

	private static void DoAction(int n1, int n2, Action<int, int> action) => action?.Invoke(n1, n2);

	private static bool CheckForZero(int obj) => obj == 0;

	private static bool CheckForOne(int obj) => obj == 1;

	private static bool? DoPredicate(int num, Predicate<int> pred) => pred?.Invoke(num);

	private static double Multiply(int arg1, int arg2) => arg1 * arg2;

	private static double Divide(int arg1, int arg2) => arg1 / arg2;

	private static double? DoFunc(int n1, int n2, Func<int, int, double> func) => func?.Invoke(n1, n2);
}
