using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace ComicCollectorApp.View.Converters
{
    /// <summary>
    /// Конвертер значений, который преобразует значение типа bool
    /// в значение, подходящее для свойства IsEnabled.
    /// </summary>
    public class BoolToIsEnabledConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует пришедшее от привязки значение в тот тип, 
        /// который понимается приемником привязки (IsEnabled).
        /// </summary>
        /// <param name="value">Значение, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, к которому надо преобразовать значение.</param>
        /// <param name="parameter">Вспомогательный параметр.</param>
        /// <param name="culture">Текущая культура приложения.</param>
        /// <returns>Возвращает преобразованное значение (true/false).</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                // Если параметр "Reverse" указан, инвертируем значение
                if (parameter != null && parameter.ToString().Equals("Reverse", StringComparison.OrdinalIgnoreCase))
                {
                    return !boolValue;
                }

                return boolValue;
            }

            return false; // По умолчанию, если значение не bool, возвращаем false
        }

        /// <summary>
        /// Обратное преобразование (не используется для IsEnabled).
        /// </summary>
        /// <param name="value">Значение, которое нужно преобразовать обратно.</param>
        /// <param name="targetType">Тип, к которому надо преобразовать значение.</param>
        /// <param name="parameter">Вспомогательный параметр.</param>
        /// <param name="culture">Текущая культура приложения.</param>
        /// <returns>Возвращает значение по умолчанию.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue; // Обратное преобразование не требуется
        }
    }
}
