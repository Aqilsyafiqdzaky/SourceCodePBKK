using System;
using System.Collections.Generic;
using Spectre.Console;

namespace DataMahasiswa
{
    class Mahasiswa
    {
        public string NIM { get; set; }
        public string Nama { get; set; }
        public string Prodi { get; set; }
        public double IPK { get; set; }

        public Mahasiswa(
            string nim,
            string nama,
            string prodi,
            double ipk)
        {
            NIM = nim;
            Nama = nama;
            Prodi = prodi;
            IPK = ipk;
        }
    }

    class Program
    {
        static List<Mahasiswa> daftarMahasiswa =
            new List<Mahasiswa>();

        static void Main(string[] args)
        {
            int pilihan;

            do
            {
                TampilkanMenu();

                Console.Write("Pilihan: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out pilihan))
                {
                    pilihan = 0;
                }

                switch (pilihan)
                {
                    case 1:
                        TambahMahasiswa();
                        break;

                    case 2:
                        TampilkanMahasiswa();
                        break;

                    case 3:
                        CariMahasiswa();
                        break;

                    case 4:
                        HapusMahasiswa();
                        break;

                    case 5:
                        AnsiConsole.Clear();

                        AnsiConsole.Write(
                            new Panel(
                                new Markup(
                                    "[bold green]Terima kasih telah " +
                                    "menggunakan program![/]"
                                )
                            )
                            {
                                Border = BoxBorder.Rounded,
                                Padding = new Padding(2, 1)
                            }
                        );

                        break;

                    default:
                        AnsiConsole.MarkupLine(
                            "[bold red]Pilihan tidak tersedia![/]"
                        );
                        break;
                }

                if (pilihan != 5)
                {
                    Console.WriteLine();

                    AnsiConsole.MarkupLine(
                        "[grey]Tekan ENTER untuk melanjutkan...[/]"
                    );

                    Console.ReadLine();
                }

            } while (pilihan != 5);
        }

        // ==========================================
        // METHOD MENAMPILKAN MENU
        // ==========================================

        static void TampilkanMenu()
        {
            AnsiConsole.Clear();

            var header = new Panel(
                new Rows(
                    new Markup(
                        "[bold cyan]       🎓 SISTEM DATA MAHASISWA[/]"
                    ),
                    new Markup(
                        "[grey]     KELOLA DATA MAHASISWA DENGAN MUDAH[/]"
                    )
                )
            )
            {
                Border = BoxBorder.Rounded,
                Padding = new Padding(1, 1)
            };

            AnsiConsole.Write(header);

            AnsiConsole.WriteLine();

            var menu = new Table()
                .Border(TableBorder.Rounded);

            menu.AddColumn(
                new TableColumn("[bold white]No[/]")
                    .Centered()
            );

            menu.AddColumn(
                new TableColumn("[bold white]Menu[/]")
            );

            menu.AddRow(
                "[bold green]1[/]",
                "[green]👤  Tambah Mahasiswa[/]"
            );

            menu.AddRow(
                "[bold blue]2[/]",
                "[blue]📋  Tampilkan Mahasiswa[/]"
            );

            menu.AddRow(
                "[bold yellow]3[/]",
                "[yellow]🔍  Cari Mahasiswa[/]"
            );

            menu.AddRow(
                "[bold red]4[/]",
                "[red]🗑  Hapus Mahasiswa[/]"
            );

            menu.AddRow(
                "[bold grey]5[/]",
                "[grey]🚪  Keluar[/]"
            );

            AnsiConsole.Write(menu);

            AnsiConsole.WriteLine();

            AnsiConsole.Markup(
                "[bold cyan]Pilihan:[/] "
            );
        }

        // ==========================================
        // METHOD TAMBAH MAHASISWA
        // ==========================================

        static void TambahMahasiswa()
        {
            AnsiConsole.Clear();

            AnsiConsole.Write(
                new Rule(
                    "[bold green] TAMBAH MAHASISWA [/]"
                )
                .RuleStyle("green")
            );

            AnsiConsole.WriteLine();

            string nim = AnsiConsole.Ask<string>(
                "[cyan]NIM:[/]"
            );

            string nama = AnsiConsole.Ask<string>(
                "[cyan]Nama:[/]"
            );

            string prodi = AnsiConsole.Ask<string>(
                "[cyan]Program Studi:[/]"
            );

            double ipk;

            while (true)
            {
                ipk = AnsiConsole.Ask<double>(
                    "[cyan]IPK:[/]"
                );

                if (ipk >= 0 && ipk <= 4)
                {
                    break;
                }

                AnsiConsole.MarkupLine(
                    "[bold red]IPK harus berupa angka 0 - 4.[/]"
                );
            }

            Mahasiswa mahasiswa =
                new Mahasiswa(
                    nim,
                    nama,
                    prodi,
                    ipk
                );

            daftarMahasiswa.Add(mahasiswa);

            Console.WriteLine();

            AnsiConsole.Write(
                new Panel(
                    new Markup(
                        "[bold green]✓ Data mahasiswa " +
                        "berhasil ditambahkan.[/]"
                    )
                )
                {
                    Border = BoxBorder.Rounded,
                    Padding = new Padding(2, 1)
                }
            );
        }

        // ==========================================
        // METHOD MENAMPILKAN DATA
        // ==========================================

        static void TampilkanMahasiswa()
        {
            AnsiConsole.Clear();

            if (daftarMahasiswa.Count == 0)
            {
                AnsiConsole.Write(
                    new Panel(
                        new Markup(
                            "[yellow]Belum ada data mahasiswa.[/]"
                        )
                    )
                    {
                        Header = new PanelHeader(
                            "[bold cyan] DAFTAR MAHASISWA [/]"
                        ),
                        Border = BoxBorder.Rounded,
                        Padding = new Padding(2, 1)
                    }
                );

                return;
            }

            var table = new Table()
                .Border(TableBorder.Rounded)
                .Title("[bold cyan]DAFTAR MAHASISWA[/]");

            table.AddColumn(
                new TableColumn("[bold]NIM[/]")
                    .Centered()
            );

            table.AddColumn(
                new TableColumn("[bold]Nama[/]")
            );

            table.AddColumn(
                new TableColumn("[bold]Prodi[/]")
            );

            table.AddColumn(
                new TableColumn("[bold]IPK[/]")
                    .Centered()
            );

            foreach (Mahasiswa m in daftarMahasiswa)
            {
                table.AddRow(
                    m.NIM,
                    m.Nama,
                    m.Prodi,
                    m.IPK.ToString("F2")
                );
            }

            AnsiConsole.Write(table);
        }

        // ==========================================
        // METHOD MENCARI MAHASISWA
        // ==========================================

        static void CariMahasiswa()
        {
            AnsiConsole.Clear();

            AnsiConsole.Write(
                new Rule(
                    "[bold yellow] CARI MAHASISWA [/]"
                )
                .RuleStyle("yellow")
            );

            AnsiConsole.WriteLine();

            string nimCari = AnsiConsole.Ask<string>(
                "[cyan]Masukkan NIM:[/]"
            );

            Mahasiswa mahasiswaDitemukan = null;

            foreach (Mahasiswa m in daftarMahasiswa)
            {
                if (m.NIM.Equals(
                    nimCari,
                    StringComparison.OrdinalIgnoreCase))
                {
                    mahasiswaDitemukan = m;
                    break;
                }
            }

            Console.WriteLine();

            if (mahasiswaDitemukan != null)
            {
                var table = new Table()
                    .Border(TableBorder.Rounded)
                    .Title("[bold green]DATA DITEMUKAN[/]");

                table.AddColumn("[bold cyan]Informasi[/]");
                table.AddColumn("[bold white]Data[/]");

                table.AddRow(
                    "NIM",
                    mahasiswaDitemukan.NIM
                );

                table.AddRow(
                    "Nama",
                    mahasiswaDitemukan.Nama
                );

                table.AddRow(
                    "Prodi",
                    mahasiswaDitemukan.Prodi
                );

                table.AddRow(
                    "IPK",
                    mahasiswaDitemukan.IPK.ToString("F2")
                );

                AnsiConsole.Write(table);
            }
            else
            {
                AnsiConsole.Write(
                    new Panel(
                        new Markup(
                            "[bold red]Mahasiswa dengan NIM " +
                            "tersebut tidak ditemukan.[/]"
                        )
                    )
                    {
                        Border = BoxBorder.Rounded,
                        Padding = new Padding(2, 1)
                    }
                );
            }
        }

        // ==========================================
        // METHOD MENGHAPUS MAHASISWA
        // ==========================================

        static void HapusMahasiswa()
        {
            AnsiConsole.Clear();

            AnsiConsole.Write(
                new Rule(
                    "[bold red] HAPUS MAHASISWA [/]"
                )
                .RuleStyle("red")
            );

            AnsiConsole.WriteLine();

            string nimHapus = AnsiConsole.Ask<string>(
                "[cyan]Masukkan NIM:[/]"
            );

            Mahasiswa mahasiswaDitemukan = null;

            foreach (Mahasiswa m in daftarMahasiswa)
            {
                if (m.NIM.Equals(
                    nimHapus,
                    StringComparison.OrdinalIgnoreCase))
                {
                    mahasiswaDitemukan = m;
                    break;
                }
            }

            Console.WriteLine();

            if (mahasiswaDitemukan != null)
            {
                bool konfirmasi = AnsiConsole.Confirm(
                    $"Apakah kamu yakin ingin menghapus " +
                    $"[yellow]{mahasiswaDitemukan.Nama}[/]?"
                );

                if (konfirmasi)
                {
                    daftarMahasiswa.Remove(
                        mahasiswaDitemukan
                    );

                    AnsiConsole.Write(
                        new Panel(
                            new Markup(
                                "[bold green]✓ Data mahasiswa " +
                                "berhasil dihapus.[/]"
                            )
                        )
                        {
                            Border = BoxBorder.Rounded,
                            Padding = new Padding(2, 1)
                        }
                    );
                }
                else
                {
                    AnsiConsole.MarkupLine(
                        "[yellow]Penghapusan dibatalkan.[/]"
                    );
                }
            }
            else
            {
                AnsiConsole.Write(
                    new Panel(
                        new Markup(
                            "[bold red]Data mahasiswa " +
                            "tidak ditemukan.[/]"
                        )
                    )
                    {
                        Border = BoxBorder.Rounded,
                        Padding = new Padding(2, 1)
                    }
                );
            }
        }
    }
}