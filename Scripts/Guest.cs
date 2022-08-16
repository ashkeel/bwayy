using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace bwayy.Scripts
{
    public struct Reaction
    {
        public List<string> Messages;
        public float Value;
        public bool IsMultiplier;
    }
    
    public class Guest
    {
        private const float DefaultRelationship = 0;
        public float Relationship { get; private set; }
        public readonly Attribute First, Second, Third;

        public Guest(Attribute first, Attribute second, Attribute third)
        {
            First = first;
            Second = second;
            Third = third;
            Relationship = DefaultRelationship;
        }

        public Guest(AttributeType first, AttributeType second, AttributeType third)
        {
            First = first.Attr();
            Second = second.Attr();
            Third = third.Attr();
        }

        public static Guest Random()
        {
            var attributes = Enum.GetValues(typeof(AttributeType)).Cast<AttributeType>().ToList().GetRandomElements(3);
            return new Guest(attributes[0], attributes[1], attributes[2]);
        }

        public bool CanOffer(SpellType action)
        {
            // Mix all flags together
            var allFlags = First.Flags | Second.Flags | Third.Flags;
            
            // Check for ghostly/deaf/whatever
            switch (action)
            {
                case SpellType.Say:
                    return (allFlags & AttributeModifiers.CannotSay) == 0;
                case SpellType.Touch:
                    return (allFlags & AttributeModifiers.CannotTouch) == 0;
                case SpellType.Give:
                    return (allFlags & AttributeModifiers.CannotGive) == 0;
            }

            return true;
        }
        
        public List<Reaction> Offer(SpellType action, DeviceType device)
        {
            var deviceName = device.Name();
            var reactions = new List<Reaction>();
            
            // First reaction is spell affinity
            var firstSpellAffinity = First.MultiplierForSpell(action);
            var secondSpellAffinity = Second.MultiplierForSpell(action);
            var thirdSpellAffinity = Third.MultiplierForSpell(action);

            var totalAffinity = 1 + firstSpellAffinity + secondSpellAffinity + thirdSpellAffinity;
            var affinityEntry = new Reaction
            {
                Messages = new List<string>(),
                Value = totalAffinity,
                IsMultiplier = true
            };

            switch (action)
            {
                case SpellType.Say:
                    affinityEntry.Messages.Add($"You talk about {deviceName} with {Name}");
                    if (firstSpellAffinity > 0)
                    {
                        affinityEntry.Messages.Add("Your guest is a communicative one.");
                    }
                    if (secondSpellAffinity > 0)
                    {
                        affinityEntry.Messages.Add("They enjoys conversing.");
                    }
                    if (thirdSpellAffinity > 0)
                    {
                        affinityEntry.Messages.Add($"{Name} likes to hear your voice.");
                    }
                    break;
                case SpellType.Touch:
                    affinityEntry.Messages.Add($"You touch {Name}'s {deviceName}");
                    if (firstSpellAffinity > 0)
                    {
                        affinityEntry.Messages.Add("Your guest is a physical one.");
                    }
                    if (secondSpellAffinity > 0)
                    {
                        affinityEntry.Messages.Add("They enjoy things touching.");
                    }
                    if (thirdSpellAffinity > 0)
                    {
                        affinityEntry.Messages.Add($"{Name} likes to be touched.");
                    }
                    break;
                case SpellType.Give:
                    affinityEntry.Messages.Add($"You give your {deviceName} to {Name}");
                    if (firstSpellAffinity > 0)
                    {
                        affinityEntry.Messages.Add("Your guest wants to have everything.");
                    }
                    if (secondSpellAffinity > 0)
                    {
                        affinityEntry.Messages.Add("They enjoy being given things.");
                    }
                    if (thirdSpellAffinity > 0)
                    {
                        affinityEntry.Messages.Add($"{Name} likes stuff.");
                    }
                    break;
                case SpellType.Leave:
                    affinityEntry.Messages.Add("You run away.");
                    break;
            }
            
            reactions.Add(affinityEntry);

            var firstReaction = First.ReactionForDevice(device);
            var secondReaction = Second.ReactionForDevice(device);
            var thirdReaction = Third.ReactionForDevice(device);
            
            // Second reaction is positive responses
            if (firstReaction > 0 || secondReaction > 0 || thirdReaction > 0)
            {
                var positiveEntry = new Reaction
                {
                    Messages = new List<string>(),
                    Value = 0,
                    IsMultiplier = false
                };

                if (firstReaction > 0)
                {
                    positiveEntry.Value += firstReaction;
                    positiveEntry.Messages.Add($"{Name}'s {First.AttributeName} trait appreciates {deviceName}.");
                }

                if (secondReaction > 0)
                {
                    positiveEntry.Value += secondReaction;
                    positiveEntry.Messages.Add($"{Name}'s {Second.AttributeName}ness loves {deviceName}.");
                }

                if (thirdReaction > 0)
                {
                    positiveEntry.Value += thirdReaction;
                    positiveEntry.Messages.Add($"{Name}, being {Third.AttributeName}, likes {deviceName}.");
                }

                positiveEntry.Value *= totalAffinity;
                reactions.Add(positiveEntry);
            }
            else
            {
                reactions.Add(new Reaction
                {
                    Messages = new List<string>{$"{Name} is not impressed with your actions."},
                    Value = 0,
                    IsMultiplier = false
                });
            }
            
            // Third reaction is negative responses
            if (firstReaction < 0 || secondReaction < 0 || thirdReaction < 0)
            {
                var negativeEntry = new Reaction
                {
                    Messages = new List<string>(),
                    Value = 0
                };

                if (firstReaction < 0)
                {
                    negativeEntry.Value += firstReaction;
                    negativeEntry.Messages.Add($"{Name}'s {First.AttributeName} trait hates {deviceName}.");
                }

                if (secondReaction < 0)
                {
                    negativeEntry.Value += secondReaction;
                    negativeEntry.Messages.Add($"{Name}'s {Second.AttributeName}ness despises {deviceName}.");
                }

                if (thirdReaction < 0)
                {
                    negativeEntry.Value += thirdReaction;
                    negativeEntry.Messages.Add($"{Name}, being {Third.AttributeName}, finds {deviceName} repulsive.");
                }

                negativeEntry.Value *= totalAffinity;
                reactions.Add(negativeEntry);
            }
            else
            {
                reactions.Add(new Reaction
                {
                    Messages = new List<string>{$"{Name} is not displeased with your actions."},
                    Value = 0,
                    IsMultiplier = false
                });
            }

            // Last reaction is the summary
            var totalRelationshipChange = totalAffinity * (firstReaction + secondReaction + thirdReaction);

            var summaryMessage = "This has accomplished absolutely nothing.";
            if (totalRelationshipChange > 10)
            {
                summaryMessage = $"You won {Name} over with your {deviceName}.";
            } else if (totalRelationshipChange > 0)
            {
                summaryMessage = $"You pleased {Name}";
            } else if (totalRelationshipChange < -10)
            {
                summaryMessage = $"You angered {Name} with your {deviceName}";
            } else if (totalRelationshipChange < 0)
            {
                summaryMessage = $"You pissed off {Name}";
            }
            
            reactions.Add(new Reaction
            {
                Messages = new List<string>{ summaryMessage },
                Value = totalRelationshipChange,
                IsMultiplier = false
            });

            // Actually mutate relationship value
            Relationship += totalRelationshipChange;
            
            return reactions;
        }

        [Pure]
        public string Name => $"{First.NamePrefix}{Second.NameMiddle}{Third.NameSuffix}";

        [Pure]
        public string CustomMessage =>
            $"As it is their customary and diplomatic salute, {Name} {First.CustomAction} your {Second.CustomTarget} with their {Third.CustomBody}.";

        [Pure]
        public string KillMessage =>
            $"{Name} {First.KillingAction} {Second.KillingMean} in your {Third.KillingBody}, killing you.";

        [Pure]
        public string OfferMessage(DeviceType device) => $"{Name} ${ActionFromRelationship} ${device.Name()}";
        
        [Pure]
        public string RelationshipStatus
        {
            get
            {
                if (Relationship > 15)
                {
                    return "loving";
                }

                if (Relationship > 10)
                {
                    return "friendly";
                }

                if (Relationship > 5)
                {
                    return "accepting";
                }

                if (Relationship > 1)
                {
                    return "casual";
                }

                if (Relationship < -15)
                {
                    return "enemy";
                }

                if (Relationship < -10)
                {
                    return "homicidal";
                }

                if (Relationship < -5)
                {
                    return "hostile";
                }

                if (Relationship < -1)
                {
                    return "annoyed";
                }

                return "neutral";
            }
        }

        [Pure]
        private string ActionFromRelationship
        {
            get
            {
                if (Relationship < -15)
                {
                    return "replies with";
                }

                if (Relationship < -10)
                {
                    return "answers with";
                }

                if (Relationship < 0)
                {
                    return "gestures at";
                }

                if (Relationship > 15)
                {
                    return "offers you their";
                }

                if (Relationship > 10)
                {
                    return "presents you their";
                }

                return "shows you their";
            }
        }
    }
}