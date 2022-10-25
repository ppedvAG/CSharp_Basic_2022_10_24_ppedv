using M006.BuildingPart; //Import the BuildingParts

namespace M006;

internal class Program
{
	static void Main(string[] args)
	{
		Window w = new Window(); //Create a new object from the blueprint with new

		w.SetLength(5); //With set method
		w.Width = 9; //With property

		Console.WriteLine(w.GetLength()); //With get method
		Console.WriteLine(w.Width); //With property

		//w.State = WindowState.Opened; //Not possible since the set accessor is private
		Console.WriteLine(w.State);

		//w.Area = 20; //Not possible since there is no set accessor
		Console.WriteLine(w.Area);

		w.OpenWindow(); //The object has the function

		Window w2 = new Window(3, 5); //Set the default values of the object at creation
		Window w3 = new Window(4, 5, WindowState.Opened); //Uses both constructors



		Room r = new Room();
		r.Door = new Door();
		r.Windows[0] = w;
		r.Windows[1] = w2;
		r.Windows[2] = w3;
		r.Width = 10;
		r.Length = 10;

		//System -> Console, Int32, Enum, ...
		//System.IO -> File, Directory, Path, ...
		//System.Net.Http -> HttpClient, HttpResponseMessage, StringContent, ...
	}
}