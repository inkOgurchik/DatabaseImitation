using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Data_base_app.Model
{
    [DataContract]
    public class Employee : INotifyPropertyChanged, ICloneable, IExtensibleDataObject, IDataErrorInfo
    {
        private string _name;
        private string _position;
        private int _age;
        private bool _married;
        private DateTime _employmentDate;
        private Int64 _phone;


        [DataMember]
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        [DataMember]
        public string Position
        {
            get { return _position; }
            set 
            { 
                _position = value; 
                OnPropertyChanged("Position"); 
            }
        }

        [DataMember]
        public int Age
        {
            get { return _age; }
            set 
            { 
                _age = value; 
                OnPropertyChanged("Age"); 
            }
        }

        [DataMember]
        public bool Married
        {
            get { return _married; }
            set
            {
                _married = value;
                OnPropertyChanged("Married");
            }
        }

        [DataMember]
        public Int64 Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        [DataMember]
        public DateTime EmploymentDate
        {
            get { return _employmentDate; }
            set 
            { 
                _employmentDate = value; 
                OnPropertyChanged("EmploymentDate");
            }
        }

        public Employee()
        {
            _name = "";
            _position = "";
            _age = 18;
            _married = false;
            _employmentDate = DateTime.Now;
            _phone = 375290000000;
        }
        public Employee(string name, string position, int age, bool married, Int64 phone, DateTime employmentDate)
        {
            _name = name;
            _position = position;
            _age = age;
            _married = married;
            _phone = phone;
            _employmentDate = employmentDate;
        }

        public void Copy(Employee empl)
        {
            this.Name = empl.Name;
            this.Position = empl.Position;
            this.Age = empl.Age;
            this.Married = empl.Married;
            this.Phone = empl.Phone;
            this.EmploymentDate = empl.EmploymentDate;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        private ExtensionDataObject extensionDatavalue;
        public ExtensionDataObject ExtensionData
        {
            get => extensionDatavalue;
            set => extensionDatavalue = value;
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Age":
                        if ((Age < 18) || (Age > 100))
                        {
                            error = "Age must be between 18 and 100";
                        }
                        break;
                    case "Phone":
                        if ((Phone < 0) || (Phone > 375339999999))
                        {
                            error = "Invalid phone number format";
                        }
                        break;
                    case "EmploymentDate":
                        if ((EmploymentDate > DateTime.Now) || (EmploymentDate < new DateTime(1980, 1, 1)))
                        {
                            error = "Invalid data";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
