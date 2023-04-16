using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_1
{
    public class Pos
    {
        public int x_pos;
        public int y_pos;
        public int pos_pos;
        public string btn_text = "";
        public string figure = "";
        public object tag;
        public Button pos_btn;
        public string team;
        public string image;
        public string[] non_food = new string[6];
        public string[] igralec0_figure = { "trdnjava", "kmet", "konj", "tekac", "kraljica", "kralj" };
        public string[] igralec1_figure = { "trdnjava1", "kmet1", "konj1", "tekac1", "kraljica1", "kralj1" };
        public int stevec = 0;

        public void team_selector()
        {
            if (figure == "")
            {
                team = "neutral";
                return;
            }
            foreach (string fig in igralec0_figure)
            {
                if (fig == figure)
                {
                    team = "white0";
                    break;
                }
            }
            foreach (string fig in igralec1_figure)
            {
                if (fig == figure)
                {
                    team = "black1";
                    break;
                }
            }

        }
    }
    public class Pos_check
    {
        public Pos r_pos;

        public List<Pos> poss;

        public List<Pos> possible_poss = new List<Pos> { };

        public bool rosada0 = false;
        public int rosada_assist;
        public bool rosada1 = false;
        

        public bool pos_check(int x_plus, int y_plus)
        {
            foreach (Pos pos in poss)
            {
                if (pos.x_pos == x_plus && pos.y_pos == y_plus)
                {
                    if (r_pos.team == pos.team)
                    {
                        return false;
                    }
                    else if (pos.team == "neutral")
                    {
                        possible_poss.Add(pos);
                        return true;
                    }
                    else if (r_pos.team != pos.team)
                    {
                        possible_poss.Add(pos);
                        return false;
                    }

                }
            }
            return false;
        }
        public List<Pos> check(bool trd, bool tek, int st_ponovitev)
        {
            if (tek == true)//teka�
            {
                for (int j = -1; j <= 1; j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        if (k == 0)
                            continue;
                        if (j == 0)
                            continue;
                        for (int i = 1; i <= st_ponovitev; i++)
                        {
                            //if (r_pos.x_pos >= 0 || r_pos.y_pos >= 0 || r_pos.x_pos <= 7 || r_pos.y_pos <= 7)
                            //    break;
                            int x_plus = i * j;
                            int y_plus = i * k;
                            if (pos_check(x_plus + r_pos.x_pos, y_plus + r_pos.y_pos) == false)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            if (trd == true)//trdnjava
            {
                for (int j = -1; j <= 1; j += 1)
                {
                    if (j == 0)
                        continue;
                    for (int i = 1; i <= st_ponovitev; i++)
                    {
                        int x_plus = i * j;
                        if (pos_check(x_plus + r_pos.x_pos, r_pos.y_pos) == false)
                        {
                            break;
                        }
                    }
                }
                for (int j = -1; j <= 1; j += 1)
                {
                    if (j == 0)
                        continue;
                    for (int i = 1; i <= st_ponovitev; i++)
                    {
                        int y_plus = i * j;
                        if (pos_check(r_pos.x_pos, y_plus + r_pos.y_pos) == false)
                        {
                            break;
                        }
                    }
                }
            }
            if (st_ponovitev == 998)
            {
                for (int j = -1; j <= 1; j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        if (k == 0)
                            continue;
                        if (j == 0)
                            continue;
                        int x_plus = 1 * j;
                        int y_plus = 2 * k;
                        if (pos_check(x_plus + r_pos.x_pos, y_plus + r_pos.y_pos) == false)
                        { }
                        x_plus = 2 * j;
                        y_plus = 1 * k;
                        if (pos_check(x_plus + r_pos.x_pos, y_plus + r_pos.y_pos) == false)
                        { }
                    }
                }
            }
            return possible_poss;

        }

        public bool pos_check_kmet(int x_plus, int y_plus, bool eat)
        {
            foreach (Pos pos in poss)
            {
                if (pos.x_pos == x_plus && pos.y_pos == y_plus)
                {
                    if (r_pos.team == pos.team)
                    {
                        return false;
                    }
                    else if (pos.team == "neutral")
                    {
                        if (eat == true)
                            continue;
                        possible_poss.Add(pos);
                        return true;
                    }
                    else if (r_pos.team != pos.team && eat)
                    {
                        possible_poss.Add(pos);
                        return false;
                    }

                }
            }
            return false;
        }
        
        public List<Pos> kmet0(int pogoj, int plus_minus)
        {
            int st1;
            if (r_pos.x_pos == pogoj)
            {
                st1 = 2 * plus_minus;
                pos_check_kmet(r_pos.x_pos + st1, r_pos.y_pos, false);
            }

            st1 = 1 * plus_minus;
            pos_check_kmet(r_pos.x_pos + st1, r_pos.y_pos, false);

            pos_check_kmet(r_pos.x_pos + st1, r_pos.y_pos + 1, true);
            pos_check_kmet(r_pos.x_pos + st1, r_pos.y_pos - 1, true);
            return possible_poss;
        }
        public List<Pos> rosada(string team, int x)
        {
            Pos ps = null;
            bool can = true;
            
            foreach (Pos pos in poss)
            {
                if (pos.x_pos == x && pos.y_pos == 1) 
                { 
                    if (pos.figure == team && pos.stevec == 0) { }
                    else { can = false; }
                }
                for (int i = 2; i < 5; i++)
                {
                    if (pos.x_pos == x && pos.y_pos == i)
                    {
                        if (pos.figure == "") { }
                        else { can = false; }
                    }
                }
                if (pos.x_pos == x && pos.y_pos == 3)
                {
                    ps = pos;
                }
            }
            if (can == true) 
            { 
                possible_poss.Add(ps); 
                if (ps.x_pos == 8)
                {
                    rosada0 = true;
                }
                else if (ps.x_pos == 1)
                {
                    rosada1 = true;
                }
            }
            can = true;
            foreach (Pos pos in poss)
            {
                if (pos.x_pos == x && pos.y_pos == 8)
                {
                    if (pos.figure == team && pos.stevec == 0) { }
                    else { can = false; }
                }
                for (int i = 6; i < 8; i++)
                {
                    if (pos.x_pos == x && pos.y_pos == i)
                    {
                        if (pos.figure == "") { }
                        else { can = false; }
                    }
                }
                if (pos.x_pos == x && pos.y_pos == 7)
                { 
                    ps = pos;
                }
            }
            if (can == true) 
            { 
                possible_poss.Add(ps);
                if (ps.x_pos == 1)
                {
                    rosada1 = true;
                }
                else if (ps.x_pos == 8)
                {
                    rosada0 = true;
                }
            }
            return possible_poss;
        }
        public List<Pos> figure_check()
        {

            if (r_pos.figure == "kraljica" || r_pos.figure == "kraljica1")
                check(true, true, 8);
            else if (r_pos.figure == "trdnjava" || r_pos.figure == "trdnjava1")
                check(true, false, 8);
            else if (r_pos.figure == "tekac" || r_pos.figure == "tekac1")
                check(false, true, 8);
            else if (r_pos.figure == "kralj" || r_pos.figure == "kralj1")
                check(true, true, 1);
            else if (r_pos.figure == "konj" || r_pos.figure == "konj1")
                check(false, false, 998);
            else if (r_pos.figure == "kmet")
                kmet0(7, -1);
            else if (r_pos.figure == "kmet1")
                kmet0(2, 1);
            if (r_pos.figure == "kralj" && r_pos.stevec == 0)
                rosada("trdnjava", 8);
            else if (r_pos.figure == "kralj1" && r_pos.stevec == 0)
                rosada("trdnjava1", 1);
            return possible_poss;
        }
    }
}
