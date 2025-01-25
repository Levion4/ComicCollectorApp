using ComicCollectorApp.Core.Services;
using ComicCollectorApp.Model.Comics;
using ComicCollectorApp.ViewModel;
using Moq;

namespace ComicCollectorApp.Tests
{
    public class MainViewModelTests
    {
        private readonly Mock<IFileDialogService> _mockFileDialogService;
        private readonly MainViewModel _viewModel;

        public MainViewModelTests()
        {
            _mockFileDialogService = new Mock<IFileDialogService>();
            _viewModel = new MainViewModel(_mockFileDialogService.Object);
        }

        [Fact]
        public void ApplyCommand_ShouldUpdateComicsCollection()
        {
            // Arrange
            var comic = new Comic { Title = "Test Comic" };
            _viewModel.CurrentComic = comic;
            _viewModel.Comics.Add(comic);

            // Act
            _viewModel.ApplyCommand.Execute(null);

            // Assert
            Assert.Contains(comic, _viewModel.Comics);
        }

        [Fact]
        public void RemoveCommand_ShouldRemoveComicFromCollection()
        {
            // Arrange
            var comic = new Comic { Title = "Test Comic" };
            _viewModel.CurrentComic = comic;
            _viewModel.Comics.Add(comic);

            // Act
            _viewModel.RemoveCommand.Execute(null);

            // Assert
            Assert.DoesNotContain(comic, _viewModel.Comics);
        }

        [Fact]
        public void EditCommand_ShouldCloneCurrentComic()
        {
            // Arrange
            var comic = new Comic { Title = "Test Comic" };
            _viewModel.CurrentComic = comic;

            // Act
            _viewModel.EditCommand.Execute(null);

            // Assert
            Assert.NotSame(comic, _viewModel.CurrentComic);
            Assert.Equal(comic.Title, _viewModel.CurrentComic.Title);
        }
    }
}
