using System.ComponentModel;

namespace Wpf_Client.model
{
    /// <summary>
    /// The ameModel interface.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    interface GameModel : INotifyPropertyChanged
    {
        void StartGame(string generate);
    }
}
