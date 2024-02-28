namespace WebApplication1.Models.Repositories;

public static class ShirtRepository
{
    private static List<Shirt> shirts = new List<Shirt>()
    {
        new Shirt { ShirtId = 1, Brand = "Brand1", Color = "Blue", Gender = "Male", Price = 80, Size = 10 },
        new Shirt { ShirtId = 2, Brand = "My Brand2", Color = "Yellow", Gender = "Male", Price = 100, Size = 11 },
        new Shirt { ShirtId = 3, Brand = "My Brand3", Color = "Red", Gender = "Male", Price = 70, Size = 9 },
        new Shirt { ShirtId = 4, Brand = "Brand4", Color = "Black", Gender = "Female", Price = 60, Size = 7 },
        new Shirt { ShirtId = 5, Brand = "Brand5", Color = "Blue", Gender = "Female", Price = 40, Size = 6 },
    };

    public static List<Shirt> GetShirts()
    {
        return shirts;
    }
    public static bool ShirtExists(int id)
    {
        return shirts.Any(x => x.ShirtId == id);
    }

    public static Shirt? GetShirtById(int id)
    {
        return shirts.FirstOrDefault(x => x.ShirtId == id);
    }
    
    public static Shirt? GetShirtByProperites(string?  brand, string? gender, string? color, int? size)
    {
        return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue && x.Size.HasValue && size.Value == x.Size.Value
        );
    }
    public static void AddShirts(Shirt shirt)
    {
        int newShirtId = shirts.Max(x => x.ShirtId) + 1;
        shirt.ShirtId = newShirtId;
        shirts.Add(shirt);
    }

    public static void UpdateShirt(Shirt shirt)
    {
        var shirtToUpdate = shirts.First(x => x.ShirtId == shirt.ShirtId);
        shirtToUpdate.Brand = shirt.Brand;
        shirtToUpdate.Color = shirt.Color;
        shirtToUpdate.Size = shirt.Size;
        shirtToUpdate.Price = shirt.Price;
    }

    public static void DeleteShirt(int shirtId)
    {
        var shirt = GetShirtById(shirtId);
        if (shirt != null)
        {
            shirts.Remove(shirt);
        }
    }
}