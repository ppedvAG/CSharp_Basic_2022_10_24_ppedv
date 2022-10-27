namespace M009;

internal abstract class BuildingPart //abstract: Gives a structure to derived classes, cannot be instantiated
{
	public double Length { get; set; }

	public double Width { get; set; }

	public abstract double CalcArea(); //Abstract methods don't have a body, they must be implemented in the derived classes
}
