using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		List<int> list = new List<int>(); //Creation of a list with a generic, all T's in the List class will be replaced with the given type (int here)
		list.Add(1); //T gets replaced by int
		list.Add(2); //Adds a new element to the end of the list
		list.Add(3);
		list.Add(4);

		list.Remove(3); //Removes the first occurrence of the given value

		list.RemoveAt(1); //Removes the element at the given index

		//List always moves elements together when elements get removed

		List<string> list2 = new List<string>();
		list2.Add("Test"); //T gets replaced by string

		Console.WriteLine(list[0]); //Element at position 0 (the same as an array)

		Console.WriteLine(list.Count); //Count instead of Length to get the amount of elements

		list[1] = 3; //Assignment like in an array

		list.Sort(); //Sort a list (works fine with int, string, ...)

		foreach (int i in list) //Iterate a list like in an array
		{
			Console.WriteLine(i);
		}

		if (list.Contains(2)) //Is one or more of the given element inside the list?
		{
			//false
		}

		list.Clear(); //Removes all elements

		Stack<int> intStack = new Stack<int>(); //Stack: List that can only be accessed from the top (last element added)
		intStack.Push(1); //Put elements on top
		intStack.Push(2);
		intStack.Push(3);
		intStack.Push(4);
		intStack.Push(5);

		Console.WriteLine(intStack.Peek()); //Look at the top element (5)

		Console.WriteLine(intStack.Pop()); //Look at and remove the top element (5)

		//Queue: List that can only be accessed from the front (first element added)
		Queue<int> queue = new Queue<int>();
		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);
		queue.Enqueue(4);
		queue.Enqueue(5);

		Console.WriteLine(queue.Peek()); //Look at the first element (1)

		Console.WriteLine(queue.Dequeue()); //Look at and remove the first element (1)

		//Dictionary: list of KeyValuePairs, keys must unique
		Dictionary<string, int> populationNumbers = new(); //Target-typed new: omits the type (since it is already declared in the variable)
		populationNumbers.Add("Vienna", 2_000_000); //Literal: _ in numbers to make large numbers more readable (has no impact on the number)
		populationNumbers.Add("Berlin", 3_650_000);
		populationNumbers.Add("Paris", 2_160_000);
		//populationNumbers.Add("Paris", 2_160_000); //Can't add the same key twice

		Console.WriteLine(populationNumbers["Paris"]); //Access values in my dictionary

		if (populationNumbers.ContainsKey("Paris")) //Check first if a certain key exists
		{
			//...
		}

		if (populationNumbers.ContainsValue(2_000_000)) //Checks if a value exists in the dictionary
		{
			//...
		}

		foreach (KeyValuePair<string, int> kv in populationNumbers) //Iterate through a dictionary
		{
			Console.WriteLine($"The city {kv.Key} has {kv.Value} inhabitants."); //Access keys and values with kv.Key and kv.Value
		}

		Console.WriteLine(populationNumbers.Keys); //Access only the keys
		Console.WriteLine(populationNumbers.Values); //Access only the values

		SortedDictionary<string, int> popSorted = new(); //SortedDictionary: sorts itself by the key after every Add
		popSorted.Add("Vienna", 2_000_000);
		popSorted.Add("Berlin", 3_650_000); //Before Vienna
		popSorted.Add("Paris", 2_160_000); //Between Berlin and Paris

		ObservableCollection<int> oc = new(); //ObservableCollection: notifies whenever something happens in the list
		oc.CollectionChanged += Oc_CollectionChanged; //Whenever the list changes, the attached method gets executed
		oc.Add(1);
		oc.Add(2);
		oc.Add(3);
		oc.Remove(2);
	}

	private static void Oc_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
			case NotifyCollectionChangedAction.Add:
				Console.WriteLine($"An element was added: {e.NewItems[0]}"); //With NewItems[0] we can see what was added
				break;
			case NotifyCollectionChangedAction.Remove:
				Console.WriteLine($"An element was removed: {e.OldItems[0]}"); //With OldItems[0] we can see what was removed
				break;
			//case NotifyCollectionChangedAction.Replace:
			//	break;
			//case NotifyCollectionChangedAction.Move:
			//	break;
			//case NotifyCollectionChangedAction.Reset:
			//	break;
		}
	}
}