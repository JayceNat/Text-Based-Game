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

        public RoomModel YourBedroom = Room.CreateRoom(
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
    }
}