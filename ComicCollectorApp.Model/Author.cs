namespace ComicCollectorApp.Model
{
    /// <summary>
    /// Хранит данные об авторе.
    /// </summary>
    public class Author : BaseEntity
    {
        /// <summary>
        /// Счетчик всех существующих объектов авторов.
        /// </summary>
        private static int _authorCount;

        /// <summary>
        /// Создает экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="name">Полное имя автора.</param>
        public Author(string name) : base(name) 
        {
            _id = ++_authorCount;
        }
    }
}
