namespace CardInfo;
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public Card Credit_Card { get; set; }
    public User(){ }
    public User(Guid id, string name, string surname, Card credit_Card)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Credit_Card = credit_Card;
    }

    public override string ToString()
    {
        return $"Name: {Name}\nSurname: {Surname}\nCard Number: {Credit_Card}";
    }
}
    







