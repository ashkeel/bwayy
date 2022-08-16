using Godot.Collections;

namespace bwayy.Scripts
{
    public enum DeviceType
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
        Mud
    }

    public static class DeviceExtensions
    {
        private static readonly Dictionary<DeviceType, string> DeviceNames = new Dictionary<DeviceType, string>
        {
            [DeviceType.Money] = "money",
            [DeviceType.Food] = "food",
            [DeviceType.Toys] = "toys",
            [DeviceType.Weapons] = "weapons",
            [DeviceType.Children] = "children",
            [DeviceType.Gold] = "gold",
            [DeviceType.Garbage] = "garbage",
            [DeviceType.Genitals] = "genitals",
            [DeviceType.Ego] = "Ego",
            [DeviceType.Love] = "love",
            [DeviceType.Blood] = "blood",
            [DeviceType.Kittens] = "kitten",
            [DeviceType.Books] = "books",
            [DeviceType.Paperwork] = "paperwork",
            [DeviceType.Guts] = "guts",
            [DeviceType.Mansion] = "mansion",
            [DeviceType.Alcohol] = "alcohol",
            [DeviceType.Technology] = "technology",
            [DeviceType.Feces] = "feces",
            [DeviceType.Pain] = "pain",
            [DeviceType.Army] = "army",
            [DeviceType.World] = "world",
            [DeviceType.Education] = "education",
            [DeviceType.Drugs] = "drugs",
            [DeviceType.Faith] = "faith",
            [DeviceType.Robots] = "robots",
            [DeviceType.Tumor] = "tumor",
            [DeviceType.Violin] = "violin",
            [DeviceType.Mud] = "mud"
        };
        
        public static string Name(this DeviceType device) => DeviceNames[device];
    }
}