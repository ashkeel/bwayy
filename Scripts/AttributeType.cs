using System;
using System.Collections.Generic;

namespace bwayy.Scripts
{
    using SpellRelation = Dictionary<SpellType, float>;
    using ItemRelation = Dictionary<ItemType, float>;

    public enum AttributeType
    {
        Ancient,
        Childish,
        Deaf,
        Deviant,
        Evil,
        Gentle,
        Ghostly,
        Greedy,
        Industrial,
        Lustful,
        Noble,
        Nudist,
        Pestilent,
        Religious,
        Rich,
        Sadist,
        Scientific,
        Tribal,
        Unpredictable,
        Violent,
        Wise
    }

    [Flags]
    public enum AttributeModifiers: short
    {
        None = 0,
        CannotSay = 1,
        CannotTouch = 2,
        CannotGive = 4,
        RandomReactions = 8
    }

    public struct Attribute
    {
        public readonly string AttributeName;
        public readonly string Adjective;
        public readonly string NamePrefix, NameMiddle, NameSuffix;
        public readonly string CustomAction, CustomTarget, CustomBody;
        public readonly string KillingAction, KillingMean, KillingBody;
        public readonly AttributeModifiers Flags;
        public readonly SpellRelation SpellReaction;
        public readonly ItemRelation ItemReaction;

        public Attribute(string name, AttributeModifiers flags, string adjective, string namePrefix, string nameMiddle, string nameSuffix,
            string customAction, string customBody, string customTarget, string killingAction, string killingMean,
            string killingBody, SpellRelation spellReaction, ItemRelation itemReactions)
        {
            AttributeName = name;
            Flags = flags;
            Adjective = adjective;
            NamePrefix = namePrefix;
            NameMiddle = nameMiddle;
            NameSuffix = nameSuffix;
            CustomAction = customAction;
            CustomBody = customBody;
            CustomTarget = customTarget;
            KillingAction = killingAction;
            KillingBody = killingBody;
            KillingMean = killingMean;
            SpellReaction = spellReaction;
            ItemReaction = itemReactions;
        }
    }

