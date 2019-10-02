﻿using System;
using System.Drawing;

namespace TextBasedGame.Game.Models
{
    [Serializable]
    public class GameTitle
    {
        public string Title { get; set; }

        public Color TitleTextColor { get; set; }

        public string Author { get; set; }

        public Color AuthorTextColor { get; set; }
    }
}