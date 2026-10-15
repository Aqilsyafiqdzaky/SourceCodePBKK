/*
    Hands-On Lab 2 - WPF + ADO.NET + SQL Server
    Database: StudentRegistrationDB

    Script ini merangkum query yang digunakan untuk:
    1. Menguji koneksi SQL Server
    2. Membuat database dan tabel
    3. Mengisi data program studi dan mahasiswa contoh
    4. Menambahkan mahasiswa Rina Putri untuk pengujian Refresh
    5. Menampilkan data mahasiswa, menghitung total, dan memverifikasi data

    Script dibuat agar bisa dijalankan ulang tanpa menggandakan data contoh.
*/

/* =========================================================
   1. Menguji koneksi dan melihat versi SQL Server
   ========================================================= */
SELECT @@SERVERNAME AS ServerName;
SELECT @@VERSION AS SQLServerVersion;
GO

/* =========================================================
   2. Membuat database jika belum tersedia
   ========================================================= */
IF DB_ID(N'StudentRegistrationDB') IS NULL
    CREATE DATABASE StudentRegistrationDB;
GO

USE StudentRegistrationDB;
GO

/* =========================================================
   3. Membuat tabel Programs
   ========================================================= */
IF OBJECT_ID(N'dbo.Programs', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Programs (
        ProgramId INT IDENTITY(1,1) PRIMARY KEY,
        ProgramCode NVARCHAR(20) NOT NULL UNIQUE,
        ProgramName NVARCHAR(100) NOT NULL,
        IsActive BIT NOT NULL DEFAULT 1
    );
END;
GO

/* =========================================================
   4. Membuat tabel Students
   ========================================================= */
IF OBJECT_ID(N'dbo.Students', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Students (
        StudentId INT IDENTITY(1,1) PRIMARY KEY,
        NIM NVARCHAR(20) NOT NULL UNIQUE,
        [Name] NVARCHAR(100) NOT NULL,
        ProgramId INT NOT NULL,
        BirthDate DATE NULL,
        [Address] NVARCHAR(250) NULL,
        PhoneNumber NVARCHAR(30) NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
        UpdatedAt DATETIME2 NULL,
        CONSTRAINT FK_Students_Programs
            FOREIGN KEY (ProgramId)
            REFERENCES dbo.Programs(ProgramId)
    );
END;
GO

/* =========================================================
   5. Memasukkan data program studi contoh
   ========================================================= */
INSERT INTO dbo.Programs (ProgramCode, ProgramName, IsActive)
SELECT v.ProgramCode, v.ProgramName, v.IsActive
FROM (VALUES
    (N'TI',  N'Teknik Informatika', 1),
    (N'SI',  N'Sistem Informasi',   1),
    (N'MNJ', N'Manajemen',          1),
    (N'EL',  N'Teknik Elektro',     1)
) AS v(ProgramCode, ProgramName, IsActive)
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.Programs AS p
    WHERE p.ProgramCode = v.ProgramCode
);
GO

/* =========================================================
   6. Memasukkan lima data mahasiswa awal
   ========================================================= */
INSERT INTO dbo.Students
    (NIM, [Name], ProgramId, BirthDate, [Address], PhoneNumber)
SELECT
    v.NIM,
    v.StudentName,
    p.ProgramId,
    v.BirthDate,
    v.StudentAddress,
    v.PhoneNumber
FROM (VALUES
    (N'20231001', N'Ahmad Rizki',   N'TI', CAST('2005-01-12' AS DATE), N'Surabaya', N'081234567001'),
    (N'20231002', N'Siti Aisyah',   N'SI', CAST('2005-03-20' AS DATE), N'Surabaya', N'081234567002'),
    (N'20231003', N'Budi Santoso',  N'TI', CAST('2004-08-15' AS DATE), N'Sidoarjo', N'081234567003'),
    (N'20231004', N'Citra Lestari', N'MNJ', CAST('2005-05-10' AS DATE), N'Gresik', N'081234567004'),
    (N'20231005', N'Dimas Prayoga', N'EL', CAST('2004-11-25' AS DATE), N'Surabaya', N'081234567005')
) AS v(NIM, StudentName, ProgramCode, BirthDate, StudentAddress, PhoneNumber)
INNER JOIN dbo.Programs AS p
    ON p.ProgramCode = v.ProgramCode
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.Students AS s
    WHERE s.NIM = v.NIM
);
GO

/* =========================================================
   7. Menambahkan mahasiswa Rina Putri untuk menguji Refresh
   ========================================================= */
INSERT INTO dbo.Students
    (NIM, [Name], ProgramId, BirthDate, [Address], PhoneNumber)
SELECT
    N'20231006',
    N'Rina Putri',
    p.ProgramId,
    CAST('2005-07-14' AS DATE),
    N'Surabaya',
    N'081234567006'
FROM dbo.Programs AS p
WHERE p.ProgramCode = N'TI'
  AND NOT EXISTS (
      SELECT 1
      FROM dbo.Students AS s
      WHERE s.NIM = N'20231006'
  );
GO

/* =========================================================
   8. Menampilkan semua mahasiswa beserta nama program studi
      Query yang digunakan StudentRepository.GetAll()
   ========================================================= */
SELECT
    s.StudentId,
    s.NIM,
    s.Name,
    s.ProgramId,
    p.ProgramName,
    s.BirthDate,
    s.Address,
    s.PhoneNumber,
    s.CreatedAt,
    s.UpdatedAt
FROM dbo.Students AS s
INNER JOIN dbo.Programs AS p
    ON s.ProgramId = p.ProgramId
ORDER BY s.StudentId;
GO

/* =========================================================
   9. Menghitung total mahasiswa
      Query yang digunakan StudentRepository.GetTotalStudents()
   ========================================================= */
SELECT COUNT(*) AS TotalMahasiswa
FROM dbo.Students;
GO

/* =========================================================
   10. Memverifikasi data mahasiswa Rina Putri
   ========================================================= */
SELECT
    s.StudentId,
    s.NIM,
    s.Name,
    p.ProgramName
FROM dbo.Students AS s
INNER JOIN dbo.Programs AS p
    ON s.ProgramId = p.ProgramId
WHERE s.NIM = N'20231006';
GO
