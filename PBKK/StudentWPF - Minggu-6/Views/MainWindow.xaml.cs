using System;
using System.Windows;
using StudentWPF.Repositories;

namespace StudentWPF.Views
{
    public partial class MainWindow : Window
    {
        private readonly StudentRepository _studentRepository;

        public MainWindow()
        {
            InitializeComponent();
            _studentRepository = new StudentRepository();
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                var students = _studentRepository.GetAll();

                StudentDataGrid.ItemsSource = students;

                int totalStudents = _studentRepository.GetTotalStudents();

                TotalStudentsText.Text = totalStudents.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }


        private void RefreshButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            LoadStudents();
        }
    }
}