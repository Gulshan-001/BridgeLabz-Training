abstract class WarehouseItem
{
    public string Name { get; set; }

    public WarehouseItem(string name)
    {
        Name = name;
    }

    public abstract void Display();
}
