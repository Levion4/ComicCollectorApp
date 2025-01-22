using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ComicCollectorApp.Model;
using System.Collections.ObjectModel;
using ComicCollectorApp.Model.Comics;

namespace ComicCollectorApp.ViewModel
{
    /// <summary>
    /// ViewModel главного окна.
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Comic> _comics = 
            new ObservableCollection<Comic>();

        private Comic _currentComic;

        /// <summary/>
        /// Отвечает за доступность элементов.
        /// </summary>
        [ObservableProperty]
        private bool _isAvailable = false;

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
                    IsAvailable = false;
                    //RemoveCommand.NotifyCanExecuteChanged();
                    //EditCommand.NotifyCanExecuteChanged();
                    //ApplyCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Команда на добавление комикса.
        /// </summary>
        [RelayCommand]
        private void Add()
        {
            
        }
    }
}
