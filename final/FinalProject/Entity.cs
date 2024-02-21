
public abstract class Entity
{
    protected Entity(string name)
    {
        Name = name;
    }

    public string Name { get; }

    // Virtual method for displaying details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Entity Name: {Name}");
    }
}
