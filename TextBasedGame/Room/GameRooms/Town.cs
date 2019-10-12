using System.Collections.Generic;
using TextBasedGame.Character.Constants;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Constants;
using TextBasedGame.Shared.Models;
using Items = TextBasedGame.Item.Models.Items;

namespace TextBasedGame.Room.GameRooms
{
    public class Town
    {
        // Note: These should only ever be referenced by the RoomCreator

        // Files to edit when adding a room: GameRooms.cs, RoomCreator.cs, GameSetupHandler.cs

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
            KeywordsToEnter = RoomKeywords.TownEntrance
        };

        public static Models.Room TownNorthEntrance = new Models.Room
        {
            RoomName = "Ashbury - North Entrance",
            InitialRoomDescription = "You've just gone through the North Gate, exiting Ashbury.\n" +
                                     "It's quite a bit cooler on this side of town...\n\n" +
                                     "The night feels like it's never going to end, and the moon\n" +
                                     "doesn't even look like it's moved once since you've left your house.\n\n" +
                                     "You know it's not much farther now to get to Henry's...",
            GenericRoomDescription = "You're standing just outside the North Gate of Ashbury.\n" +
                                     "You notice it's a lot colder on this side of the town.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.CannedMeat
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.TownEntrance,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.TownNorthGateKey.ItemName,
                RelevantItem = Program.ItemCreator.TownNorthGateKey
            }
        };

        public static Models.Room TownEastEntrance = new Models.Room
        {
            RoomName = "Ashbury - East Entrance",
            InitialRoomDescription = "After working your way through the fog,\n" +
                                     "you finally begin to see the East Gate entrance into town.\n" +
                                     "The fog dissipates quickly as you ascend the slope going up to the gate.\n\n" +
                                     "Just as you reach the gate, \n" +
                                     "you faintly hear a distant scream from deep inside the East Forest...",
            GenericRoomDescription = "You're standing just outside the East Gate of Ashbury.\n" +
                                     "There's a dense fog that dissipates closer to the gate entrance.\n" +
                                     "The whole town is dark inside...",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.MissingPersonPosterLucy
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.TownEntrance,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room TownWestEntrance = new Models.Room
        {
            RoomName = "Ashbury - West Entrance",
            InitialRoomDescription = "You've exited town on the West side... But you know all too well\n" +
                                     "that the West Forest is often said to be haunted.\n\n" +
                                     "Before all the missing persons reports, the West Forest \n" +
                                     "was known to drive people mad within the confines of its trees.\n" +
                                     "There are even stories about people who live out here,\n" +
                                     "in the brush and bramble, like animals, \n" +
                                     "driven mad simply by venturing off of the road.",
            GenericRoomDescription = "You're standing just outside the West Gate of Ashbury.\n" +
                                     "There is an air of danger here...\n" +
                                     "Your instincts tell you to get back inside town.\n\n" +
                                     "Many consider the West Forest to be haunted.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.GoldWristwatch
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.TownEntrance,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.TownWestGateKey.ItemName,
                RelevantItem = Program.ItemCreator.TownWestGateKey
            }
        };

        public static Models.Room AshburySouthSquare = new Models.Room
        {
            RoomName = "Ashbury - South Square",
            InitialRoomDescription = "You make your way through the South gate, and you're standing in the South Square.\n" +
                                     "The town looks ghostly to you with all the power out... Almost like no one has ever even lived here.\n\n" +
                                     "Being inside the town walls makes you finally feel very safe and secure.\n" +
                                     "You are starting to feel convinced that there really is some beast out there...\n" +
                                     "And that perhaps you glimpsed it... ever so briefly.\n" +
                                     "You really need to get to Henry's.\n\n" +
                                     "You notice the alley into South Main Street has been blocked by a metal door with a padlock on it...\n" +
                                     "A crowbar could break that easily.",
            GenericRoomDescription = "You're in the South Square of Ashbury.\n" +
                                     "The town feels ghostly with all the power being out...",
            KeywordsToEnter = RoomKeywords.AshburySquare,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.TownSouthGateKey.ItemName,
                RelevantItem = Program.ItemCreator.TownSouthGateKey
            }
        };

        public static Models.Room AshburyNorthSquare = new Models.Room
        {
            RoomName = "Ashbury - North Square",
            InitialRoomDescription = "You're in the North Square of Ashbury.\n" +
                                     "All around you are darkened light posts, benches, and grassy areas.\n\n" +
                                     "It's a very pretty part of town, when it's illuminated and full of people.\n" +
                                     "Without those two things, it just feels like an abandoned town\n" +
                                     "with ghosts staring at you from the building windows.",
            GenericRoomDescription = "You're in the North Square of Ashbury.\n" +
                                     "The empty benches and darkened streetlights around you feel wrong...",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.WestForestNotice
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.AshburySquare
        };

        public static Models.Room AshburyEastSquare = new Models.Room
        {
            RoomName = "Ashbury - East Square",
            InitialRoomDescription = "You're in the East Square of Ashbury.\n" +
                                     "You know that, logically, everyone in town must be sleeping.\n" +
                                     "But somehow, as you observe the darkened second floor windows,\n" +
                                     "it almost feels like there isn't a single soul here at all...\n\n" +
                                     "The town feels lifeless.",
            GenericRoomDescription = "You're in the East Square of Ashbury.\n" +
                                     "The town feels lifeless... Like no one is here.",
            KeywordsToEnter = RoomKeywords.AshburySquare,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.TownEastGateKey.ItemName,
                RelevantItem = Program.ItemCreator.TownEastGateKey
            }
        };

        public static Models.Room AshburyWestSquare = new Models.Room
        {
            RoomName = "Ashbury - West Square",
            InitialRoomDescription = "You're in the West Square of Ashbury.\n" +
                                     "You can hear the wind lashing through the trees outside town to the West.\n" +
                                     "To you, the wind almost sounds angry...\n\n" +
                                     "The West Square looks like it hasn't had visitors in quite some time.\n" +
                                     "The other parts of town have looked somewhat more traversed, but the way\n" +
                                     "the West Square looks and feels is very odd compared to the rest of town.",
            GenericRoomDescription = "You're in the West Square of Ashbury.\n" +
                                     "This side of town feels off to you...",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.MissingPersonPosterPenny
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.AshburySquare
        };

        public static Models.Room AshburySouthMainStreet = new Models.Room
        {
            RoomName = "Ashbury - South Main Street",
            InitialRoomDescription = "You walk onto the South Main Street of Ashbury.\n" +
                                     "There's a large banner stretched across the road that says\n" +
                                     "\"Welcome to Quiet & Quaint Ashbury!\"\n" +
                                     "It dances occasionally in the sporadic gusts of wind.\n\n" +
                                     "Along the street on either side you spot the darkened shop windows of\n" +
                                     "the town grocery, veterinary clinic, and tavern.\n" +
                                     "You shine your flashlight through the clinic window on the West side of the street,\n" +
                                     "and for the slightest instant you think you see something moving around in there.",
            GenericRoomDescription = "You're standing on the South Main street of Ashbury.\n" +
                                     "You can see some dark shop windows and signs lining the sidewalk,\n" +
                                     "and a banner over the street saying:\n" +
                                     "\"Welcome to Quiet & Quaint Ashbury!\"",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>(),
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.AshburyMainStreet,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Crowbar.ItemName,
                RelevantItem = Program.ItemCreator.Crowbar
            }
        };

        public static Models.Room AshburyNorthMainStreet = new Models.Room
        {
            RoomName = "Ashbury - North Main Street",
            InitialRoomDescription = "Now you're standing on the North Main Street of Ashbury.\n" +
                                     "It's not as welcoming as South Main Street, but it's clear that \n" +
                                     "it's because of all the missing person posters on the buildings here.\n\n" +
                                     "You can see some more familiar building windows, like the Ashbury Theater,\n" +
                                     "Jack's Ice Cream Parlor, and the hardware store... but all of the shops\n" +
                                     "almost appear like they haven't been opened in ages.",
            GenericRoomDescription = "You're standing on the North Main street of Ashbury.\n" +
                                     "You can see some dark building windows and signs lining the sidewalk.\n" +
                                     "There are 'Missing Person' posters on many of the buildings.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.MissingPersonPosterSimon
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.AshburyMainStreet
        };

        public static Models.Room AshburyEastPlaza = new Models.Room
        {
            RoomName = "Ashbury - East Plaza",
            InitialRoomDescription = "You're in the East Plaza of Ashbury.\n" +
                                     "You feel very bothered to see the town so dark and so quiet.\n\n" +
                                     "You remember the East Plaza being home to great gatherings,\n" +
                                     "farmers markets, and cook-outs in the summertime... \n\n" +
                                     "In the light-less dark, chilled fall air it really doesn't feel like Ashbury...",
            GenericRoomDescription = "You're in the East Plaza of Ashbury.\n" +
                                     "In the light-less dark, chilled fall air it really doesn't feel like Ashbury...",
            KeywordsToEnter = RoomKeywords.AshburyPlaza
        };

        public static Models.Room AshburyWestPlaza = new Models.Room
        {
            RoomName = "Ashbury - West Plaza",
            InitialRoomDescription = "You're in the West Plaza of Ashbury.\n" +
                                     "There's a non-functioning fountain here in the center of the plaza.\n" +
                                     "You remember seeing children throwing coins into it when it was still Summer.\n\n" +
                                     "You also remember there being walkways going North and South from the plaza,\n" +
                                     "but those routes seem to have been boarded up and blocked off... \n\n" +
                                     "That seems pretty odd to you... Why would they board up paths inside the \n" +
                                     "town when the entire town is already walled off?",
            GenericRoomDescription = "You're in the West Plaza of Ashbury.\n" +
                                     "The walkways that you remember going North and South \n" +
                                     "from here are boarded up and blocked off...",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.ToyBoat
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.AshburyPlaza
        };

        public static Models.Room AshburyTownCenter = new Models.Room
        {
            RoomName = "Ashbury - Town Center",
            InitialRoomDescription = "You're in the Town Center of Ashbury.\n" +
                                     "The moon is bright here, and the Town Center looks really nice.\n" +
                                     "It's mostly a large grass plot, with a twenty-foot bronze statue\n" +
                                     "of Emmett Skepp - the town's first mayor - in the middle of the plot.\n\n" +
                                     "Encircling the area around the statue are weathered wood and metal benches,\n" +
                                     "some even look like they may fall apart if you sat down in one.\n" +
                                     "You recollect a time here, when you were much younger, sitting on the base\n" +
                                     "of the grand statue. Your mother had accompanied you, but you can't seem to\n" +
                                     "remember her face. She'd passed on when you were around five years old.",
            GenericRoomDescription = "You're in the Town Center of Ashbury.\n" +
                                     "The moon is brightly illuminating the twenty-foot bronze statue\n" +
                                     "of Emmett Skepp - the towns first mayor - in the middle of the \n" +
                                     "grass plot that makes up the center of town.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.BottleOfRum,
                    Program.ItemCreator.MissingPersonPosterArthur,
                    Program.ItemCreator.Crowbar
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.AshburyTownCenter
        };

        public static Models.Room AshburySouthSquareEastAlley = new Models.Room
        {
            RoomName = "SouthEast Alley",
            InitialRoomDescription = "You make your way into the brick-floored alley to the East of the South Square.\n" +
                                     "The red brick looks nice in the moonlight, and you're pretty blocked from the wind here.",
            GenericRoomDescription = "You're in a small, brick-floored alley just to the East of Ashbury's South Square.",
            KeywordsToEnter = RoomKeywords.AshburyAlley
        };

        public static Models.Room AshburySouthEastVeterinaryClinic = new Models.Room
        {
            RoomName = "Ashbury - Veterinary Clinic",
            InitialRoomDescription = "You open the back door into the Veterinary Clinic with no issues...\n" +
                                     "The door was unlocked.\n\n" +
                                     "You immediately note a disturbingly dead silence in here...\n" +
                                     "Not even a sign of any animals.\n\n" +
                                     "The floor and counter tops are a bright, sterile white.\n" +
                                     "It makes it easy to see with your flashlight.",
            GenericRoomDescription = "You entered the Veterinary Clinic through the unlocked back door.\n" +
                                     "The floor and counter tops are a bright, sterile white.\n" +
                                     "It's disturbingly quiet in here... and there aren't any animals.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.TownEastGateKey,
                    Program.ItemCreator.BrandNewFlashlightBattery
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.AshburySouthEastVeterinaryClinic,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room AshburySouthEastCornerLot = new Models.Room
        {
            RoomName = "Ashbury - SouthEast Corner Lot",
            InitialRoomDescription = "You walk out of the brick alleyway into an open lot.\n" +
                                     "It's a quaint corner of the town, it feels very peaceful.\n" +
                                     "It reminds you of a smaller version of a cul-de-sac.",
            GenericRoomDescription = "You're in the open lot,\n" +
                                     "It's quaint and peaceful, and reminds you of a miniature cul-de-sac.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.MissingPersonPosterDuncan
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.AshburySouthEastCornerLot
        };

        public static Models.Room AshburySouthEastDurrowHouse = new Models.Room
        {
            RoomName = "Ashbury - Durrow House",
            InitialRoomDescription = "You knock on the door of the Durrow house.\n" +
                                     "...No one answers.\n" +
                                     "You unlock the front door and walk inside. You loudly say \"Hello?\"...\n" +
                                     "... And hear silence in response.\n\n" +
                                     "It's really somber inside... You can feel sadness all around you.\n" +
                                     "You can see into the main room of the house, and it seems well-kept.\n\n" +
                                     "You recollect a time you'd enjoyed dinner here by invitation of Robert Durrow,\n" +
                                     "as well as his wife Lucy and their son Simon...\n" +
                                     "You quickly expel the memory from your mind, as it brings you great sorrow.\n\n" +
                                     "You hope your old friend Robert is doing ok, wherever he is.",
            GenericRoomDescription = "You're standing in the somber, cold home of the Durrow family.\n" +
                                     "It just reminds you of the time you had dinner here with Robert, Lucy, and Simon...",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.ForestGreenCargoPants,
                    Program.ItemCreator.ChildsDrawing,
                    Program.ItemCreator.NoteToRobertDurrow
                },
                WeaponItems = new List<WeaponItem>
                {
                    Program.ItemCreator.Shotgun
                }
            },
            KeywordsToEnter = RoomKeywords.AshburySouthEastDurrowHouse,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.TownDurrowHouseKey.ItemName,
                RelevantItem = Program.ItemCreator.TownDurrowHouseKey
            }
        };

        public static Models.Room AshburySouthEastAviary = new Models.Room
        {
            RoomName = "Ashbury - Aviary",
            InitialRoomDescription = "You go into the town Aviary, it's quite spacious and open inside.\n" +
                                     "There are no birds here anymore; you know it was mostly just a fad for a while.\n" +
                                     "Some of the residents really loved it, and cared for many birds here.\n\n" +
                                     "It's pretty dilapidated now, but there are still dozens of perches and toys\n" +
                                     "secured to and dangling from all parts of the cage's interior.",
            GenericRoomDescription = "You're inside a big outdoor bird cage. There are no birds, but the\n" +
                                     "entire cage is still full of perches and toys.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.MangledBallCap
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.AshburySouthEastAviary
        };

        public static Models.Room AshburySouthEastWell = new Models.Room
        {
            RoomName = "Ashbury - Community Well",
            InitialRoomDescription = "You approach the town well. It's a smaller than average stone well.\n" +
                                     "It's been around for some time. You heard someone tell you once that\n" +
                                     "it was built around the time of the Salem Witch trials. \n\n" +
                                     "It has the typical wench and pulley system as you'd expect, \n" +
                                     "with a bucket attached to the end of a rope.\n\n" +
                                     "The only thing out of the ordinary with the well is how deep it goes.\n" +
                                     "In fact, no one actually knows. You heard once from Henry\n" +
                                     "that Arthur Walden once threw a fish into it and a splash was never heard.",
            GenericRoomDescription = "You're at the Ashbury town well. \n" +
                                     "It's somewhat small in diameter, but it's dangerously deep.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.TownDurrowHouseKey
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = RoomKeywords.AshburySouthEastWell
        };


        public static Models.Room AshburySouthSquareWestAlley = new Models.Room
        {
            RoomName = "SouthWest Alley",
            InitialRoomDescription = "You make your way into the musty alley to the West of the South Square.\n" +
                                     "The alley is dark, concealed from the moonlight. \n" +
                                     "Sounds like rats are squeaking inside the walls of the alley.",
            GenericRoomDescription = "You're in a musty, dark alley just to the West of Ashbury's South Square.",
            KeywordsToEnter = RoomKeywords.AshburyAlley
        };
    }
}