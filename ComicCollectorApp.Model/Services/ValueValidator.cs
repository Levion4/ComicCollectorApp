namespace ComicCollectorApp.Model.Services
{
    /// <summary>
    /// Предоставляет методы для валидации.
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Проверяет, чтобы строка не превышала заданную длину.
        /// </summary>
        /// <param name="value">Строка для проверки.</param>
        /// <param name="maxLength">Максимальная допустимая длина.</param>
        /// <param name="propertyName">Имя свойства 
        /// для сообщений об ошибке.</param>
        /// <returns>Сообщение об ошибке или null,
        /// если строка валидна.</returns>
        public static string? AssertStringOnLength(
            string value, int maxLength, string propertyName)
        {
            if (value.Length > maxLength)
            {
                return $"The {propertyName} must be no longer" +
                    $" than {maxLength} characters, but was {value.Length}.";
            }

            return null;
        }

        /// <summary>
        /// Проверяет, что значение положительное.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="propertyName">Имя свойства или объекта, которое
        /// подлежит проверке.</param>
        /// <returns>Сообщение об ошибке или null,
        /// если строка валидна.</returns>
        public static string? AssertOnPositiveValue(
            int value, string propertyName)
        {
            if (value <= 0)
            {
                return $"The {propertyName} cannot be negative" +
                    $" or equal to zero, but was {value}.";
            }

            return null;
        }

        /// <summary>
        /// Проверяет, что строка состоит только из букв.
        /// </summary>
        /// <param name="value">Проверямая строка.</param>
        /// <param name="propertyName">Имя свойства или объекта, которое
        /// подлежит проверке.</param>
        /// <returns>Сообщение об ошибке или null,
        /// если строка валидна.</returns>
        public static string? AssertStringContainsOnlyLetters(
            string value, string propertyName)
        {
            for (var i = 0; i < value.Length; i++)
            {
                if (!char.IsLetter(value[i]))
                {
                    return $"{propertyName} must contains letters only.";
                }
            }

            return null;
        }

        /// <summary>
        /// Проверяет, что значение входит в заданный диапазон.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="min">Нижняя граница диапазона.</param>
        /// <param name="max">Верхняя граница диапазона.</param>
        /// <param name="propertyName">Имя свойства или объекта, которое
        /// подлежит проверке.</param>
        /// <returns>Сообщение об ошибке или null,
        /// если строка валидна.</returns>
        public static string? AssertValueInRange(
            int value, int min, int max, string propertyName)
        {
            if (value < min || value > max)
            {
                return $"The {propertyName} should be in the range " +
                    $"from {min} to {max}, but was {value}.";
            }

            return null;
        }
    }
}