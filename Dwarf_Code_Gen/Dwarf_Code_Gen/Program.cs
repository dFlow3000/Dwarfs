using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarf_Code_Gen
{
    class Program
    {
        static void Main(string[] args)
        {
            Button_Grid_Generator();
            Console.ReadLine();
        }

        public static void Button_Grid_Generator()
        {
            for(int i = 0; i < 50; i++)
            {
                //Console.WriteLine("#region " + (i + 1).ToString() + " Row");
                Console.WriteLine("<!-- " + (i + 1).ToString() + ". Row ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->");
                for(int x = 0;  x < 50; x++)
                {

                    Console.WriteLine("<Button x:Name=\"GRID_" + (i < 10 ? "0" : "") + i.ToString() +"I" + (x < 10 ? "0" : "") + x.ToString() + "\" Grid.ColumnSpan=\"1\" Content=\"\" Grid.Column=\"" + i.ToString() + "\" " +
                                        "Grid.Row=\"" + x.ToString() + "\" Width=\"11\" Height=\"11\"/>");
                }
                //Console.WriteLine("#endregion");
            }
        }
    }
}
