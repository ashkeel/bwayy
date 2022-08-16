using Godot.Collections;

namespace bwayy.Scripts
{
    public enum ItemType
    {
        // Available from the start
        Money,
        Food,
        Toys,
        Weapons,
        Children,
        Gold,
        Garbage,
        Genitals,
        Ego,
        Love,
        Blood,
        Kittens,
        Books,
        Paperwork,
        Guts,
        Mansion,
        Alcohol,
        Technology,
        Feces,
        Pain,
        Army,
        World,
        Education,
        Drugs,
        Faith,
        Robots,
        Tumor,
        Violin,
        // Only obtainable through diplomacy
        Mud,
    }

    public static class ItemExtensions
    {
        private static readonly Dictionary<ItemType, string> ItemNames = new Dictionary<ItemType, string>
        {
            [ItemType.Money] = "money",
            [ItemType.Food] = "food",
            [ItemType.Toys] = "toys",
            [ItemType.Weapons] = "weapons",
            [ItemType.Children] = "children",
            [ItemType.Gold] = "gold",
            [ItemType.Garbage] = "garbage",
            [ItemType.Genitals] = "genitals",
            [ItemType.Ego] = "Ego",
            [ItemType.Love] = "love",
            [ItemType.Blood] = "blood",
            [ItemType.Kittens] = "kitten",
            [ItemType.Books] = "books",
            [ItemType.Paperwork] = "paperwork",
            [ItemType.Guts] = "guts",
            [ItemType.Mansion] = "mansion",
            [ItemType.Alcohol] = "alcohol",
            [ItemType.Technology] = "technology",
            [ItemType.Feces] = "feces",
            [ItemType.Pain] = "pain",
            [ItemType.Army] = "army",
            [ItemType.World] = "world",
            [ItemType.Education] = "education",
            [ItemType.Drugs] = "drugs",
            [ItemType.Faith] = "faith",
            [ItemType.Robots] = "robots",
            [ItemType.Tumor] = "tumor",
            [ItemType.Violin] = "violin",
            [ItemType.Mud] = "mud"
        };
        
        public static string Name(this ItemType item) => ItemNames[item];
    }
}