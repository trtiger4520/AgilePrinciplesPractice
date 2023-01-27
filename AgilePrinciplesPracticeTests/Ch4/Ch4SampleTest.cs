using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch4;

[TestFixture]
public class Ch4SampleTest
{
    [Test]
    public void TestMove()
    {
        WumpusGame g = new WumpusGame();
        g.Connect(4, 5, "E");
        g.GetPlayerRoom(4);
        g.East();
        Assert.AreEqual(5, g.GetPlayerRoom());
    }

    [Test]
    public void TestPayroll()
    {
        MockEmploueeDatabase db = new();
        MockCheckWriter w = new();

        Paycoll p = new(db, w);
        p.PayEmployees();

        Assert.IsTrue(w.ChecksWhereWrittenCorrectly());
        Assert.IsTrue(db.PaymentsWherePostedCorrectly());
    }
}

internal class MockEmploueeDatabase : IEmployeeDatabase
{
    public void GetEmployee()
    {

    }
    public void PutEmployee()
    {

    }
    public bool PaymentsWherePostedCorrectly()
    {
        return true;
    }
}
internal class MockCheckWriter : ICheckWriter
{
    public void WriterCheck()
    {

    }

    public bool ChecksWhereWrittenCorrectly()
    {
        return true;
    }
}