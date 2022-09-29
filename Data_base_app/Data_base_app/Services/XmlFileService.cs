using Data_base_app.Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Data_base_app.Services
{
    internal static class XmlFileService
    {
        public static List<Employee> Open(string filepath)
        {
            var employees = new List<Employee>();
            XmlSerializer xmlFormatter =
                new XmlSerializer(typeof(List<Employee>));
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                employees = xmlFormatter.Deserialize(fs) as List<Employee>;
            }
            return employees;
        }

        public static void Save(string filepath, List<Employee> employees)
        {
            XmlSerializer writer =
                new XmlSerializer(typeof(List<Employee>));
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            writer.Serialize(fs, employees);
            fs.Close();
        }
    }
}
