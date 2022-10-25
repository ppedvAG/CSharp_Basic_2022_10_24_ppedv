namespace M008;

class AccessModifier //Members without access modifiers are internal
{
	public string Name { get; set; } //Can be seen from everywhere (also from the outside of the project)

	private int Age { get; set; } //Can be seen nowhere except inside of this class

	internal string Address { get; set; } //Can be seen from everywhere (but not from the outside)


	protected string Color { get; set; } //Only visible inside of this class and in subclasses (also from the outside)

	protected internal string Description { get; set; } //Can be seen everywhere in the project (internal) and in subclasses outside of it (protected)

	protected private DateTime Birthday { get; set; } //Can only be seen in this class or in derived class only inside of this project
}
