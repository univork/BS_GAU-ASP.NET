CustomerBusinessLogic customerBL = new CustomerBusinessLogic(new CustomerDataAccess());
Console.WriteLine(customerBL.ProcessCustomerData(1));

CustomerBusinessLogic customerBLDifferent = new CustomerBusinessLogic(new DifferentCustomerDataAccess());
Console.WriteLine(customerBLDifferent.ProcessCustomerData(2));


public class CustomerBusinessLogic
{
    ICustomerDataAccess _dataAccess;

    public CustomerBusinessLogic(ICustomerDataAccess custDataAccess)
    {
        _dataAccess = custDataAccess;
    }

    public CustomerBusinessLogic()
    {
        _dataAccess = new CustomerDataAccess();
    }

    public string ProcessCustomerData(int id)
    {
        return _dataAccess.GetCustomerName(id);
    }
}


public interface ICustomerDataAccess
{
    string GetCustomerName(int id);
}


public class CustomerDataAccess: ICustomerDataAccess
{
    public CustomerDataAccess()
    {
    }

    public string GetCustomerName(int id) 
    {
        //get the customer name from the db in real application        
        return "Dummy Customer Name"; 
    }
}

public class DifferentCustomerDataAccess: ICustomerDataAccess
{
    public DifferentCustomerDataAccess()
    {
    }

    public string GetCustomerName(int id) 
    {
        //get the customer name from the db in real application        
        return "Customer from different data access"; 
    }
}
