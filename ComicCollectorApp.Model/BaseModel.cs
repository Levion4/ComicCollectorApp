using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ComicCollectorApp.Model
{
    /// <summary>
    /// Базовый класс для моделей (Model),
    /// реализующий интерфейс <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    /// <remarks>
    /// Этот класс используется для уведомления
    /// интерфейса пользователя об изменениях свойств,
    /// что позволяет автоматизировать обновление привязанных данных.
    /// </remarks>
    public abstract class BaseModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        /// <summary>
        /// Словарь ошибок.
        /// </summary>
        private readonly Dictionary<string, List<string>> _propertyErrors =
            new Dictionary<string, List<string>>();

        /// <summary>
        /// Событие для уведомления об изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Хранит событие на ошибки валидации.
        /// Зажигается при возникновении ошибки валидации.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        /// <inheritdoc/>
        public bool HasErrors => _propertyErrors.Any();

        /// <summary>
        /// Уведомляет интерфейс об изменении свойства.
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства.</param>
        internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <inheritdoc/>
        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        /// <summary>
        /// Добавляет ошибки в словарь.
        /// </summary>
        /// <param name="propertyName">Название свойства,
        /// где произошла ошибка.</param>
        /// <param name="errorMessage">Сообщение ошибки.</param>
        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        /// <summary>
        /// Удаляет ошибку из словаря.
        /// </summary>
        /// <param name="propertyName">Название свойства,
        /// ошибку которого нужно удалить.</param>
        public void ClearError(string propertyName)
        {
            if (_propertyErrors.Remove(propertyName))
            {
                OnPropertyChanged(propertyName);
            }
        }

        /// <summary>
        /// Зажигается при возникновении ошибки.
        /// </summary>
        /// <param name="propertyName">Название свойства,
        /// где произошла ошибка.</param>
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));
        }
    }
}
