using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Desktop.Annotations;

namespace Desktop.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private bool isCheked; 
        public bool IsChecked {            
            get => isCheked;
            set
            {
                isCheked = value;
                OnPropertyChanged();    
            } }
        public string Title { get; set; }
        public string Time { get; set; }

        private Brush brush;
        public Brush BackgroundColor
        {
            get => brush;
            set
            {
                brush = value;
                OnPropertyChanged();    
            }
        }
        

        private Brush colorBorder;
        public Brush ColorBorder
        {
            get => colorBorder;
            set
            {
                colorBorder = value;
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