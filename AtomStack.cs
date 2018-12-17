
using System;
using System.Linq;
using System.Text;
using Chemistry.Interfaces;

namespace Chemistry
{
    public class AtomStack
    {
        public AtomStack(Element element, int size = 1) : this(new Atom(element), size)
        {
        }

        public AtomStack(IAtomic atom, int size = 1)
        {
            Atom = atom;
            Size = size;
        }
        
        public IAtomic Atom { get; private set; }
        
        public int Size { get; set; }

        public static implicit operator AtomStack(Element element)
        {
            return new AtomStack(new Atom(element));
        }

        public static implicit operator AtomStack(Compound compound)
        {
            return new AtomStack(compound);
        }

        public static implicit operator AtomStack(Atom atom)
        {
            return  new AtomStack(atom);
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder();

            IAtomic atomic = Atom as Compound;

            if (atomic != null)
            {
                if (Size == 1)
                {
                    sb.Append($"{atomic}");
                    return sb.ToString();
                }

                sb.Append($"{Size}({atomic})");
                return sb.ToString();
            }

            sb.Append($"{Atom}{(Size == 1 ? string.Empty : Size.ToString())}");
            return sb.ToString();
        }

        public double? AtomicWeight => Atom.AtomicWeight * Size;
    }
}