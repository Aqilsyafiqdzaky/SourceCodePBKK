using System.Globalization;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        // Variabel kalkulator
        double firstNumber = 0;
        double secondNumber = 0;
        double result = 0;
        string operation = "";

        public Form1()
        {
            InitializeComponent();
        }

        // =========================================
        // EVENT TOMBOL ANGKA
        // =========================================
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = button.Text;
            }
            else
            {
                txtDisplay.Text += button.Text;
            }
        }

        // =========================================
        // EVENT TOMBOL OPERATOR
        // =========================================
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            try
            {
                // Simpan angka pertama
                firstNumber = double.Parse(
                    txtDisplay.Text,
                    CultureInfo.InvariantCulture
                );

                // Simpan operator
                operation = button.Text;

                // Kosongkan display untuk angka kedua
                txtDisplay.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Input angka tidak valid.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================
        // EVENT TOMBOL =
        // =========================================
        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil angka kedua
                secondNumber = double.Parse(
                    txtDisplay.Text,
                    CultureInfo.InvariantCulture
                );

                // Tentukan operasi
                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;

                    case "−":
                        result = firstNumber - secondNumber;
                        break;

                    case "×":
                        result = firstNumber * secondNumber;
                        break;

                    case "÷":
                        // Validasi pembagian dengan nol
                        if (secondNumber == 0)
                        {
                            throw new DivideByZeroException(
                                "Tidak dapat melakukan pembagian dengan nol."
                            );
                        }

                        result = firstNumber / secondNumber;
                        break;

                    default:
                        MessageBox.Show(
                            "Operator belum dipilih.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                }

                // Menampilkan hasil
                txtDisplay.Text = result.ToString(
                    CultureInfo.InvariantCulture
                );
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Input angka tidak valid.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================
        // EVENT TOMBOL CLEAR
        // =========================================
        private void btnClear_Click(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            operation = "";

            txtDisplay.Text = "0";
        }

        // =========================================
        // EVENT TOMBOL DECIMAL
        // =========================================
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }
    }
}