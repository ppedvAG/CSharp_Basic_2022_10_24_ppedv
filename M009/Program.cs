namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		Human h = new Human(); //Variable type human, can hold all objects that are derived from human or Human itself

		Species s = h; //Variable type species, can hold all objects that are Species or derived from it

		object o = h; //Variable type object, can hold anything
		o = 123;
		o = "Test";
		o = false;

		//.GetType(): gets the type of the attached object
		Console.WriteLine(h.GetType()); //M009.Human (.FullName)
		Console.WriteLine(s.GetType().Name); //Human (.Name)
		Console.WriteLine(o.GetType()); //System.Boolean

		Type t = h.GetType(); //.GetType() gives us a Type object which has more information about the object
		Type typeofHuman = typeof(Human); //With typeof(<Classname>) we can obtain a Type object via a class name

		#region Exact type comparisons
		if (h.GetType() == typeof(Human))
		{
			//true
		}

		if (h.GetType() == typeof(Species))
		{
			//false
		}
		#endregion

		#region Inheritance tree type comparison
		if (h is Human)
		{
			//true
		}

		if (h is Species)
		{
			//true
		}

		if (h is object)
		{
			//always true
		}

		if (h is Program)
		{
			//false
		}
		#endregion

		#region Virtual Override
		Human human = new Human();
		human.WhatAmI(); //I am a human and can speak

		Species species = human;
		species.WhatAmI(); //I am a human and can speak
						   //The method of the human is used
		#endregion

		#region New
		Human human2 = new Human();
		human.WhatAmI(); //I am a human and can speak

		Species species2 = human;
		species.WhatAmI(); //I am a species
						   //The connection has been interrupted by the new keyword (not overridden anymore)
		#endregion

		Species[] sp = new Species[3];
		sp[0] = new Species();
		sp[1] = new Human();
		sp[2] = new Dog();

		foreach (Species spec in sp)
		{
			if (spec.GetType() == typeof(Human))
			{
				Human h2 = (Human) spec;
				h2.HumanMethod();
			}

			if (spec is Dog d)
			{
				//Dog dog = (Dog) spec; this cast can be omitted by putting the variable name into the if
				d.DogMethod();
			}
		}
	}
}

public class Species 
{ 
	public virtual void WhatAmI()
	{
		Console.WriteLine("I am a species");
	}
}

public class Human : Species 
{
	public new void WhatAmI()
	{
		Console.WriteLine("I am a human and can speak");
	}

	public void HumanMethod()
	{

	}
}

public class Dog : Species
{
	public void DogMethod()
	{

	}
}