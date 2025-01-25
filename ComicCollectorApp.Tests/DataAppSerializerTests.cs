using ComicCollectorApp.Model;
using ComicCollectorApp.Model.Comics;
using ComicCollectorApp.ViewModel.Services;
using System.Collections.ObjectModel;
using Assert = Xunit.Assert;

namespace ComicCollectorApp.Tests
{
    public class DataAppSerializerTests
    {
        private readonly string _testFilename;

        public DataAppSerializerTests()
        {
            var tempDirectory = Path.Combine(Path.GetTempPath(), "ComicCollectorAppTests");
            _testFilename = Path.Combine(tempDirectory, "test_userdata.json");
            DataAppSerializer.Filename = _testFilename;
        }

        [Fact]
        public void CreateDirectory_ShouldCreateDirectoryIfNotExists()
        {
            // Arrange
            var directoryPath = Path.GetDirectoryName(_testFilename);
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }

            // Act
            DataAppSerializer.CreateDirectory();

            // Assert
            Assert.True(Directory.Exists(directoryPath));
        }

        [Fact]
        public void SaveToFile_ShouldSaveDataAppToFile()
        {
            // Arrange
            var dataApp = new DataApp
            {
                Comics = new ObservableCollection<Comic>(),
                Authors = new ObservableCollection<Author>(),
                Languages = new ObservableCollection<Language>(),
                Publishers = new ObservableCollection<Publisher>()
            };

            // Act
            DataAppSerializer.SaveToFile(dataApp);

            // Assert
            Assert.True(File.Exists(_testFilename));
        }

        [Fact]
        public void LoadFromFile_ShouldLoadDataAppFromFile()
        {
            // Arrange
            var dataApp = new DataApp
            {
                Comics = new ObservableCollection<Comic>(),
                Authors = new ObservableCollection<Author>(),
                Languages = new ObservableCollection<Language>(),
                Publishers = new ObservableCollection<Publisher>()
            };
            DataAppSerializer.SaveToFile(dataApp);

            // Act
            var loadedDataApp = DataAppSerializer.LoadFromFile();

            // Assert
            Assert.NotNull(loadedDataApp);
            Assert.Equal(dataApp.Comics.Count, loadedDataApp.Comics.Count);
            Assert.Equal(dataApp.Authors.Count, loadedDataApp.Authors.Count);
            Assert.Equal(dataApp.Languages.Count, loadedDataApp.Languages.Count);
            Assert.Equal(dataApp.Publishers.Count, loadedDataApp.Publishers.Count);
        }

        [Fact]
        public void LoadFromFile_ShouldReturnNewDataAppIfFileDoesNotExist()
        {
            // Arrange
            if (File.Exists(_testFilename))
            {
                File.Delete(_testFilename);
            }

            // Act
            var loadedDataApp = DataAppSerializer.LoadFromFile();

            // Assert
            Assert.NotNull(loadedDataApp);
            Assert.Empty(loadedDataApp.Comics);
            Assert.Empty(loadedDataApp.Authors);
            Assert.Empty(loadedDataApp.Languages);
            Assert.Empty(loadedDataApp.Publishers);
        }
    }
}
