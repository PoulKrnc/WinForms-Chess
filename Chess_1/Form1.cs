using System.Runtime.InteropServices;

namespace Chess_1
{
    public partial class Form1 : Form
    {
        public string read_write = "r";
        public int stevec = 2;
        public List<Pos> poss = new List<Pos>();
        public List<Button> btns = new List<Button>();
        public int[] starting_figure_pos = { 11, 12, 13, 14, 15, 16, 17, 18, 21, 22, 23, 24, 25, 26, 27, 28, 31, 32, 33, 34, 35, 36, 37, 38, 41, 42, 43, 44, 45, 46, 47, 48, 51, 52, 53, 54, 55, 56, 57, 58, 61, 62, 63, 64, 65, 66, 67, 68, 71, 72, 73, 74, 75, 76, 77, 78, 81, 82, 83, 84, 85, 86, 87, 88 };
        public string[] starting_figure1 = { "trdnjava1", "konj1", "tekac1", "kraljica1", "kralj1", "tekac1", "konj1", "trdnjava1",
                                             "kmet1", "kmet1", "kmet1", "kmet1", "kmet1","kmet1", "kmet1", "kmet1",
                                             "", "", "", "", "", "", "", "",
                                             "", "", "", "", "", "", "", "",
                                             "", "", "", "", "", "", "", "",
                                             "", "", "", "", "", "", "", "",
                                             "kmet", "kmet", "kmet", "kmet", "kmet", "kmet", "kmet", "kmet",
                                             "trdnjava", "konj", "tekac", "kraljica", "kralj", "tekac", "konj", "trdnjava"};
        public string[] igralec0_figure = { "trdnjava", "kmet", "konj", "tekac", "kraljica", "kralj" };
        public string[] igralec1_figure = { "trdnjava1", "kmet1", "konj1", "tekac1", "kraljica1", "kralj1" };
        public string moving_figure;
        public object moving_figure_tag;
        public bool bt_was_clicked = false;
        public int kmet_on_end0;
        public int kmet_on_end1;


        public bool end_of_game;

        public Form1()
        {
            InitializeComponent();
            button3.Visible = false;
            label1.Text = "";
            panel2.Visible = false;
            label2.Visible = false;
            flowLayoutPanel1.Visible = true;
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            read_write = "r";
            stevec = 2;
            poss = new List<Pos>();
            btns = new List<Button>();
            panel1.Controls.Clear();

            panel2.Visible = false;
            label1.Visible = false;
            end_of_game = false;

            //start_btn.Enabled = false;
            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    Pos pos = new Pos();
                    pos.x_pos = x;
                    pos.y_pos = y;
                    pos.pos_pos = x * 10 + y;

                    for (int i = 0; i < starting_figure_pos.Length; i++)
                    {
                        if (pos.pos_pos == starting_figure_pos[i])
                        {
                            pos.figure = starting_figure1[i];
                            break;
                        }
                    }
                    pos.btn_text = pos.figure;
                    var btn = new Button
                    {
                        Width = 75,
                        Height = 75,
                        Left = (y * 75 - 75),
                        Top = (x * 75 - 75),
                        Font = new Font(new FontFamily("Microsoft Sans Serif"), 6.5f),
                        Tag = pos.pos_pos,
                    };
                    pos.pos_btn = btn;
                    pos.tag = btn.Tag;
                    if (x % 2 == 0 || x == 0)
                    {
                        if (y % 2 != 0) { btn.BackColor = SystemColors.ControlDarkDark; }
                        else { btn.BackColor = SystemColors.ControlLightLight; }
                    }
                    else if (x % 2 != 0 || x != 0)
                    {
                        if (y % 2 == 0 || y == 0) { btn.BackColor = SystemColors.ControlDarkDark; }
                        else { btn.BackColor = SystemColors.ControlLightLight; }
                    }
                    btn.Click += button3_Click;
                    poss.Add(pos);
                    btns.Add(btn);
                    pos.team_selector();
                    if (pos.team == "white0")
                        pos.non_food = igralec1_figure;
                    else if (pos.team == "black1")
                        pos.non_food = igralec0_figure;
                }

            }
            panel1.Controls.AddRange(btns.ToArray());
            pictures();
            foreach (int figure_pos in starting_figure_pos)
            {

            }

            flowLayoutPanel1.Controls.Clear();

