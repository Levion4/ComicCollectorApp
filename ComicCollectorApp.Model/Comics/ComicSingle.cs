namespace ComicCollectorApp.Model.Comics
{
    /// <summary>
    /// Хранит данные о синглах.
    /// </summary>
    public class ComicSingle : Comic
    {
        /// <summary>
        /// Номер выпуска в серии.
        /// </summary>
        private int _issueNumber;

        /// <summary>
        /// Номер версии печати.
        /// </summary>
        private int _numberPrintVersion;

        /// <summary>
        /// Признак "ключевого" выпуска.
        /// </summary>
        private bool _isKeyIssue;

        /// <summary>
        /// Возвращает и задает номер выпуска в серии.
        /// </summary>
        public int IssueNumber
        {
            get
            {
                return _issueNumber;
            }
            set
            {
                if (value != _issueNumber)
                {
                    _issueNumber = value;
                    OnPropertyChanged(nameof(IssueNumber));
                }
            } 
        }

        /// <summary>
        /// Возвращает и задает номер версии печати.
        /// </summary>
        public int NumberPrintVersion
        {
            get
            {
                return _numberPrintVersion;
            }
            set
            {
                if (value != _numberPrintVersion)
                {
                    _numberPrintVersion = value;
                    OnPropertyChanged(nameof(NumberPrintVersion));
                }
            }
        }

        /// <summary>
        /// Возвращает и задает признак "ключевого" выпуска.
        /// </summary>
        public bool IsKeyIssue
        {
            get
            {
                return _isKeyIssue;
            }
            set
            {
                if (value != _isKeyIssue)
                {
                    _isKeyIssue = value;
                    OnPropertyChanged(nameof(IsKeyIssue));
                }
            }
        }

        /// <summary>
        /// Создает клон экземпляра класса <see cref="Comic"/>.
        /// </summary>
        /// <returns>Возвращает клон экземпляра.</returns>
        public object Clone()
        {
            return new ComicSingle(IssueNumber, NumberPrintVersion,
                IsKeyIssue, Year, Title, Image, IsVariantСover,
                Publisher, Author, Language, TypeComic);
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="ComicSingle"/>.
        /// </summary>
        public ComicSingle()
        {
            _id = _allComicsCount++;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="ComicSingle"/>.
        /// </summary>
        /// <param name="issueNumber">Номер комикса в серии.</param>
        /// <param name="numberPrintVersion">Номер версии печати.</param>
        /// <param name="isKeyIssue">Признак "ключевого" комикса.</param>
        /// <param name="year">Год выпуска.</param>
        /// <param name="title">Название.</param>
        /// <param name="image">Фотография/картинка.</param>
        /// <param name="variantCover">Признак варинтной обложки.</param>
        /// <param name="publisher">Издатель.</param>
        /// <param name="author">Автор.</param>
        /// <param name="language">Язык текста.</param>
        /// <param name="typeComic">Тип.</param>
        public ComicSingle(int issueNumber, int numberPrintVersion,
            bool isKeyIssue, int year, string title, byte[] image,
            bool variantCover, Publisher publisher, Author author,
            Language language, TypeComic typeComic)
            : base(year, title, image, variantCover, publisher,
                  author, language, typeComic)
        {
            IssueNumber = issueNumber;
            NumberPrintVersion = numberPrintVersion;
            IsKeyIssue = isKeyIssue;

            _id = _allComicsCount++;
        }
    }
}
