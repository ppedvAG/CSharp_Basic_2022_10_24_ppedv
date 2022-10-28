namespace M015;

internal class EventsTest
{
	event EventHandler TestEvent;

	event EventHandler<TestEventArgs> ArgsEvent; //Specify custom EventArgs

	static void Main(string[] args)
	{
		EventsTest e = new EventsTest();
		e.TestEvent += E_TestEvent; //Attach a method to my event using +=
		e.TestEvent(e, EventArgs.Empty); //Call the event with e as the sender and no data (EventArgs.Empty)

		e.ArgsEvent += E_ArgsEvent; //If I attach a method, it gets the TestEventArgs instead of the generic ones
		e.ArgsEvent(e, new TestEventArgs("Notification", "The event was fired"));

		e.ArgsEvent += (sender, args) => Console.WriteLine("Anonymous event");
		e.ArgsEvent(e, null);
	}

	private static void E_TestEvent(object? sender, EventArgs e)
	{
		Console.WriteLine("Event was fired");
	}

	private static void E_ArgsEvent(object? sender, TestEventArgs e)
	{
		if (e is not null)
			Console.WriteLine(e.Message + " " + e.Status);
	}
}

public class TestEventArgs : EventArgs
{
	public string Status { get; set; }

	public string Message { get; set; }

	public TestEventArgs(string status, string message)
	{
		Status = status;
		Message = message;
	}
}