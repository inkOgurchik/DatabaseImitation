using Data_base_app.Model;
using System.Windows;

namespace Data_base_app.ViewModel
{
    internal class AddEmployeeViewModel:ViewModelBase
    {
        private Employee _newEmployee;

        private Command _confirmCommandHandler;
        public Employee NewEmployee
        {
            get
            {
                return _newEmployee;
            }
            set
            {
                _newEmployee = value;
                OnPropertyChanged("NewEmployee");
            }
        }

        public delegate void Add();
        public event Add AddEvent;

        public Command ConfirmCommandHandler
        {
            get
            {
                return _confirmCommandHandler ??
                  (_confirmCommandHandler = new Command(obj =>
                  {
                      var win = obj as Window;
                      AddEvent.Invoke();
                      win.DialogResult = true;
                  }));
            }
        }

        public AddEmployeeViewModel(Employee empl, Add addMethod)
        {
            _newEmployee = empl;
            AddEvent = addMethod;
        }
    }
}
