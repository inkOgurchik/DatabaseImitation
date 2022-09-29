using Data_base_app.Interfaces;
using Microsoft.Win32;
using System.Windows;

namespace Data_base_app.Services
{
    internal class DefaultDialogService:IDialogService
    {
        public string FilePath { get; set; }
        public string FileFormat { get; set; }

        public DefaultDialogService(string format)
        {
            FileFormat = format;
        }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FileFormat + " files (*." + FileFormat + ")|*." + FileFormat;
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName + "." + FileFormat;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
