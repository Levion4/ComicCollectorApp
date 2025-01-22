namespace ComicCollectorApp.Core.Services
{
    /// <summary>
    /// Интерфейс для работы с диалогами выбора файлов.
    /// </summary>
    public interface IFileDialogService
    {
        /// <summary>
        /// Открывает диалог выбора файла.
        /// </summary>
        /// <param name="filter">Фильтр для выбора файлов,
        /// например "Image Files|*.jpg;*.jpeg;*.png;*.bmp".</param>
        /// <returns>Путь к выбранному файлу или null,
        /// если выбор отменён.</returns>
        string OpenFile(string filter);
    }
}
