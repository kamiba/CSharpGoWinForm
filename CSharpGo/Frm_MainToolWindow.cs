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
    public partial class Frm_MainToolWindow : DockContent
    {

        private void InitializeOutlookbar()
        {
            this.treeViewTask.Nodes.Clear();

            TreeNode nodeRoot = new TreeNode();
            nodeRoot.Text = "CSharpGoWinFormWinForm";
            nodeRoot.Tag = -1;
            this.treeViewTask.Nodes.Add(nodeRoot);


            foreach (string strModule in Frm_Main.m_dicFormText2FormTypeName.Keys)
            {
                TreeNode node = new TreeNode();
                node.Text = strModule;

                node.Tag = 0;
                node.ImageIndex = 0;
                nodeRoot.Nodes.Add(node);
                foreach (string strItem in Frm_Main.m_dicFormText2FormTypeName[strModule].Keys)
                {
                    TreeNode nodeChild = new TreeNode();
                    nodeChild.Text = strItem;

                    nodeChild.Tag = 1;
                    nodeChild.ImageIndex = 1;
                    node.Nodes.Add(nodeChild);

                }

            }

            this.treeViewTask.SelectedNode = this.treeViewTask.TopNode;
            nodeRoot.Expand();

     
        }
        
 
         public Frm_MainToolWindow()
        {
            
            InitializeComponent();
            InitializeOutlookbar();
        }

         private void Frm_MainToolWindow_Load(object sender, EventArgs e)
         {

         }

  

         private void treeViewTask_MouseDoubleClick(object sender, MouseEventArgs e)
         {
             Point pos = new Point(e.X, e.Y);
             TreeNode nodeClick = this.treeViewTask.GetNodeAt(pos);
             if (nodeClick.Text == "CSharpGoWinFormWinForm")
             {


                 return;
             }
             if (nodeClick != null && e.Button == MouseButtons.Left)
             {
                 int nTag = (int)nodeClick.Tag;
                 if (nTag == 0)
                 {
                     return;
                 }
                 this.treeViewTask.SelectedNode = nodeClick;

                 //LoadInfoByNode();

             }

             //ShowContent((string)this.treeViewTask.SelectedNode.Parent.Text + "\\" + (string)this.treeViewTask.SelectedNode.Text);
             Frm_Main.GetMainForm().ShowContent(this.treeViewTask.SelectedNode.Text);
         }
    }
}

