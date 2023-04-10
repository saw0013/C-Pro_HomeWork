using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Unit18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public IFileRS fileRS { get => typeSave.SelectedItem as IFileRS; }
        public IAnimal selectedAnimal { get => gridAnimal.SelectedItem as IAnimal; }

        public List<IAnimal> animals { set => gridAnimal.ItemsSource = value; }
        public IFileRS[] fileRSMode { set => typeSave.ItemsSource = value; }

        Presenter presenter;

        public MainWindow()
        {
            InitializeComponent();

            presenter = new Presenter(this);

            //Подписываемся на все события

            presenter.GetStart();

            typeSave.SelectionChanged += (s, e) => presenter.SelectionChanged();
            gridAnimal.CurrentCellChanged += (s, e) => presenter.GVCurrentCellChanged();
            gridAnimal.CellEditEnding += (s, e) => presenter.GVCellEditEnding();
        }

        public void MenuItemAddClick(object sender, RoutedEventArgs e) { presenter.MenuItemAddClick(); }


        public void MenuItemDeleteClick(object sender, RoutedEventArgs e) { presenter.MenuItemDeleteClick(); }

    }
}
