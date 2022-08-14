using System.Collections.Generic;
using Godot;

namespace bwayy.Scripts
{
    using AttributeMap = Dictionary<Attribute, string>;

    public enum Attribute
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
        Wise,
    }

    public class AttributeSet
    {
        public readonly Attribute First, Second, Third;

        public AttributeSet(string name, Attribute first, Attribute second, Attribute third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public string Name => $"{NamePrefixParts[First]}{NameMiddleParts[Second]}{NameSuffixParts[Third]}";

        public string Custom =>
            $"As it is their customary and diplomatic salute, {Name} {CustomAction[First]} your {CustomTarget[Second]} with their {CustomBody[Third]}.";

        public string Kill =>
            $"{Name} {KillingAction[First]} {KillingItem[Second]} in your {KillingBody[Third]}, killing you.";
        
        private static readonly AttributeMap NamePrefixParts = new AttributeMap
        {
            [Attribute.Ancient] = "Cloc",
            [Attribute.Childish] = "Bian",
            [Attribute.Deaf] = "Lat",
            [Attribute.Deviant] = "Eln",
            [Attribute.Evil] = "Khav",
            [Attribute.Gentle] = "Faun",
            [Attribute.Ghostly] = "Cas",
            [Attribute.Greedy] = "Arc",
            [Attribute.Industrial] = "Bol",
            [Attribute.Lustful] = "Ishm",
            [Attribute.Noble] = "Flun",
            [Attribute.Nudist] = "Weh",
            [Attribute.Pestilent] = "Erq",
            [Attribute.Religious] = "Arch",
            [Attribute.Rich] = "Den",
            [Attribute.Sadist] = "Il",
            [Attribute.Scientific] = "Selm",
            [Attribute.Tribal] = "Bras",
            [Attribute.Unpredictable] = "What",
            [Attribute.Violent] = "Kash",
            [Attribute.Wise] = "Erl"
        };
        
        private static readonly AttributeMap NameMiddleParts = new AttributeMap
        {
            [Attribute.Ancient] = "elan",
            [Attribute.Childish] = "ub",
            [Attribute.Deaf] = "omel",
            [Attribute.Deviant] = "iobl",
            [Attribute.Evil] = "iol",
            [Attribute.Gentle] = "iol",
            [Attribute.Ghostly] = "egal",
            [Attribute.Greedy] = "onim",
            [Attribute.Industrial] = "one",
            [Attribute.Lustful] = "anev",
            [Attribute.Noble] = "avel",
            [Attribute.Nudist] = "yah",
            [Attribute.Pestilent] = "ash",
            [Attribute.Religious] = "orell",
            [Attribute.Rich] = "aml",
            [Attribute.Sadist] = "ol",
            [Attribute.Scientific] = "anis",
            [Attribute.Tribal] = "arg",
            [Attribute.Unpredictable] = "the",
            [Attribute.Violent] = "iat",
            [Attribute.Wise] = "ionel"
        };

        private static readonly AttributeMap NameSuffixParts = new AttributeMap
        {
            [Attribute.Ancient] = "fil",
            [Attribute.Childish] = "eflo",
            [Attribute.Deaf] = "tre",
            [Attribute.Deviant] = "esse",
            [Attribute.Evil] = "olat",
            [Attribute.Gentle] = "ven",
            [Attribute.Ghostly] = "ne",
            [Attribute.Greedy] = "eq",
            [Attribute.Industrial] = "mel",
            [Attribute.Lustful] = "iel",
            [Attribute.Noble] = "bit",
            [Attribute.Nudist] = "ha",
            [Attribute.Pestilent] = "mol",
            [Attribute.Religious] = "stef",
            [Attribute.Rich] = "ivec",
            [Attribute.Sadist] = "lem",
            [Attribute.Scientific] = "grev",
            [Attribute.Tribal] = "ulb",
            [Attribute.Unpredictable] = "fuck",
            [Attribute.Violent] = "det",
            [Attribute.Wise] = "dente"
        };

        private static readonly AttributeMap CustomAction = new AttributeMap
        {
            [Attribute.Ancient] = "knocks on",
            [Attribute.Childish] = "pokes",
            [Attribute.Deaf] = "pats",
            [Attribute.Deviant] = "slaps",
            [Attribute.Evil] = "stabs",
            [Attribute.Gentle] = "mames",
            [Attribute.Ghostly] = "blows on",
            [Attribute.Greedy] = "scratches",
            [Attribute.Industrial] = "pulls at",
            [Attribute.Lustful] = "rubs",
            [Attribute.Noble] = "dusts",
            [Attribute.Nudist] = "rubs on",
            [Attribute.Pestilent] = "rubs",
            [Attribute.Religious] = "gropes",
            [Attribute.Rich] = "pats",
            [Attribute.Sadist] = "cuts",
            [Attribute.Scientific] = "studies",
            [Attribute.Tribal] = "bashes",
            [Attribute.Unpredictable] = "touches",
            [Attribute.Violent] = "mangles",
            [Attribute.Wise] = "draws on"
        };

        private static readonly AttributeMap CustomTarget = new AttributeMap
        {
            [Attribute.Ancient] = "children",
            [Attribute.Childish] = "skull",
            [Attribute.Deaf] = "face",
            [Attribute.Deviant] = "genitals",
            [Attribute.Evil] = "arms",
            [Attribute.Gentle] = "ass",
            [Attribute.Ghostly] = "psyche",
            [Attribute.Greedy] = "back",
            [Attribute.Industrial] = "arms",
            [Attribute.Lustful] = "feet",
            [Attribute.Noble] = "shoulder",
            [Attribute.Nudist] = "groin",
            [Attribute.Pestilent] = "throat",
            [Attribute.Religious] = "forehead",
            [Attribute.Rich] = "head",
            [Attribute.Sadist] = "neck",
            [Attribute.Scientific] = "suprasternal notch",
            [Attribute.Tribal] = "mother",
            [Attribute.Unpredictable] = "friends",
            [Attribute.Violent] = "shoulders",
            [Attribute.Wise] = "telescope"
        };

        private static readonly AttributeMap CustomBody = new AttributeMap
        {
            [Attribute.Ancient] = "mandibles",
            [Attribute.Childish] = "claw",
            [Attribute.Deaf] = "cane",
            [Attribute.Deviant] = "hand",
            [Attribute.Evil] = "nails",
            [Attribute.Gentle] = "tentacles",
            [Attribute.Ghostly] = "shadow",
            [Attribute.Greedy] = "cane",
            [Attribute.Industrial] = "arms",
            [Attribute.Lustful] = "index",
            [Attribute.Noble] = "crown",
            [Attribute.Nudist] = "tentacles",
            [Attribute.Pestilent] = "fat",
            [Attribute.Religious] = "teeth",
            [Attribute.Rich] = "hand",
            [Attribute.Sadist] = "toenails",
            [Attribute.Scientific] = "chin",
            [Attribute.Tribal] = "tail",
            [Attribute.Unpredictable] = "pineapple",
            [Attribute.Violent] = "elbow",
            [Attribute.Wise] = "horns"
        };

        private static readonly AttributeMap KillingAction = new AttributeMap
        {
            [Attribute.Ancient] = "hides",
            [Attribute.Childish] = "feeds",
            [Attribute.Deaf] = "kicks",
            [Attribute.Deviant] = "lays",
            [Attribute.Evil] = "pushes",
            [Attribute.Gentle] = "feeds",
            [Attribute.Ghostly] = "summons",
            [Attribute.Greedy] = "pours",
            [Attribute.Industrial] = "hammers",
            [Attribute.Lustful] = "injects",
            [Attribute.Noble] = "draws",
            [Attribute.Nudist] = "pours",
            [Attribute.Pestilent] = "vomits",
            [Attribute.Religious] = "shoots",
            [Attribute.Rich] = "fires",
            [Attribute.Sadist] = "inflates",
            [Attribute.Scientific] = "sews",
            [Attribute.Tribal] = "cooks",
            [Attribute.Unpredictable] = "invokes",
            [Attribute.Violent] = "installs",
            [Attribute.Wise] = "plants"
        };

        private static readonly AttributeMap KillingItem = new AttributeMap
        {
            [Attribute.Ancient] = "maggots",
            [Attribute.Childish] = "poison",
            [Attribute.Deaf] = "paint",
            [Attribute.Deviant] = "eggs",
            [Attribute.Evil] = "brambles",
            [Attribute.Gentle] = "puss",
            [Attribute.Ghostly] = "fireflies",
            [Attribute.Greedy] = "puke",
            [Attribute.Industrial] = "nails",
            [Attribute.Lustful] = "acid",
            [Attribute.Noble] = "gold",
            [Attribute.Nudist] = "lube",
            [Attribute.Pestilent] = "flies",
            [Attribute.Religious] = "snakes",
            [Attribute.Rich] = "rocks",
            [Attribute.Sadist] = "needles",
            [Attribute.Scientific] = "spores",
            [Attribute.Tribal] = "tar",
            [Attribute.Unpredictable] = "mushrooms",
            [Attribute.Violent] = "bolts",
            [Attribute.Wise] = "vines"
        };

        private static readonly AttributeMap KillingBody = new AttributeMap
        {
            [Attribute.Ancient] = "throat",
            [Attribute.Childish] = "eyelids",
            [Attribute.Deaf] = "face",
            [Attribute.Deviant] = "skull",
            [Attribute.Evil] = "ears",
            [Attribute.Gentle] = "tongue",
            [Attribute.Ghostly] = "mind",
            [Attribute.Greedy] = "heart",
            [Attribute.Industrial] = "chest",
            [Attribute.Lustful] = "veins",
            [Attribute.Noble] = "brain",
            [Attribute.Nudist] = "ass",
            [Attribute.Pestilent] = "legs",
            [Attribute.Religious] = "head",
            [Attribute.Rich] = "hands",
            [Attribute.Sadist] = "skin",
            [Attribute.Scientific] = "lungs",
            [Attribute.Tribal] = "entrails",
            [Attribute.Unpredictable] = "eyes",
            [Attribute.Violent] = "spine",
            [Attribute.Wise] = "scalp"
        };
    }

    public static class AttributeExtensions
    {
        private static readonly AttributeMap AttributeNames = new AttributeMap
        {
            [Attribute.Ancient] = "ancient",
            [Attribute.Childish] = "childish",
            [Attribute.Deaf] = "deaf",
            [Attribute.Deviant] = "deviant",
            [Attribute.Evil] = "evil",
            [Attribute.Gentle] = "gentle",
            [Attribute.Ghostly] = "ghostly",
            [Attribute.Greedy] = "greedy",
            [Attribute.Industrial] = "industrial",
            [Attribute.Lustful] = "lustful",
            [Attribute.Noble] = "noble",
            [Attribute.Nudist] = "nudist",
            [Attribute.Pestilent] = "pestilent",
            [Attribute.Religious] = "religious",
            [Attribute.Rich] = "rich",
            [Attribute.Sadist] = "sadist",
            [Attribute.Scientific] = "scientific",
            [Attribute.Tribal] = "tribal",
            [Attribute.Unpredictable] = "unpredictable",
            [Attribute.Violent] = "violent",
            [Attribute.Wise] = "wise"
        };
        
        
        private static readonly AttributeMap AttributeAdjective = new AttributeMap
        {
            [Attribute.Ancient] = "rough",
            [Attribute.Childish] = "stumpy",
            [Attribute.Deaf] = "uneasy",
            [Attribute.Deviant] = "disgusting",
            [Attribute.Evil] = "spiky",
            [Attribute.Gentle] = "soft",
            [Attribute.Ghostly] = "intangible",
            [Attribute.Greedy] = "rusty",
            [Attribute.Industrial] = "metal",
            [Attribute.Lustful] = "wet",
            [Attribute.Noble] = "velvet-like",
            [Attribute.Nudist] = "rubbery",
            [Attribute.Pestilent] = "stinky",
            [Attribute.Religious] = "golden",
            [Attribute.Rich] = "sacred",
            [Attribute.Sadist] = "bloody",
            [Attribute.Scientific] = "misinformed",
            [Attribute.Tribal] = "hairy",
            [Attribute.Unpredictable] = "absurd",
            [Attribute.Violent] = "bloody",
            [Attribute.Wise] = "scaly"
        };

        public static string Name(this Attribute attr)
        {
            return AttributeNames[attr];
        }

        public static string Adjective(this Attribute attr)
        {
            return AttributeAdjective[attr];
        }
    }
}