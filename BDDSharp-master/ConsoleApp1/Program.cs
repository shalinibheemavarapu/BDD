using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCLouvain.BDDSharp;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new BDDManager(10);
            //var n3 = new BDDNode(2, manager.One, manager.One);
            //var n4 = new BDDNode(1, n3, manager.Zero);
            //var n2 = new BDDNode(1, n3, manager.Zero);
            //var n3 = manager.Create(2, manager.One, manager.One);
            //var n4 = manager.Create(1, n3, manager.Zero);
            //var n2 = manager.Create(1, n3, manager.Zero);
            //var root = manager.Create(0,n2, n4);
            //Console.WriteLine(n2);
            //Console.WriteLine(n3);
            //Console.WriteLine(n4);
            //Console.WriteLine(root);
            int index = 1;


            var p1_s = manager.Create(index++, manager.One, manager.Zero);
            var p1_k = manager.Create(index++, manager.One, manager.Zero);
            //var root = manager.Create(3, p1_s, p1_k);
            Console.WriteLine(p1_k);
            Console.WriteLine(p1_s);

            //var n2 = new BDDNode(1, p1_s, manager.Zero);
            var node = manager.Or(p1_k, p1_s);
            //node.Index = index++;
            var root = manager.Create(0, node, manager.Zero);
            Console.WriteLine(node);
            Console.WriteLine(root);
            //var reducedNode=manager.Reduce(root);
            //Console.WriteLine(reducedNode);
            var str = manager.ToDot(node);
            Console.WriteLine(str);
            //var root = new BDDNode(0, node, manager.Zero);
            //Console.WriteLine(root);
            //var node1 = manager.And(p1_k, p1_s);

            //var root1 = new BDDNode(0, node1, manager.Zero);
            //
            //var c = manager.Create(10, manager.Zero, manager.One);
            //string str = manager.Zero.ToString();
            //string str1 = manager.One.ToString();

            //Console.WriteLine(node1);


            //Console.WriteLine(node);
            //Console.WriteLine(node1);
            //Console.WriteLine(reucedBddNode);
            // --------------------------
            //Program p = new Program();
            //p.TestLarge01(30, 30);


            // Console.WriteLine(manager.ToDot(root));
            //var reucedBddNode = manager.Reduce(node);
            //Console.WriteLine(manager.ToDot(reucedBddNode));
            //Console.WriteLine(str);
            //Console.WriteLine(str1);

            //Console.WriteLine(root1);
            //Console.WriteLine(reucedBddNode);
            Console.Read();
            //var root =new BDDNode(0, P1_1&000&000BI, P1_1&000&000CSL, P1_1&500&000BI, P1_1&500&000CSL, P1_10&000&000BI, P1_10&000&000CSL, P1_100&000BI, P1_100&000CSL, P1_2&000&000BI, P1_2&000&000CSL, P1_200&000BI, P1_200&000CSL, P1_25&000BI, P1_25&000CSL, P1_3&000&000BI, P1_3&000&000CSL, P1_300&000BI, P1_300&000CSL, P1_4&000&000BI, P1_4&000&000CSL, P1_5&000&000BI, P1_5&000&000CSL, P1_50&000BI, P1_50&000CSL, P1_500&000BI, P1_500&000CSL)
            //   var P2_1&000&000BI = new BDDNode(2, false);

            //var P1_1 &000&000BI=new BDDNode(1,)



        }

        public void TestLarge01(int m1, int m2)
        {
            var manager = new BDDManager(0);
            Random r = new Random();
            var bdd = Generate(0, m1, m2,manager,r);

            Console.WriteLine("Number of nodes in BDD: " + manager.GetSize(bdd) + "/" + manager.N);
            bdd = manager.Sifting(bdd);
            Console.WriteLine("Number of nodes in BDD: " + manager.GetSize(bdd));
        }

        BDDNode Generate(int height, int max, int m2, BDDManager manager,Random r)
        {
            if (height > max)
            {
                var id = manager.CreateVariable();
                var v = manager.Create(id, manager.Zero, manager.One);
                //Console.WriteLine(manager.ToDot(v, (x) => "["+x.Id+"] x" + x.Index + " (" + x.RefCount.ToString() + ")"));
                return v;
            }
            else
            {
                var acc = GetAndOr(height, max, m2, manager,r);
                //Console.WriteLine(manager.ToDot(acc, (x) => "["+x.Id+"] x" + x.Index + " (" + x.RefCount.ToString() + ")"));
                for (int i = 0; i < m2; i++)
                {
                    //if (r.NextDouble() > .5)
                    //    acc = manager.Or(acc, Generate(height + 1, max, m2));
                    //else
                    acc = manager.And(acc, Generate(height + 1, max, m2,manager,r));

                    //Console.WriteLine(manager.ToDot(acc, (x) => "["+x.Id+"] x" + x.Index + " (" + x.RefCount.ToString() + ")"));
                }
                //Console.WriteLine(manager.ToDot(acc, (x) => "["+x.Id+"] x" + x.Index + " (" + x.RefCount.ToString() + ")"));
                //acc.RefCount++;
                //manager.GarbageCollect();
                //acc.RefCount--;
                //Console.WriteLine(manager.ToDot(acc, (x) => "["+x.Id+"] x" + x.Index + " (" + x.RefCount.ToString() + ")"));
                //int v = manager.GetSize(acc);
                //acc = manager.Sifting(acc);
                //throw new Exception();
                //Console.WriteLine ("  Number of nodes: " + v + " -> " + manager.GetSize(acc));
                return acc;
            }
        }

        private BDDNode GetAndOr(int height, int max, int m2, BDDManager manager,Random r)
        {
            if (r.NextDouble() > .5)
                return manager.Or(Generate(height + 1, max, m2, manager,r), Generate(height + 1, max, m2, manager,r));
            else
                return manager.And(Generate(height + 1, max, m2, manager,r), Generate(height + 1, max, m2, manager,r));
        }
    }
}

