using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RecipeBook.Settings
{
    public class NotifyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
