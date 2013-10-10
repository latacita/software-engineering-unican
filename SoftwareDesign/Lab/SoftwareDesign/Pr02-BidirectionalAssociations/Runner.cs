using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr02_BidirectionalAssociations.PeopleMustBeMarried
{
    class Runner
    {
        public static void Main() {

            Man man = new Man("Pablo");
            Woman scarlett = new Woman("Scarlett");
            Woman catherine = new Woman("Catherine");


            // I married Scarlett, which means Scarlett marries me
            man.Wife = scarlett;
            Console.WriteLine("Sucesfully married with Scarlett");

            // I get divorced with Scarlett :-(, which means Scarlett is free 
            man.Wife = null;
            Console.WriteLine("Sucesfully divorced from Scarlett");

            // I married Scarlett, but I got confused during the weeding and I married 
            // catherine in the end, so catherine is married with me
            man.Wife = scarlett;
            man.Wife = catherine;
            Console.WriteLine("Process finished");

            Console.ReadKey();
            
        }
    }
}
