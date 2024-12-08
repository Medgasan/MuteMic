namespace MuteMic
{
    partial class MuteMic
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MuteMic));
            button1 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            muteToolStripMenuItem = new ToolStripMenuItem();
            showStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem1 = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            notifyIcon1 = new NotifyIcon(components);
            timer1 = new System.Windows.Forms.Timer(components);
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.ContextMenuStrip = contextMenuStrip1;
            button1.Font = new Font("Source Sans Pro", 15F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(-2, -1);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(119, 82);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += button1_mouse_click;
            button1.MouseDown += Form1_MouseDown;
            button1.MouseMove += Form1_MouseMove;
            button1.MouseUp += Form1_MouseUp;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { muteToolStripMenuItem, showStripMenuItem2, toolStripMenuItem2, toolStripSeparator1, toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(175, 98);
            // 
            // muteToolStripMenuItem
            // 
            muteToolStripMenuItem.Name = "muteToolStripMenuItem";
            muteToolStripMenuItem.Size = new Size(174, 22);
            muteToolStripMenuItem.Click += muteToolStripMenuItem_Click;
            // 
            // showStripMenuItem2
            // 
            showStripMenuItem2.Name = "showStripMenuItem2";
            showStripMenuItem2.Size = new Size(174, 22);
            showStripMenuItem2.Click += showStripMenuItem2_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(174, 22);
            toolStripMenuItem2.Text = "Centrar en Pantalla";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(171, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(174, 22);
            toolStripMenuItem1.Text = "Salir";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(-1, 79);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(118, 10);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "MuteMic";
            notifyIcon1.Visible = true;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 500;
            timer1.Tick += check_mic_status;
            // 
            // MuteMic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(117, 90);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MuteMic";
            StartPosition = FormStartPosition.Manual;
            Text = "MuteMic";
            TopMost = true;
            TransparencyKey = Color.FromArgb(64, 0, 64);
            FormClosing += Form1_Closing;
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem muteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem showStripMenuItem2;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem toolStripMenuItem2;
    }
}