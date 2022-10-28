namespace M015;

internal class EventComponent
{
	static void Main(string[] args)
	{
		Component c = new Component();
		c.ValueChanged += (i) => Console.WriteLine($"The process has progressed: {i}"); //Change the behavior of the component
		c.ProcessCompleted += () => Console.WriteLine("The process is done."); //Event without a parameter ()
		c.StartProcess();
	}
}

public class Component
{
	public event Action ProcessCompleted;

	public event Action<int> ValueChanged; //Action with a parameter as the EventHandler

	public void StartProcess()
	{
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			ValueChanged(i); //Notify when the process has progressed
		}
		ProcessCompleted(); //Notify when the process is done
	}
}