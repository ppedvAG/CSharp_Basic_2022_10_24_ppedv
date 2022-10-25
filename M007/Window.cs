namespace M007;

internal class Window
{
	#region Variable + Get/Set
	private double length; //Fields should not be accessible from the outside

	/// <summary>
	/// Returns the length of the window.
	/// </summary>
	/// <returns>The length of the window in meters.</returns>
	public double GetLength()
	{
		return length;
	}

	/// <summary>
	/// Sets the length of the window to a new value.
	/// </summary>
	/// <param name="length">The new length of the window in meters (0.1m to 10m).</param>
	public void SetLength(double length)
	{
		if (length > 0.1 && length < 10) //Check before the value is set
			this.length = length; //this: point outside of the method (take the upper length field)
		else
			Console.WriteLine("The new length is not valid");
	}
	#endregion

	#region Properties
	private double width;

	public double Width
	{
		get { return width; }
		set //We can also do some checks here
		{
			if (value > 0.1 && value < 10)
				width = value; //value: The new value (like above in the set method -> length)
			else
				Console.WriteLine("The new length is not valid");
		}
	}

	private WindowState state = WindowState.Closed; //Set the default value

	public WindowState State
	{
		get { return state; }
		private set { state = value; } //Private set: Make the property not settable from the outside (only inside of this class)
	}

	public double Area
	{
		get { return length * width; } //Get-only property (no set accessor)
	}
	#endregion

	/// <summary>
	/// A method that opens the window.
	/// </summary>
	public void OpenWindow() //Object will also have all functions that are defined in the class
	{
		if (state == WindowState.Closed)
			state = WindowState.Opened;
		else
			Console.WriteLine("The window is already open");
	}

	#region Constructor
	public Window() { } //Default constructor, every object has one

	//Constructor: Sets the default values of the object at creation
	public Window(double length, double width) //The default constructor gets deleted
	{
		SetLength(length); //Set the default values
		Width = width;
		//this.width = width; //Circumvents the checks from the property
	}

	//With : this we can chain constructors together
	//if I execute this constructor the upper one will be executed as well
	public Window(double length, double width, WindowState state) : this(length, width)
	{
		this.state = state;
	}
	#endregion

	~Window() //~ + Tab + Tab
	{
		Console.WriteLine($"Window was collected {GetHashCode()}"); //Gets called when the garbage collector destroys this object
		//GetHashCode(): Gets the memory address of the object
	}

	public static int Counter { get; set; } //static property is attached the class and not to the object

	public static void CountWindow() //static method is attached to the class
	{
		Counter++;
		//Console.WriteLine(length);
		//OpenWindow(); not possible, because we don't have an object here
	}
}

enum WindowState
{
	Closed,
	Opened
}
