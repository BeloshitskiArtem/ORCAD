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

namespace AirScrewPlugin.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        } 

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            AirScrewParametrs parametrs = new AirScrewParametrs(150, 1000, 10, 13, 3);
        }

        private void textBoxBladeWidth_TextChanged(object sender, EventArgs e)
        {
            textBoxBladeWidth.Text = Validator.ParametrCheck(textBoxBladeWidth.Text);
        }

        private void textBoxBladeLength_TextChanged(object sender, EventArgs e)
        {
            textBoxBladeLength.Text = Validator.ParametrCheck(textBoxBladeLength.Text);
        }

        private void textBoxInnerRadius_TextChanged(object sender, EventArgs e)
        {
            textBoxInnerRadius.Text = Validator.ParametrCheck(textBoxInnerRadius.Text);
        }

        private void textBoxOuterRadius_TextChanged(object sender, EventArgs e)
        {
            textBoxOuterRadius.Text = Validator.ParametrCheck(textBoxOuterRadius.Text);
        }

        private void textBoxNumberOfBlades_TextChanged(object sender, EventArgs e)
        {
            textBoxNumberOfBlades.Text = Validator.ParametrCheck(textBoxNumberOfBlades.Text);
        }
    }
}
