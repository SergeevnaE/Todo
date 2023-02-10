using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Media;
using Desktop.Annotations;

namespace Desktop
{
    public class TaskModel : INotifyPropertyChanged
    {
        private string task;

        public string Task
        {
            get => task;
            set
            {
                task = value;
                OnPropertyChanged();
            }
        }
        public string Time { get; set; }

        private bool done;
        public bool Done { 
            get => done;
            set
            {
                done = value;
                OnPropertyChanged();
            }
         }

        private Brush checkBoxColor;
        public Brush CheckBoxColor {             
            get => checkBoxColor;
            set
            {
                checkBoxColor = value;
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
