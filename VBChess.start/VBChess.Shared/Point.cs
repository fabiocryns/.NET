using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBChess.Shared {
    public class Point {
        public Point(int x = 0, int y = 0) {
            this.X = x;
            this.Y = y;
        }
        public int X { get; }
        public int Y { get; }

        public static  bool operator ==(Point one, Point two) {
            if ((object)one == null && (object)two == null)
                return true;
            if((object)one == null || (object)two == null)
                return false;
            return one.X == two.X && one.Y == two.Y;
        }
        public static bool operator !=(Point one, Point two) {
            if((object)one == null && (object)two == null)
                return false;
            if((object)one == null || (object)two == null)
                return true;
            return one.X != two.X || one.Y != two.Y;
        }
        public override bool Equals(object obj) {
            var p = obj as Point;
            if(p == null)
                return false;
            else
                return p.X == this.X && p.Y == this.Y;
        }
        public override int GetHashCode() => this.X.GetHashCode() ^ this.Y.GetHashCode();
    }
}
