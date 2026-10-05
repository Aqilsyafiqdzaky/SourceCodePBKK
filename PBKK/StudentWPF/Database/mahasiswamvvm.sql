CREATE DATABASE IF NOT EXISTS db_mahasiswa;

USE db_mahasiswa;

CREATE TABLE IF NOT EXISTS mahasiswa (
    nrp VARCHAR(20) PRIMARY KEY,
    nama VARCHAR(100) NOT NULL,
    prodi VARCHAR(100) NOT NULL,
    ipk DECIMAL(3,2) NOT NULL
);

INSERT INTO mahasiswa (nrp, nama, prodi, ipk) VALUES
('5025241001', 'Aqil', 'Teknik Informatika', 3.80),
('5025241002', 'Budi', 'Teknik Informatika', 3.50),
('5025241003', 'Citra', 'Sistem Informasi', 3.90);