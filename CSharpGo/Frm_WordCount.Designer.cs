namespace CSharpGoWinForm
{
    partial class Frm_WordCount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxGet = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxIput = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBoxGet
            // 
            this.textBoxGet.Location = new System.Drawing.Point(38, 18);
            this.textBoxGet.Name = "textBoxGet";
            this.textBoxGet.Size = new System.Drawing.Size(464, 328);
            this.textBoxGet.TabIndex = 6;
            this.textBoxGet.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(362, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "开始统计";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxIput
            // 
            this.listBoxIput.FormattingEnabled = true;
            this.listBoxIput.ItemHeight = 12;
            this.listBoxIput.Location = new System.Drawing.Point(550, 18);
            this.listBoxIput.Name = "listBoxIput";
            this.listBoxIput.Size = new System.Drawing.Size(284, 328);
            this.listBoxIput.TabIndex = 4;
            this.listBoxIput.SelectedIndexChanged += new System.EventHandler(this.listBoxIput_SelectedIndexChanged);
            // 
            // Frm_WordCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 420);
            this.Controls.Add(this.textBoxGet);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxIput);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Frm_WordCount";
            this.Text = "单词统计";
            this.Load += new System.EventHandler(this.Frm_WordCount_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBoxGet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxIput;
    }
}