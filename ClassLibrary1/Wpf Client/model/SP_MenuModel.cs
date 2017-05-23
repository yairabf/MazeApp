using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Client.model
{
    class SP_MenuModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //properties of SP_MenuVm
        public int NumOfRows
        {
            get { return Properties.Settings.Default.NumOfRows; }
            set { Properties.Settings.Default.NumOfRows = value; }
        }

        public int NumOfCol
        {
            get { return Properties.Settings.Default.NumOfCol; }
            set { Properties.Settings.Default.NumOfCol = value; }
        }

        public string NameOfMaze
        {
            get { return Properties.Settings.Default.NameOfMaze; }
            set { Properties.Settings.Default.NameOfMaze = value; }
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
