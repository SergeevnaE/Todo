using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Entities.Annotations;

namespace Entities.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        public Guid? Id { get; set; }
        [CanBeNull] public string Title { get; set; }
        [CanBeNull] public string Category { get; set; }
        [CanBeNull] public string Description { get; set; }
        [CanBeNull] public long Date { get; set; }
        [CanBeNull] public string Time { get; set; }
        
        private bool _isCompleted;
        public bool IsCompleted {            
            get => _isCompleted;
            set
            {
                _isCompleted = value;
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