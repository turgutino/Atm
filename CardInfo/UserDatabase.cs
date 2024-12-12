namespace CardInfo;

public class DataBase
{
    
    public List<User> Users { get; set; } = new List<User>();
    public List<string> Last { get; set; }=new List<string>();

    User user1 = new User(Guid.NewGuid(), "Elvin", "Memmedov", new Card("5212398475631023", "2027", "856", "07/29", 3225));
    User user2 = new User(Guid.NewGuid(), "Nigar", "Huseynova", new Card("1982376453107284", "2025", "472", "03/31", 5000));
    User user3 = new User(Guid.NewGuid(), "Tural", "Aliyev", new Card("7812643918475629", "2031", "993", "05/32", 150));
    User user4 = new User(Guid.NewGuid(), "Leyla", "Quliyeva", new Card("8903456728124701", "2028", "215", "01/30", 7500));
    User user5 = new User(Guid.NewGuid(), "Fidan", "Rzayeva", new Card("6758492031765378", "2026", "307", "12/28", 2100));


    public void Add_User()
    {
        Users.Add(user1);
        Users.Add(user2);
        Users.Add(user3);
        Users.Add(user4);
        Users.Add(user5);
    }

    public void Kocurme(User user)
    {
        decimal money;
        string pin2;

        try
        {
            Console.Write("\u001b[33m" + "Kocurme etme istediyiniz hesabin pin kodunu daxil edin: " + "\u001b[0m");
            pin2 = Console.ReadLine();

            bool userFound = false;
            foreach (var user2 in Users)
            {
                if (pin2 == user2.Credit_Card.Pin)
                {
                    userFound = true;
                    Console.Write("Kocurulecek meblegi daxil edin: ");
                    string input = Console.ReadLine();

                    try
                    {
                        money = Convert.ToDecimal(input);
                        if (money <= 0)
                        {
                            Console.WriteLine("\u001b[31m" + "Xeta: Daxil edilen mebleg sifir ve ya menfi ola bilmez." + "\u001b[0m");
                        }
                        else if (money > user.Credit_Card.Balance)
                        {
                            Console.WriteLine("\u001b[31m" + "Xeta: Daxil edilen mebleg hesabinizdaki balansdan boyukdur." + "\u001b[0m");
                        }
                        else
                        {
                            user2.Credit_Card.Balance += money;
                            user.Credit_Card.Balance -= money;
                            Console.WriteLine("\u001b[32m" + "Emeliyyat ugurla tamamlandi." + "\u001b[0m");
                            string operationDetail = $"{DateTime.Now}: {user.Name} {user.Surname} kocurme emeliyyati etdi. Mebleg: {money} $";
                            Last.Add(operationDetail);
                            string operationDetail2 = $"{DateTime.Now}: {user2.Name} {user2.Surname} kocurme emeliyyati aldi. Mebleg: {money} $";
                            Last.Add(operationDetail2);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\u001b[31m" + "Xeta: Meblegi duzgun formatda daxil etmediniz. Zehmet olmasa reqem daxil edin." + "\u001b[0m");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\u001b[31m" + "Xeta bas verdi: " + ex.Message + "\u001b[0m");
                    }
                    break;
                }
            }

            if (!userFound)
            {
                Console.WriteLine("\u001b[31m" + "Xeta: Hesabin PIN kodu tapilmadi." + "\u001b[0m");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\u001b[31m" + "Xeta bas verdi: " + ex.Message + "\u001b[0m");
        }
    }


    public void Nagdlasdirma(User user)
    {
        decimal money = 0;
        try
        {
            Console.Write("\u001b[33m" + "Nagdalasdirmaq istediyiniz meblegi daxil edin: " + "\u001b[0m");
            string input = Console.ReadLine();
            money = Convert.ToDecimal(input);

            if (money > user.Credit_Card.Balance)
            {
                Console.WriteLine("\u001b[31m" + "Xeta: Daxil edilen mebleg hesabinizdaki balansdan boyukdur." + "\u001b[0m");
            }
            else
            {
                user.Credit_Card.Balance -= money;
                Console.WriteLine("\u001b[32m" + "Emeliyyat ugurla tamamlandi." + "\u001b[0m");
                string operationDetail = $"{DateTime.Now}: {user.Name} {user.Surname} nagdlasdirma emeliyyati etdi. Mebleg: {money}";
                Last.Add(operationDetail);

            }
        }
        catch (FormatException)
        {
            Console.WriteLine("\u001b[31m" + "Xeta: Siz duzgun qaydada mebleg daxil etmediniz, zehmet olmasa duzgun daxil edin." + "\u001b[0m");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\u001b[31m" + "Xeta bas verdi: " + ex.Message + "\u001b[0m");
        }
    }

    public void History(User user)
    {
        bool historyFound = false;

        foreach (var last in Last)
        {
            if (last.Contains(user.Name))
            {
                Console.WriteLine(last);
                historyFound = true;
            }
        }

        if (!historyFound)
        {
            Console.WriteLine("\nEdilen emeliyyat yoxdur...\n");
        }
    }



    public void Operations(User user)
    {
        bool exit = false;  
        while (!exit)
        {
            Console.WriteLine("\nEmeliyyatlar : \n");
            Console.WriteLine("1 - > Nagdlasdirma");
            Console.WriteLine("2 - > Basqa sexsin hesabina kocurme");
            Console.WriteLine("3 - > Son edilen emeliyyatlar");
            Console.WriteLine("4 - > Hesabdan cixis\n");
            int select = 0;
            try
            {
                Console.Write("Emeliyyat nomresini secin: ");
                select = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Xeta : Siz duzgun qaydada secim daxil etmediniz, zehmet olmasa duzgun edin");
            }

            if (select == 1)
            {
                Nagdlasdirma(user);
            }
            else if (select == 2)
            {
                Kocurme(user);
            }
            else if (select == 3)
            {
                History(user);
            }
            else if (select == 4)
            {
                
                exit = true;  
                Console.Clear();
            }
        }
    }


    public void Check_User(string pin)
    {
        Console.Clear();
        try
        {
            foreach (var user in Users)
            {
                if (pin == user.Credit_Card.Pin)
                {
                    Console.WriteLine("User found: " + user.Name + " " + user.Surname);
                    Console.WriteLine("Card Number: " + user.Credit_Card.Pan);
                    Console.WriteLine("Balance: " + user.Credit_Card.Balance);
                    Operations(user);
                    return;
                }
            }

            Console.WriteLine("User not found!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    public void Login_System(string pin)
    {
        Check_User(pin); 
    }
}
        
       





