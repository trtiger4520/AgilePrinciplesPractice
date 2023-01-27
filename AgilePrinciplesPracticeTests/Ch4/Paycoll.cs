namespace AgilePrinciplesPracticeTests.Ch4;

public class Paycoll
{
    private readonly IEmployeeDatabase _db;
    private readonly ICheckWriter _writer;

    public Paycoll(IEmployeeDatabase db, ICheckWriter w)
    {
        _db = db;
        _writer = w;
    }

    public void PayEmployees()
    {

    }
}