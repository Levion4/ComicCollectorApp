using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ComicCollectorApp.Model;
using System.Collections.ObjectModel;
using ComicCollectorApp.Model.Comics;
using ComicCollectorApp.Core.Services;
using ComicCollectorApp.ViewModel.Services;

namespace ComicCollectorApp.ViewModel
{
    /// <summary>
    /// ViewModel главного окна.
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {
        /// <summary>
        /// Сервис для взаимодействия с файловыми диалогами.
        /// </summary>
        private readonly IFileDialogService _fileDialogService;

        /// <summary>
        /// Коллекция комиксов.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Comic> _comics = 
            new ObservableCollection<Comic>();

        /// <summary>
        /// Коллекция авторов.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Author> _authors =
            new ObservableCollection<Author>();

        /// <summary>
        /// Коллекция языков.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Language> _languages =
            new ObservableCollection<Language>();

        /// <summary>
        /// Коллекция издательств.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Publisher> _publishers =
            new ObservableCollection<Publisher>();

        /// <summary>
        /// Данные приложения.
        /// </summary>
        private DataApp _dataApp;

        /// <summary>
        /// Текующий комикс.
        /// </summary>
        private Comic _currentComic;

        /// <summary>
        /// Клон комикса.
        /// </summary>
        private Comic _cloneComic;

        /// <summary>
        /// Изначальный комикс.
        /// </summary>
        private Comic _initialComic;

        /// <summary/>
        /// Отвечает за доступность элементов.
        /// </summary>
        [ObservableProperty]
        private bool _isAvailable = false;

        /// <summary/>
        /// Отвечает за доступность элементов комиксов типа "сингл".
        /// </summary>
        [ObservableProperty]
        private bool _isAvailableSingleComic = false;

        /// <summary>
        /// Возвращает и задает текущий комикс.
        /// </summary>
        public Comic CurrentComic
        {
            get 
            { 
                return _currentComic; 
            }
            set
            {
                if (SetProperty(ref _currentComic, value))
                {
                    IsAvailableSingleComic = false;
                    IsAvailable = false;
                    RemoveCommand.NotifyCanExecuteChanged();
                    EditCommand.NotifyCanExecuteChanged();
                    ApplyCommand.NotifyCanExecuteChanged();
                    AddPhotoCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Команда на применение изменений в комикс.
        /// </summary>
        [RelayCommand]
        private void Apply()
        {
            IsAvailable = false;
            IsAvailableSingleComic = false;

            if (_cloneComic != null)
            {
                int index = Comics.IndexOf(_initialComic);
                Comics[index] = _cloneComic;
                _cloneComic = null;
                CurrentComic = Comics[index];

                return;
            }

            if (!Comics.Contains(CurrentComic))
            {
                CurrentComic.Author = 
                    EnsureUnique(Authors, CurrentComic.Author);
                CurrentComic.Language = 
                    EnsureUnique(Languages, CurrentComic.Language);
                CurrentComic.Publisher = 
                    EnsureUnique(Publishers, CurrentComic.Publisher);

                Comics.Add(CurrentComic);
                return;
            }
        }

        /// <summary>
        /// Команда на удаление комикса.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CheckingCurrentComicForNull))]
        private void Remove()
        {
            if (Comics.Count > 1)
            {
                int index = Comics.IndexOf(CurrentComic);

                if (index == 0)
                {
                    CurrentComic = Comics[index + 1];
                }
                else
                {
                    CurrentComic = Comics[index - 1];
                }

                Comics.RemoveAt(index);
            }
            else
            {
                Comics.Remove(CurrentComic);
            }
        }

        /// <summary>
        /// Команда на изменение комикса.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CheckingCurrentComicForNull))]
        private void Edit()
        {
            _cloneComic = (Comic)CurrentComic.Clone();
            _initialComic = CurrentComic;
            CurrentComic = _cloneComic;

            if (CurrentComic != null && Comics.Count > 0)
            {
                IsAvailable = true;
                IsAvailableSingleComic = true;
            }
        }

        /// <summary>
        /// Команда на добавление комикса сингла.
        /// </summary>
        [RelayCommand]
        private void AddSingle()
        {
            CurrentComic = null;
            CurrentComic = new ComicSingle();
            IsAvailable = true;
            IsAvailableSingleComic = true;
        }

        /// <summary>
        /// Команда на добавление комикса сборника.
        /// </summary>
        [RelayCommand]
        private void AddCollection()
        {
            CurrentComic = null;
            CurrentComic = new Comic();
            IsAvailable = true;
            IsAvailableSingleComic = false;
        }

        /// <summary>
        /// Команда на добавление фотографии комикса.
        /// </summary>
        [RelayCommand]
        private void AddPhoto()
        {
            var filePath = _fileDialogService.OpenFile("Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png");

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                var imageBytes = File.ReadAllBytes(filePath);
                if (CurrentComic != null)
                {
                    CurrentComic.Image = imageBytes;
                }
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="MainViewModel"/>
        /// с предоставленным сервисом диалогов файлов.
        /// </summary>
        /// <param name="fileDialogService">
        /// Интерфейс сервиса для работы с файловыми диалогами.
        /// </param>
        public MainViewModel(IFileDialogService fileDialogService)
        {
            _fileDialogService = fileDialogService;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="MainViewModel"/>
        /// с зависимостями по умолчанию. 
        /// </summary>
        public MainViewModel()
        { 
        }

        /// <summary>
        /// Сохраняет данные.
        /// </summary>
        public void Save()
        {
            _dataApp.Comics = Comics;
            _dataApp.Authors = Authors;
            _dataApp.Publishers = Publishers;
            _dataApp.Languages = Languages;
            DataAppSerializer.SaveToFile(_dataApp);
        }

        /// <summary>
        /// Загружает данные.
        /// </summary>
        public void Load()
        {
            _dataApp = DataAppSerializer.LoadFromFile();
            Comics = _dataApp.Comics;
            Authors = _dataApp.Authors;
            Publishers = _dataApp.Publishers;
            Languages = _dataApp.Languages;
        }

        /// <summary>
        /// Проверяет выбранный комикс на null.
        /// </summary>
        /// <returns>Возвращает false,
        /// если комикс равен null, иначе true.</returns>
        private bool CheckingCurrentComicForNull()
        {
            if (CurrentComic != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверяет, существует ли элемент с таким же именем в коллекции.
        /// Если элемент найден, возвращает его. Если не найден,
        /// добавляет новый элемент в коллекцию.
        /// </summary>
        /// <typeparam name="T">Тип элемента
        /// коллекции.</typeparam>
        /// <param name="collection">Коллекция
        /// для проверки уникальности.</param>
        /// <param name="newItem">Элемент,
        /// который нужно проверить и добавить при отсутствии.</param>
        /// <returns>Существующий элемент или добавленный новый.</returns>
        private T EnsureUnique<T>(ICollection<T> collection, T newItem) where T : class
        {
            var existingItem = collection.FirstOrDefault(item =>
                item.GetType().GetProperty("Name")?.GetValue(item)?.ToString() ==
                newItem.GetType().GetProperty("Name")?.GetValue(newItem)?.ToString());

            if (existingItem != null)
            {
                return existingItem;
            }

            collection.Add(newItem);
            return newItem;
        }
    }
}
