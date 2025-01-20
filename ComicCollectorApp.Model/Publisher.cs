namespace ComicCollectorApp.Model
{
    /// <summary>
    /// Хранит данные об издательтве.
    /// </summary>
    public class Publisher : BaseEntity
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="Publisher"/>.
        /// </summary>
        /// <param name="name">Название издательства.</param>
        public Publisher(string name) : base(name) { }
    }
}
