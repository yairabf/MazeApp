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

        public event PropertyChangedEventHandler PropertyChanged;

        /*public String MazeAsString
        {
            get
            {
                return model.mazeProp.ToString();
            }
            set
            {
                NotifyPropertyChanged("MazeAsString");
            }
        }*/


        public string MazeAsStringProp
        {
            get { return model.MazeAsStringProp; }
            set
            {
                model.MazeAsStringProp = value;
                NotifyPropertyChanged("MazeAsString");
            }
        }

        /*public string MazeSolution
        {
            get { return model.SolveGame(); }
            set
            {
                NotifyPropertyChanged("Solution");
            }
        }*/

        public int Rows
        {
            get { return model.NumOfRows; }
            set
            {
                this.model.NumOfRows = value;
                NotifyPropertyChanged("Rows");
            }
        }

        public int Cols
        {
            get { return model.NumOfCol; }
            set
            {
                this.model.NumOfCol = value;
                NotifyPropertyChanged("Cols");
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
