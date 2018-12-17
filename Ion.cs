using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chemistry.Interfaces;

namespace Chemistry
{
    public class Ion : ICharged
    {
        public Ion(IAtomic content)
        {
            if(!content.IsIon())
                throw new ArgumentException("Не является ионом");
            Content = content;
        }
        
        public Ion(Element element, int charge = 0) : this(new Atom(element, charge)){}
        
        public Ion(IEnumerable<Atom> atoms) : this(new Compound(atoms.Select(x => new AtomStack(x)))) {}

        public bool IsPolyatomic => Content.IsCompound() && ((Compound) Content).Sum(x => x.Size) > 1;

        public bool IsCation => GetCharge() > 0;

        public bool IsAnion => GetCharge() < 0;

        public bool IsMonatomic => !Content.IsCompound();
        
        public IAtomic Content { get; }
        
        public int GetCharge() => -(Content.Electrons - Content.Protons);

        public static implicit operator Ion(Compound compound)
        {
            if (!compound.IsIon())
            {
                throw new ArgumentException(string.Format("Cоединение {} не является ионом", compound));
            }
            return new Ion(compound);
        }

        public static implicit operator Ion(Atom atom)
        {
            if(!atom.IsIon())
                throw new ArgumentException(string.Format("Атом {} не является ионом", atom));
            return new Ion(atom);
        }

        public Compound ToCompound()
        {
            return Content.IsCompound() ? (Compound) Content : null;
        }

        public Atom ToAtom()
        {
            return !Content.IsCompound() ? (Atom) Content : null;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", Content, IsAnion ? "-" : "+");
        }
    }
}