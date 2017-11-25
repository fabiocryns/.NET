using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBChess.Shared {
    public enum PawnTypes : int {
        Bishop = 3,
        King = 0,
        Knight = 4,
        Pawn = 5,
        Queen = 1,
        Rook = 2,
        None = -1,
        PossibleMove = 6
    }
}