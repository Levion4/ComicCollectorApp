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
    public abstract class BaseModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие для уведомления об изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Уведомляет интерфейс об изменении свойства.
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства.</param>
        internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
