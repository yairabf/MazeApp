using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Wpf_Client.model;

namespace Wpf_Client.viewModel
{
    //he
    class SP_MenuVm : ViewModel
    {
        private SinglePlayerModel model;

        public SP_MenuVm(SinglePlayerModel m)
        {
            this.model = m;
            /*model.PropertyChanged +=
                delegate(Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };*/
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public String NameOfMaze
        {
            get { return model.NameOfMaze; }
            set
            {
                model.NameOfMaze = value;
                NotifyPropertyChanged("NameOfMaze");
            }
        }

        public int NumOfRows
        {
            get { return model.NumOfRows; }
            set
            {
                model.NumOfRows = value;
                NotifyPropertyChanged("NumOfRows");
            }
        }


        public int NumOfCol
        {
            get { return model.NumOfCol; }
            set
            {
                model.NumOfCol = value;
                NotifyPropertyChanged("NumOfCols");
            }
        }

        public void StartGame()
        {
            model.StartGame();
        }

        public SinglePlayerModel Model
        {
            get
            {
                return this.model;

            }
        }
    }
}
