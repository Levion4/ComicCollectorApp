using System.Collections.ObjectModel;
using ComicCollectorApp.Model;
using Newtonsoft.Json;

namespace ComicCollectorApp.ViewModel.Services
{
    /// <summary>
    /// Предоставляет методы для сериализации данных приложения.
    /// </summary>
    public static class DataAppSerializer
    {
        /// <summary>
        /// Возвращает и задает путь к файлу.
        /// </summary>
        public static string Filename { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="DataAppSerializer"/>
        /// </summary>
        static DataAppSerializer()
        {
            var appDataFolder =
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                @"\ComicCollectorApp\userdata.json";
            Filename = appDataFolder;
        }

        /// <summary>
        /// Проверяет, существует ли папка, указанная в свойстве Filename.
        /// И, если папка не существует, то создает папку.
        /// </summary>
        public static void CreateDirectory()
        {
            if (!Directory.Exists(Filename))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Filename));
            }
        }

        /// <summary>
        /// Сохраняет данные приложения в файл.
        /// </summary>
        /// <param name="dataApp">Данные приложения,
        /// которые нужно сохранить.</param>
        public static void SaveToFile(DataApp dataApp)
        {
            CreateDirectory();
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            JsonSerializer serializer = new JsonSerializer();
            serializer = JsonSerializer.Create(settings);
            using (StreamWriter sw = new StreamWriter(Filename))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, dataApp);
            }
        }

        /// <summary>
        /// Загружает данные из файла и передает их в список.
        /// </summary>
        /// <returns>Возвращает данные приложения.</returns>
        public static DataApp LoadFromFile()
        {
            DataApp dataApp = null;

            try
            {
                CreateDirectory();
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                JsonSerializer serializer = new JsonSerializer();
                serializer = JsonSerializer.Create(settings);
                using (StreamReader sr = new StreamReader(Filename))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    dataApp = serializer.Deserialize<DataApp>(reader);
                }
            }
            catch
            {
                return new DataApp();
            }

            return dataApp;
        }
    }
}
