using System;

// ---------- INTERFACE ----------
interface IMealPlan
{
    string GetMealDetails();
}

// ---------- MEAL TYPES ----------
class VegetarianMeal : IMealPlan
{
    public string GetMealDetails()
    {
        return "Vegetarian Meal: Rice, Dal, Vegetables";
    }
}

class VeganMeal : IMealPlan
{
    public string GetMealDetails()
    {
        return "Vegan Meal: Quinoa, Beans, Salad";
    }
}

class KetoMeal : IMealPlan
{
    public string GetMealDetails()
    {
        return "Keto Meal: Eggs, Avocado, Cheese";
    }
}

class HighProteinMeal : IMealPlan
{
    public string GetMealDetails()
    {
        return "High Protein Meal: Chicken, Eggs, Nuts";
    }
}

// ---------- GENERIC MEAL CLASS ----------
class Meal<T> where T : IMealPlan
{
    private T mealType;

    public Meal(T mealType)
    {
        this.mealType = mealType;
    }

    public void ShowMeal()
    {
        Console.WriteLine(mealType.GetMealDetails());
    }
}

// ---------- GENERIC METHOD UTILITY ----------
class MealPlanGenerator
{
    public void GenerateMealPlan<T>(T meal) where T : IMealPlan
    {
        Console.WriteLine("Generating meal plan...");
        Console.WriteLine(meal.GetMealDetails());
    }
}

// ---------- PROGRAM ----------
class Program
{
    static void Main()
    {
        // user chooses meal types
        VegetarianMeal veg = new VegetarianMeal();
        VeganMeal vegan = new VeganMeal();
        KetoMeal keto = new KetoMeal();
        HighProteinMeal protein = new HighProteinMeal();

        // using generic class
        Meal<VegetarianMeal> vegMeal = new Meal<VegetarianMeal>(veg);
        Meal<VeganMeal> veganMeal = new Meal<VeganMeal>(vegan);

        Console.WriteLine("Meal using Generic Class:");
        vegMeal.ShowMeal();
        veganMeal.ShowMeal();

        // using generic method
        MealPlanGenerator generator = new MealPlanGenerator();

        Console.WriteLine("\nMeal using Generic Method:");
        generator.GenerateMealPlan(keto);
        generator.GenerateMealPlan(protein);
    }
}
