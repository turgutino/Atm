namespace Program;
using CardInfo;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        DataBase db = new DataBase();
        db.Add_User();
        while (true)
        {
            Console.WriteLine("------------------------------------------------------Turgut bank------------------------------------------------------");
            string pin;
            Console.Write("4 reqemli Pin kodunu daxil edin : ");
            pin = Console.ReadLine();
            db.Login_System(pin);
        }
    }
}

    

        
        








        


