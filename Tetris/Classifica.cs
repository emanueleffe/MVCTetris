using System;

namespace Tetris.Model
{
    // Classe serializzabile, utilizzata per salvare il punteggio e nome sul file "classifica.xml"
    [Serializable()]
    public class Classifica
    {
        public int Punteggio { get; set; }
        public string Nome { get; set; }
    }
}
