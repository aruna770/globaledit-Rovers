using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace globaledit_Rovers
{
    public class Coordinates : IEquatable<Coordinates>
    {
        public int x { get; set; }
        public int y { get; set; }
        //public string direction { get; set; }
        

        public Coordinates() { }

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
            //this.direction = direction;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;
            Coordinates objAsPart = obj as Coordinates;
            
            if (objAsPart == null) 
                return false;
            else 
                return Equals(objAsPart);
        }

        public bool Equals(Coordinates other)
        {
            if (other == null) 
                return false;
            return (
                this.x.Equals(other.x) && this.y.Equals(other.y));
        }

        public override int GetHashCode()
        {
            return Tuple.Create(x, y).GetHashCode();
        }
    }
}
