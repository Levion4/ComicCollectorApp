using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ComicCollectorApp.View.Converters
{
    /// <summary>
    /// Конвертер значений, который преобразовывает
    /// значение типа bool к обратному.
    /// </summary>
    public class ReverseBoolConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует пришедшее от привязки значение в тот
        /// тип, который понимается приемником привязки.
        /// </summary>
        /// <param name="value">Значение, которое надо преобразовать.</param>
        /// <param name="targetType">Тип, к которому надо
        /// преобразовать значение value.</param>
        /// <param name="parameter">Вспомогательный параметр.</param>
        /// <param name="culture">Текущая культура приложения.</param>
        /// <returns>Возвращает преобразованное значение.</returns>
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        /// <summary>
        /// Преобразует значение, которое понимается
        /// приемником привязки, в тип привязки.
        /// </summary>
        /// <param name="value">Значение, которое надо преобразовать.</param>
        /// <param name="targetType">Тип, к которому надо
        /// преобразовать значение value.</param>
        /// <param name="parameter">Вспомогательный параметр.</param>
        /// <param name="culture">Текущая культура приложения.</param>
        /// <returns>Возвращает преобразованное значение.</returns>
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
