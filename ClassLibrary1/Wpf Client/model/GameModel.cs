using System.ComponentModel;

namespace WpfMaze.model
{
    /// <summary>
    /// The ameModel interface.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    interface GameModel : INotifyPropertyChanged
    {
        void StartGame();

    }
}
