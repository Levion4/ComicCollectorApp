using ComicCollectorApp.Model.Comics;
using System.Collections.ObjectModel;

namespace ComicCollectorApp.Model
{
    /// <summary>
    /// Хранит данные приложения.
    /// </summary>
    public class DataApp
    {
        /// <summary>
        /// Возвращает и задает коллекцию комиксов.
        /// </summary>
        public ObservableCollection<Comic> Comics { get; set; }

        /// <summary>
        /// Возвращает и задает коллекцию авторов.
        /// </summary>
        public ObservableCollection<Author> Authors { get; set; }

        /// <summary>
        /// Возвращает и задает коллекцию языков.
        /// </summary>
        public ObservableCollection<Language> Languages { get; set; }

        /// <summary>
        /// Возвращает и задает коллекцию издательств.
        /// </summary>
        public ObservableCollection<Publisher> Publishers { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="DataApp"/>.
        /// </summary>
        public DataApp()
        {
            Comics = new ObservableCollection<Comic>();
            Authors = new ObservableCollection<Author>();
            Languages = new ObservableCollection<Language>();
            Publishers = new ObservableCollection<Publisher>();
        }
    }
}
