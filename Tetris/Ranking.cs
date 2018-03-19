using System;

namespace Tetris.Model
{
    // Serializable class, used to save scores and name in file "HighScores.xml"
    [Serializable()]
    public class Ranking
    {
        public int Score { get; set; }
        public string Name { get; set; }
    }
}