    public readonly struct AttributeSet
    {
        public readonly Attribute First, Second, Third;

        public AttributeSet(Attribute first, Attribute second, Attribute third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public AttributeSet(AttributeType first, AttributeType second, AttributeType third)
        {
            First = first.Attr();
            Second = second.Attr();
            Third = third.Attr();
        }

        public string Name => $"{First.NamePrefix}{Second.NameMiddle}{Third.NameSuffix}";

        public string Custom =>
            $"As it is their customary and diplomatic salute, {Name} {First.CustomAction} your {Second.CustomTarget} with their {Third.CustomBody}.";

        public string Kill =>
            $"{Name} {First.KillingAction} {Second.KillingMean} in your {Third.KillingBody}, killing you.";
    }

    public static class AttributeExtensions
    {
        private static readonly Dictionary<AttributeType, Attribute> AttributeInfos =
            new Dictionary<AttributeType, Attribute>
            {
                [AttributeType.Ancient] = new Attribute(
                    "ancient",
                    AttributeModifiers.None,
                    "rough",
                    "Cloc",
                    "elan",
                    "fil",
                    "knocks on",
                    "children",
                    "mandibles",
                    "hides",
                    "maggots",
                    "throat",
                    new SpellRelation {[SpellType.Say] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Gold] = 2,
                        [ItemType.Love] = 2,
                        [ItemType.Children] = 1,
                        [ItemType.Faith] = 1,
                        [ItemType.Alcohol] = 1,
                        [ItemType.Books] = 1,
                        [ItemType.Violin] = 2,
                        // Negative
                        [ItemType.Education] = -2,
                        [ItemType.Blood] = -2,
                        [ItemType.Genitals] = -1,
                        [ItemType.Alcohol] = -1,
                        [ItemType.Mansion] = -1,
                        [ItemType.Technology] = -1,
                        [ItemType.Robots] = -2
                    }
                ),
                [AttributeType.Childish] = new Attribute(
                    "childish",
                    AttributeModifiers.None,
                    "stumpy",
                    "Bian",
                    "ub",
                    "eflo",
                    "pokes",
                    "skull",
                    "claw",
                    "feeds",
                    "poison",
                    "eyelids",
                    new SpellRelation {[SpellType.Give] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Food] = 2,
                        [ItemType.Toys] = 2,
                        [ItemType.Children] = 3,
                        [ItemType.Love] = 1,
                        // Negative
                        [ItemType.Money] = -1,
                        [ItemType.Blood] = -1,
                        [ItemType.Alcohol] = -2,
                        [ItemType.Pain] = -2,
                        [ItemType.Education] = -1,
                        [ItemType.Books] = -1
                    }
                ),
                [AttributeType.Deaf] = new Attribute(
                    "deaf",
                    AttributeModifiers.CannotSay,
                    "uneasy",
                    "Lat",
                    "omel",
                    "tre",
                    "pats",
                    "face",
                    "cane",
                    "kicks",
                    "paint",
                    "face",
                    new SpellRelation(),
                    new ItemRelation()
                ),
                [AttributeType.Deviant] = new Attribute(
                    "deviant",
                    AttributeModifiers.None,
                    "disgusting",
                    "Eln",
                    "iobl",
                    "esse",
                    "slaps",
                    "genitals",
                    "hand",
                    "lays",
                    "eggs",
                    "skull",
                    new SpellRelation {[SpellType.Touch] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Toys] = 1,
                        [ItemType.Guts] = 1,
                        [ItemType.Alcohol] = 1,
                        [ItemType.Feces] = 1,
                        [ItemType.Food] = 1,
                        [ItemType.Pain] = 1,
                        [ItemType.Drugs] = 1,
                        [ItemType.Violin] = 1,
                        // Negative
                        [ItemType.Money] = -1,
                        [ItemType.Mansion] = -1,
                        [ItemType.Paperwork] = -1,
                        [ItemType.Education] = -1,
                        [ItemType.Faith] = -1,
                        [ItemType.Weapons] = -1,
                        [ItemType.Gold] = -1,
                        [ItemType.Army] = -2
                    }
                ),
                [AttributeType.Evil] = new Attribute(
                    "evil",
                    AttributeModifiers.None,
                    "spiky",
                    "Khav",
                    "iol",
                    "olat",
                    "stabs",
                    "arms",
                    "nails",
                    "pushes",
                    "brambles",
                    "ears",
                    new SpellRelation {[SpellType.Say] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Money] = 1,
                        [ItemType.Weapons] = 1,
                        [ItemType.Blood] = 1,
                        [ItemType.Paperwork] = 1,
                        [ItemType.Army] = 1,
                        [ItemType.Mansion] = 1,
                        [ItemType.Ego] = 1,
                        [ItemType.Kittens] = 1,
                        [ItemType.Faith] = 1,
                        [ItemType.Tumor] = 1,
                        [ItemType.Violin] = 1,
                        [ItemType.Robots] = 2,
                        // Negative
                        [ItemType.Toys] = -2,
                        [ItemType.Children] = -3,
                        [ItemType.Genitals] = -1,
                        [ItemType.Food] = -2,
                        [ItemType.Love] = -2
                    }
                ),
                [AttributeType.Gentle] = new Attribute(
                    "gentle",
                    AttributeModifiers.None,
                    "soft",
                    "Faun",
                    "iol",
                    "ven",
                    "mames",
                    "ass",
                    "tentacles",
                    "feeds",
                    "puss",
                    "tongue",
                    new SpellRelation {[SpellType.Say] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Food] = 1,
                        [ItemType.Toys] = 1,
                        [ItemType.Children] = 1,
                        [ItemType.Genitals] = 1,
                        [ItemType.Education] = 1,
                        [ItemType.Love] = 1,
                        [ItemType.Faith] = 1,
                        [ItemType.Books] = 1,
                        [ItemType.Guts] = 1,
                        [ItemType.World] = 1,
                        // Negative
                        [ItemType.Pain] = -2,
                        [ItemType.Money] = -2,
                        [ItemType.Gold] = -2,
                        [ItemType.Army] = -2,
                        [ItemType.Alcohol] = -1,
                        [ItemType.Weapons] = -1,
                        [ItemType.Feces] = -1,
                        [ItemType.Tumor] = -2,
                        [ItemType.Robots] = -1,
                        [ItemType.Violin] = -1
                    }
                ),
                [AttributeType.Ghostly] = new Attribute(
                    "ghostly",
                    AttributeModifiers.CannotTouch,
                    "intangible",
                    "Cas",
                    "egal",
                    "ne",
                    "blows on",
                    "psyche",
                    "shadow",
                    "summons",
                    "fireflies",
                    "mind",
                    new SpellRelation(),
                    new ItemRelation()
                ),
                [AttributeType.Greedy] = new Attribute(
                    "greedy",
                    AttributeModifiers.None,
                    "rusty",
                    "Arc",
                    "onim",
                    "eq",
                    "scratches",
                    "back",
                    "cane",
                    "pours",
                    "puke",
                    "heart",
                    new SpellRelation {[SpellType.Give] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Money] = 1,
                        [ItemType.Food] = 1,
                        [ItemType.Children] = 1,
                        [ItemType.Mansion] = 1,
                        [ItemType.World] = 2,
                        [ItemType.Ego] = 1,
                        [ItemType.Robots] = 1,
                        // Negative
                        [ItemType.Love] = -1,
                        [ItemType.Blood] = -1,
                        [ItemType.Paperwork] = -1,
                        [ItemType.Garbage] = -1,
                        [ItemType.Genitals] = -1,
                        [ItemType.Mud] = -1,
                        [ItemType.Feces] = -1,
                        [ItemType.Faith] = -1,
                    }
                ),
                [AttributeType.Industrial] = new Attribute(
                    "industrial",
                    AttributeModifiers.None,
                    "metal",
                    "Bol",
                    "one",
                    "mel",
                    "pulls at",
                    "arms",
                    "arms",
                    "hammers",
                    "nails",
                    "chest",
                    new SpellRelation {[SpellType.Give] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Money] = 1,
                        [ItemType.Gold] = 1,
                        [ItemType.Weapons] = 1,
                        [ItemType.Army] = 1,
                        [ItemType.Garbage] = 1,
                        [ItemType.Alcohol] = 1,
                        [ItemType.Drugs] = 1,
                        [ItemType.Technology] = 1,
                        [ItemType.Education] = 1,
                        [ItemType.Robots] = 1,
                        // Negative
                        [ItemType.Love] = -5,
                        [ItemType.Toys] = -2,
                        [ItemType.Paperwork] = -2
                    }
                ),
                [AttributeType.Lustful] = new Attribute(
                    "lustful",
                    AttributeModifiers.None,
                    "wet",
                    "Ishm",
                    "anev",
                    "iel",
                    "rubs",
                    "feet",
                    "index",
                    "injects",
                    "acid",
                    "veins",
                    new SpellRelation {[SpellType.Touch] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Food] = 1,
                        [ItemType.Children] = 1,
                        [ItemType.Genitals] = 1,
                        [ItemType.Love] = 1,
                        [ItemType.Alcohol] = 1,
                        [ItemType.Kittens] = 1,
                        [ItemType.Toys] = 1,
                        [ItemType.Blood] = 1,
                        [ItemType.Drugs] = 1,
                        [ItemType.Guts] = 1,
                        // Negative
                        [ItemType.Garbage] = -3,
                        [ItemType.Ego] = -2,
                        [ItemType.Faith] = -3,
                        [ItemType.Paperwork] = -2
                    }
                ),
                [AttributeType.Noble] = new Attribute(
                    "noble",
                    AttributeModifiers.None,
                    "velvet-like",
                    "Flun",
                    "avel",
                    "bit",
                    "dusts",
                    "shoulder",
                    "crown",
                    "draws",
                    "gold",
                    "brain",
                    new SpellRelation {[SpellType.Say] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Money] = 1,
                        [ItemType.Food] = 1,
                        [ItemType.Weapons] = 1,
                        [ItemType.Children] = 1,
                        [ItemType.Paperwork] = 1,
                        [ItemType.Mansion] = 1,
                        [ItemType.Ego] = 1,
                        [ItemType.Gold] = 1,
                        [ItemType.Education] = 1,
                        [ItemType.Faith] = 1,
                        [ItemType.Alcohol] = 1,
                        // Negative
                        [ItemType.Blood] = -3,
                        [ItemType.Toys] = -3,
                        [ItemType.Garbage] = -2,
                        [ItemType.Pain] = -2,
                        [ItemType.Guts] = -1,
                        [ItemType.Tumor] = -1
                    }
                ),
                [AttributeType.Nudist] = new Attribute(
                    "nudist",
                    AttributeModifiers.None,
                    "rubbery",
                    "Weh",
                    "yah",
                    "ha",
                    "rubs on",
                    "groin",
                    "tentacles",
                    "pours",
                    "lube",
                    "ass",
                    new SpellRelation {[SpellType.Touch] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Food] = 1,
                        [ItemType.Children] = 1,
                        [ItemType.Genitals] = 1,
                        [ItemType.Love] = 1,
                        [ItemType.Alcohol] = 1,
                        [ItemType.Toys] = 1,
                        [ItemType.Drugs] = 1,
                        [ItemType.Garbage] = 1,
                        [ItemType.Faith] = 1,
                        [ItemType.World] = 1,
                        // Negative
                        [ItemType.Garbage] = -2,
                        [ItemType.Paperwork] = -2,
                        [ItemType.Education] = -2,
                        [ItemType.Technology] = -2,
                        [ItemType.Weapons] = -2,
                        [ItemType.Tumor] = -1
                    }
                ),
                [AttributeType.Pestilent] = new Attribute(
                    "pestilent",
                    AttributeModifiers.None,
                    "stinky",
                    "Erq",
                    "ash",
                    "mol",
                    "rubs",
                    "throat",
                    "fat",
                    "vomits",
                    "flies",
                    "legs",
                    new SpellRelation {[SpellType.Touch] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Guts] = 1,
                        [ItemType.Blood] = 1,
                        [ItemType.Feces] = 2,
                        [ItemType.Kittens] = 1,
                        [ItemType.Gold] = 1,
                        [ItemType.Garbage] = 1,
                        [ItemType.Tumor] = 2,
                        // Negative
                        [ItemType.Education] = -1,
                        [ItemType.Mansion] = -1,
                        [ItemType.Money] = -1,
                        [ItemType.Love] = -3,
                        [ItemType.Paperwork] = -1,
                        [ItemType.Faith] = -1,
                        [ItemType.Robots] = -1,
                        [ItemType.Violin] = -1
                    }
                ),
                [AttributeType.Religious] = new Attribute(
                    "religious",
                    AttributeModifiers.None,
                    "golden",
                    "Arch",
                    "orell",
                    "stef",
                    "gropes",
                    "forehead",
                    "teeth",
                    "shoots",
                    "snakes",
                    "head",
                    new SpellRelation {[SpellType.Touch] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Money] = 1,
                        [ItemType.Faith] = 2,
                        [ItemType.Weapons] = 1,
                        [ItemType.Children] = 1,
                        [ItemType.Blood] = 1,
                        [ItemType.Books] = 1,
                        [ItemType.Gold] = 1,
                        [ItemType.Violin] = 2,
                        // Negative
                        [ItemType.Love] = -2,
                        [ItemType.Alcohol] = -2,
                        [ItemType.Feces] = -1,
                        [ItemType.Kittens] = -1,
                        [ItemType.Ego] = -1,
                        [ItemType.Technology] = -1,
                        [ItemType.Robots] = -2
                    }
                ),
                [AttributeType.Rich] = new Attribute(
                    "rich",
                    AttributeModifiers.None,
                    "sacred",
                    "Den",
                    "aml",
                    "ivec",
                    "pats",
                    "head",
                    "hand",
                    "fires",
                    "rocks",
                    "hands",
                    new SpellRelation {[SpellType.Say] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Money] = 1,
                        [ItemType.Food] = 1,
                        [ItemType.Weapons] = 1,
                        [ItemType.Blood] = 1,
                        [ItemType.Paperwork] = 1,
                        [ItemType.Mansion] = 1,
                        [ItemType.Ego] = 1,
                        [ItemType.Gold] = 1,
                        [ItemType.Drugs] = 1,
                        [ItemType.Violin] = 1,
                        // Negative
                        [ItemType.Children] = -2,
                        [ItemType.Toys] = -2,
                        [ItemType.Garbage] = -2,
                        [ItemType.Pain] = -2,
                        [ItemType.Faith] = -1,
                        [ItemType.Tumor] = -2
                    }
                ),
                [AttributeType.Sadist] = new Attribute(
                    "sadist",
                    AttributeModifiers.None,
                    "bloody",
                    "Il",
                    "ol",
                    "lem",
                    "cuts",
                    "neck",
                    "toenails",
                    "inflates",
                    "needles",
                    "skin",
                    new SpellRelation {[SpellType.Touch] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Blood] = 2,
                        [ItemType.Weapons] = 2,
                        [ItemType.Guts] = 1,
                        [ItemType.Toys] = 1,
                        [ItemType.Drugs] = 1,
                        [ItemType.Pain] = 1,
                        [ItemType.Tumor] = 1,
                        [ItemType.Violin] = 2,
                        // Negative
                        [ItemType.Kittens] = -2,
                        [ItemType.Children] = -2,
                        [ItemType.Money] = -2,
                        [ItemType.Education] = -2
                    }
                ),
                [AttributeType.Scientific] = new Attribute(
                    "scientific",
                    AttributeModifiers.None,
                    "misinformed",
                    "Selm",
                    "anis",
                    "grev",
                    "studies",
                    "suprasternal notch",
                    "chin",
                    "sews",
                    "spores",
                    "lungs",
                    new SpellRelation {[SpellType.Say] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Kittens] = 1,
                        [ItemType.Money] = 1,
                        [ItemType.Paperwork] = 1,
                        [ItemType.Alcohol] = 1,
                        [ItemType.Technology] = 1,
                        [ItemType.Books] = 1,
                        [ItemType.Guts] = 1,
                        [ItemType.Education] = 1,
                        [ItemType.World] = 1,
                        [ItemType.Tumor] = 1,
                        [ItemType.Robots] = 1,
                        [ItemType.Violin] = 1,
                        // Negative
                        [ItemType.Children] = -2,
                        [ItemType.Food] = -2,
                        [ItemType.Love] = -2,
                        [ItemType.Faith] = -1,
                        [ItemType.Alcohol] = -2
                    }
                ),
                [AttributeType.Tribal] = new Attribute(
                    "tribal",
                    AttributeModifiers.None,
                    "hairy",
                    "Bras",
                    "arg",
                    "ulb",
                    "bashes",
                    "mother",
                    "tail",
                    "cooks",
                    "tar",
                    "entrails",
                    new SpellRelation {[SpellType.Give] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Food] = 1,
                        [ItemType.Weapons] = 2,
                        [ItemType.Gold] = 1,
                        [ItemType.Alcohol] = 1,
                        [ItemType.Army] = 1,
                        [ItemType.Faith] = 1,
                        [ItemType.World] = 1,
                        // Negative
                        [ItemType.Money] = -2,
                        [ItemType.Paperwork] = -2,
                        [ItemType.Mansion] = -2,
                        [ItemType.Education] = -1,
                        [ItemType.Technology] = -1,
                        [ItemType.Books] = -1,
                        [ItemType.Robots] = -3,
                        [ItemType.Violin] = -1,
                    }
                ),
                [AttributeType.Unpredictable] = new Attribute(
                    "unpredictable",
                    AttributeModifiers.RandomReactions,
                    "absurd",
                    "What",
                    "the",
                    "fuck",
                    "touches",
                    "friends",
                    "pineapple",
                    "invokes",
                    "mushrooms",
                    "eyes",
                    new SpellRelation {[SpellType.Leave] = 1},
                    null
                ),
                [AttributeType.Violent] = new Attribute(
                    "violent",
                    AttributeModifiers.None,
                    "bloody",
                    "Kash",
                    "iat",
                    "det",
                    "mangles",
                    "shoulders",
                    "elbow",
                    "installs",
                    "bolts",
                    "spine",
                    new SpellRelation {[SpellType.Touch] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Kittens] = 2,
                        [ItemType.Money] = 2,
                        [ItemType.Gold] = 2,
                        [ItemType.Love] = 1,
                        [ItemType.Genitals] = 1,
                        [ItemType.Alcohol] = 1,
                        [ItemType.Robots] = 2,
                        [ItemType.Violin] = 2,
                        // Negative
                        [ItemType.Gold] = -2,
                        [ItemType.Toys] = -2,
                        [ItemType.Education] = -2,
                        [ItemType.Pain] = -2,
                        [ItemType.Tumor] = -2
                    }
                ),
                [AttributeType.Wise] = new Attribute(
                    "wise",
                    AttributeModifiers.None,
                    "scaly",
                    "Erl",
                    "ionel",
                    "dente",
                    "draws on",
                    "telescope",
                    "horns",
                    "plants",
                    "vines",
                    "scalp",
                    new SpellRelation {[SpellType.Give] = 1},
                    new ItemRelation
                    {
                        // Positive
                        [ItemType.Education] = 2,
                        [ItemType.Love] = 2,
                        [ItemType.Money] = 2,
                        [ItemType.Food] = 1,
                        [ItemType.Technology] = 1,
                        [ItemType.Robots] = 1,
                        [ItemType.Violin] = 1,
                        // Negative
                        [ItemType.Pain] = -2,
                        [ItemType.Blood] = -2,
                        [ItemType.Genitals] = -2,
                        [ItemType.Alcohol] = -1,
                        [ItemType.Faith] = -1,
                        [ItemType.Tumor] = -1
                    }
                )
            };


        public static Attribute Attr(this AttributeType attr) => AttributeInfos[attr];
        public static string Name(this AttributeType attr) => attr.Attr().AttributeName;
        public static string Adjective(this AttributeType attr) => attr.Attr().Adjective;
    }
}