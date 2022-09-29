using Data_base_app.Model;
using System.Windows;

namespace Data_base_app.ViewModel
{
    internal class EditEmployeeViewModel:ViewModelBase
    {
        private Employee _newEmployee;
        private Employee _oldEmployee;

        private Command? _confirmCommandHandler;
        private Command _cancelCommandHandler;

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

        public Command ConfirmCommandHandler
        {
            get
            {
                return _confirmCommandHandler ??
                    (_confirmCommandHandler = new Command(obj =>
                    {
                        var win = obj as Window;
                        win.DialogResult = true;
                    }));
            }
        }

        public Command CancelCommandHandler
        {
            get
            {
                return _cancelCommandHandler ??
                    (_cancelCommandHandler = new Command(obj =>
                    {
                        var win = obj as Window;
                        _newEmployee.Copy(_oldEmployee);
                        win.DialogResult = false;
                    }));
            }
        }

        public EditEmployeeViewModel(Employee empl)
        {
            _oldEmployee = (Employee)empl.Clone();
            _newEmployee = empl;
        }

    }
}
