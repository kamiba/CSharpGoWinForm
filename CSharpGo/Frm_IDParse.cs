using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Globalization;

namespace CSharpGoWinForm
{
    public partial class Frm_IDParse : DockContent
    {
        public Frm_IDParse()
        {
            InitializeComponent();
        }
        void research()
        {
            string strPath = Application.StartupPath;
            strPath = strPath.Replace(@"bin\Debug","");
            strPath = strPath.Replace(@"bin\Release", "");
            if (textBoxNum.Text.Length != 18)
            {
                MessageBox.Show("输入信息有误，请重新输入！");
                return;
            }
            Dictionary<string, string> dicNum2Area = new Dictionary<string, string>();
            string strLine;

            FileStream aFile = new FileStream(strPath + @"\AreaCode.txt", FileMode.Open);
            StreamReader sr = new StreamReader(aFile, Encoding.UTF8);
            strLine = sr.ReadLine();
            while (strLine != null)
            {
                if (strLine != null)
                {
                    string[] strArr = strLine.Split(' ');
                    dicNum2Area.Add(strArr[0], strArr[1]);
                }
                strLine = sr.ReadLine();
            }
            sr.Close();
            textBoxPlace.Text = dicNum2Area[textBoxNum.Text.Substring(0, 6)];
            dateTimePickerBirthday.Value = DateTime.ParseExact(textBoxNum.Text.Substring(6, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
            int iBool = int.Parse(textBoxNum.Text.Substring(16,1)) % 2;
            if (0 == (iBool))
                textBoxSex.Text = "女";
            else
                textBoxSex.Text = "男";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            research();
        }

        private void textBoxNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                research();
            }
        }

    }
}
