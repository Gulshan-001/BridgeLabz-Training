class Product
{
    public int ProductId { get; private set; }
    public string Name { get; private set; }
    public int Discount { get; private set; }

    public Product(int productId, string name, int discount)
    {
        ProductId = productId;
        Name = name;
        Discount = discount;
    }
}
