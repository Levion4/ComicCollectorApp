namespace ComicCollectorApp.Model
{
    /// <summary>
    /// Хранит данные об издательстве.
    /// </summary>
    public class Publisher : BaseEntity
    {
        /// <summary>
        /// Счетчик всех существующих объектов издательств.
        /// </summary>
        private static int _publisherCount;

        /// <summary>
        /// Создает экземпляр класса <see cref="Publisher"/>.
        /// </summary>
        /// <param name="name">Название издательства.</param>
        public Publisher(string name) : base(name) 
        {
            _id = ++_publisherCount;
        }
    }
}
