using Microsoft.VisualBasic.FileIO;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Environment; //using on a single class and embed this class into our own class

namespace M014;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Paths to special folders in windows (here desktop)

		string folderPath = Path.Combine(desktop, "Test"); //Path class to do path operations

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath); //Directory class to do things with directories

		string filePath = Path.Combine(folderPath, "M014.txt"); //Create the file path

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

		//Streams();

		//Json();

		//Xml();

		//CSV();
	}

	static void Streams()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Paths to special folders in windows (here desktop)

		string folderPath = Path.Combine(desktop, "Test"); //Path class to do path operations

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath); //Directory class to do things with directories

		string filePath = Path.Combine(folderPath, "M014.txt"); //Create the file path

		StreamWriter sw = new StreamWriter(filePath); //Open a writer to a path
		sw.WriteLine("Test1"); //Fill stream
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		//sw.Flush(); //We can write the content of the stream into the file
		sw.Close(); //With close we can 'free' up the file again

		using (StreamWriter sw2 = new StreamWriter(filePath)) //Using block: closes automatically at the end of the block, object needs the IDisposable interface
		{
			sw2.WriteLine("Test1");
			sw2.WriteLine("Test2");
			sw2.WriteLine("Test3");
		} //Closes and flushes here automatically

		using StreamWriter sw3 = new StreamWriter(filePath); //Using statement: gets closed at the end of the method
		sw3.WriteLine("Test1");
		sw3.WriteLine("Test2");
		sw3.WriteLine("Test3");

		using StreamReader sr = new StreamReader(filePath);
		string full = sr.ReadToEnd(); //Read the entire file into a single string
		string[] lines = full.Split(NewLine, StringSplitOptions.RemoveEmptyEntries); //Split the read string into lines and remove the last empty line

		File.WriteAllText(filePath, "Test1\nTest2"); //Write a file quickly

		File.WriteAllLines(filePath, lines); //Write an array quickly

		File.ReadAllText(filePath); //Read the entire file into a single string

		File.ReadAllLines(filePath); //Read the entire file into a string array (lines)
	}

	static void Json()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Paths to special folders in windows (here desktop)

		string folderPath = Path.Combine(desktop, "Test"); //Path class to do path operations

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath); //Directory class to do things with directories

		string filePath = Path.Combine(folderPath, "M014.txt"); //Create the file path

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

		string json = JsonSerializer.Serialize(cars); //Convert the object list into json
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		Car[] carArray = JsonSerializer.Deserialize<Car[]>(readJson); //Convert the json string back to a collection (here array)
	}

	static void Xml()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Paths to special folders in windows (here desktop)

		string folderPath = Path.Combine(desktop, "Test"); //Path class to do path operations

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath); //Directory class to do things with directories

		string filePath = Path.Combine(folderPath, "M014.txt"); //Create the file path

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

		XmlSerializer xml = new XmlSerializer(cars.GetType()); //Give the type of object to serialize
		using (FileStream fs = new FileStream(filePath, FileMode.Create)) //Xml uses streams to serialize/deserialize
			xml.Serialize(fs, cars);

		List<Car> readXml;
		using (FileStream fs = new FileStream(filePath, FileMode.Open))
			readXml = xml.Deserialize(fs) as List<Car>;
	}

	static void CSV()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Paths to special folders in windows (here desktop)

		string folderPath = Path.Combine(desktop, "Test"); //Path class to do path operations

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath); //Directory class to do things with directories

		string filePath = Path.Combine(folderPath, "M014.txt"); //Create the file path

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

		TextFieldParser tfp = new TextFieldParser(filePath);
		tfp.SetDelimiters(";");
		List<string[]> lines = new();
		while (!tfp.EndOfData)
		{
			lines.Add(tfp.ReadFields());
		}
	}
}

public class Car
{
	public int MaxV { get; set; }

	public Brand Brand { get; set; }

	public Car(int maxV, Brand brand)
	{
		MaxV = maxV;
		Brand = brand;
	}

	public Car()
	{

	}
}

public enum Brand
{
	Audi, BMW, VW
}