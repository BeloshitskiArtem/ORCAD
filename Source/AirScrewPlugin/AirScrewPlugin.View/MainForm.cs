namespace AirScrewPlugin.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using AirScrewPlugin.Model;
    using AirScrewPlugin.Wrapper;

    /// <summary>
    /// Класс Main.
    /// </summary>
    public partial class MainForm : Form
    {
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
        /// Контейнер параметров детали.
        /// </summary>
        #pragma warning disable SA1201 // Elements should appear in the correct order
        private readonly AirScrewParametrs _parameters = new AirScrewParametrs();
        #pragma warning restore SA1201 // Elements should appear in the correct order

        /// <summary>
        /// Объект-сроитель.
        /// </summary>
        private readonly AirScrewBuilder _builder = new AirScrewBuilder();

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

                if (errorTextBox.Text.Length != 0)
                {
                    errorTextBox.BackColor = Color.LightPink;
                }
                else
                {
                    errorTextBox.BackColor = Color.White;
                }
            }

            if (flagActiveButton == false)
            {
                buttonBuild.Enabled = false;
            }
            else
            {
                buttonBuild.Enabled = true;
            }
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
    }
}
