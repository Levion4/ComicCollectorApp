using System.ComponentModel;

namespace ComicCollectorApp.Model.Comics
{
    /// <summary>
    /// Хранит информацию о комиксе.
    /// </summary>
    public class Comic : BaseModel
    {
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
        private bool _variantCover;

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
        private TypeComic _typeComic;

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
        public bool VariantСover
        { 
            get
            {
                return _variantCover;
            }
            set
            {
                if (value != _variantCover)
                {
                    _variantCover = value;
                    OnPropertyChanged(nameof(VariantСover));
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
            set
            {
                if (value != _typeComic)
                {
                    _typeComic = value;
                    OnPropertyChanged(nameof(TypeComic));
                }
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Comic"/>.
        /// </summary>
        public Comic()
        {
            _id = _allComicsCount++;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Comic"/>.
        /// </summary>
        /// <param name="year">Год выпуска.</param>
        /// <param name="title">Название.</param>
        /// <param name="image">Фотография/картинка.</param>
        /// <param name="variantCover">Признак варинтной обложки.</param>
        /// <param name="publisher">Издатель.</param>
        /// <param name="author">Автор.</param>
        /// <param name="language">Язык текста.</param>
        /// <param name="typeComic">Тип.</param>
        public Comic(int year, string title, byte[] image,
            bool variantCover, Publisher publisher, Author author,
            Language language, TypeComic typeComic)
        {
            Year = year;
            Title = title;
            Image = image;
            _variantCover = variantCover;
            Publisher = publisher;
            Author = author;
            Language = language;
            TypeComic = typeComic;

            _id = _allComicsCount++;
        }
    }
}