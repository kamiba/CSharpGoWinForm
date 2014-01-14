using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CSharpGoWinForm
{
    public partial class Email : DockContent
    {
        public Email()
        {
            InitializeComponent();
        }

        void Split()
        {
            if (textBoxGet.Text == "" || textBoxGet.Text == null)
            {
                MessageBox.Show("请正确输入！");
                return;
            }
            bool Check1 = false;
            bool Check2 = true;
            int i = 0;
            foreach (char c in textBoxGet.Text)
            {
                if (c == '@')
                {
                    Check1 = true;
                    i++;
                    if (i > 1)
                    {
                        Check2 = false;
                    }
                }
            }
            if (Check1 == false || Check2 == false)
            {
                MessageBox.Show("请正确输入！");
                return;
            }
            string[] strTemp = textBoxGet.Text.Split('@');
            textBoxGetName.Text = strTemp[0];
            textBoxGetDomain.Text = strTemp[1];
        }
        void Integrate()
        {
            if (textBoxIputName.Text == "" || textBoxIputName.Text == null || textBoxInputDomain.Text == "" || textBoxInputDomain.Text == null)
            {
                MessageBox.Show("请正确输入！");
                return;
            }
            string[] strTemp = new string[2];
            strTemp[0] = textBoxIputName.Text;
            strTemp[1] = textBoxInputDomain.Text;
            textBoxInput.Text = string.Join("@", strTemp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Split();
        }

        private void textBoxGet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Split();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Integrate();
        }
    }
}
