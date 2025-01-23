using ComicCollectorApp.Model.Services;
using System.ComponentModel.DataAnnotations;

namespace ComicCollectorApp.Model.Comics
{
    /// <summary>
    /// Хранит данные о синглах.
    /// </summary>
    public class ComicSingle : Comic
    {
        /// <summary>
        /// Ограничение на количество символов
        /// в номере версии печати.
        /// </summary>
        private readonly int _maxLengthNumberPrintVersion = 2;

        /// <summary>
        /// Ограничение на количество символов
        /// в номере выпуска в серии.
        /// </summary>
        private readonly int _maxLengthIssueNumber = 10;

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
                    ClearError(nameof(IssueNumber));

                    var error = ValueValidator.AssertStringOnLength(
                        _issueNumber.ToString(),
                        _maxLengthIssueNumber,
                        nameof(IssueNumber));

                    if (error != null)
                    {
                        AddError(nameof(IssueNumber), error);
                    }

                    error = ValueValidator.AssertOnPositiveValue(
                        _issueNumber,
                        nameof(IssueNumber));

                    if (error != null)
                    {
                        AddError(nameof(IssueNumber), error);
                    }

                    OnPropertyChanged(nameof(HasErrors));
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
                    ClearError(nameof(NumberPrintVersion));

                    var error = ValueValidator.AssertStringOnLength(
                        _numberPrintVersion.ToString(),
                        _maxLengthNumberPrintVersion,
                        nameof(NumberPrintVersion));

                    if (error != null)
                    {
                        AddError(nameof(NumberPrintVersion), error);
                    }

                    error = ValueValidator.AssertOnPositiveValue(
                        _numberPrintVersion,
                        nameof(NumberPrintVersion));

                    if (error != null)
                    {
                        AddError(nameof(NumberPrintVersion), error);
                    }

                    OnPropertyChanged(nameof(HasErrors));
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
        /// Создает клон экземпляра класса <see cref="ComicSingle"/>.
        /// </summary>
        /// <returns>Возвращает клон экземпляра.</returns>
        public override object Clone()
        {
            return new ComicSingle(IssueNumber, NumberPrintVersion,
                IsKeyIssue, Year, Title, Image, IsVariantСover,
                Publisher, Author, Language);
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="ComicSingle"/>.
        /// </summary>
        public ComicSingle()
        {
            Author = new Author("");
            Publisher = new Publisher("");
            Language = new Language("");
            _typeComic = TypeComic.Single;
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
        public ComicSingle(int issueNumber, int numberPrintVersion,
            bool isKeyIssue, int year, string title, byte[] image,
            bool variantCover, Publisher publisher, Author author,
            Language language)
            : base(year, title, image, variantCover, publisher,
                  author, language)
        {
            IssueNumber = issueNumber;
            NumberPrintVersion = numberPrintVersion;
            IsKeyIssue = isKeyIssue;

            _id = _allComicsCount++;
            _typeComic = TypeComic.Single;
        }
    }
}
