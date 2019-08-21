using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Dwarfs
{
    public class Part
    {
        Button button = new Button();
        Coords Coords;
        string Type = "";

        public Part(Button i_Button,int i_X, int i_Y, string i_Type)
        {
            button = i_Button;
            Coords = new Coords(i_X, i_Y);
            SetType(i_Type);
        }

        public string GetType ()
        {
            return Type;
        } 

        public void SetType(string i_Type)
        {
            Type = i_Type;
            string styleName = ""; 
            switch(Type)
            {
                case Const.Type_Standard: styleName = Const.Type_Standard; break;
                case Const.Type_Base: styleName = Const.Type_Base; break;
                case Const.Type_Gold_Mine: styleName = Const.Type_Gold_Mine; break;
                case Const.Type_Stone_Quarry: styleName = Const.Type_Stone_Quarry; break;
                case Const.Type_Stone_Wall: styleName = Const.Type_Stone_Wall; break;
                case Const.Type_Village_Ground: styleName = Const.Type_Village_Ground; break;
                case Const.Type_Goblin_Land: styleName = Const.Type_Goblin_Land; break;
                case Const.Type_Goblin: styleName = Const.Type_Goblin; break;
            }

            button.Style = (Style)Application.Current.Resources[styleName + "_Field_Button"];
        }
        
    }
}
