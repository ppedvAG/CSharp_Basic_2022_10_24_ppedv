using M006.BuildingPart; //Import the BuildingParts

namespace M006;

internal class Room
{
	public Door Door { get; set; }

	public Window[] Windows = new Window[10];

	public double Length, Width;
}
