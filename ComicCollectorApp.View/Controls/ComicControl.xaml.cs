using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComicCollectorApp.View.Controls
{
    /// <summary>
    /// Логика взаимодействия для ComicControl.xaml
    /// </summary>
    public partial class ComicControl : UserControl
    {
        /// <summary>
        /// Хранит свойство зависимости возможности редактирования.
        /// </summary>
        public static readonly DependencyProperty IsEditProperty =
            DependencyProperty.Register(nameof(IsEdit), typeof(bool),
                typeof(ComicControl));

        public static readonly DependencyProperty ParentContextProperty =
            DependencyProperty.Register(nameof(ParentContext), typeof(object),
                typeof(ComicControl), new PropertyMetadata(null));

        /// <summary>
        /// Возвращает и задает возможность редактирования.
        /// </summary>
        public bool IsEdit
        {
            get => (bool)GetValue(IsEditProperty);
            set => SetValue(IsEditProperty, value);
        }

        public object ParentContext
        {
            get => GetValue(ParentContextProperty);
            set => SetValue(ParentContextProperty, value);
        }

        public ComicControl()
        {
            InitializeComponent();
        }
    }
}
