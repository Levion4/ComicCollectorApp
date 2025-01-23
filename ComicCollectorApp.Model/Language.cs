namespace ComicCollectorApp.Model
{
    /// <summary>
    /// Хранит данные о языке.
    /// </summary>
    public class Language : BaseEntity
    {
        /// <summary>
        /// Счетчик всех существующих объектов языков.
        /// </summary>
        private static int _languageCount;

        /// <summary>
        /// Создает экземпляр класса <see cref="Language"/>.
        /// </summary>
        /// <param name="name">Название издательства.</param>
        public Language(string name) : base(name)
        {
            _id = ++_languageCount;
        }
    }
}
