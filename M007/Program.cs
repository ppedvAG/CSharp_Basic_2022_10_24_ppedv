using System.Drawing;

namespace M007
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region GC
			for (int i = 0; i < 10; i++)
			{
				Window w = new Window();
			}

			GC.Collect(); //Force GC here
			GC.WaitForPendingFinalizers(); //Wait for finalizers
			#endregion

			#region Static
			//Static members work without objects
			//Console c = new Console(); not possible
			//c.WriteLine(); not possible
			//Console.WriteLine();

			Window w2 = new Window();
			//w2.Counter not possible because static
			Console.WriteLine(Window.Counter);
			//w2.CountWindow(); not possible because static
			Window.CountWindow();
			#endregion

			#region Value- and Referencetypes
			//Valuetype
			int original = 5;
			int x = original; //Value gets copied (5)
			original = 10; //No reference, so x is unchanged

			//Referencetypes
			Window w3 = new Window();
			Window w4 = w3; //Creates a reference
			w3.Width = 9; //Both windows now have a width of 9

			Console.WriteLine(w3.GetHashCode()); //Same memory address
			Console.WriteLine(w4.GetHashCode()); //Same memory address

			//class: Referencetype, struct: Valuetype
			#endregion

			#region Null
			Window w5; //Default value: null
			w5 = null; //Clear a variable

			//w5.OpenWindow(); no instance on w5 so I cannot open the window
			if (w5 == null) //Check if object is null
			{
				Console.WriteLine("Object is null");
				w5 = new Window();
			}

			if (w5 != null) //Check if the object exists
			{
				w5.OpenWindow();
			}

			if (w5 is null || w5 is not null) //Same as == and !=
			{

			}
			#endregion
		}
	}
}