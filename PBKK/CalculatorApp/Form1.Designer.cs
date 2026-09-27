namespace CalculatorApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtDisplay;

        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnDivide;

        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btnMultiply;

        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btnMinus;

        private Button btn0;
        private Button btnDecimal;
        private Button btnClear;
        private Button btnPlus;

        private Button btnEquals;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitle = new Label();
            txtDisplay = new TextBox();

            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnDivide = new Button();

            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btnMultiply = new Button();

            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnMinus = new Button();

            btn0 = new Button();
            btnDecimal = new Button();
            btnClear = new Button();
            btnPlus = new Button();

            btnEquals = new Button();

            SuspendLayout();

            // =========================================
            // FORM
            // =========================================

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(340, 560);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;

            StartPosition = FormStartPosition.CenterScreen;

            Text = "Calculator";

            // =========================================
            // LABEL TITLE
            // =========================================

            lblTitle.AutoSize = true;

            lblTitle.Font = new Font(
                "Segoe UI",
                16F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );

            lblTitle.Location = new Point(20, 15);

            lblTitle.Name = "lblTitle";

            lblTitle.Size = new Size(101, 30);

            lblTitle.TabIndex = 0;

            lblTitle.Text = "Calculator";

            // =========================================
            // DISPLAY
            // =========================================

            txtDisplay.Font = new Font(
                "Segoe UI",
                20F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            txtDisplay.Location = new Point(20, 55);

            txtDisplay.Name = "txtDisplay";

            txtDisplay.ReadOnly = true;

            txtDisplay.Size = new Size(300, 43);

            txtDisplay.TabIndex = 1;

            txtDisplay.Text = "0";

            txtDisplay.TextAlign = HorizontalAlignment.Right;

            // =========================================
            // BUTTON 7
            // =========================================

            btn7.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btn7.Location = new Point(20, 120);

            btn7.Name = "btn7";

            btn7.Size = new Size(65, 55);

            btn7.TabIndex = 2;

            btn7.Text = "7";

            btn7.UseVisualStyleBackColor = true;

            btn7.Click += NumberButton_Click;

            // =========================================
            // BUTTON 8
            // =========================================

            btn8.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btn8.Location = new Point(95, 120);

            btn8.Name = "btn8";

            btn8.Size = new Size(65, 55);

            btn8.TabIndex = 3;

            btn8.Text = "8";

            btn8.UseVisualStyleBackColor = true;

            btn8.Click += NumberButton_Click;

            // =========================================
            // BUTTON 9
            // =========================================

            btn9.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btn9.Location = new Point(170, 120);

            btn9.Name = "btn9";

            btn9.Size = new Size(65, 55);

            btn9.TabIndex = 4;

            btn9.Text = "9";

            btn9.UseVisualStyleBackColor = true;

            btn9.Click += NumberButton_Click;

            // =========================================
            // BUTTON DIVIDE
            // =========================================

            btnDivide.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btnDivide.Location = new Point(245, 120);

            btnDivide.Name = "btnDivide";

            btnDivide.Size = new Size(75, 55);

            btnDivide.TabIndex = 5;

            btnDivide.Text = "÷";

            btnDivide.UseVisualStyleBackColor = true;

            btnDivide.Click += OperatorButton_Click;

            // =========================================
            // BUTTON 4
            // =========================================

            btn4.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btn4.Location = new Point(20, 185);

            btn4.Name = "btn4";

            btn4.Size = new Size(65, 55);

            btn4.TabIndex = 6;

            btn4.Text = "4";

            btn4.UseVisualStyleBackColor = true;

            btn4.Click += NumberButton_Click;

            // =========================================
            // BUTTON 5
            // =========================================

            btn5.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btn5.Location = new Point(95, 185);

            btn5.Name = "btn5";

            btn5.Size = new Size(65, 55);

            btn5.TabIndex = 7;

            btn5.Text = "5";

            btn5.UseVisualStyleBackColor = true;

            btn5.Click += NumberButton_Click;

            // =========================================
            // BUTTON 6
            // =========================================

            btn6.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btn6.Location = new Point(170, 185);

            btn6.Name = "btn6";

            btn6.Size = new Size(65, 55);

            btn6.TabIndex = 8;

            btn6.Text = "6";

            btn6.UseVisualStyleBackColor = true;

            btn6.Click += NumberButton_Click;

            // =========================================
            // BUTTON MULTIPLY
            // =========================================

            btnMultiply.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btnMultiply.Location = new Point(245, 185);

            btnMultiply.Name = "btnMultiply";

            btnMultiply.Size = new Size(75, 55);

            btnMultiply.TabIndex = 9;

            btnMultiply.Text = "×";

            btnMultiply.UseVisualStyleBackColor = true;

            btnMultiply.Click += OperatorButton_Click;

            // =========================================
            // BUTTON 1
            // =========================================

            btn1.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btn1.Location = new Point(20, 250);

            btn1.Name = "btn1";

            btn1.Size = new Size(65, 55);

            btn1.TabIndex = 10;

            btn1.Text = "1";

            btn1.UseVisualStyleBackColor = true;

            btn1.Click += NumberButton_Click;

            // =========================================
            // BUTTON 2
            // =========================================

            btn2.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btn2.Location = new Point(95, 250);

            btn2.Name = "btn2";

            btn2.Size = new Size(65, 55);

            btn2.TabIndex = 11;

            btn2.Text = "2";

            btn2.UseVisualStyleBackColor = true;

            btn2.Click += NumberButton_Click;

            // =========================================
            // BUTTON 3
            // =========================================

            btn3.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btn3.Location = new Point(170, 250);

            btn3.Name = "btn3";

            btn3.Size = new Size(65, 55);

            btn3.TabIndex = 12;

            btn3.Text = "3";

            btn3.UseVisualStyleBackColor = true;

            btn3.Click += NumberButton_Click;

            // =========================================
            // BUTTON MINUS
            // =========================================

            btnMinus.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btnMinus.Location = new Point(245, 250);

            btnMinus.Name = "btnMinus";

            btnMinus.Size = new Size(75, 55);

            btnMinus.TabIndex = 13;

            btnMinus.Text = "−";

            btnMinus.UseVisualStyleBackColor = true;

            btnMinus.Click += OperatorButton_Click;

            // =========================================
            // BUTTON 0
            // =========================================

            btn0.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btn0.Location = new Point(20, 315);

            btn0.Name = "btn0";

            btn0.Size = new Size(65, 55);

            btn0.TabIndex = 14;

            btn0.Text = "0";

            btn0.UseVisualStyleBackColor = true;

            btn0.Click += NumberButton_Click;

            // =========================================
            // BUTTON DECIMAL
            // =========================================

            btnDecimal.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btnDecimal.Location = new Point(95, 315);

            btnDecimal.Name = "btnDecimal";

            btnDecimal.Size = new Size(65, 55);

            btnDecimal.TabIndex = 15;

            btnDecimal.Text = ".";

            btnDecimal.UseVisualStyleBackColor = true;

            btnDecimal.Click += btnDecimal_Click;

            // =========================================
            // BUTTON CLEAR
            // =========================================

            btnClear.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btnClear.Location = new Point(170, 315);

            btnClear.Name = "btnClear";

            btnClear.Size = new Size(65, 55);

            btnClear.TabIndex = 16;

            btnClear.Text = "C";

            btnClear.UseVisualStyleBackColor = true;

            btnClear.Click += btnClear_Click;

            // =========================================
            // BUTTON PLUS
            // =========================================

            btnPlus.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            btnPlus.Location = new Point(245, 315);

            btnPlus.Name = "btnPlus";

            btnPlus.Size = new Size(75, 55);

            btnPlus.TabIndex = 17;

            btnPlus.Text = "+";

            btnPlus.UseVisualStyleBackColor = true;

            btnPlus.Click += OperatorButton_Click;

            // =========================================
            // BUTTON EQUALS
            // =========================================

            btnEquals.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );

            btnEquals.Location = new Point(20, 390);

            btnEquals.Name = "btnEquals";

            btnEquals.Size = new Size(300, 55);

            btnEquals.TabIndex = 18;

            btnEquals.Text = "=";

            btnEquals.UseVisualStyleBackColor = true;

            btnEquals.Click += btnEquals_Click;

            // =========================================
            // ADD CONTROLS TO FORM
            // =========================================

            Controls.Add(lblTitle);
            Controls.Add(txtDisplay);

            Controls.Add(btn7);
            Controls.Add(btn8);
            Controls.Add(btn9);
            Controls.Add(btnDivide);

            Controls.Add(btn4);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btnMultiply);

            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btnMinus);

            Controls.Add(btn0);
            Controls.Add(btnDecimal);
            Controls.Add(btnClear);
            Controls.Add(btnPlus);

            Controls.Add(btnEquals);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}