namespace CardInfo;

public class Card
{
    public string Pan { get; set; }
    public string Pin { get; set; }

    public string Cvc { get; set; }

    public string Expire_Date{get;set;}

    public decimal Balance { get; set; }
    public Card()
    {
        Pan = "";
        Pin = "";
        Cvc = "";
        Expire_Date = "";
        Balance = 0;
    }
    public Card(string pan, string pin, string cvc, string expire_Date, decimal balance)
    {
        Pan = pan;
        Pin = pin;
        Cvc = cvc;
        Expire_Date = expire_Date;
        Balance = balance;
    }

    public override string ToString()
    {
        return $"Card Details :\n" +
               $"PAN : {Pan}\n" +
               $"PIN : {Pin}\n" +
               $"CVC : {Cvc}\n" +
               $"Expire Date : {Expire_Date}\n" +
               $"Balance : {Balance} $";
    }
}
     











