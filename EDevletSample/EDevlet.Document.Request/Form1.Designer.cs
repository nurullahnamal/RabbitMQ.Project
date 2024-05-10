namespace EDevlet.Document.Request
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            txtConnectionString = new System.Windows.Forms.TextBox();
            btnConnect = new System.Windows.Forms.Button();
            btnCreateDocument = new System.Windows.Forms.Button();
            txtLog = new System.Windows.Forms.RichTextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtConnectionString);
            groupBox1.Controls.Add(btnConnect);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(800, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(83, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 15);
            label1.TabIndex = 2;
            label1.Text = "ConnectionString";
            // 
            // txtConnectionString
            // 
            txtConnectionString.Location = new System.Drawing.Point(228, 39);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new System.Drawing.Size(306, 23);
            txtConnectionString.TabIndex = 1;
            txtConnectionString.Text = "amqp://guest:guest@localhost:5672";
            // 
            // btnConnect
            // 
            btnConnect.Location = new System.Drawing.Point(613, 39);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(75, 23);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnCreateDocument
            // 
            btnCreateDocument.Location = new System.Drawing.Point(327, 171);
            btnCreateDocument.Name = "btnCreateDocument";
            btnCreateDocument.Size = new System.Drawing.Size(158, 58);
            btnCreateDocument.TabIndex = 1;
            btnCreateDocument.Text = "Create Document";
            btnCreateDocument.UseVisualStyleBackColor = true;
            btnCreateDocument.Click += btnCreateDocument_Click;
            // 
            // txtLog
            // 
            txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtLog.Location = new System.Drawing.Point(0, 270);
            txtLog.Name = "txtLog";
            txtLog.Size = new System.Drawing.Size(800, 180);
            txtLog.TabIndex = 2;
            txtLog.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(txtLog);
            Controls.Add(btnCreateDocument);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCreateDocument;
        private System.Windows.Forms.RichTextBox txtLog;
    }
}
