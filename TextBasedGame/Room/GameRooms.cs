using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using TextBasedGame.Character.Constants;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Constants;
using TextBasedGame.Shared.Models;
using Items = TextBasedGame.Item.Models.Items;

namespace TextBasedGame.Room
{
    public class GameRooms
    {
        // This is where all Rooms for the game are defined/instantiated
        // Note: These should only ever be referenced by the RoomCreator

        // Files to edit when adding a room: GameRooms.cs, RoomCreator.cs, GameSetupHandler.cs

        public static Models.Room YourBedroom = new Models.Room
        {
            RoomName = "Your Bedroom",
            InitialRoomDescription = "You are standing in your bedroom, next to your bed. \n" +
                                     "There's faint moonlight coming in through the blinds of your open window. \n" +
                                     "You can feel the cool night air coming in from outside.",
            GenericRoomDescription = "You are standing in your bedroom.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    Program.ItemCreator.RunningShoes
                },
                WeaponItems = new List<WeaponItem>()
                {
                    Program.ItemCreator.LetterOpener
                }
            },
            KeywordsToEnter = Constants.RoomKeywords.YourBedroom
        };

        public static Models.Room YourLivingRoom = new Models.Room
        {
            RoomName = "Your Living Room",
            InitialRoomDescription = "You are now standing in your living room. \n" +
                                     "You hear the wind start blowing quite intensely through one of your open living room windows. \n" +
                                     "Tree branches rattle and tap on the glass just before the gusts of wind begin to calm down a bit. \n\n" +
                                     "Just then, you hear some strange and sudden *clank* sound from your kitchen. \n\n\n" +
                                     "HINT: There are some items that require you to have high enough stats to see or take them. \n" +
                                     "Try typing 'items' - you will see the Tiny Backpack if your Luck is 1 or more.",
            GenericRoomDescription = "You are standing in your living room.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    Program.ItemCreator.TinyBackpack
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = Constants.RoomKeywords.YourLivingRoom
        };

        public static Models.Room YourKitchen = new Models.Room
        {
            RoomName = "Your Kitchen",
            InitialRoomDescription = "You've entered your kitchen, and you're looking around for anything that might \n" +
                                     "have made that strange noise... \n\n" +
                                     "In an flurry of fur, you see a dark gray (and very plump) rat jump out from beneath your counter, \n" +
                                     "and scurry through your living room and out of the house through a small hole in your window screen.",
            GenericRoomDescription = "You're standing in your kitchen, on the light beige floor tiles.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    Program.ItemCreator.PlainBagel
                },
                WeaponItems = new List<WeaponItem>()
                {

                }
            },
            KeywordsToEnter = Constants.RoomKeywords.YourKitchen
        };

        public static Models.Room YourFrontEntryway = new Models.Room
        {
            RoomName = "Your Front Entryway",
            InitialRoomDescription = "Now you're standing just inside the front door of your house, in the entryway. \n" +
                                     "As you begin to notice the sound of your own breathing, the wind picks up outside again. \n" +
                                     "You can hear it pushing tree limbs into each other, and what sounds like other things too. \n\n" +
                                     "It's getting really windy out there. \n\n\n" +
                                     "HINT: There are some rooms that require you to have specific items or high enough stats to enter them. \n" +
                                     "Try typing 'exits' - you will see the exits from this room.\n" +
                                     "Try typing 'enter the porch' - if you are carrying the Tiny Backpack you can leave the house.",
            GenericRoomDescription = "You're standing inside the entryway of your home.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.Flashlight
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = Constants.RoomKeywords.YourFrontEntryway
        };

        public static Models.Room YourBasement = new Models.Room
        {
            RoomName = "Your Basement",
            InitialRoomDescription = "You walked down the dark stairs into your basement, thanks to the flashlight.\n" +
                                     "The wind seems far quieter from down here... Almost silent, in fact.\n\n" +
                                     "Something about being in the basement right now is giving you the creeps.\n\n" +
                                     "Just then, your flashlight briefly flickers.",
            GenericRoomDescription = "You're in your basement. It's really dark and creepy in here.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.StrangeCreaturesBook,
                    Program.ItemCreator.FlashlightBattery
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.YourBasement,
            ItemRequirementToSee = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            },
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room YourFrontPorch = new Models.Room
        {
            RoomName = "Your Front Porch",
            InitialRoomDescription = "You've just walked out of your house, and you're standing outside the front door. \n" +
                                     "The wind is gusting aggressively in the trees overhead, but the air is oddly calm around you. \n\n" +
                                     "Those haunting sounds that woke you up seem to be non-existent... Maybe you dreamt them? \n\n" +
                                     "You suddenly notice a small, dirty letter poking out from under your doormat... \n" +
                                     "It definitely wasn't there when you came home earlier.",
            GenericRoomDescription = "You're on your front porch, just outside the front door of your house.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.DirtyLetter
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = Constants.RoomKeywords.YourFrontPorch,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.TinyBackpack.ItemName,
                RelevantItem = Program.ItemCreator.TinyBackpack
            }
        };

        public static Models.Room YourDriveway = new Models.Room
        {
            RoomName = "Your Driveway",
            InitialRoomDescription = "You walk over to your driveway in the moonlight.\n\n" +
                                     "Very quickly you notice the hood of your car is open, and the battery is missing...\n" +
                                     "You start wondering if Henry did that... And if so, why?\n\n" +
                                     "The walk to town is about a mile North.\n\n" +
                                     "The wind picks up suddenly and...\n\n" +
                                     "... Wait... It almost sounds like someone is stomping around in the grove of trees behind your house.",
            GenericRoomDescription = "You're standing outside your house on the moonlit driveway.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.Newspaper
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = Constants.RoomKeywords.YourDriveway
        };

        public static Models.Room YourShed = new Models.Room
        {
            RoomName = "Your Shed",
            InitialRoomDescription = "You open the rusted metal makeshift shed door and it creaks and screeches loudly.\n\n" +
                                     "It's really cold in here, and the whole shed seems flimsy in the wind.\n" +
                                     "It keeps shifting slightly from side to side and making unsettling noises with each gust.\n" +
                                     "You keep hearing strange sounds in the forest just outside the shed...\n" +
                                     "Almost sounds like far off footsteps.",
            GenericRoomDescription = "You're in your rusted, creaky old shed.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.ScotchWhiskey,
                    Program.ItemCreator.CanvasBookBag
                },
                WeaponItems = new List<WeaponItem>
                {
                    Program.ItemCreator.BaseballBat
                }
            },
            KeywordsToEnter = Constants.RoomKeywords.YourShed,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Wisdom - 3+",
                RelevantCharacterAttribute = AttributeStrings.Wisdom,
                MinimumAttributeValue = 3
            },
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room RoadConnectingYourHouseToTown = new Models.Room
        {
            RoomName = "The Road Between Your House and Town",
            InitialRoomDescription = "You've started walking North away from your house, towards town.\n" +
                                     "The road is well lit by the bright moonlight, but the forest on \n" +
                                     "each side of the road is incredibly dark and ominous.\n\n" +
                                     "Seems a bit crazy to you that you're about to walk to Henry's at this time of night...\n\n" +
                                     "Though with everything that's been going on around here lately, you know it's justified.\n" +
                                     "Maybe you'll be able to help Henry find his wife before morning.",
            GenericRoomDescription = "You're on the moonlit road that's between your house and town.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.DirtyGoldBullet
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.RoadConnectingYourHouseToTown
        };

        public static Models.Room ForestLake = new Models.Room
        {
            RoomName = "The Lake in the Forest",
            InitialRoomDescription = "You've entered the forest on the West side of the road between your house and town.\n" +
                                     "It' so incredibly dark in the thick trees, but luckily you have a flashlight.\n\n" +
                                     "You keep on walking between the trees and through the fallen branches that cover the ground.\n" +
                                     "You can't fight off the feeling that you're being watched... \n\n" +
                                     ". . . . . . .\n\n" +
                                     "You finally make it to an opening in the trees, and you walk out of the forest\n" +
                                     "onto the sandy bank of the moonlit Forest Lake.",
            GenericRoomDescription = "You've traversed through the forest on the West side of the road between your house and town,\n" +
                                     "and you're standing on the sandy bank of the moonlit Forest Lake.",
            KeywordsToEnter = RoomKeywords.ForestLake,
            ItemRequirementToSee = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            },
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room ForestLakeTent = new Models.Room
        {
            RoomName = "Collapsed Lakeside Tent",
            InitialRoomDescription = "You followed the shoreline of the lake until you reached the Collapsed Lakeside Tent. \n" +
                                     "It seems like it hasn't been here very long, almost like it was abandoned in a hurry.\n\n" +
                                     "The front door flap is wide open, and just the rear portion of the tent is collapsed.\n" +
                                     "Shining the flashlight into the tent reveals some pillows\n" +
                                     "and sleeping bags that appear to have been left behind... \n\n" +
                                     "... Is that... blood in the back of the collapsed tent?",
            GenericRoomDescription = "You walked along the shoreline and are standing at the Collapsed Lakeside Tent.\n" +
                                     "There appears to be blood inside the tent, near the abandoned suitcases.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.WornLeatherBoots,
                    Program.ItemCreator.RabbitsFoot,
                    Program.ItemCreator.StrangeThermos,
                    Program.ItemCreator.AbandonedFlashlightBattery
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.ForestLakeTent,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Wisdom - 4+",
                RelevantCharacterAttribute = AttributeStrings.Wisdom,
                MinimumAttributeValue = 4
            },
            ItemRequirementToSee = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            },
            AttributeRequirementToEnter = new AttributeRequirement
            {
                RequirementName = "Wisdom - 4+",
                RelevantCharacterAttribute = AttributeStrings.Wisdom,
                MinimumAttributeValue = 4
            },
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room EastForest = new Models.Room
        {
            RoomName = "The East Forest",
            InitialRoomDescription = "You wander from the moonlit road into the dark forest to the East...\n" +
                                     "As soon as you pass the first row of trees, you feel engulfed by the darkness.\n" +
                                     "You begin to feel convinced that, if it weren't for your flashlight, \n" +
                                     "you'd become dinner for some creature in these woods. \n\n" +
                                     "You hear the wind creaking and bending the trees, and to the South you're pretty positive\n" +
                                     "that occasionally you can faintly hear that stomping sound you'd heard out behind your house...\n\n" +
                                     "But you keep on trekking through the trees; their tops swaying insanely to the song of the wind,\n" +
                                     "and their trunks staying perfectly still - as though nothing could move them at all.",
            GenericRoomDescription = "You're standing in the forest, East of the road between your house and town.\n" +
                                     "It's really dark here, and you almost feel hunted.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.HumanTeeth
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.EastForest,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room EastForestLowerClearing = new Models.Room
        {
            RoomName = "East Forest Lower Clearing",
            InitialRoomDescription = "You kept walking East, and you've made it out of the forest \n" +
                                     "into a small clearing about the size of a football field.\n\n" +
                                     "You're standing at the South end of it, and to the North the grade slopes down\n" +
                                     "enough that you can see the top of some of the vast forest.\n\n" +
                                     "You can see the moon again, and you're beginning to feel comforted by it.\n" +
                                     "It bathes your surroundings with enough light that you know where you are.\n" +
                                     "You almost don't want to go into the forest again... \n" +
                                     "You feel like it's making you crazy just to be walking in there this late at night.\n\n" +
                                     "... And you're pretty sure that stomping sound you were hearing was getting closer.",
            GenericRoomDescription = "You're at the South end of the football-field sized clearing in the East Forest. \n" +
                                     "The moon is bright here, but you don't feel too safe...",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.WomansNecklace
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.EastForestLowerClearing,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room EastForestUpperClearing = new Models.Room
        {
            RoomName = "East Forest Upper Clearing",
            InitialRoomDescription = "You go North, still in the clearing. You're grateful for the moonlight. \n" +
                                     "You notice that you aren't walking nearly as quickly as you were in the forest.\n" +
                                     "It's almost like the wall of trees surrounding you create a safe-haven,\n" +
                                     "and the yellow-white light of the moon acts as a ward against the fear setting into you.\n\n" +
                                     "You almost want to smile, in fact. But you don't, because you know that to get out of here\n" +
                                     "you're going to have to go back into the forest................ Wait........\n" +
                                     "......... Is that the stomping sound again?\n\n" +
                                     "You turn around and look in the direction of the sound, by where you came into the clearing.\n" +
                                     "You see a white looking thing, very briefly, before it dashes back into the trees...\n\n" +
                                     "It almost looked like a person, but... bigger?\n" +
                                     "You notice your hands are shaking from fear and adrenaline... You need to get out of here.",
            GenericRoomDescription = "You're at the North end of the football-field sized clearing in the East Forest. \n" +
                                     "The moon is bright here, and you feel safe somehow...\n\n" +
                                     "... But you know you're not.",
            KeywordsToEnter = RoomKeywords.EastForestUpperClearing
        };

        public static Models.Room DeepEastForest = new Models.Room
        {
            RoomName = "Deep East Forest",
            InitialRoomDescription = "You hesitantly go back into the dense darkness of the trees,\n" +
                                     "and as the moonlight fades away, you think about the thing you saw in the clearing.\n\n" +
                                     "You tell yourself it wasn't real, that you're just getting tired and seeing things...\n\n" +
                                     "That thought quickly vanishes from your mind as you begin to hear the stomping again.",
            GenericRoomDescription = "You're deep in the East Forest... \n" +
                                     "It's pitch black all around you, and you feel very uneasy here.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.BloodyJeans,
                    Program.ItemCreator.LuckyBrandChewingGum
                },
                WeaponItems = new List<WeaponItem>
                {
                    Program.ItemCreator.Femur
                }
            },
            KeywordsToEnter = RoomKeywords.DeepEastForest,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room DeepEastForestLowerRiver = new Models.Room
        {
            RoomName = "East Forest Lower River",
            InitialRoomDescription = "You followed the sound of running water, and made it to the Southern bank of the\n" +
                                     "East Forest River. The current is going South, and it's really roaring. \n" +
                                     "You reach down and feel the icy water running between your fingers. \n\n" +
                                     "It makes you wonder what would happen if you fell in.",
            GenericRoomDescription = "You're on the Southern bank of the roaring East Forest River. The water is freezing.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.HuntingCap,
                    Program.ItemCreator.PlatinumRing,
                    Program.ItemCreator.SomberNote,
                    Program.ItemCreator.TownSouthGateKey
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.DeepEastForestLowerRiver,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Luck - 5+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 5
            },
            AttributeRequirementToEnter = new AttributeRequirement
            {
                RequirementName = "Luck - 5+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 5
            },
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room DeepEastForestUpperRiver = new Models.Room
        {
            RoomName = "East Forest Upper River",
            InitialRoomDescription = "You follow the riverbank North, where the treeline gets closer to the water.\n" +
                                     "Northwards up the river is a waterfall; maybe 25 feet high. It's plunging loudly.\n\n" +
                                     "A cloud rolls over the moon, and for a moment you think you see something moving\n" +
                                     "in the trees on the other side of the river...\n\n" +
                                     "You hear an owl *Who*, and as the moonlight returns, you decide that what you\n" +
                                     "might have seen across the river was just in your imagination.",
            GenericRoomDescription = "You're on the Northern bank of the East Forest River, just South of a waterfall. \n" +
                                     "An owls yellow eyes stare down at you from the trees.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.EnergyBar,
                    Program.ItemCreator.BottleOfScentMask,
                    Program.ItemCreator.BoxOf44MagnumAmmo,
                    Program.ItemCreator.WetGoldBullet
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.DeepEastForestUpperRiver,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Wisdom - 5+",
                RelevantCharacterAttribute = AttributeStrings.Wisdom,
                MinimumAttributeValue = 5
            },
            AttributeRequirementToEnter = new AttributeRequirement
            {
                RequirementName = "Wisdom - 5+",
                RelevantCharacterAttribute = AttributeStrings.Wisdom,
                MinimumAttributeValue = 5
            },
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room DeepEastForestUpperRiverCave = new Models.Room
        {
            RoomName = "East Forest River Waterfall Cave",
            InitialRoomDescription = "You carefully shimmy behind the waterfall of the East Forest River,\n" +
                                     "into the hidden cave behind the falls. It's pretty cold inside.\n\n" +
                                     "You quickly notice that there's a wooden chair, a table, and some bedding...\n" +
                                     "Someone must be living here.",
            GenericRoomDescription = "You made your way into the hidden cave behind the falls of the East Forest River.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.MiracleTonic,
                    Program.ItemCreator.SnakeBracelet,
                    Program.ItemCreator.WaterloggedJournal
                },
                WeaponItems = new List<WeaponItem>
                {
                    Program.ItemCreator.FiremansAxe
                }
            },
            KeywordsToEnter = RoomKeywords.DeepEastForestUpperRiverCave,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Stamina - 8+",
                RelevantCharacterAttribute = AttributeStrings.Stamina,
                MinimumAttributeValue = 8
            },
            AttributeRequirementToEnter = new AttributeRequirement
            {
                RequirementName = "Stamina - 8+",
                RelevantCharacterAttribute = AttributeStrings.Stamina,
                MinimumAttributeValue = 8
            },
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room EastForestCampground = new Models.Room
        {
            RoomName = "East Forest Camp",
            InitialRoomDescription = "You continue West, and notice the trees are a bit less dense here.\n" +
                                     "You see three tents and a burnt out campfire here... But all the tents are torn up\n" +
                                     "and there is blood on and around them...\n" +
                                     "You see various items strewn around the camp, as if there had been a tussle going on... \n" +
                                     "To you, it almost looks like a bear attack or something.\n\n" +
                                     "And then you notice a thick trail of blood behind one of the tents...",
            GenericRoomDescription = "You're standing in the center of a wrecked campsite. \n" +
                                     "Three tents are torn up and stained with blood...",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.BloodyGoldBullet,
                    Program.ItemCreator.BomberJacket,
                    Program.ItemCreator.BoxOfShotgunShells,
                    Program.ItemCreator.LargeKnapsack
                },
                WeaponItems = new List<WeaponItem>
                {
                    Program.ItemCreator.LumberAxe
                }
            },
            KeywordsToEnter = RoomKeywords.EastForestCampground,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room TownSouthEntrance = new Models.Room
        {
            RoomName = "Ashbury - South Entrance",
            InitialRoomDescription = "After some time (and jogging), you approach the South entrance of Ashbury.\n" +
                                     "It looks barricaded, and the South town gate is shut...\n\n" +
                                     "This entrance to town has been sealed off.\n" +
                                     "Through the South gate you can easily tell that the whole town is dark,\n" +
                                     "the power is out here also.\n" +
                                     "It's completely silent, aside from the gusts of wind.\n\n" +
                                     "You see a bulletin board near the gate with a box full of papers that says: \n" +
                                     "\"Ashbury Residents - Please Read.\"",
            GenericRoomDescription = "You're standing just outside the South Gate of Ashbury.\n" +
                                     "The whole town is dark...",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.TownCurfewNotice
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.TownSouthEntrance
        };

        public static Models.Room AshburySouthSquare = new Models.Room
        {
            RoomName = "Ashbury - South Square",
            InitialRoomDescription = "You make your way through the South gate, and you're standing in the South Square.\n" +
                                     "The town looks ghostly to you with all the power out... Almost like no one has ever even lived here.\n\n" +
                                     "Being inside the town walls makes you finally feel very safe and secure.\n" +
                                     "You are starting to feel convinced that there really is some beast out there...\n" +
                                     "And that perhaps you glimpsed it... ever so briefly.\n\n" +
                                     "You really need to get to Henry's.",
            GenericRoomDescription = "You're in the South Square of Ashbury.\n" +
                                     "The town feels ghostly with all the power being out...",
            KeywordsToEnter = RoomKeywords.AshburySouthSquare,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.TownSouthGateKey.ItemName,
                RelevantItem = Program.ItemCreator.TownSouthGateKey
            }
        };
    }
}