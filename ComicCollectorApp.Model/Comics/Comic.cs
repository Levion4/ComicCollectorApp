using ComicCollectorApp.Model.Services;

namespace ComicCollectorApp.Model.Comics
{
    /// <summary>
    /// Хранит информацию о комиксе.
    /// </summary>
    public class Comic : BaseModel, ICloneable
    {
        /// <summary>
        /// Ограничение на минимальное значение года комикса.
        /// </summary>
        private readonly int _minValueComicYear = 1896;

        /// <summary>
        /// Ограничение на количество символов
        /// в названии комикса.
        /// </summary>
        private readonly int _maxLengthTitle = 150;

        /// <summary>
        /// Год выпуска комикса.
        /// </summary>
        private int _year;

        /// <summary>
        /// Название комикса.
        /// </summary>
        private string _title;

        /// <summary>
        /// Фотография/картинка комикса.
        /// </summary>
        private byte[] _image;

        /// <summary>
        /// Признак варинтной обложки комикса.
        /// </summary>
        private bool _isVariantCover;

        /// <summary>
        /// Издатель комикса.
        /// </summary>
        private Publisher _publisher;

        /// <summary>
        /// Автор комикса.
        /// </summary>
        private Author _author;

        /// <summary>
        /// Язык текста комикса.
        /// </summary>
        private Language _language;

        /// <summary>
        /// Тип комикса.
        /// </summary>
        protected TypeComic _typeComic;

        /// <summary>
        /// Счетчик всех существующих объектов комиксов.
        /// </summary>
        protected static int _allComicsCount;

        /// <summary>
        /// Уникальный идентификатор для всех объектов
        /// данного класса.
        /// </summary>
        protected int _id;

        /// <summary>
        /// Возвращает и задает уникальный идентификатор
        /// комикса. Задает только во время инициализации.
        /// </summary>
        public int Id
        { 
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Возвращает и задает год выпуска комикса.
        /// </summary>
        public int Year
        { 
            get
            {
                return _year;
            }
            set
            {
                if (value != _year)
                {
                    _year = value;
                    ClearError(nameof(Year));

                    var error = ValueValidator.AssertValueInRange(
                        _year,
                        _minValueComicYear,
                        DateTime.Now.Year,
                        nameof(Year));

                    if (error != null)
                    {
                        AddError(nameof(Year), error);
                    }

                    OnPropertyChanged(nameof(HasErrors));
                    OnPropertyChanged(nameof(Year));
                }
            }
        }

        /// <summary>
        /// Возвращает и задает название комикса.
        /// </summary>
        public string Title
        { 
            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    ClearError(nameof(Title));

                    var error = ValueValidator.AssertStringOnLength(
                        _title.ToString(),
                        _maxLengthTitle,
                        nameof(Title));

                    if (error != null)
                    {
                        AddError(nameof(Title), error);
                    }

                    OnPropertyChanged(nameof(HasErrors));
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        /// <summary>
        /// Возвращает и задает фотографию/картинку комикса.
        /// </summary>
        public byte[] Image
        { 
            get
            {
                return _image;
            }
            set
            {
                if (value != _image)
                {
                    _image = value;
                    OnPropertyChanged(nameof(Image));
                }
            }
        }

        /// <summary>
        /// Возвращает и задает признак вариантной обложки комикса.
        /// </summary>
        public bool IsVariantСover
        { 
            get
            {
                return _isVariantCover;
            }
            set
            {
                if (value != _isVariantCover)
                {
                    _isVariantCover = value;
                    OnPropertyChanged(nameof(IsVariantСover));
                }
            }
        }

        /// <summary>
        /// Возвращает и задает автора комикса.
        /// </summary>
        public Author Author 
        { 
            get
            {
                return _author;
            }
            set
            {
                if (value != _author)
                {
                    _author = value;
                    OnPropertyChanged(nameof(Author));
                }
            }
        }

        /// <summary>
        /// Возвращает и задает издателя комикса.
        /// </summary>
        public Publisher Publisher 
        { 
            get
            {
                return _publisher;
            }
            set
            {
                if (value != _publisher)
                {
                    _publisher = value;
                    OnPropertyChanged(nameof(Publisher));
                }
            }
        }

        /// <summary>
        /// Возвращает и задает язык текста комикса.
        /// </summary>
        public Language Language
        {
            get
            {
                return _language;
            }
            set
            {
                if (value != _language)
                {
                    _language = value;
                    OnPropertyChanged(nameof(Language));
                }
            }
        }

        /// <summary>
        /// Возвращает и задает тип комикса.
        /// </summary>
        public TypeComic TypeComic
        {
            get
            {
                return _typeComic;
            }
            private set
            {
                _typeComic = value;
            }
        }

        /// <summary>
        /// Создает клон экземпляра класса <see cref="Comic"/>.
        /// </summary>
        /// <returns>Возвращает клон экземпляра.</returns>
        public virtual object Clone()
        {
            _id = _allComicsCount--;
            return new Comic(Year, Title, Image, IsVariantСover,
                Publisher, Author, Language);
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Comic"/>.
        /// </summary>
        public Comic()
        {
            _typeComic = TypeComic.Collection;
            _id = _allComicsCount++;
            _author = new Author("");
            _publisher = new Publisher("");
            _language = new Language("");
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Comic"/>.
        /// </summary>
        /// <param name="year">Год выпуска.</param>
        /// <param name="title">Название.</param>
        /// <param name="image">Фотография/картинка.</param>
        /// <param name="variantCover">Признак вариантной обложки.</param>
        /// <param name="publisher">Издатель.</param>
        /// <param name="author">Автор.</param>
        /// <param name="language">Язык текста.</param>
        public Comic(int year, string title, byte[] image,
            bool variantCover, Publisher publisher, Author author,
            Language language)
        {
            Year = year;
            Title = title;
            Image = image;
            IsVariantСover = variantCover;
            Publisher = publisher;
            Author = author;
            Language = language;

            _typeComic = TypeComic.Collection;
            _id = _allComicsCount++;
        }
    }
}