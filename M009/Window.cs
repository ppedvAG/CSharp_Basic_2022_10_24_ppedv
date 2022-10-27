namespace M009;

internal class Window : BuildingPart
{
	public override double CalcArea() //Implementation with override (Ctrl + . on the class name to generate 
	{
		return Length * Width;
	}
}
