using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Text.RegularExpressions;

namespace CSharpGoWinForm
{
    public partial class Frm_WordCount :DockContent
    {
        Color m_Color;
        Font m_Font;    
        public Frm_WordCount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxIput.Items.Clear();
            string strRemove = Regex.Replace(textBoxGet.Text, @"[\p{P}*]", " ");//删除标点符号
            int iMax = 0;
            string[] strWordArr = Regex.Split(strRemove, @"\s");//空格，回车分割
            Dictionary<string, int> dicWord2Num = new Dictionary<string, int>();
            foreach (string strTemp in strWordArr)
            {
                if (strTemp.Length > iMax)
                {
                    iMax = strTemp.Length;
                }
                if (strTemp != "")
                {
                    if (!dicWord2Num.ContainsKey(strTemp))
                    {
                        dicWord2Num.Add(strTemp, 1);
                    }
                    else
                    {
                        int iTemp = dicWord2Num[strTemp];
                        dicWord2Num[strTemp] = iTemp + 1;
                    }
                }
            }

            IOrderedEnumerable<KeyValuePair<string, int>> result = dicWord2Num.OrderByDescending(u => u.Value);

            foreach (KeyValuePair<string, int> kv in result)
            {
                listBoxIput.Items.Add(kv.Key + strAdd(iMax - kv.Key.Length) + kv.Value);
            }  
        }

        string strAdd(int iLong)
        {
            string str = "-----";
            for (int i = 0; i < iLong; i++)
            {
                str += "-";
            }
            return str;
        }

        private void Frm_WordCount_Load(object sender, EventArgs e)
        {
            m_Color = textBoxGet.SelectionColor;
            m_Font = textBoxGet.SelectionFont;
            this.textBoxGet.Text = "My father was a self-taught mandolin player. He was one of the best string instrument players in our town. He could not read music, but if he heard a tune a few times, he could play it. When he was younger, he was a member of a small country music band. They would play at local dances and on a few occasions would play for the local radio station. He often told us how he had auditioned and earned a position in a band that featured Patsy Cline as their lead singer. He told the family that after he was hired he never went back. Dad was a very religious man. He stated that there was a lot of drinking and cursing the day of his audition and he did not want to be around that type of environment.";
        }

        private void listBoxIput_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxGet.Select(0, textBoxGet.Text.Length);
            textBoxGet.SelectionColor = m_Color;
            textBoxGet.SelectionFont = m_Font;
            ListBox lstTemp = sender as ListBox;
            int nIndex = lstTemp.SelectedIndex;
            string strTemp = lstTemp.Items[nIndex] as string;
            string[] strArr = strTemp.Split('-');

            int index = textBoxGet.Find(strArr[0], RichTextBoxFinds.WholeWord  |RichTextBoxFinds.MatchCase);//调用find方法，并设置区分全字匹配  
            int startPos = index;
            int nextIndex = 0;
            while (nextIndex != startPos)//循环查找字符串，并用蓝色加粗12号Times New Roman标记之  
            {
                textBoxGet.SelectionStart = index;
                textBoxGet.SelectionLength = strArr[0].Length;
                textBoxGet.SelectionColor = Color.Blue;
                textBoxGet.SelectionFont = new Font("Times New Roman", (float)12, FontStyle.Bold);
                nextIndex = textBoxGet.Find(strArr[0], index + strArr[0].Length, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
                if (nextIndex == -1)//若查到文件末尾，则充值nextIndex为初始位置的值，使其达到初始位置，顺利结束循环，否则会有异常。  
                    nextIndex = startPos;
                index = nextIndex;
            } 
        }
    }
}
