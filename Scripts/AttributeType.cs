using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace bwayy.Scripts
{
    using SpellRelation = Dictionary<SpellType, float>;
    using DeviceRelation = Dictionary<DeviceType, float>;

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
        public readonly DeviceRelation DeviceReaction;

        public Attribute(string name, AttributeModifiers flags, string adjective, string namePrefix, string nameMiddle, string nameSuffix,
            string customAction, string customBody, string customTarget, string killingAction, string killingMean,
            string killingBody, SpellRelation spellReaction, DeviceRelation deviceReactions)
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
            DeviceReaction = deviceReactions;
        }

        [Pure]
        public float MultiplierForSpell(SpellType spell)
        {
            if (SpellReaction.TryGetValue(spell, out var multiplier))
            {
                return multiplier;
            }
            return 0;
        }

        [Pure]
        public float ReactionForDevice(DeviceType device)
        {
            if (DeviceReaction.TryGetValue(device, out var reaction))
            {
                return reaction;
            }

            return 0;
        }
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Gold] = 2,
                        [DeviceType.Love] = 2,
                        [DeviceType.Children] = 1,
                        [DeviceType.Faith] = 1,
                        [DeviceType.Alcohol] = 1,
                        [DeviceType.Books] = 1,
                        [DeviceType.Violin] = 2,
                        // Negative
                        [DeviceType.Education] = -2,
                        [DeviceType.Blood] = -2,
                        [DeviceType.Genitals] = -1,
                        [DeviceType.Alcohol] = -1,
                        [DeviceType.Mansion] = -1,
                        [DeviceType.Technology] = -1,
                        [DeviceType.Robots] = -2
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Food] = 2,
                        [DeviceType.Toys] = 2,
                        [DeviceType.Children] = 3,
                        [DeviceType.Love] = 1,
                        // Negative
                        [DeviceType.Money] = -1,
                        [DeviceType.Blood] = -1,
                        [DeviceType.Alcohol] = -2,
                        [DeviceType.Pain] = -2,
                        [DeviceType.Education] = -1,
                        [DeviceType.Books] = -1
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
                    new DeviceRelation()
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Toys] = 1,
                        [DeviceType.Guts] = 1,
                        [DeviceType.Alcohol] = 1,
                        [DeviceType.Feces] = 1,
                        [DeviceType.Food] = 1,
                        [DeviceType.Pain] = 1,
                        [DeviceType.Drugs] = 1,
                        [DeviceType.Violin] = 1,
                        // Negative
                        [DeviceType.Money] = -1,
                        [DeviceType.Mansion] = -1,
                        [DeviceType.Paperwork] = -1,
                        [DeviceType.Education] = -1,
                        [DeviceType.Faith] = -1,
                        [DeviceType.Weapons] = -1,
                        [DeviceType.Gold] = -1,
                        [DeviceType.Army] = -2
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Money] = 1,
                        [DeviceType.Weapons] = 1,
                        [DeviceType.Blood] = 1,
                        [DeviceType.Paperwork] = 1,
                        [DeviceType.Army] = 1,
                        [DeviceType.Mansion] = 1,
                        [DeviceType.Ego] = 1,
                        [DeviceType.Kittens] = 1,
                        [DeviceType.Faith] = 1,
                        [DeviceType.Tumor] = 1,
                        [DeviceType.Violin] = 1,
                        [DeviceType.Robots] = 2,
                        // Negative
                        [DeviceType.Toys] = -2,
                        [DeviceType.Children] = -3,
                        [DeviceType.Genitals] = -1,
                        [DeviceType.Food] = -2,
                        [DeviceType.Love] = -2
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Food] = 1,
                        [DeviceType.Toys] = 1,
                        [DeviceType.Children] = 1,
                        [DeviceType.Genitals] = 1,
                        [DeviceType.Education] = 1,
                        [DeviceType.Love] = 1,
                        [DeviceType.Faith] = 1,
                        [DeviceType.Books] = 1,
                        [DeviceType.Guts] = 1,
                        [DeviceType.World] = 1,
                        // Negative
                        [DeviceType.Pain] = -2,
                        [DeviceType.Money] = -2,
                        [DeviceType.Gold] = -2,
                        [DeviceType.Army] = -2,
                        [DeviceType.Alcohol] = -1,
                        [DeviceType.Weapons] = -1,
                        [DeviceType.Feces] = -1,
                        [DeviceType.Tumor] = -2,
                        [DeviceType.Robots] = -1,
                        [DeviceType.Violin] = -1
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
                    new DeviceRelation()
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Money] = 1,
                        [DeviceType.Food] = 1,
                        [DeviceType.Children] = 1,
                        [DeviceType.Mansion] = 1,
                        [DeviceType.World] = 2,
                        [DeviceType.Ego] = 1,
                        [DeviceType.Robots] = 1,
                        // Negative
                        [DeviceType.Love] = -1,
                        [DeviceType.Blood] = -1,
                        [DeviceType.Paperwork] = -1,
                        [DeviceType.Garbage] = -1,
                        [DeviceType.Genitals] = -1,
                        [DeviceType.Mud] = -1,
                        [DeviceType.Feces] = -1,
                        [DeviceType.Faith] = -1,
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Money] = 1,
                        [DeviceType.Gold] = 1,
                        [DeviceType.Weapons] = 1,
                        [DeviceType.Army] = 1,
                        [DeviceType.Garbage] = 1,
                        [DeviceType.Alcohol] = 1,
                        [DeviceType.Drugs] = 1,
                        [DeviceType.Technology] = 1,
                        [DeviceType.Education] = 1,
                        [DeviceType.Robots] = 1,
                        // Negative
                        [DeviceType.Love] = -5,
                        [DeviceType.Toys] = -2,
                        [DeviceType.Paperwork] = -2
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Food] = 1,
                        [DeviceType.Children] = 1,
                        [DeviceType.Genitals] = 1,
                        [DeviceType.Love] = 1,
                        [DeviceType.Alcohol] = 1,
                        [DeviceType.Kittens] = 1,
                        [DeviceType.Toys] = 1,
                        [DeviceType.Blood] = 1,
                        [DeviceType.Drugs] = 1,
                        [DeviceType.Guts] = 1,
                        // Negative
                        [DeviceType.Garbage] = -3,
                        [DeviceType.Ego] = -2,
                        [DeviceType.Faith] = -3,
                        [DeviceType.Paperwork] = -2
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Money] = 1,
                        [DeviceType.Food] = 1,
                        [DeviceType.Weapons] = 1,
                        [DeviceType.Children] = 1,
                        [DeviceType.Paperwork] = 1,
                        [DeviceType.Mansion] = 1,
                        [DeviceType.Ego] = 1,
                        [DeviceType.Gold] = 1,
                        [DeviceType.Education] = 1,
                        [DeviceType.Faith] = 1,
                        [DeviceType.Alcohol] = 1,
                        // Negative
                        [DeviceType.Blood] = -3,
                        [DeviceType.Toys] = -3,
                        [DeviceType.Garbage] = -2,
                        [DeviceType.Pain] = -2,
                        [DeviceType.Guts] = -1,
                        [DeviceType.Tumor] = -1
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Food] = 1,
                        [DeviceType.Children] = 1,
                        [DeviceType.Genitals] = 1,
                        [DeviceType.Love] = 1,
                        [DeviceType.Alcohol] = 1,
                        [DeviceType.Toys] = 1,
                        [DeviceType.Drugs] = 1,
                        [DeviceType.Garbage] = 1,
                        [DeviceType.Faith] = 1,
                        [DeviceType.World] = 1,
                        // Negative
                        [DeviceType.Garbage] = -2,
                        [DeviceType.Paperwork] = -2,
                        [DeviceType.Education] = -2,
                        [DeviceType.Technology] = -2,
                        [DeviceType.Weapons] = -2,
                        [DeviceType.Tumor] = -1
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Guts] = 1,
                        [DeviceType.Blood] = 1,
                        [DeviceType.Feces] = 2,
                        [DeviceType.Kittens] = 1,
                        [DeviceType.Gold] = 1,
                        [DeviceType.Garbage] = 1,
                        [DeviceType.Tumor] = 2,
                        // Negative
                        [DeviceType.Education] = -1,
                        [DeviceType.Mansion] = -1,
                        [DeviceType.Money] = -1,
                        [DeviceType.Love] = -3,
                        [DeviceType.Paperwork] = -1,
                        [DeviceType.Faith] = -1,
                        [DeviceType.Robots] = -1,
                        [DeviceType.Violin] = -1
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Money] = 1,
                        [DeviceType.Faith] = 2,
                        [DeviceType.Weapons] = 1,
                        [DeviceType.Children] = 1,
                        [DeviceType.Blood] = 1,
                        [DeviceType.Books] = 1,
                        [DeviceType.Gold] = 1,
                        [DeviceType.Violin] = 2,
                        // Negative
                        [DeviceType.Love] = -2,
                        [DeviceType.Alcohol] = -2,
                        [DeviceType.Feces] = -1,
                        [DeviceType.Kittens] = -1,
                        [DeviceType.Ego] = -1,
                        [DeviceType.Technology] = -1,
                        [DeviceType.Robots] = -2
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Money] = 1,
                        [DeviceType.Food] = 1,
                        [DeviceType.Weapons] = 1,
                        [DeviceType.Blood] = 1,
                        [DeviceType.Paperwork] = 1,
                        [DeviceType.Mansion] = 1,
                        [DeviceType.Ego] = 1,
                        [DeviceType.Gold] = 1,
                        [DeviceType.Drugs] = 1,
                        [DeviceType.Violin] = 1,
                        // Negative
                        [DeviceType.Children] = -2,
                        [DeviceType.Toys] = -2,
                        [DeviceType.Garbage] = -2,
                        [DeviceType.Pain] = -2,
                        [DeviceType.Faith] = -1,
                        [DeviceType.Tumor] = -2
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Blood] = 2,
                        [DeviceType.Weapons] = 2,
                        [DeviceType.Guts] = 1,
                        [DeviceType.Toys] = 1,
                        [DeviceType.Drugs] = 1,
                        [DeviceType.Pain] = 1,
                        [DeviceType.Tumor] = 1,
                        [DeviceType.Violin] = 2,
                        // Negative
                        [DeviceType.Kittens] = -2,
                        [DeviceType.Children] = -2,
                        [DeviceType.Money] = -2,
                        [DeviceType.Education] = -2
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Kittens] = 1,
                        [DeviceType.Money] = 1,
                        [DeviceType.Paperwork] = 1,
                        [DeviceType.Alcohol] = 1,
                        [DeviceType.Technology] = 1,
                        [DeviceType.Books] = 1,
                        [DeviceType.Guts] = 1,
                        [DeviceType.Education] = 1,
                        [DeviceType.World] = 1,
                        [DeviceType.Tumor] = 1,
                        [DeviceType.Robots] = 1,
                        [DeviceType.Violin] = 1,
                        // Negative
                        [DeviceType.Children] = -2,
                        [DeviceType.Food] = -2,
                        [DeviceType.Love] = -2,
                        [DeviceType.Faith] = -1,
                        [DeviceType.Alcohol] = -2
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Food] = 1,
                        [DeviceType.Weapons] = 2,
                        [DeviceType.Gold] = 1,
                        [DeviceType.Alcohol] = 1,
                        [DeviceType.Army] = 1,
                        [DeviceType.Faith] = 1,
                        [DeviceType.World] = 1,
                        // Negative
                        [DeviceType.Money] = -2,
                        [DeviceType.Paperwork] = -2,
                        [DeviceType.Mansion] = -2,
                        [DeviceType.Education] = -1,
                        [DeviceType.Technology] = -1,
                        [DeviceType.Books] = -1,
                        [DeviceType.Robots] = -3,
                        [DeviceType.Violin] = -1,
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Kittens] = 2,
                        [DeviceType.Money] = 2,
                        [DeviceType.Gold] = 2,
                        [DeviceType.Love] = 1,
                        [DeviceType.Genitals] = 1,
                        [DeviceType.Alcohol] = 1,
                        [DeviceType.Robots] = 2,
                        [DeviceType.Violin] = 2,
                        // Negative
                        [DeviceType.Gold] = -2,
                        [DeviceType.Toys] = -2,
                        [DeviceType.Education] = -2,
                        [DeviceType.Pain] = -2,
                        [DeviceType.Tumor] = -2
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
                    new DeviceRelation
                    {
                        // Positive
                        [DeviceType.Education] = 2,
                        [DeviceType.Love] = 2,
                        [DeviceType.Money] = 2,
                        [DeviceType.Food] = 1,
                        [DeviceType.Technology] = 1,
                        [DeviceType.Robots] = 1,
                        [DeviceType.Violin] = 1,
                        // Negative
                        [DeviceType.Pain] = -2,
                        [DeviceType.Blood] = -2,
                        [DeviceType.Genitals] = -2,
                        [DeviceType.Alcohol] = -1,
                        [DeviceType.Faith] = -1,
                        [DeviceType.Tumor] = -1
                    }
                )
            };


        public static Attribute Attr(this AttributeType attr) => AttributeInfos[attr];
        public static string Name(this AttributeType attr) => attr.Attr().AttributeName;
        public static string Adjective(this AttributeType attr) => attr.Attr().Adjective;
    }
}