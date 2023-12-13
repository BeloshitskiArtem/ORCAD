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
        }

        private AirScrewBuilder _builder = new AirScrewBuilder();
        AirScrewParametrs parametrs = new AirScrewParametrs(25, 110, 10, 19, 4);

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            _builder.BuildAirScrew(parametrs);
        }

        private void textBoxBladeWidth_TextChanged(object sender, EventArgs e)
        {
            textBoxBladeWidth.Text = Validator.ParametrCheck(textBoxBladeWidth.Text);
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
