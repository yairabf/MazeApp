using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Wpf_Client.model;

namespace Wpf_Client.viewModel
{
    class SP_GameVm:ViewModel
    {
        private SinglePlayerModel model;

        public SP_GameVm(SinglePlayerModel m)
        {
            this.model = m;
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };
        }

        /*public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }*/

       
        public string MazeAsStringProp
        {
            get { return model.MazeAsStringProp; }
            set
            {
                model.MazeAsStringProp = value;
                NotifyPropertyChanged("MazeAsStringProp");
            }
        }

        public void StartGame()
        {
            string generate = "generate " + Properties.Settings.Default.NameOfMaze + " " + Properties.Settings.Default.NumOfRows +
                              " " + Properties.Settings.Default.NumOfCol;
            this.model.StartGame(generate);
        }


        public int RowsProp
        {
            get { return model.RowsProp; }
            set
            {
                this.model.RowsProp = value;
                NotifyPropertyChanged("RowsProp");
            }
        }

        public int ColsProp
        {
            get { return model.ColsProp; }
            set
            {
                this.model.ColsProp = value;
                NotifyPropertyChanged("ColsProp");
            }
        }


    }
}



/*
 * public String NameOfMaze
        {
            get { return model.NameOfMaze; }
            set
            {
                model.NameOfMaze = value;
                NotifyPropertyChanged("NameOfMaze");
            }
        }
        public String MazeAsString
        {
            get
            {
                return model.mazeProp.ToString();
            }
            set
            {
                NotifyPropertyChanged("MazeAsString");
            }
        }
*/
