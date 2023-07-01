public enum Flavors { Liquid, Powder, Spice, Herb,  }
public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Flavors[] FlavorProfile { get; set; }
    public bool HasAnimalProducts { get; set; } = false;
    public bool HasMeat { get; set; } = false;
    public bool HasGluten { get; set; } = false;
    public bool HasEgg { get; set; } = false;
    public bool HasTreeNuts { get; set; } = false;
    public bool HasShellfish { get; set; } = false;
    public bool HasPeanuts { get; set; } = false;
    public bool HasSoy { get; set; } = false;
    public bool HasFish { get; set; } = false;
    public bool HasDairy { get; set; } = false;

    public bool IsPescetarian => !HasMeat;
    public bool IsVegetarian => IsPescetarian && !HasFish;
    public bool IsVegan => IsVegetarian && !HasEgg && !HasAnimalProducts && !HasDairy;
    public bool IsDairyFree => !HasDairy;
    public bool IsGlutenFree => !HasGluten;
}