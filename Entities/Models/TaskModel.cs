using System.ComponentModel;
using System.Runtime.CompilerServices;
using Entities.Annotations;

namespace Entities.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        
        private bool _isChecked;
        public bool IsChecked {            
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged();
            } 
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}