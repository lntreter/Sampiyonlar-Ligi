using Kura.Properties;
using System;
using System.Media;
using System.Numerics;
using System.Windows.Forms;

namespace Kura
{
    public partial class Form1 : Form
    {

        List<takim> takimlar;

        List<ListBox> torbalar = new List<ListBox>();
        List<ListBox> gruplar = new List<ListBox>();


        public Form1()
        {
            InitializeComponent();
        }
        
        public int control = 0;
        public int control2 = 0;

        private bool sesCaliyormu = true;

        SoundPlayer ses = new SoundPlayer(Resourcess.ses1);
        SoundPlayer ses2 = new SoundPlayer(Resourcess.x2mate_com___REFEREE_WHISTLE_SOUND_EFFECT__128_kbps_);

        private void TakimlariEkle(string yol, List<takim> t)
        {
            if (File.Exists(yol))
            {
                string[] satir = File.ReadAllLines(yol);

                for (int i = 0; i < satir.Length; i += 2)
                {
                    string teamName = satir[i];
                    string country = satir[i + 1];

                    takim yeniTakim = new takim(teamName, country);
                    t.Add(yeniTakim);
                }
            }
            else
            {
                MessageBox.Show("Dosya bulunamadı: " + yol);
            }
        }

        public string[] stringArray = new string[4];
            
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

            if (label6.Text == "label6")
            {
                label6.Text = macSonucu;
            }
            else if (label7.Text == "label7")
            {
                label7.Text = macSonucu;
            }
            else if (label8.Text == "label8")
            {
                label8.Text = macSonucu;
            }
            else if (label9.Text == "label9")
            {
                label9.Text = macSonucu;
            }

            if (label6.Text != "label6" && label7.Text != "label7" && label8.Text != "label8" && label9.Text != "label9")
            {
                stringArray[0] = label6.Text;
                stringArray[1] = label7.Text;
                stringArray[2] = label8.Text;
                stringArray[3] = label9.Text;
            }

