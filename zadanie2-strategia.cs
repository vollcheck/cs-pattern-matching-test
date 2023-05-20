using System;

public interface ICreditCard
{
  string GetCreditCard();
  void GiveBankDetails();
}

public class BankCustomer : ICreditCard
{
    private string _creditCardNumber;
    private BankDetails _bankDetails;

    public BankCustomer(string creditCardNumber, BankDetails bankDetails)
    {
        _creditCardNumber = creditCardNumber;
        _bankDetails = bankDetails;
    }

    public string GetCreditCard()
    {
        return _creditCardNumber;
    }

    public void GiveBankDetails()
    {
        Console.WriteLine($"Account Number: {_bankDetails.AccNumber}");
        Console.WriteLine($"Account Holder Name: {_bankDetails.AccHolderName}");
        Console.WriteLine($"Bank Name: {_bankDetails.BankName}");
    }
}

public class BankDetails
{
    private long _accNumber;
    private string _accHolderName;
    private string _bankName;

    public long AccNumber
    {
        get { return _accNumber; }
        set { _accNumber = value; }
    }

    public string AccHolderName
    {
        get { return _accHolderName; }
        set { _accHolderName = value; }
    }

    public string BankName
    {
        get { return _bankName; }
        set { _bankName = value; }
    }

    public BankDetails(long accNumber, string accHolderName, string bankName)
    {
        AccNumber = accNumber;
        AccHolderName = accHolderName;
        BankName = bankName;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var bankDetails = new BankDetails(123456789, "John Doe", "Awesome Bank");
        var customer = new BankCustomer("1234-5678-9012-3456", bankDetails);

        Console.WriteLine(customer.GetCreditCard());
        customer.GiveBankDetails();
    }
}
