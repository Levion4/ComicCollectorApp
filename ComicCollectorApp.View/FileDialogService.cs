using Microsoft.Win32;
using ComicCollectorApp.Core.Services;

namespace ComicCollectorApp.View
{
    /// <summary>
    /// Реализация сервиса для работы с диалогами выбора файлов.
    /// </summary>
    public class FileDialogService : IFileDialogService
    {
        public string OpenFile(string filter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            { 
                Filter = filter
            };

            return openFileDialog.ShowDialog() ==
                true ? openFileDialog.FileName : null;
        }
    }
}