            if (label6.Text != "label6" && label7.Text != "label7" && label8.Text != "label8" && label9.Text != "label9")
            {
                label6.Text = "label6";
                label7.Text = "label7";
                label8.Text = "label8";
                label9.Text = "label9";
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

        private void Form1_Load(object sender, EventArgs e)
        {

            ses.Play();

            panel2.Visible = false;
            

            //Takım sınıfından bir obje oluşturuldu ve takimlar listesine eklendi.

            takim yeniTakim = null;

            takimlar = new List<takim>();
            
            TakimlariEkle("C:\\Users\\bsahi\\source\\repos\\Kura\\Kura\\takkimlar.txt", takimlar);




            /*yeniTakim = new takim("TrabzonSpor", "Türkiye");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Galatasaray", "Türkiye");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Fenerbahçe", "Türkiye");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Beşiktaş", "Türkiye");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Chelsea", "İngiltere");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Manchester United", "İngiltere");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Manchester City", "İngiltere");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Arsenal", "İngiltere");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Real Madrid", "İspanya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Barcelona", "İspanya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Atletico Madrid", "İspanya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Valencia", "İspanya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Juventus", "İtalya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Milan", "İtalya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Inter", "İtalya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Roma", "İtalya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Bayern Münih", "Almanya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Borussia Dortmund", "Almanya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Schalke 04", "Almanya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Bayer Leverkusen", "Almanya");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Paris Saint-Germain", "Fransa");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Lyon", "Fransa");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Marseille", "Fransa");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Lille", "Fransa");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Ajax", "Hollanda");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("PSV", "Hollanda");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Feyenoord", "Hollanda");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("AZ Alkmaar", "Hollanda");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Porto", "Portekiz");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Benfica", "Portekiz");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Sporting Lizbon", "Portekiz");
            takimlar.Add(yeniTakim);
            yeniTakim = new takim("Braga", "Portekiz");
            takimlar.Add(yeniTakim);*/

            //if (control == 0 && control2 == 0)
            //{
            //    button3.Enabled = false;
            //}
            //else
            //{
            //    button3.Enabled = true;
            //}

            button3.Enabled = false;


            

        }

        private void button2_Click_1(object sender, EventArgs e) 
        {
            Random rastgele = new Random(); //Random sınıfından bir obje oluşturuldu.

            List<int> secilenTakimlar = new List<int>(); //Seçilen takımların indexlerini tutan liste oluşturuldu.

            if (!(control == 1 && control2 == 0 )/*(gruplar[0].Items.Count == 0 && torbalar.Count == 0) || (gruplar[0].Items.Count != 0 && gruplar[0].Items[0] != null)*/) { // Bir mesaj kutusu oluştur.

                MessageBox.Show("Torbalar oluşturulmamaış veya gruplar zaten seçilmiş!");

            }
            else
            {
                for (int j = 0; j < 4; j++)  //For döngüsü ile torbalar için işlem yapıldı.
                {
                    secilenTakimlar.Clear();
                    for (int i = 0; i < 8; i++)
                    {
                        int secilenTakim = rastgele.Next(0, takimlar.Count / 4); //Random sınıfı ile 0 ile takimlar listesinin 1/4'ü arasında bir sayı seçildi.

                        if (secilenTakimlar.Contains(secilenTakim)) //Eğer seçilen takım daha önce seçilmişse seçilmesi engellendi.
                        {
                            i--;
                        }
                        else
                        {
                            secilenTakimlar.Add(secilenTakim);
                        }
                    }
                    bool ayniUlkedenTakimVar = false; //Aynı ülkeden takım var mı diye kontrol eden değişken oluşturuldu.
                    for (int k = 0; k < 8; k++)
                    {
                        ayniUlkedenTakimVar = ayniUlkedenTakimVarmi(gruplar[k], torbalar[j].Items[secilenTakimlar[k]] as takim); //Aynı ülkeden takım var mı diye kontrol edildi.
                        if (ayniUlkedenTakimVar) { break; }
                    }
                    if (!ayniUlkedenTakimVar) //Aynı ülkeden takım var ise tekrar seçim yapılması için döngüden çıkıldı.
                    {
                        listBox1.Items.Add(torbalar[j].Items[secilenTakimlar[0]] as takim);
                        listBox2.Items.Add(torbalar[j].Items[secilenTakimlar[1]] as takim);
                        listBox3.Items.Add(torbalar[j].Items[secilenTakimlar[2]] as takim);
                        listBox4.Items.Add(torbalar[j].Items[secilenTakimlar[3]] as takim);
                        listBox5.Items.Add(torbalar[j].Items[secilenTakimlar[4]] as takim);
                        listBox6.Items.Add(torbalar[j].Items[secilenTakimlar[5]] as takim);
                        listBox7.Items.Add(torbalar[j].Items[secilenTakimlar[6]] as takim);
                        listBox8.Items.Add(torbalar[j].Items[secilenTakimlar[7]] as takim);
                    }
                    else
                    {
                        j--;
                    }


                }

                control2 = 1;

                button3.Enabled = true;

                button7.Enabled = true;
            }

        }

        private bool ayniUlkedenTakimVarmi(ListBox grup, takim takim) 
        {
            bool durum = false;
            for (int i = 0; i < grup.Items.Count; i++)
            {
                takim gruptakim = grup.Items[i] as takim;  //Listbox içindeki takımların ülkeleri kontrol edildi.
                if (gruptakim.TeamCountry == takim.TeamCountry)
                {
                    durum = true;
                    break;
                }
            }
            return durum;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (control == 1)
            {
                MessageBox.Show("Torbalar zaten oluşturulmuş!");
            }
            else
            {
                Random rastgele = new Random();
                List<int> secilenTakimlar = new List<int>();
                for (int i = 0; i < takimlar.Count; i++)
                {
                    int secilenTakim = rastgele.Next(0, takimlar.Count);
                    if (secilenTakimlar.Contains(secilenTakim)) //Seçilen takımlarda zaten seçilen takımı barındırıyor mu diye kontrol edildi.
                    {
                        i--;
                    }
                    else
                    {
                        secilenTakimlar.Add(secilenTakim);
                    }
                }
                for (int i = 0; i < secilenTakimlar.Count; i++)  //Bu for döngüsü ile takımlar listesindeki takımlar gruplara dağıtıldı.
                {
                    if (i < 8)
                    {
                        LstTorba1.Items.Add(takimlar[secilenTakimlar[i]]);
                    }
                    else if (i < 16)
                    {
                        LstTorba2.Items.Add(takimlar[secilenTakimlar[i]]);
                    }
                    else if (i < 24)
                    {
                        LstTorba3.Items.Add(takimlar[secilenTakimlar[i]]);
                    }
                    else
                    {
                        LstTorba4.Items.Add(takimlar[secilenTakimlar[i]]);
                    }
                }

                //Torbalara ve gruplara takımların dağıtılması işlemi yapıldı.


                torbalar.Add(LstTorba1);
                torbalar.Add(LstTorba2);
                torbalar.Add(LstTorba3);
                torbalar.Add(LstTorba4);


                gruplar.Add(listBox1);
                gruplar.Add(listBox2);
                gruplar.Add(listBox3);
                gruplar.Add(listBox4);
                gruplar.Add(listBox5);
                gruplar.Add(listBox6);
                gruplar.Add(listBox7);
                gruplar.Add(listBox8);

                control = 1;

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //İşlemlerin yeniden yapılabilmesi için reset butonu eklendi.
            
            foreach (ListBox torba in torbalar) 
            {
                torba.Items.Clear();
            }

            
            foreach (ListBox grup in gruplar)
            {
                grup.Items.Clear();
            }

          
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();

            control = 0;
            control2 = 0;

            listBox9.Items.Clear();
            listBox10.Items.Clear();
            listBox11.Items.Clear();
            listBox12.Items.Clear();
            listBox13.Items.Clear();
            listBox14.Items.Clear();
            listBox15.Items.Clear();
            listBox16.Items.Clear();
            

            button3.Enabled = false;

            foreach (takim takim in takimlar)
            {
                takim.puan = 0;
                takim.oynananMac = 0;
            }

            listBox17.Items.Clear();
            
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

        private void button5_Click(object sender, EventArgs e)
        {
            //Uygulamadan cıkmak için exit tuşu
            Application.Exit();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this, takimlar, sesCaliyormu, ses, listBox1, listBox2, listBox3, listBox4, listBox5, listBox6, listBox7, listBox8);
            form2.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            ses2.Play();

            System.Threading.Thread.Sleep(3000);

            ses.Play();

            GrupMac(listBox1);
            foreach (string item in stringArray)
            {
                listBox16.Items.Add(item);
            }
            listBox16.Items.Add("-------------------");
            List<takim> takimList = listBox1.Items.Cast<takim>().ToList();

            takimList.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList)
            {
                listBox16.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList[0].ToString() + " - " + takimList[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList[1].ToString() + " - " + takimList[1].puan.ToString() + " Puan");


            GrupMac(listBox2);
            foreach (string item in stringArray)
            {
                listBox15.Items.Add(item);
            }
            listBox15.Items.Add("-------------------");

            List<takim> takimList2 = listBox2.Items.Cast<takim>().ToList();

            takimList2.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList2)
            {
                listBox15.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList2[0].ToString() + " - " + takimList2[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList2[1].ToString() + " - " + takimList2[1].puan.ToString() + " Puan");

            GrupMac(listBox3);
            foreach (string item in stringArray)
            {
                listBox14.Items.Add(item);
            }
            listBox14.Items.Add("-------------------");

            List<takim> takimList3 = listBox3.Items.Cast<takim>().ToList();

            takimList3.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList3)
            {
                listBox14.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList3[0].ToString() + " - " + takimList3[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList3[1].ToString() + " - " + takimList3[1].puan.ToString() + " Puan");

            GrupMac(listBox4);
            foreach (string item in stringArray)
            {
                listBox13.Items.Add(item);
            }
            listBox13.Items.Add("-------------------");

            List<takim> takimList4 = listBox4.Items.Cast<takim>().ToList();

            takimList4.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList4)
            {
                listBox13.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList4[0].ToString() + " - " + takimList4[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList4[1].ToString() + " - " + takimList4[1].puan.ToString() + " Puan");


            GrupMac(listBox5);
            foreach (string item in stringArray)
            {
                listBox9.Items.Add(item);
            }
            listBox9.Items.Add("-------------------");

            List<takim> takimList5 = listBox5.Items.Cast<takim>().ToList();

            takimList5.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList5)
            {
                listBox9.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList5[0].ToString() + " - " + takimList5[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList5[1].ToString() + " - " + takimList5[1].puan.ToString() + " Puan");

            GrupMac(listBox6);
            foreach (string item in stringArray)
            {
                listBox10.Items.Add(item);
            }
            listBox10.Items.Add("-------------------");

            List<takim> takimList6 = listBox6.Items.Cast<takim>().ToList();

            takimList6.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList6)
            {
                listBox10.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList6[0].ToString() + " - " + takimList6[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList6[1].ToString() + " - " + takimList6[1].puan.ToString() + " Puan");

            GrupMac(listBox7);
            foreach (string item in stringArray)
            {
                listBox11.Items.Add(item);
            }
            listBox11.Items.Add("-------------------");

            List<takim> takimList7 = listBox7.Items.Cast<takim>().ToList();

            takimList7.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList7)
            {
                listBox11.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList7[0].ToString() + " - " + takimList7[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList7[1].ToString() + " - " + takimList7[1].puan.ToString() + " Puan");

            GrupMac(listBox8);
            foreach (string item in stringArray)
            {
                listBox12.Items.Add(item);
            }
            listBox12.Items.Add("-------------------");

            List<takim> takimList8 = listBox8.Items.Cast<takim>().ToList();

            takimList8.Sort((team1, team2) => team2.TeamPoint.CompareTo(team1.TeamPoint));

            foreach (takim t in takimList8)
            {
                listBox12.Items.Add(t.ToString() + " Puan: " + t.TeamPoint);
            }

            listBox17.Items.Add(takimList8[0].ToString() + " - " + takimList8[0].puan.ToString() + " Puan");
            listBox17.Items.Add(takimList8[1].ToString() + " - " + takimList8[1].puan.ToString() + " Puan");

            button7.Enabled = false;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}