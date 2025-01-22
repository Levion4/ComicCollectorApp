using ComicCollectorApp.Infrastructure.Interfaces;

namespace ComicCollectorApp.Infrastructure.Services
{
    public class WindowService : IWindowService
    {
        public void ShowWindow(object viewModel)
        {
            var viewTypeName = viewModel.GetType().Name.Replace("ViewModel", "Window");
            var viewType = Type.GetType($"ComicCollectorApp.View.{viewTypeName}");

            if (viewType == null)
            {
                throw new InvalidOperationException($"View not found for {viewModel.GetType().Name}");
            }

            var window = (Window)Activator.CreateInstance(viewType);
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
