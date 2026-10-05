using StudentWPF.Models;
using StudentWPF.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace StudentWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService databaseService;

        // ==========================================
        // DATA MAHASISWA
        // ==========================================

        public ObservableCollection<Mahasiswa> MahasiswaList
        {
            get;
        } = new();

        private Mahasiswa? selectedMahasiswa;

        public Mahasiswa? SelectedMahasiswa
        {
            get => selectedMahasiswa;
            set
            {
                selectedMahasiswa = value;

                if (value != null)
                {
                    NRP = value.NRP;
                    Nama = value.Nama;
                    Prodi = value.Prodi;
                    IPK = value.IPK;
                }

                OnPropertyChanged();
            }
        }

        // ==========================================
        // INPUT
        // ==========================================

        private string nrp = string.Empty;

        public string NRP
        {
            get => nrp;
            set
            {
                nrp = value;
                OnPropertyChanged();
            }
        }

        private string nama = string.Empty;

        public string Nama
        {
            get => nama;
            set
            {
                nama = value;
                OnPropertyChanged();
            }
        }

        private string prodi = string.Empty;

        public string Prodi
        {
            get => prodi;
            set
            {
                prodi = value;
                OnPropertyChanged();
            }
        }

        private decimal ipk;

        public decimal IPK
        {
            get => ipk;
            set
            {
                ipk = value;
                OnPropertyChanged();
            }
        }

        private string searchText = string.Empty;

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }

        // ==========================================
        // COMMAND
        // ==========================================

        public ICommand LoadCommand { get; }

        public ICommand AddCommand { get; }

        public ICommand UpdateCommand { get; }

        public ICommand DeleteCommand { get; }

        public ICommand SearchCommand { get; }

        public ICommand ClearCommand { get; }

        // ==========================================
        // CONSTRUCTOR
        // ==========================================

        public MainViewModel()
        {
            databaseService = new DatabaseService();

            LoadCommand = new RelayCommand(
                async _ => await LoadMahasiswaAsync()
            );

            AddCommand = new RelayCommand(
                async _ => await AddMahasiswaAsync()
            );

            UpdateCommand = new RelayCommand(
                async _ => await UpdateMahasiswaAsync()
            );

            DeleteCommand = new RelayCommand(
                async _ => await DeleteMahasiswaAsync()
            );

            SearchCommand = new RelayCommand(
                async _ => await SearchMahasiswaAsync()
            );

            ClearCommand = new RelayCommand(
                _ => ClearForm()
            );

            _ = LoadMahasiswaAsync();
        }

        // ==========================================
        // LOAD
        // ==========================================

        private async Task LoadMahasiswaAsync()
        {
            try
            {
                var data =
                    await databaseService.GetAllMahasiswaAsync();

                MahasiswaList.Clear();

                foreach (var mahasiswa in data)
                {
                    MahasiswaList.Add(mahasiswa);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Gagal mengambil data:\n{ex.Message}",
                    "Database Error"
                );
            }
        }

        // ==========================================
        // ADD
        // ==========================================

        private async Task AddMahasiswaAsync()
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                var mahasiswa = new Mahasiswa
                {
                    NRP = NRP,
                    Nama = Nama,
                    Prodi = Prodi,
                    IPK = IPK
                };

                await databaseService.AddMahasiswaAsync(
                    mahasiswa
                );

                await LoadMahasiswaAsync();

                ClearForm();

                System.Windows.MessageBox.Show(
                    "Data mahasiswa berhasil ditambahkan.",
                    "Berhasil"
                );
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Gagal menambahkan data:\n{ex.Message}",
                    "Database Error"
                );
            }
        }

        // ==========================================
        // UPDATE
        // ==========================================

        private async Task UpdateMahasiswaAsync()
        {
            if (SelectedMahasiswa == null)
            {
                System.Windows.MessageBox.Show(
                    "Pilih mahasiswa yang ingin diubah.",
                    "Perhatian"
                );

                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            try
            {
                var mahasiswa = new Mahasiswa
                {
                    NRP = NRP,
                    Nama = Nama,
                    Prodi = Prodi,
                    IPK = IPK
                };

                await databaseService.UpdateMahasiswaAsync(
                    mahasiswa
                );

                await LoadMahasiswaAsync();

                ClearForm();

                System.Windows.MessageBox.Show(
                    "Data mahasiswa berhasil diperbarui.",
                    "Berhasil"
                );
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Gagal memperbarui data:\n{ex.Message}",
                    "Database Error"
                );
            }
        }

        // ==========================================
        // DELETE
        // ==========================================

        private async Task DeleteMahasiswaAsync()
        {
            if (SelectedMahasiswa == null)
            {
                System.Windows.MessageBox.Show(
                    "Pilih mahasiswa yang ingin dihapus.",
                    "Perhatian"
                );

                return;
            }

            try
            {
                await databaseService.DeleteMahasiswaAsync(
                    SelectedMahasiswa.NRP
                );

                await LoadMahasiswaAsync();

                ClearForm();

                System.Windows.MessageBox.Show(
                    "Data mahasiswa berhasil dihapus.",
                    "Berhasil"
                );
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Gagal menghapus data:\n{ex.Message}",
                    "Database Error"
                );
            }
        }

        // ==========================================
        // SEARCH
        // ==========================================

        private async Task SearchMahasiswaAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    await LoadMahasiswaAsync();
                    return;
                }

                var data =
                    await databaseService
                        .SearchMahasiswaAsync(SearchText);

                MahasiswaList.Clear();

                foreach (var mahasiswa in data)
                {
                    MahasiswaList.Add(mahasiswa);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Gagal melakukan pencarian:\n{ex.Message}",
                    "Database Error"
                );
            }
        }

        // ==========================================
        // CLEAR
        // ==========================================

        private void ClearForm()
        {
            SelectedMahasiswa = null;

            NRP = string.Empty;
            Nama = string.Empty;
            Prodi = string.Empty;
            IPK = 0;
        }

        // ==========================================
        // VALIDASI
        // ==========================================

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(NRP))
            {
                System.Windows.MessageBox.Show(
                    "NRP harus diisi."
                );

                return false;
            }

            if (string.IsNullOrWhiteSpace(Nama))
            {
                System.Windows.MessageBox.Show(
                    "Nama harus diisi."
                );

                return false;
            }

            if (string.IsNullOrWhiteSpace(Prodi))
            {
                System.Windows.MessageBox.Show(
                    "Program studi harus diisi."
                );

                return false;
            }

            if (IPK < 0 || IPK > 4)
            {
                System.Windows.MessageBox.Show(
                    "IPK harus berada pada rentang 0 sampai 4."
                );

                return false;
            }

            return true;
        }

        // ==========================================
        // PROPERTY CHANGED
        // ==========================================

        public event PropertyChangedEventHandler?
            PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }
    }

    // ==========================================
    // RELAY COMMAND
    // ==========================================

    public class RelayCommand : ICommand
    {
        private readonly Action<object?> execute;
        private readonly Predicate<object?>? canExecute;

        public RelayCommand(
            Action<object?> execute,
            Predicate<object?>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null ||
                   canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}