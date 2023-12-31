﻿namespace AirScrewPlugin.View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonBuild = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBladeWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBladeLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxInnerRadius = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxOuterRadius = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxNumberOfBlades = new System.Windows.Forms.TextBox();
            this.comboBoxForm = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonStressTests = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(35, 306);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(464, 82);
            this.buttonBuild.TabIndex = 0;
            this.buttonBuild.Text = "Построить";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ширина лопасти винта (Влопасти)";
            // 
            // textBoxBladeWidth
            // 
            this.textBoxBladeWidth.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBladeWidth.Location = new System.Drawing.Point(234, 67);
            this.textBoxBladeWidth.Name = "textBoxBladeWidth";
            this.textBoxBladeWidth.Size = new System.Drawing.Size(121, 20);
            this.textBoxBladeWidth.TabIndex = 2;
            this.textBoxBladeWidth.Text = "20";
            this.textBoxBladeWidth.TextChanged += new System.EventHandler(this.textBoxBladeWidth_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "15 — 60мм";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "100 — 300мм";
            // 
            // textBoxBladeLength
            // 
            this.textBoxBladeLength.Location = new System.Drawing.Point(234, 108);
            this.textBoxBladeLength.Name = "textBoxBladeLength";
            this.textBoxBladeLength.Size = new System.Drawing.Size(121, 20);
            this.textBoxBladeLength.TabIndex = 5;
            this.textBoxBladeLength.Text = "100";
            this.textBoxBladeLength.TextChanged += new System.EventHandler(this.textBoxBladeLength_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Длинна лопасти винта (Lлопасти)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(361, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "От Lлопасти / 10, до Lлопасти / 2\r\n";
            // 
            // textBoxInnerRadius
            // 
            this.textBoxInnerRadius.Location = new System.Drawing.Point(234, 150);
            this.textBoxInnerRadius.Name = "textBoxInnerRadius";
            this.textBoxInnerRadius.Size = new System.Drawing.Size(121, 20);
            this.textBoxInnerRadius.TabIndex = 8;
            this.textBoxInnerRadius.Text = "15";
            this.textBoxInnerRadius.TextChanged += new System.EventHandler(this.textBoxInnerRadius_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 26);
            this.label6.TabIndex = 7;
            this.label6.Text = "Внутренний радиус окружности \r\nоснования винта (Rвнутр)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(361, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "От Rвнутр + 10%, до Rвнутр * 2";
            // 
            // textBoxOuterRadius
            // 
            this.textBoxOuterRadius.Location = new System.Drawing.Point(234, 186);
            this.textBoxOuterRadius.Name = "textBoxOuterRadius";
            this.textBoxOuterRadius.Size = new System.Drawing.Size(121, 20);
            this.textBoxOuterRadius.TabIndex = 11;
            this.textBoxOuterRadius.Text = "20";
            this.textBoxOuterRadius.TextChanged += new System.EventHandler(this.textBoxOuterRadius_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 26);
            this.label8.TabIndex = 10;
            this.label8.Text = "Внешний радиус окружности \r\nоснования винта (Rвнеш)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Форма лопасти";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 26);
            this.label10.TabIndex = 14;
            this.label10.Text = "Количество лопастей на окружности \r\nоснования";
            // 
            // textBoxNumberOfBlades
            // 
            this.textBoxNumberOfBlades.Location = new System.Drawing.Point(234, 259);
            this.textBoxNumberOfBlades.Name = "textBoxNumberOfBlades";
            this.textBoxNumberOfBlades.Size = new System.Drawing.Size(121, 20);
            this.textBoxNumberOfBlades.TabIndex = 11;
            this.textBoxNumberOfBlades.Text = "3";
            this.textBoxNumberOfBlades.TextChanged += new System.EventHandler(this.textBoxNumberOfBlades_TextChanged);
            // 
            // comboBoxForm
            // 
            this.comboBoxForm.FormattingEnabled = true;
            this.comboBoxForm.Items.AddRange(new object[] {
            "Прямоугольная",
            "Скруглённая",
            "Эллептическая"});
            this.comboBoxForm.Location = new System.Drawing.Point(234, 223);
            this.comboBoxForm.Name = "comboBoxForm";
            this.comboBoxForm.Size = new System.Drawing.Size(121, 21);
            this.comboBoxForm.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(361, 262);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "От 2, до 15";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(538, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 607);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // buttonStressTests
            // 
            this.buttonStressTests.Location = new System.Drawing.Point(35, 394);
            this.buttonStressTests.Name = "buttonStressTests";
            this.buttonStressTests.Size = new System.Drawing.Size(464, 75);
            this.buttonStressTests.TabIndex = 18;
            this.buttonStressTests.Text = "StressTesting";
            this.buttonStressTests.UseVisualStyleBackColor = true;
            this.buttonStressTests.Click += new System.EventHandler(this.buttonStressTests_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 606);
            this.Controls.Add(this.buttonStressTests);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxForm);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxNumberOfBlades);
            this.Controls.Add(this.textBoxOuterRadius);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxInnerRadius);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxBladeLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxBladeWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBuild);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBladeWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBladeLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxInnerRadius;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxOuterRadius;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxNumberOfBlades;
        private System.Windows.Forms.ComboBox comboBoxForm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonStressTests;
    }
}

