using Data_base_app.Model;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Data_base_app.Services
{
    internal static class JsonFileService
    {
        public static List<Employee> Open(string filepath)
        {
            var employees = new List<Employee>();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Employee>));
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                employees = jsonFormatter.ReadObject(fs) as List<Employee>;
            }

            return employees;
        }

        public static void Save(string filepath, List<Employee> employees)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Employee>));
            using (FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, employees);
            }
        }
    }
}
