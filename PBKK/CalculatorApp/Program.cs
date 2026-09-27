namespace CalculatorApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Mengatur konfigurasi default Windows Forms
            ApplicationConfiguration.Initialize();

            // Menjalankan Form1
            Application.Run(new Form1());
        }
    }
}