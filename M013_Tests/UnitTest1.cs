using M013;

namespace M013_Tests;

[TestClass]
public class CalculatorTests
{
	Calculator calc;

	[TestInitialize]
	public void Init()
	{
		calc = new Calculator();
	}

	[TestCleanup]
	public void Cleanup()
	{
		calc = null;
	}

	[TestMethod]
	[TestCategory("Addition Test")]
	public void TestAdd()
	{
		double result = calc.Add(5, 8);
		//Assert.Fail("This test has failed"); //combine with an if
		Assert.AreEqual(13, result);
	}

	[TestMethod]
	[TestCategory("Subtraction Test")]
	public void TestSub()
	{
		double result = calc.Subtract(8, 2);
		Assert.AreEqual(6, result);
	}
}