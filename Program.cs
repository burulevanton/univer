using System;
using System.Collections.Generic;
using System.IO.Enumeration;

namespace Chemistry
{
    class Program
    {
        static void Main(string[] args)
        {
           Element C = new Element("C",6, 12, 14, 2);
           Element O = new Element("O", 8, 16, 16, 2);
            C.AddIsotope(12, 12, 0.9893);
            foreach (var isotope in C.Isotopes)
            {
                Console.WriteLine(isotope);
            }
            List<AtomStack> list = new List<AtomStack>();
            AtomStack c_atom_isotope = new AtomStack(C.PrincipalIsotope,1);
            AtomStack c_atom = new AtomStack(C);
            AtomStack o_atom = new AtomStack(O, 2);
            list.Add(c_atom_isotope);
            list.Add(o_atom);
            list.Add(c_atom_isotope);
            Compound co2 = new Compound(list);
            co2.Electrons -= 1;
            Ion test_ion = (Ion) co2;
            Console.WriteLine(test_ion);
            AtomStack test = (AtomStack) co2;
            Compound test_compound = new Compound(new[] {test});
            Console.WriteLine(co2.With(O));
            //Console.WriteLine(test);
        }
    }
}