            string str = "Start of game";
            var lb = new Label();
            lb.Text = str;
            lb.Visible = true;
            flowLayoutPanel1.Controls.Add(lb);
        }

        private void quit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pos_check pos_Check = new Pos_check();
            foreach (Button btn in btns)
            {
                if (btn.BackColor == Color.SeaGreen)
                    btn.BackColor = SystemColors.ControlDarkDark;
                else if (btn.BackColor == Color.LightGreen)
                    btn.BackColor = SystemColors.ControlLightLight;

                if (btn.BackColor == SystemColors.ControlDark)
                    btn.BackColor = SystemColors.ControlDarkDark;
                else if (btn.BackColor == Color.LightGray)
                    btn.BackColor = SystemColors.ControlLightLight;
            }
            foreach (Button btn in btns)
            {
                bool MouseIsOverControl(Button btn2) =>
                    btn2.ClientRectangle.Contains(btn2.PointToClient(Cursor.Position));
                if (MouseIsOverControl(btn))
                {
                    if (read_write == "r")
                    {
                        if (btn.BackColor == SystemColors.ControlDarkDark)
                            btn.BackColor = SystemColors.ControlDark;
                        else if (btn.BackColor == SystemColors.ControlLightLight)
                            btn.BackColor = Color.LightGray;

                        foreach (Pos pos in poss)
                        {
                            if (btn.Tag == pos.tag)
                            {
                                foreach (string figure1 in igralec0_figure)
                                {
                                    if (pos.figure == figure1 && stevec % 2 == 0)
                                    {

                                        moving_figure = pos.figure;
                                        moving_figure_tag = pos.tag;
                                        read_write = "w";

                                        pos_Check.r_pos = pos;
                                        pos_Check.poss = poss;
                                        foreach (Pos pos1 in pos_Check.figure_check())
                                        {
                                            foreach(Button btn1 in btns)
                                            {
                                                if (btn1.Tag == pos1.tag)
                                                {
                                                    if (btn1.BackColor == SystemColors.ControlDarkDark)
                                                        btn1.BackColor = Color.SeaGreen;
                                                    else if (btn1.BackColor == SystemColors.ControlLightLight)
                                                        btn1.BackColor = Color.LightGreen;
                                                }
                                            }
                                        }

                                        break;
                                    }
                                }
                                foreach (string figure2 in igralec1_figure)
                                {
                                    if (pos.figure == figure2 && stevec % 2 != 0)
                                    {

                                        moving_figure = pos.figure;
                                        moving_figure_tag = pos.tag;
                                        read_write = "w";

                                        pos_Check.r_pos = pos;
                                        pos_Check.poss = poss;
                                        foreach (Pos pos1 in pos_Check.figure_check())
                                        {
                                            foreach (Button btn1 in btns)
                                            {
                                                if (btn1.Tag == pos1.tag)
                                                {
                                                    if (btn1.BackColor == SystemColors.ControlDarkDark)
                                                        btn1.BackColor = Color.SeaGreen;
                                                    else if (btn1.BackColor == SystemColors.ControlLightLight)
                                                        btn1.BackColor = Color.LightGreen;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }

                            }
                        }
                        break;
                    }
                    //¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸¸
                    else if (read_write == "w")
                    {

                        read_write = "r";
                        foreach (Pos pos in poss)
                        {
                            if (btn.Tag == pos.tag)
                            {
                                
                                foreach (Pos pos2 in poss)
                                {
                                    if (pos2.tag == moving_figure_tag)
                                    {
                                        foreach (Button btn2 in btns)
                                        {
                                            if (btn2.Tag == pos2.tag)
                                            {
                                                //if stavek �e je mo�no premakniti
                                                
                                                pos_Check.r_pos = pos2;
                                                pos_Check.poss = poss;
                                                foreach (Pos pos3 in pos_Check.figure_check())
                                                {
                                                    if (pos == pos3)
                                                    {
                                                        if (pos2.figure == "kmet" & pos.x_pos == 1)
                                                        {
                                                            kmet_on_end0 = pos.x_pos;
                                                            kmet_on_end1 = pos.y_pos;
                                                            panel2.Visible = true;
                                                            foreach (Button bt in btns)
                                                            {
                                                                bt.Enabled = false;
                                                            }
                                                        }
                                                        if (pos2.figure == "kmet1" & pos.x_pos == 8)
                                                        {
                                                            kmet_on_end0 = pos.x_pos;
                                                            kmet_on_end1 = pos.y_pos;
                                                            panel2.Visible = true;
                                                            foreach (Button bt in btns)
                                                            {
                                                                bt.Enabled = false;
                                                            }
                                                        }
                                                        //
                                                        if (pos2.figure == "kralj" || pos2.figure == "kralj1")
                                                        {
                                                            if (pos.y_pos == 3) { pos_Check.rosada_assist = 1; }
                                                            else if (pos.y_pos == 7) { pos_Check.rosada_assist = 8; }
                                                        }
                                                        //
                                                        pos2.figure = "";
                                                        pos2.team_selector();
                                                        //IF KING IS EATEN
                                                        if (pos.figure == "kralj")
                                                        {
                                                            end_of_game = true;
                                                            label1.Visible = true;
                                                            label1.Text = "BLACK WINS!";
                                                            foreach (Button bt in btns)
                                                            {
                                                                bt.Enabled = false;
                                                            }
                                                        }
                                                        if (pos.figure == "kralj1")
                                                        {
                                                            end_of_game = true;
                                                            label1.Visible = true;
                                                            label1.Text = "WHITE WINS!";
                                                            foreach (Button bt in btns)
                                                            {
                                                                bt.Enabled = false;
                                                            }
                                                        }
                                                        //text panel

                                                        string str1 = "abcdefgh";
                                                        string pos2_str = str1[pos2.y_pos - 1] + Convert.ToString(pos2.x_pos);
                                                        string pos_str = str1[pos.y_pos - 1] + Convert.ToString(pos.x_pos);


                                                        string str = Convert.ToString(stevec-1) + ". " + Convert.ToString(pos2_str) + " -> " + Convert.ToString(pos_str);
                                                        var lb = new Label();
                                                        lb.Text = str;
                                                        lb.Visible = true;
                                                        flowLayoutPanel1.Controls.Add(lb);
                                                        flowLayoutPanel1.ScrollControlIntoView(lb);
                                                        //
                                                        pos.figure = moving_figure;
                                                        pos.stevec++;
                                                        pos2.stevec++;
                                                        pos2.btn_text = pos2.figure;
                                                        pos.btn_text = pos.figure;
                                                        pos.team_selector();
                                                        pictures();
                                                        if (pos.team == "white0")
                                                            pos.non_food = igralec1_figure;
                                                        else if (pos.team == "black1")
                                                            pos.non_food = igralec0_figure;
                                                        stevec++;

                                                    }
                                                }

                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
            

            if (pos_Check.rosada0 == true)
            {
                
                int st1 = 0;
                if (pos_Check.rosada_assist == 1)
                {
                    st1 = 4;
                }
                else if (pos_Check.rosada_assist == 8)
                {
                    st1 = 6;
                }
                Pos ps_t = null;
                Pos ps_p = null;
                foreach(Pos ps1 in poss)
                {
                    if (ps1.y_pos == pos_Check.rosada_assist && ps1.x_pos == 8)
                    {
                        ps_t = ps1;
                    }
                    if (ps1.y_pos == st1 && ps1.x_pos == 8)
                    {
                        ps_p = ps1;
                    }
                }
                string fg = ps_p.figure;
                ps_p.figure = ps_t.figure;
                ps_t.figure = fg;
                ps_p.team_selector();
                ps_t.team_selector();
                ps_p.stevec++;
                ps_t.stevec++;
                pictures();
                pos_Check.rosada0 = false;
            }
            if (pos_Check.rosada1 == true)
            {
                int st1 = 0;
                if (pos_Check.rosada_assist == 1)
                {
                    st1 = 4;
                }
                else if (pos_Check.rosada_assist == 8)
                {
                    st1 = 6;
                }
                Pos ps_t = null;
                Pos ps_p = null;
                foreach (Pos ps1 in poss)
                {
                    if (ps1.y_pos == pos_Check.rosada_assist && ps1.x_pos == 1)
                    {
                        ps_t = ps1;
                    }
                    if (ps1.y_pos == st1 && ps1.x_pos == 1)
                    {
                        ps_p = ps1;
                    }
                }
                string fg = ps_p.figure;
                ps_p.figure = ps_t.figure;
                ps_t.figure = fg;
                ps_p.team_selector();
                ps_t.team_selector();
                ps_p.stevec++;
                ps_t.stevec++;
                pictures();
                pos_Check.rosada1 = false;
            }
        }

        public void pictures()//pictures
        {
            foreach (Pos pos in poss)
            {
                foreach (Button btn in btns)
                {
                    if (btn.Tag == pos.tag)
                    {
                        if (pos.figure == "kmet1")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.crni_kmet;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "kmet")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.beli_kmet;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "tekac")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.beli_tekac;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "tekac1")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.crni_tekac;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "konj")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.beli_konj;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "konj1")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.crni_konj;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "trdnjava")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.beli_trdnjava;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "trdnjava1")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.crni_trdnjava;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "kraljica")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.beli_kraljica;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "kraljica1")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.crni_kraljica;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "kralj")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.beli_kralj;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (pos.figure == "kralj1")
                        {
                            btn.BackgroundImage = global::Chess_1.Properties.Resources.crni_kralj;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else
                        {
                            btn.BackgroundImage = null;
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        /*
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        */
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void rook_choose_Click(object sender, EventArgs e)
        {
            if (end_of_game == true) { return; }
            foreach (Pos ps in poss)
            {
                if (ps.x_pos == kmet_on_end0 && ps.y_pos == kmet_on_end1)
                {
                    if (ps.x_pos == 1) { ps.figure = "trdnjava"; }
                    else if (ps.x_pos == 8) { ps.figure = "trdnjava1"; }
                    ps.btn_text = ps.figure;
                    pictures();
                    ps.btn_text = ps.figure;
                    pictures();
                }
            }
            kmet_on_end0 = 0;
            kmet_on_end1 = 0;
            panel2.Visible = false;
            foreach (Button bt in btns)
            {
                bt.Enabled = true;
            }
        }

        private void queen_choose_Click(object sender, EventArgs e)
        {
            if (end_of_game == true) { return; }
            foreach (Pos ps in poss)
            {
                if (ps.x_pos == kmet_on_end0 && ps.y_pos == kmet_on_end1)
                {
                    if (ps.x_pos == 1) { ps.figure = "kraljica"; }
                    else if (ps.x_pos == 8) { ps.figure = "kraljica1"; }
                    ps.btn_text = ps.figure;
                    pictures();
                }
            }
            kmet_on_end0 = 0;
            kmet_on_end1 = 0;
            panel2.Visible = false;
            foreach (Button bt in btns)
            {
                bt.Enabled = true;
            }
        }

        private void bishop_choose_Click(object sender, EventArgs e)
        {
            if (end_of_game == true) { return; }
            foreach (Pos ps in poss)
            {
                if (ps.x_pos == kmet_on_end0 && ps.y_pos == kmet_on_end1)
                {
                    if (ps.x_pos == 1){ ps.figure = "tekac"; }
                    else if (ps.x_pos == 8) { ps.figure = "tekac1"; }
                    ps.btn_text = ps.figure;
                    pictures();
                }
            }
            kmet_on_end0 = 0;
            kmet_on_end1 = 0;
            panel2.Visible = false;
            foreach (Button bt in btns)
            {
                bt.Enabled = true;
            }
        }

        private void knight_choose_Click(object sender, EventArgs e)
        {
            if (end_of_game == true) { return; }
            foreach (Pos ps in poss)
            {
                if (ps.x_pos == kmet_on_end0 && ps.y_pos == kmet_on_end1)
                {
                    if (ps.x_pos == 1) { ps.figure = "konj"; }
                    else if (ps.y_pos == 8) { ps.figure = "konj1"; }
                    ps.btn_text = ps.figure;
                    pictures();
                }
            }
            kmet_on_end0 = 0;
            kmet_on_end1 = 0;
            panel2.Visible = false;
            foreach (Button bt in btns)
            {
                bt.Enabled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void enter_bt_Click(object sender, EventArgs e)
        {
            string str1 = textBox1.Text;
            textBox1.Clear();
            string str2 = "";
            string str3 = "";
            if (str1[0] == '/' && str1.Contains("spawn"))
            {
                str2 = Convert.ToString(str1[7]) + Convert.ToString(str1[8]);
                str3 = Convert.ToString(str1[10]) + Convert.ToString(str1[11]);
                foreach (Pos pos in poss)
                {
                    if (pos.pos_pos == Convert.ToInt32(str2))
                    {
                        if (str3 == "wp") { pos.figure = "kmet"; }
                        else if (str3 == "wr") { pos.figure = "trdnjava"; }
                        else if (str3 == "wb") { pos.figure = "tekac"; }
                        else if (str3 == "wn") { pos.figure = "konj"; }
                        else if (str3 == "wq") { pos.figure = "kraljica"; }
                        else if (str3 == "wk") { pos.figure = "kralj"; }
                        if (str3 == "bp") { pos.figure = "kmet1"; }
                        else if (str3 == "br") { pos.figure = "trdnjava1"; }
                        else if (str3 == "bb") { pos.figure = "tekac1"; }
                        else if (str3 == "bn") { pos.figure = "konj1"; }
                        else if (str3 == "bq") { pos.figure = "kraljica1"; }
                        else if (str3 == "bk") { pos.figure = "kralj1"; }
                        pos.team_selector();
                    }
                }
            }
            pictures();
        }
        /*
        private static void panel_text(string[] args)
        {
            string str = "";
            foreach (string arg in args)
            {
                str += arg;
            }
            var lb = new Label();
            lb.Text = str;
            lb.Visible = true;
            
        }
        */
    }
}