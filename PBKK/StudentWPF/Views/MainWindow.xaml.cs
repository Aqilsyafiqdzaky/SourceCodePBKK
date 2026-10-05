using System.Windows;
using StudentWPF.ViewModels;

namespace StudentWPF.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Menghubungkan View dengan ViewModel
            DataContext = new MainViewModel();
        }
    }
}