using MySqlConnector;
using StudentWPF.Models;
using System.Collections.Generic;

namespace StudentWPF.Services
{
    public class DatabaseService
    {
        private readonly string connectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=mahasiswamvvm;" +
            "User ID=root;" +
            "Password=root;";

        // ==========================================
        // READ - Mengambil semua data mahasiswa
        // ==========================================

        public async Task<List<Mahasiswa>> GetAllMahasiswaAsync()
        {
            var daftarMahasiswa = new List<Mahasiswa>();

            await using var connection =
                new MySqlConnection(connectionString);

            await connection.OpenAsync();

            const string query = @"
                SELECT nrp, nama, prodi, ipk
                FROM mahasiswa
                ORDER BY nrp;
            ";

            await using var command =
                new MySqlCommand(query, connection);

            await using var reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                daftarMahasiswa.Add(
                    new Mahasiswa
                    {
                        NRP = reader.GetString("nrp"),
                        Nama = reader.GetString("nama"),
                        Prodi = reader.GetString("prodi"),
                        IPK = reader.GetDecimal("ipk")
                    }
                );
            }

            return daftarMahasiswa;
        }

        // ==========================================
        // CREATE - Menambahkan mahasiswa
        // ==========================================

        public async Task AddMahasiswaAsync(Mahasiswa mahasiswa)
        {
            await using var connection =
                new MySqlConnection(connectionString);

            await connection.OpenAsync();

            const string query = @"
                INSERT INTO mahasiswa (nrp, nama, prodi, ipk)
                VALUES (@nrp, @nama, @prodi, @ipk);
            ";

            await using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@nrp", mahasiswa.NRP);
            command.Parameters.AddWithValue("@nama", mahasiswa.Nama);
            command.Parameters.AddWithValue("@prodi", mahasiswa.Prodi);
            command.Parameters.AddWithValue("@ipk", mahasiswa.IPK);

            await command.ExecuteNonQueryAsync();
        }

        // ==========================================
        // UPDATE - Mengubah mahasiswa
        // ==========================================

        public async Task UpdateMahasiswaAsync(Mahasiswa mahasiswa)
        {
            await using var connection =
                new MySqlConnection(connectionString);

            await connection.OpenAsync();

            const string query = @"
                UPDATE mahasiswa
                SET nama = @nama,
                    prodi = @prodi,
                    ipk = @ipk
                WHERE nrp = @nrp;
            ";

            await using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@nrp", mahasiswa.NRP);
            command.Parameters.AddWithValue("@nama", mahasiswa.Nama);
            command.Parameters.AddWithValue("@prodi", mahasiswa.Prodi);
            command.Parameters.AddWithValue("@ipk", mahasiswa.IPK);

            await command.ExecuteNonQueryAsync();
        }

        // ==========================================
        // DELETE - Menghapus mahasiswa
        // ==========================================

        public async Task DeleteMahasiswaAsync(string nrp)
        {
            await using var connection =
                new MySqlConnection(connectionString);

            await connection.OpenAsync();

            const string query = @"
                DELETE FROM mahasiswa
                WHERE nrp = @nrp;
            ";

            await using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@nrp", nrp);

            await command.ExecuteNonQueryAsync();
        }

        // ==========================================
        // SEARCH - Mencari mahasiswa
        // ==========================================

        public async Task<List<Mahasiswa>> SearchMahasiswaAsync(
            string keyword)
        {
            var daftarMahasiswa = new List<Mahasiswa>();

            await using var connection =
                new MySqlConnection(connectionString);

            await connection.OpenAsync();

            const string query = @"
                SELECT nrp, nama, prodi, ipk
                FROM mahasiswa
                WHERE nrp LIKE @keyword
                   OR nama LIKE @keyword
                   OR prodi LIKE @keyword
                ORDER BY nrp;
            ";

            await using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@keyword",
                $"%{keyword}%"
            );

            await using var reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                daftarMahasiswa.Add(
                    new Mahasiswa
                    {
                        NRP = reader.GetString("nrp"),
                        Nama = reader.GetString("nama"),
                        Prodi = reader.GetString("prodi"),
                        IPK = reader.GetDecimal("ipk")
                    }
                );
            }

            return daftarMahasiswa;
        }
    }
}