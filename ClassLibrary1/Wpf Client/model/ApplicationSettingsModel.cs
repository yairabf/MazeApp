using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Client.model
{
    class ApplicationSettingsModel : ISettingsModel
    {
        public string ServerIP
        {
            get { return Properties.Settings.Default.ServerIP; }
            set { Properties.Settings.Default.ServerIP = value; }
        }
        public int ServerPort
        {
            get { return Properties.Settings.Default.ServerPort; }
            set { Properties.Settings.Default.ServerPort = value; }
        }
        //…
        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }

        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
        public int SearchAlgorithm {
            get { return SearchAlgorithm; }
            set { Properties.Settings.Default.SearchAlgorithm = value; }
        }
    }
}
