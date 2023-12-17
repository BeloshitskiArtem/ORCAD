using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirScrewPlugin.Model;
using AirScrewPlugin.Wrapper;


namespace AirScrewPlugin.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Запрещает писать текст в комбобоксе
            comboBoxForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxForm.SelectedIndex = 0;
            buttonBuild.Enabled = false;
        }

        /// <summary>
        /// Контейнер параметров детали
        /// </summary>
        AirScrewParametrs parametrs = new AirScrewParametrs(/*25, 110, 10, 25, 4*/); 

        /// <summary>
        /// Объект-сроитель
        /// </summary>
        private AirScrewBuilder _builder = new AirScrewBuilder();

        /// <summary>
        /// Доп валидация всех параметров для активации/дизактивации кнопки build
        /// </summary>
        private void VakidationAllParam()
        {
            //Флаг  актива
            bool FlagActiveButton = true;
            var ErrorTextBox = new TextBox();   
            try
            {
                ErrorTextBox = textBoxBladeWidth;
                parametrs.BladeWidth = float.Parse(textBoxBladeWidth.Text);
                ErrorTextBox = textBoxBladeLength;
                parametrs.BladeLength = float.Parse(textBoxBladeLength.Text);
                ErrorTextBox = textBoxInnerRadius;
                parametrs.InnerRadius = float.Parse(textBoxInnerRadius.Text);
                ErrorTextBox = textBoxOuterRadius;
                parametrs.OuterRadius = float.Parse(textBoxOuterRadius.Text);
                ErrorTextBox = textBoxNumberOfBlades;
                parametrs.NumberOfBlades = float.Parse(textBoxNumberOfBlades.Text);
            }
            catch (Exception)
            {
                FlagActiveButton = false;

                if (ErrorTextBox.Text.Length != 0)
                {
                    ErrorTextBox.BackColor = Color.LightPink; 
                }
                else
                {
                    ErrorTextBox.BackColor = Color.White;
                }
            }

            if (FlagActiveButton == false)
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
            _builder.BuildAirScrew(parametrs, comboBoxForm.SelectedIndex);
        }

        private void textBoxBladeWidth_TextChanged(object sender, EventArgs e)
        {
            textBoxBladeWidth.Text = Validator.ParametrCheck(textBoxBladeWidth.Text);
            VakidationAllParam();
            try
            {
                parametrs.BladeWidth = float.Parse(textBoxBladeWidth.Text);
                textBoxBladeWidth.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                textBoxBladeWidth.BackColor = Color.LightPink;
            }
        }

        private void textBoxBladeLength_TextChanged(object sender, EventArgs e)
        {
            textBoxBladeLength.Text = Validator.ParametrCheck(textBoxBladeLength.Text);
            VakidationAllParam();
            try
            {
                parametrs.BladeLength = float.Parse(textBoxBladeLength.Text);
                textBoxBladeLength.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                textBoxBladeLength.BackColor = Color.LightPink;
            }
        }

        private void textBoxInnerRadius_TextChanged(object sender, EventArgs e)
        {
            textBoxInnerRadius.Text = Validator.ParametrCheck(textBoxInnerRadius.Text);
            VakidationAllParam();
            try
            {
                parametrs.InnerRadius = float.Parse(textBoxInnerRadius.Text);
                textBoxInnerRadius.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                textBoxInnerRadius.BackColor = Color.LightPink;
            }
        }

        private void textBoxOuterRadius_TextChanged(object sender, EventArgs e)
        {
            textBoxOuterRadius.Text = Validator.ParametrCheck(textBoxOuterRadius.Text);
            VakidationAllParam();
            try
            {
                parametrs.OuterRadius = float.Parse(textBoxOuterRadius.Text);
                textBoxOuterRadius.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                textBoxOuterRadius.BackColor = Color.LightPink;
            }
        }

        private void textBoxNumberOfBlades_TextChanged(object sender, EventArgs e)
        {
            textBoxNumberOfBlades.Text = Validator.ParametrCheck(textBoxNumberOfBlades.Text);
            VakidationAllParam();
            try
            {
                parametrs.NumberOfBlades = float.Parse(textBoxNumberOfBlades.Text);
                textBoxNumberOfBlades.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                textBoxNumberOfBlades.BackColor = Color.LightPink;
            }
        }
    }
}
