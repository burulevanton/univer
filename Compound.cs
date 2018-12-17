using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chemistry.Interfaces;

namespace Chemistry
{
    public class Compound : List<AtomStack>, IAtomic
    {
        public Compound(IEnumerable<AtomStack> enumerable, int charge = 0) : base(enumerable)
        {
            Electrons = this.Sum(x => x.Size * x.Atom.Electrons) - charge;
            Neutrons = this.Sum(x => x.Size * x.Atom.Neutrons);
            Protons = this.Sum(x => x.Size * x.Atom.Protons);

            Organize();
        }

        public double? AtomicWeight => this.Sum(x => x.AtomicWeight);
        public int Electrons { get; set; }
        public int Protons { get; }
        public int Neutrons { get; }
        public Ion ToIon()
        {
            if(!IsIon())
                throw new Exception("Невозможно преобразовать незаряженное соединение в ион");
            return new Ion(this);
        }

        public bool IsIon()
        {
            return Electrons != Protons;
        }

        public bool IsCompound() => true;

        public IEnumerable<Element> GetElements() => this.SelectMany(x => x.Atom.GetElements().Distinct());

        private void Organize()
        {
            foreach (var element in GetElements().ToArray())
            {
                int count = this.Count(x => Equals(x.Atom.GetElements().ToArray()[0], element) && x.Atom.GetType() != typeof(Isotope));

                if (count <= 1) continue;

                int size = this.Where(x => Equals(x.Atom.GetElements().ToArray()[0], element)).Sum(x => x.Size);
                var stack = new AtomStack(element, size);

                int index = FindIndex(x => x.Atom.GetElements().ToArray()[0].Equals(element));

                RemoveAll(x => x.Atom.GetElements().ToArray()[0].Equals(element));
                Insert(index, stack);
            }
        }

        public Compound With(Element element, int size = 1)
        {
            Add(new AtomStack(element, size));
            return this;
        }

        public Compound With(params IAtomic[] items)
        {
            AddRange(items.Select(x => new AtomStack(x)));
            return this;
        }

        public Compound With(params Element[] elements)
        {
            AddRange(elements.Select(x => new AtomStack(x)));
            return this;
        }

        public Compound With(params AtomStack[] stacks)
        {
            AddRange(stacks);
            return this;
        }

        public bool Contains(Element element) => GetElements().Any(x => x.Equals(element));

        public static implicit operator Compound(Element[] elements) => new Compound(elements.Select(x => new AtomStack(x)));
        
        public static implicit operator Compound(Atom[] atoms) => new Compound(atoms.Select(x => new AtomStack(x)));
        
        public static implicit operator Compound(AtomStack[] stacks) => new Compound(stacks);
        
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var stack in this)
                sb.Append(stack);

            return sb.ToString();
        }
    }
}