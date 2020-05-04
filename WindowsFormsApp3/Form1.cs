using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //label1.Text = MyApplicationContext.GetSystemKeyboardLayouts().All;
            //foreach (string Language in MyApplicationContext.GetSystemKeyboardLayouts().ToString(Environment.ExitCode))
            //{
              //  label1.Text = "1111";
            //}
        }

       // public void SetTextForLabel(string myText)
       // {
        //    this.label1.Text = myText;
       // }

        public string LabelText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        // public bool ControlIsVisible
        //{
        //     get { return control.Visible; }
        //    set { control.Visible = value; }
        //}

    }
}
