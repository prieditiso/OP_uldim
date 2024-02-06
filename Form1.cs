﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;


namespace ulda_atrisinajums
{ 
    public partial class BUT_rekins : Form
    {
        public BUT_rekins()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int darba_samaksa = 15;
        int PVN = 21;

        private void but_izveidot_Click(object sender, EventArgs e)
        {
            string varda_ga = TB_velejums.Text;
            int gar = varda_ga.Length;

            if (
                int.TryParse(TB_platums.Text, out int platums) &&
                int.TryParse(TB_augstums.Text, out int augstums) &&
                int.TryParse(TB_garums.Text, out int garums) &&
                int.TryParse(TB_kokmateriala.Text, out int materiala_cena))
            {
                int charCount = gar;
                int multipliedCount = (int)(charCount * 1.2);

                double produkta_cena = (gar * 1.2) + ((platums / 100.0) * (augstums / 100.0) * (garums / 100.0)) / 3.0 * materiala_cena;
                int PVN_summa = (int)((produkta_cena + darba_samaksa) * PVN / 100);

                int rekina_summa = (int)(produkta_cena + darba_samaksa + PVN_summa);

                RB_rekins.Text = $"Produkta cena: {produkta_cena:C}\n" +
                                 $"PVN summa: {PVN_summa:C}\n" +
                                 $"Rekina summa: {rekina_summa:C}\n";
            }
            else
            {
                RB_rekins.Text = "Kaut kas nav pareizi";
            }

            if (TB_vards.Text != "")
            {
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConeection();

                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO ULDA_darbam(Klienta_vards, Velejums, Platums, Garums, Augstums,Komateriala_cena) VALUES('" + TB_vards.Text + "','" + TB_velejums.Text + "','" + TB_platums.Text + "','" + TB_garums.Text + "', '" + TB_augstums.Text + ""+ TB_kokmateriala.Text + "');";
                sqlite_cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Lūdzu ievadiet nosaukumu");
            }



        }
        static SQLiteConnection CreateConeection()
        {
            SQLiteConnection ulda_datubaze;
            ulda_datubaze = new SQLiteConnection("Data Source=ulda_datubaze.db; Version = 3; New = true; Compress = True;");
            try
            {
                ulda_datubaze.Open();

            }
            catch
            {

            }
            return ulda_datubaze;
        }

        private void TB_vards_TextChanged(object sender, EventArgs e)
        {

        }

        private void BUT_fails_Click(object sender, EventArgs e)
        {

            {
                StreamWriter a = new StreamWriter("rekins.txt");

                

                a.WriteLine(label1.Text + " " + TB_vards.Text);
                a.WriteLine(label2.Text + " " + TB_velejums.Text);
                a.WriteLine(label3.Text + " " + TB_platums.Text);
                a.WriteLine(label4.Text + " " + TB_garums.Text);
                a.WriteLine(label5.Text + " " + TB_augstums.Text);
                a.WriteLine(label6.Text + " " + TB_kokmateriala.Text);

                


                a.Close();





            }
        }   



        

    }


}


    
