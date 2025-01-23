using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ComicCollectorApp.Model;
using System.Collections.ObjectModel;
using ComicCollectorApp.Model.Comics;
using ComicCollectorApp.Core.Services;

namespace ComicCollectorApp.ViewModel
{
    /// <summary>
    /// ViewModel главного окна.
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {
        private readonly IFileDialogService _fileDialogService;

        [ObservableProperty]
        private ObservableCollection<Comic> _comics = 
            new ObservableCollection<Comic>();

        private Comic _currentComic;

        private Comic _cloneComic;

        private Comic _initialComic;

        private Comic _cloneComicSingle;

        private Comic _initialComicSingle;

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

        public IEnumerable<TypeComic> ComicTypes =>
            Enum.GetValues(typeof(TypeComic))
            .Cast<TypeComic>();
            //.Where(type => type != TypeComic.Single);

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
            //CurrentComic.TypeComic = ComicTypes.FirstOrDefault();
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

        public MainViewModel(IFileDialogService fileDialogService)
        {
            _fileDialogService = fileDialogService;
        }

        public MainViewModel()
        { 
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
    }
}
