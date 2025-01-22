using ComicCollectorApp.Model.Comics;

namespace ComicCollectorApp.Model
{
    /// <summary>
    /// Хранит данные об авторе.
    /// </summary>
    public class Author : BaseEntity
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="name">Полное имя автора.</param>
        public Author(string name) : base(name) {}
    }
}
