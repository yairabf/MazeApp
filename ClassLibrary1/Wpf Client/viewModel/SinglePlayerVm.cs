using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using WpfMaze.model;
using Wpf_Client.model;

namespace Wpf_Client.viewModel
{
    //he
    class SinglePlayerVm:ViewModel
    {
        private SinglePlayerModel model;   
        public SinglePlayerVm(SinglePlayerModel m)
        {
            this.model = m;
            model.PropertyChanged +=
                delegate(Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public String NameOfMaze
        {
            get { return model.NameOfMaze; }
            set { model.NameOfMaze = value; }
        }

        public int NumOfRows
        {
            get { return model.NumOfRows; }
            set { model.NumOfRows = value; }
        }


        public int NumOfCol
        {
            get { return model.NumOfCol; }
            set { model.NumOfCol = value; }
        }

        public void StartGame()
        {
            model.StartGame();
        }

        public String MazeAsString
        {
            get { return model.mazeProp.ToString(); }
        }
      
       
    }
}
