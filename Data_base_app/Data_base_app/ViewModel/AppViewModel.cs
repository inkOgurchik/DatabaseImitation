using Data_base_app.Model;
using Data_base_app.Services;
using Data_base_app.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Data_base_app.ViewModel
{
    class AppViewModel :ViewModelBase
    {
        private ObservableCollection<Employee> _database;
        public ObservableCollection<Employee> Database { 
            get
            {
                return _database;
            }
            set
            {
                _database = value;
                OnPropertyChanged("Database");
            }
        }

        private Employee? _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        private Employee? _newEmployee;

        private Command? _changeThemeCommandHandler;
        private Command? _exportCommandHandler;
        private Command? _importCommandHandler;
        private Command? _exitCommandHandler;

        private Command? _openEditWindowCommandHandler;
        private Command? _openAddWindowCommandHandler;

        private Command? _deleteCommandHandler;


        //не меняется тема для главного окна
        //только для новых создаваемых
        public Command ChangeThemeCommandHandler
        {
            get
            {
                return _changeThemeCommandHandler ??
                    (_changeThemeCommandHandler = new Command(obj =>
                    {
                        Uri uri;
                        bool isDarkTheme = (bool)obj;
                        ResourceDictionary oldDict;

                        if (isDarkTheme)
                        {
                            uri = new Uri(@"Resourses\DarkTheme.xaml", UriKind.Relative);
                            oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                                             where d.Source.OriginalString.StartsWith("Resourses/Dictionary.xaml")
                                                             select d).First();
                        }
                        else
                        {
                            uri = new Uri(@"Resourses\LightTheme.xaml", UriKind.Relative);
                            oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                                          where d.Source.OriginalString.StartsWith("Resourses/Dictionary.xaml")
                                                          select d).First();
                        }
                        
                        var resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
                        Application.Current.Resources.Remove(oldDict);
                        Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
                    }));
            }
        }

        public Command ExportCommandHandler
        {
            get
            {
                return _exportCommandHandler ??
                    (_exportCommandHandler = new Command(obj =>
                    {
                        string fileType = obj.ToString();
                        var dialogService = new DefaultDialogService(fileType);
                        try
                        {
                            if (dialogService.SaveFileDialog() == true)
                            {
                                switch (fileType)
                                {
                                    case ("json"):
                                        JsonFileService.Save(dialogService.FilePath, Database.ToList());
                                        break;
                                    case ("xml"):
                                        XmlFileService.Save(dialogService.FilePath, Database.ToList());
                                        break;
                                }
                                dialogService.ShowMessage("File saved");
                            }
                        }
                        catch (Exception ex)
                        {
                            dialogService.ShowMessage(ex.Message);
                        }

                    }));
            }
        }

        public Command ImportCommandHandler
        {
            get
            {
                return _importCommandHandler ??
                    (_importCommandHandler = new Command(obj =>
                    {
                        string fileType = obj.ToString();
                        var dialogService = new DefaultDialogService(fileType);
                        try
                        {
                            if (dialogService.OpenFileDialog() == true)
                            {
                                List<Employee> employees = new List<Employee>();
                                switch (fileType)
                                {
                                    case ("json"):
                                        employees = JsonFileService.Open(dialogService.FilePath);
                                        break;
                                    case ("xml"):
                                        employees = XmlFileService.Open(dialogService.FilePath);
                                        break;
                                }
                                Database.Clear();
                                foreach (var p in employees)
                                    Database.Add(p);
                            }
                        }
                        catch (Exception ex)
                        {
                            dialogService.ShowMessage(ex.Message);
                        }
                    }));
            }
        }

        public Command ExitCommandHandler
        {
            get
            {
                return _exitCommandHandler ??
                    (_exitCommandHandler = new Command(obj =>
                    {
                        if (MessageBox.Show("Are you sure you want to exit without saving?",
                                       "Configuration",
                                       MessageBoxButton.YesNo,
                                       MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            Application.Current.MainWindow.Close();
                        }
                    }));
            }
        }

        public Command OpenAddWindowCommandHandler
        {
            get
            {
                return _openAddWindowCommandHandler ??
                  (_openAddWindowCommandHandler = new Command(obj =>
                  {
                      _newEmployee = new Employee();

                      var viewModel = new AddEmployeeViewModel(_newEmployee, ()=> _database.Add(_newEmployee));
                      var addEmployeeWindow = new AddEmployeeWindow1();
                      addEmployeeWindow.DataContext = viewModel;

                      addEmployeeWindow.Owner = Application.Current.MainWindow;
                      addEmployeeWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                      addEmployeeWindow.ShowDialog();
                  }));
            }
        }

        public Command OpenEditWindowCommandHandler
        {
            get
            {
                return _openEditWindowCommandHandler ??
                  (_openEditWindowCommandHandler = new Command(obj =>
                  {
                      if (_selectedEmployee != null)
                      {
                          var viewModel= new EditEmployeeViewModel(_selectedEmployee);
                          var editEmployeeWindow = new EditEmployeeWindow1();
                          editEmployeeWindow.DataContext = viewModel;

                          editEmployeeWindow.Owner = Application.Current.MainWindow;
                          editEmployeeWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                          editEmployeeWindow.ShowDialog();
                      }
                      else
                          MessageBox.Show("Employee is not selected!");
                  }));
            }
        }

        public Command DeleteCommandHandler
        {
            get
            {
                return _deleteCommandHandler ??
                    (_deleteCommandHandler = new Command(obj =>
                    {
                        if (_selectedEmployee != null)
                        {
                            string message = "Do you really want to delete employee \"" + _selectedEmployee.Name + "\"?";
                            if (MessageBox.Show(message,
                                            "Configuration",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                Database.Remove(_selectedEmployee);
                            }
                        }
                        else
                            MessageBox.Show("Employee is not selected!");

                    }));
            }
        }

        public AppViewModel()
        {
            _database = new ObservableCollection<Employee>();
        }

    }
}
