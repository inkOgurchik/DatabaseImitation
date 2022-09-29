

namespace Data_base_app.Interfaces
{
    internal interface IDialogService
    {
        void ShowMessage(string message);
        string FilePath { get; set; } 
        bool OpenFileDialog();
        bool SaveFileDialog();
    }
}
