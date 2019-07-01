using System;
using System.Collections.Generic;

namespace Chemistry
{
    public class Knowledge
    {
        public Knowledge()
        {
            var h = new Element("H", 1, 1.00784,1, 1);
            h.AddIsotope(1,1.00783,0.9985);
            h.AddIsotope(2,2.014,0.00115);
            var o = new Element("O", 8, 15.99,16,2);
            var ca = new Element("Ca", 20, 40.078, 2, 4);
            ca.AddIsotope(40, 39.96, 0.97);
            var c = new Element("C",6, 12.0106, 14, 2);
            c.AddIsotope(12, 12, 0.9893);
            c.AddIsotope(13, 13.00335, 0.0107);
            var p = new Element("P", 15, 30.9738, 15, 3);
            var na = new Element("Na", 11, 22.9898, 1, 3);
            var n = new Element("N", 7, 14.007, 15, 2);
            n.AddIsotope(14,14.003,0.97);
            var s = new Element("S", 16, 32.06, 16, 3);
            s.AddIsotope(32, 31.97207, 0.95);
            var al = new Element("Al", 13, 26.9816, 13, 3);
            var fe = new Element("Fe", 26, 55.845, 8, 4);
            var cl = new Element("Cl", 17, 35.45, 17, 3);
            var si = new Element("Si", 14, 28.085, 14, 3);
            var k = new Element("K", 19, 39.0983, 1, 4);
            k.AddIsotope(40, 39.963, 0.0017);
            var cu = new Element("Cu", 29, 63.546, 11, 4);
            var f = new Element("F", 9, 18.9984, 17,2);
            PeriodicTable.Add(h);
            PeriodicTable.Add(o);
            PeriodicTable.Add(ca);
            PeriodicTable.Add(c);
            PeriodicTable.Add(p);
            PeriodicTable.Add(na);
            PeriodicTable.Add(n);
            PeriodicTable.Add(s);
            PeriodicTable.Add(al);
            PeriodicTable.Add(fe);
            fe.AddIsotope(54, 53.9993, 0.05845);
            PeriodicTable.Add(cl);
            PeriodicTable.Add(si);
            PeriodicTable.Add(k);
            PeriodicTable.Add(cu);
            PeriodicTable.Add(f);
            _initKnownCompounds();
            _initKnownIonCompounds();
        }
        
        public List<Compound> KnownCompounds { get; } = new List<Compound>();
        
        public Dictionary<Compound, Tuple<int,int>> KnownIonCompounds { get; } = new Dictionary<Compound, Tuple<int, int>>();

        private void _initKnownCompounds()
        {
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("H"), 2),
                new AtomStack(PeriodicTable.GetElement("O")) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Ca")),
                new AtomStack(PeriodicTable.GetElement("O")) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("P"),2),
                new AtomStack(PeriodicTable.GetElement("O"),5) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Na")),
                new AtomStack(PeriodicTable.GetElement("O")), 
                new AtomStack(PeriodicTable.GetElement("H")) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("H")),
                new AtomStack(PeriodicTable.GetElement("N")), 
                new AtomStack(PeriodicTable.GetElement("O"),3) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("H"),2),
                new AtomStack(PeriodicTable.GetElement("S")), 
                new AtomStack(PeriodicTable.GetElement("S"),4) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("H"),3),
                new AtomStack(PeriodicTable.GetElement("P")), 
                new AtomStack(PeriodicTable.GetElement("O"),4), 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("H")),
                new AtomStack(PeriodicTable.GetElement("Cl")) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("H")),
                new AtomStack(PeriodicTable.GetElement("C")), 
                new AtomStack(PeriodicTable.GetElement("N")) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("N")),
                new AtomStack(PeriodicTable.GetElement("H"),3),
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Si"),3),
                new AtomStack(PeriodicTable.GetElement("N"),4) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("C")),
                new AtomStack(PeriodicTable.GetElement("O"),2) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Na")),
                new AtomStack(PeriodicTable.GetElement("Cl")) 
            }));
            KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("K")),
                new AtomStack(PeriodicTable.GetElement("N")), 
                new AtomStack(PeriodicTable.GetElement("O"),3), 
            }));KnownCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Cu")),
                new AtomStack(PeriodicTable.GetElement("S")), 
                new AtomStack(PeriodicTable.GetElement("O"),4), 
            }));
        }

        private void _initKnownIonCompounds()
        {
            KnownIonCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Na")),
                new AtomStack(PeriodicTable.GetElement("Cl")) 
            }), new Tuple<int, int>(1,1));
            KnownIonCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Na")),
                new AtomStack(PeriodicTable.GetElement("O")) 
            }), new Tuple<int, int>(1,2));
            KnownIonCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Ca")),
                new AtomStack(PeriodicTable.GetElement("F"),2) 
            }), new Tuple<int, int>(2,1));
            KnownIonCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Na"),2),
                new AtomStack(PeriodicTable.GetElement("O")) 
            }), new Tuple<int, int>(1,2));
            KnownIonCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Na")),
                new AtomStack(PeriodicTable.GetElement("F")) 
            }), new Tuple<int, int>(1,2));
            KnownIonCompounds.Add(new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("Ca")),
                new AtomStack(PeriodicTable.GetElement("Cl"),2) 
            }), new Tuple<int, int>(1,2));
        }

    }
}