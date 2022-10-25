namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Human h = new Human("Max", 23);
		Console.WriteLine(h.Name); //Name was inherited
		h.WhatAmI();

		h.WhatAmI2();

		Room r = new Room();
		r.Parts[0] = new Door();
		r.Parts[1] = new Window();
		r.Parts[2] = new Window();
		r.Parts[3] = new Window();
		r.Parts[4] = new Window();
		r.Parts[5] = new Window();
		r.Parts[6] = new Door();
	}
}

public class Species //Base class
{
	public string Name { get; set; } //Will be inherited

	public Species(string name)
	{
		Name = name;
	}

	public void WhatAmI() //Will be inherited
	{
		Console.WriteLine("I am a species");
	}

	public virtual void WhatAmI2() //virtual: can be overriden by derived classes, but does not have to
	{
		Console.WriteLine("I am a species");
	}
}

//sealed also works on classes
public sealed class Human : Species //Human is a species
{
	//Human has inherited string Name and void WhatAmI()

	public int Age { get; set; }

	public Human(string name, int age) : base(name) //Creation of this constructor is forced, with base(...) we can chain constructors like with this(...)
	{
		Age = age; //Can add any number of parameters to the constructor
	}

	//sealed: cannot override this method
	public sealed override void WhatAmI2() //override: Overwrite the method from the base class
	{
		base.WhatAmI2(); //Call the method from the base class
		Console.WriteLine($" and I am {Age} years old");
	}
}

//public class Children : Human
//{
//	public Children(string name, int age) : base(name, age)
//	{
//	}

//	public override void WhatAmI2()
//	{
//		base.WhatAmI2();
//	}
//}