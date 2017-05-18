using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Wpf_Client.model;

namespace Wpf_Client.viewModel
{
    class SinglePlayerVm
    {
        private SinglePlayerModel model;
        public SinglePlayerVm(SinglePlayerModel m)
        {
            this.model = m;
        }

        public String NameOfMaze
        {
            get { return model.NameOfMaze; }
            set { model.NameOfMaze = value; }
        }

        public String NumOfRows
        {
            get { return model.NumOfRows; }
            set { model.NumOfRows = value; }
        }

        public String NumOfColumns
        {
            get { return model.NumOfColumns; }
            set { model.NumOfColumns = value; }
        }

        public void StartGame()
        {
            model.StartGame();
        }


    }
}
