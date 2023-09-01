using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Intrinsics.X86;
using System.Reflection.Emit;

namespace Kura
{
    public partial class Form2 : Form
    {

        ListBox list1, list2, list3, list4, list5, list6, list7, list8;

        bool sesCaliyormu;

        SoundPlayer ses;

        SoundPlayer ses2 = new SoundPlayer(Resourcess.x2mate_com___REFEREE_WHISTLE_SOUND_EFFECT__128_kbps_);
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!sesCaliyormu)
            {
                ses.Play(); // Ses çal
                sesCaliyormu = true;
                button4.Text = "🔇";
            }
            else
            {
                ses.Stop(); // Ses durdur
                sesCaliyormu = false;
                button4.Text = "🔉";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            listBox17.Items.Clear();

            foreach (takim takim in takimlarr)
            {
                takim.puan = 0;
                takim.oynananMac = 0;
            }
            label1.Visible = true;
            pictureBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            listBox17.Items.Clear();

            foreach (takim takim in takimlarr)
            {
                takim.puan = 0;
                takim.oynananMac = 0;
            }
            label1.Visible = true;
            pictureBox2.Enabled = true;

            this.Hide();
            form.Show();
        }

        public string[] stringArray = new string[4];

        string a = "a", b = "b", c = "c", d = "d";

        private void macOynat(takim t1, takim t2)
        {

            Random random = new Random();

            int t1gol = random.Next(0, 6);
            int t2gol = random.Next(0, 6);


            if (t1gol > t2gol)
            {
                t1.TeamPoint += 3;
            }
            else if (t2gol > t1gol)
            {
                t2.TeamPoint += 3;
            }
            else
            {
                t1.TeamPoint += 1;
                t2.TeamPoint += 1;
            }

            t1.oynananMac++;
            t2.oynananMac++;

            string macSonucu = t1.TeamName + " " + t1gol + " - " + t2gol + " " + t2.TeamName;

            
            
            if (a == "a")
            {
                a = macSonucu;
            }
            else if (b == "b")
            {
                b = macSonucu;
            }
            else if (c == "c")
            {
                c = macSonucu;
            }
            else if (d == "d")
            {
                d = macSonucu;
            }
            if (a != "a" && b != "b" && c != "c" && d != "d")
            {
                stringArray[0] = a;
                stringArray[1] = b;
                stringArray[2] = c;
                stringArray[3] = d;

                a = "a";
                b = "b";
                c = "c";
                d = "d";
            }
        }

        public void GrupMac(ListBox grup)
        {
            for (int i = 0; i < grup.Items.Count; i++)
            {
                for (int j = i + 1; j < grup.Items.Count; j++)
                {
                    if ((grup.Items[i] as takim).oynananMac < 2 && (grup.Items[i] as takim).oynananMac < 2)
                    {
                        macOynat((takim)grup.Items[i], (takim)grup.Items[j]);
                        macOynat((takim)grup.Items[3], (takim)grup.Items[j]);
                    }
                }
            }
        }

        List<takim> takimlarr;

        Form1 form;
        
        public Form2(Form1 form1,List<takim> takimlar,bool b, SoundPlayer s, ListBox l1, ListBox l2, ListBox l3, ListBox l4, ListBox l5, ListBox l6, ListBox l7, ListBox l8)
        {
            form = form1;
            
            takimlarr = takimlar;
            InitializeComponent();
            ses = s;
            sesCaliyormu = b;
            list1 = l1;
            list2 = l2;
            list3 = l3;
            list4 = l4;
            list5 = l5;
            list6 = l6;
            list7 = l7;
            list8 = l8;
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            //pictureBox2.Enabled = false;
            

            GrupMac(list1);
            List<takim> takimList = list1.Items.Cast<takim>().ToList();
            foreach (string item in stringArray)
            {
                listBox1.Items.Add(item);
            }
            listBox1.Items.Add("-------------------");
            

            takimList.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList)
            {
                listBox1.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList[0].ToString() + " - " + takimList[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList[1].ToString() + " - " + takimList[1].puan.ToString() + " Puan");


            GrupMac(list2);
            List<takim> takimList2 = list2.Items.Cast<takim>().ToList();
            
            foreach (string item in stringArray)
            {
                listBox2.Items.Add(item);
            }
            listBox2.Items.Add("-------------------");


            takimList2.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList2)
            {
                listBox2.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList2[0].ToString() + " - " + takimList2[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList2[1].ToString() + " - " + takimList2[1].puan.ToString() + " Puan");

            GrupMac(list3);
            List<takim> takimList3 = list3.Items.Cast<takim>().ToList();
         
            foreach (string item in stringArray)
            {
                listBox3.Items.Add(item);
            }
            listBox3.Items.Add("-------------------");

            

            takimList3.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList3)
            {
                listBox3.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList3[0].ToString() + " - " + takimList3[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList3[1].ToString() + " - " + takimList3[1].puan.ToString() + " Puan");

            GrupMac(list4);
            List<takim> takimList4 = list4.Items.Cast<takim>().ToList();
 
            foreach (string item in stringArray)
            {
                listBox4.Items.Add(item);
            }
            listBox4.Items.Add("-------------------");

            

            takimList4.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList4)
            {
                listBox4.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList4[0].ToString() + " - " + takimList4[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList4[1].ToString() + " - " + takimList4[1].puan.ToString() + " Puan");


            GrupMac(list5);
            List<takim> takimList5 = list5.Items.Cast<takim>().ToList();
            
            foreach (string item in stringArray)
            {
                listBox5.Items.Add(item);
            }
            listBox5.Items.Add("-------------------");

            

            takimList5.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList5)
            {
                listBox5.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList5[0].ToString() + " - " + takimList5[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList5[1].ToString() + " - " + takimList5[1].puan.ToString() + " Puan");

            GrupMac(list6);
            List<takim> takimList6 = list6.Items.Cast<takim>().ToList();
            
            foreach (string item in stringArray)
            {
                listBox6.Items.Add(item);
            }
            listBox6.Items.Add("-------------------");

            

            takimList6.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList6)
            {
                listBox6.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList6[0].ToString() + " - " + takimList6[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList6[1].ToString() + " - " + takimList6[1].puan.ToString() + " Puan");

            GrupMac(list7);
            List<takim> takimList7 = list7.Items.Cast<takim>().ToList();
            
            foreach (string item in stringArray)
            {
                listBox7.Items.Add(item);
            }
            listBox7.Items.Add("-------------------");

            

            takimList7.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList7)
            {
                listBox7.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList7[0].ToString() + " - " + takimList7[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList7[1].ToString() + " - " + takimList7[1].puan.ToString() + " Puan");

            GrupMac(list8);
            List<takim> takimList8 = list8.Items.Cast<takim>().ToList();
            
            foreach (string item in stringArray)
            {
                listBox8.Items.Add(item);
            }
            listBox8.Items.Add("-------------------");

            

            takimList8.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList8)
            {
                listBox8.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList8[0].ToString() + " - " + takimList8[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList8[1].ToString() + " - " + takimList8[1].puan.ToString() + " Puan");

        }
    }
}
