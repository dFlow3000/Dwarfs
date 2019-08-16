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
            //Button_Grid_Generator();
            FillField_Code_Generator();
            Console.ReadLine();
        }

        public static void Button_Grid_Generator()
        {
            for(int i = 0; i < 50; i++)
            {
                Console.WriteLine("<!--#region " + (i + 1).ToString() + " Row -->");
                Console.WriteLine("<!-- " + (i + 1).ToString() + ". Row ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->");
                for (int x = 0; x < 50; x++)
                {
                    if (i == 10 || i == 20 || i == 30 || i == 40 || x == 10 || x == 20 || x == 30 || x == 40)
                    {
                        Console.WriteLine("<Button x:Name=\"GRID_" + (i < 10 ? "0" : "") + i.ToString() + "I" + (x < 10 ? "0" : "") + x.ToString() + "\" Grid.ColumnSpan=\"1\" Content=\"\" Grid.Column=\"" + i.ToString() + "\" " +
                    "Grid.Row=\"" + x.ToString() + "\" Width=\"11\" Height=\"11\" Style=\"{ StaticResource Default_Field_Button_Overview}\"/>");
                    }
                    else
                    {
                        Console.WriteLine("<Button x:Name=\"GRID_" + (i < 10 ? "0" : "") + i.ToString() + "I" + (x < 10 ? "0" : "") + x.ToString() + "\" Grid.ColumnSpan=\"1\" Content=\"\" Grid.Column=\"" + i.ToString() + "\" " +
                                            "Grid.Row=\"" + x.ToString() + "\" Width=\"11\" Height=\"11\" Style=\"{ StaticResource Default_Field_Button}\"/>");
                    }
                }
                Console.WriteLine("<!--#endregion -->");
            }
        }

        public static void FillField_Code_Generator()
        {
            int idx = 0;
            for (int i = 0; i < 50; i++)
            {
                for (int x = 0; x < 50; x++)
                {
                    Console.WriteLine("GameFieldButton[" + idx.ToString() + "] = GRID_" + (i < 10 ? "0" : "") + i.ToString() + "I" + (x < 10 ? "0" : "") + x.ToString() + ";");
                    idx++;
                }
            }
        }
    }
}
