using System.Collections.Generic;
using TextBasedGame.Item;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room
{
    public class Rooms
    {
        private static readonly IRoom Room = new Implementations.Room();

        public static RoomModel YourBedroom = Room.CreateRoom(
            "Your Bedroom",
            "You are standing in your bedroom, next to your bed. \n" +
            "There's a faint, early morning light coming in through the blinds of your open window. \n" +
            "You can feel the cool autumn air coming in from outside.",
            "You are standing in your bedroom.",
            new List<RoomExitModel>()
            {
                RoomExits.YourLivingRoom
            }, 
            new ItemsModel
            {
                InventoryItems = new List<InventoryItemModel>()
                {
                    Items.RunningShoes
                },
                WeaponItems = new List<WeaponItemModel>()
                {
                    Weapons.BaseballBat
                }
            });

        public static RoomModel YourLivingRoom = Room.CreateRoom(
            "Your Living Room",
            "You are now standing in your living room. \n" +
            "You see the wind start blowing quite intensely through your living room windows. \n" +
            "Tree branches rattle and tap on the glass as the gusts of wind begin to calm down a bit. \n \n" +
            "Just then, you hear some strange and sudden *clank* sound from your kitchen.",
            "You are standing in your living room.",
            new List<RoomExitModel>()
            {
                // Kitchen,
                // Bathroom,
                // Basement (requires key)
                // Front entryway to leave house
            },
            new ItemsModel
            {
                InventoryItems = new List<InventoryItemModel>()
                {
                    // Book on something about the town you live in (maps?),
                    // A lighter next to a candle on the coffee table
                }
            });

    }
}