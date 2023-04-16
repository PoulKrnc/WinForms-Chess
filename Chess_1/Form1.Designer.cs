namespace Chess_1
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
            this.start_btn = new System.Windows.Forms.Button();
            this.quit_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.queen_choose = new System.Windows.Forms.Button();
            this.knight_choose = new System.Windows.Forms.Button();
            this.bishop_choose = new System.Windows.Forms.Button();
            this.rook_choose = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.enter_bt = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(12, 12);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // quit_btn
            // 
            this.quit_btn.Location = new System.Drawing.Point(12, 41);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(75, 23);
            this.quit_btn.TabIndex = 1;
            this.quit_btn.Text = "Quit";
            this.quit_btn.UseVisualStyleBackColor = true;
            this.quit_btn.Click += new System.EventHandler(this.quit_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(93, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 602);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 0;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.queen_choose);
            this.panel2.Controls.Add(this.knight_choose);
            this.panel2.Controls.Add(this.bishop_choose);
            this.panel2.Controls.Add(this.rook_choose);
            this.panel2.Location = new System.Drawing.Point(701, 237);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 162);
            this.panel2.TabIndex = 5;
            // 
            // queen_choose
            // 
            this.queen_choose.BackgroundImage = global::Chess_1.Properties.Resources.wq;
            this.queen_choose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.queen_choose.Location = new System.Drawing.Point(3, 3);
            this.queen_choose.Name = "queen_choose";
            this.queen_choose.Size = new System.Drawing.Size(75, 75);
            this.queen_choose.TabIndex = 9;
            this.queen_choose.UseVisualStyleBackColor = true;
            this.queen_choose.Click += new System.EventHandler(this.queen_choose_Click);
            // 
            // knight_choose
            // 
            this.knight_choose.BackgroundImage = global::Chess_1.Properties.Resources.wn;
            this.knight_choose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.knight_choose.Location = new System.Drawing.Point(84, 84);
            this.knight_choose.Name = "knight_choose";
            this.knight_choose.Size = new System.Drawing.Size(75, 75);
            this.knight_choose.TabIndex = 8;
            this.knight_choose.UseVisualStyleBackColor = true;
            this.knight_choose.Click += new System.EventHandler(this.knight_choose_Click);
            // 
            // bishop_choose
            // 
            this.bishop_choose.BackgroundImage = global::Chess_1.Properties.Resources.wb;
            this.bishop_choose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bishop_choose.Location = new System.Drawing.Point(3, 84);
            this.bishop_choose.Name = "bishop_choose";
            this.bishop_choose.Size = new System.Drawing.Size(75, 75);
            this.bishop_choose.TabIndex = 7;
            this.bishop_choose.UseVisualStyleBackColor = true;
            this.bishop_choose.Click += new System.EventHandler(this.bishop_choose_Click);
            // 
            // rook_choose
            // 
            this.rook_choose.BackgroundImage = global::Chess_1.Properties.Resources.wr;
            this.rook_choose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rook_choose.Location = new System.Drawing.Point(84, 3);
            this.rook_choose.Name = "rook_choose";
            this.rook_choose.Size = new System.Drawing.Size(75, 75);
            this.rook_choose.TabIndex = 6;
            this.rook_choose.UseVisualStyleBackColor = true;
            this.rook_choose.Click += new System.EventHandler(this.rook_choose_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Chess_1.Properties.Resources.crni_trdnjava;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(12, 301);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 75);
            this.button3.TabIndex = 4;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(701, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 193);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox1.Location = new System.Drawing.Point(701, 208);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 23);
            this.textBox1.TabIndex = 7;
            // 
            // enter_bt
            // 
            this.enter_bt.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.enter_bt.Location = new System.Drawing.Point(840, 207);
            this.enter_bt.Name = "enter_bt";
            this.enter_bt.Size = new System.Drawing.Size(23, 24);
            this.enter_bt.TabIndex = 8;
            this.enter_bt.UseVisualStyleBackColor = false;
            this.enter_bt.Click += new System.EventHandler(this.enter_bt_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(879, 240);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 92);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 638);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.enter_bt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quit_btn);
            this.Controls.Add(this.start_btn);
            this.Name = "Form1";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button start_btn;
        private Button quit_btn;
        private Label label1;
        private Panel panel1;
        private Button button3;
        private Panel panel2;
        private Button knight_choose;
        private Button bishop_choose;
        private Button rook_choose;
        private Button queen_choose;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBox1;
        private Button enter_bt;
        private TableLayoutPanel tableLayoutPanel1;
    }
}