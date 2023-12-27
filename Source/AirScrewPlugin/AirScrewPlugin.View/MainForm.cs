namespace AirScrewPlugin.View
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using AirScrewPlugin.Model;
    using AirScrewPlugin.Wrapper;
    using Microsoft.VisualBasic.Devices;

    /// <summary>
    /// Класс Main.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Контейнер параметров детали.
        /// </summary>
        private readonly AirScrewParametrs _parameters = new AirScrewParametrs();

        /// <summary>
        /// Объект-сроитель.
        /// </summary>
        private readonly AirScrewBuilder _builder = new AirScrewBuilder();

        /// <summary>
        /// Действия конструктора:
        /// 1. Запрещает писать текст в комбобоксе
        /// 2. Изначально значение комбо-бокса = 1
        /// 3. Делает кнопку постостроения не активной, дляя дальнейшей валидации.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            comboBoxForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxForm.SelectedIndex = 0;
            buttonBuild.Enabled = false;
        }

        /// <summary>
        /// Доп валидация всех параметров для активации/дизактивации кнопки build.
        /// </summary>
        private void ValidationAllParam()
        {
            bool flagActiveButton = true;
            var errorTextBox = new TextBox();
            try
            {
                errorTextBox = textBoxBladeWidth;
                _parameters.BladeWidth = float.Parse(textBoxBladeWidth.Text);
                errorTextBox = textBoxBladeLength;
                _parameters.BladeLength = float.Parse(textBoxBladeLength.Text);
                errorTextBox = textBoxInnerRadius;
                _parameters.InnerRadius = float.Parse(textBoxInnerRadius.Text);
                errorTextBox = textBoxOuterRadius;
                _parameters.OuterRadius = float.Parse(textBoxOuterRadius.Text);
                errorTextBox = textBoxNumberOfBlades;
                _parameters.NumberOfBlades = float.Parse(textBoxNumberOfBlades.Text);
            }
            catch (Exception)
            {
                flagActiveButton = false;

                errorTextBox.BackColor = errorTextBox.Text.Length != 0 ? Color.LightPink : Color.White;
            }

            /*if (flagActiveButton == false)
            {
                buttonBuild.Enabled = false;
            }
            else
            {
                buttonBuild.Enabled = true;
            }*/
            buttonBuild.Enabled = flagActiveButton != false;
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            _builder.BuildAirScrew(_parameters, comboBoxForm.SelectedIndex);
        }

        private void textBoxBladeWidth_TextChanged(object sender, EventArgs e)
        {
            textBoxBladeWidth.Text = Validator.ParameterCheck(textBoxBladeWidth.Text);
            ValidationAllParam();
            try
            {
                _parameters.BladeWidth = float.Parse(textBoxBladeWidth.Text);
                textBoxBladeWidth.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                textBoxBladeWidth.BackColor = Color.LightPink;
            }
        }

        private void textBoxBladeLength_TextChanged(object sender, EventArgs e)
        {
            textBoxBladeLength.Text = Validator.ParameterCheck(textBoxBladeLength.Text);
            ValidationAllParam();
            try
            {
                _parameters.BladeLength = float.Parse(textBoxBladeLength.Text);
                textBoxBladeLength.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                textBoxBladeLength.BackColor = Color.LightPink;
            }
        }

        private void textBoxInnerRadius_TextChanged(object sender, EventArgs e)
        {
            textBoxInnerRadius.Text = Validator.ParameterCheck(textBoxInnerRadius.Text);
            ValidationAllParam();
            try
            {
                _parameters.InnerRadius = float.Parse(textBoxInnerRadius.Text);
                textBoxInnerRadius.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                textBoxInnerRadius.BackColor = Color.LightPink;
            }
        }

        private void textBoxOuterRadius_TextChanged(object sender, EventArgs e)
        {
            textBoxOuterRadius.Text = Validator.ParameterCheck(textBoxOuterRadius.Text);
            ValidationAllParam();
            try
            {
                _parameters.OuterRadius = float.Parse(textBoxOuterRadius.Text);
                textBoxOuterRadius.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                textBoxOuterRadius.BackColor = Color.LightPink;
            }
        }

        private void textBoxNumberOfBlades_TextChanged(object sender, EventArgs e)
        {
            textBoxNumberOfBlades.Text = Validator.ParameterCheck(textBoxNumberOfBlades.Text);
            ValidationAllParam();
            try
            {
                _parameters.NumberOfBlades = float.Parse(textBoxNumberOfBlades.Text);
                textBoxNumberOfBlades.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                textBoxNumberOfBlades.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Оставленно на главной форме т.к. планируется дальнейшее расширение плагина НЕ УДАЛЯТЬ.
        /// </summary>
        private void buttonStressTests_Click(object sender, EventArgs e)
        {
            var builder = new AirScrewBuilder();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var parameters = new AirScrewParametrs();
            var streamWriter = new StreamWriter($"log.txt", true);
            Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            var count = 0;
            while (true)
            {
                const double gigabyteInByte = 0.000000000931322574615478515625;
                builder.BuildAirScrew(_parameters, comboBoxForm.SelectedIndex);
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory
                                  - computerInfo.AvailablePhysicalMemory)
                                 * gigabyteInByte;

                /*stopWatch.Reset();*/
                streamWriter.WriteLine(
                    $"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }

            stopWatch.Stop();
            streamWriter.Close();
            streamWriter.Dispose();
            Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
        }
    }
}