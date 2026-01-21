using System;

// ---------------- CATEGORY BASE ----------------
abstract class Category
{
    public string CategoryName { get; protected set; }
}

// ---------------- CATEGORIES ----------------
class BookCategory : Category
{
    public BookCategory()
    {
        CategoryName = "Books";
    }
}

class ClothingCategory : Category
{
    public ClothingCategory()
    {
        CategoryName = "Clothing";
    }
}

// ---------------- GENERIC PRODUCT ----------------
class Product<T> where T : Category
{
    public string Name { get; private set; }
    public double Price { get; private set; }
    public T Category { get; private set; }

    public Product(string name, double price, T category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
    }

    public void Display()
    {
        Console.WriteLine(
            Name + " | " +
            Category.CategoryName + " | Price: " +
            Price
        );
    }
}

// ---------------- GENERIC METHOD ----------------
class DiscountUtility
{
    public void ApplyDiscount<TCategory>(
        Product<TCategory> product,
        double percentage)
        where TCategory : Category
    {
        double discount = product.Price * (percentage / 100);
        product.UpdatePrice(product.Price - discount);
    }
}

// ---------------- PROGRAM ----------------
class Program
{
    static void Main()
    {
        // create categories
        BookCategory bookCategory = new BookCategory();
        ClothingCategory clothingCategory = new ClothingCategory();

        // create products
        Product<BookCategory> book =
            new Product<BookCategory>("C# Programming", 500, bookCategory);

        Product<ClothingCategory> shirt =
            new Product<ClothingCategory>("T-Shirt", 800, clothingCategory);

        Console.WriteLine("Before Discount:");
        book.Display();
        shirt.Display();

        // apply discounts
        DiscountUtility utility = new DiscountUtility();
        utility.ApplyDiscount(book, 10);
        utility.ApplyDiscount(shirt, 20);

        Console.WriteLine("\nAfter Discount:");
        book.Display();
        shirt.Display();
    }
}
