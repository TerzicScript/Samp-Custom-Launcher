using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace KuracPalac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Ovde ce da uzme folder gde se gta_sa.exe nalazi. Zatim ce da proverava da li unutar tog foldera postoji folder cleo, fajl d3d9.dll itd.. Sto su citevi naravno
        {
            string ServerIP = "samp.zara-rpg.com"; //IP servera
            string SPHash = ""; //Sifra servera ukoliko je potrebna
            string GTAPath = Registry.CurrentUser.OpenSubKey(@"Software\\SAMP").GetValue("gta_sa_exe").ToString(); 
            GTAPath = GTAPath.Substring(0, GTAPath.LastIndexOf(@"\") + 1);
            string[] ImaCheat1 = Directory.GetDirectories(GTAPath, "cleo");
            string[] ImaCheat2 = Directory.GetFiles(GTAPath, "CLEO.asi");
            string[] ImaCheat3 = Directory.GetFiles(GTAPath, "d3d9.dll");
            string[] ImaCheat4 = Directory.GetFiles(GTAPath, "SAMPFUNCS.asi");
            string[] ImaCheat5 = Directory.GetDirectories(GTAPath, "mod_sa");
            string[] ImaCheat6 = Directory.GetDirectories(GTAPath, "OverLight_Mod");
            string[] ImaCheat7 = Directory.GetFiles(GTAPath, "vorbishooked.dll");
            if (((ImaCheat1.Length > 0) || (ImaCheat2.Length > 0)) || ((ImaCheat3.Length > 0) || (ImaCheat4.Length > 0)))
            {
                MessageBox.Show("Imate Cheat! Izbrisite ga!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if ((ImaCheat5.Length > 0) || (ImaCheat6.Length > 0))
            {
                MessageBox.Show("Imate Cheat! Izbrisite ga!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (ImaCheat7.Length > 0)
            {
                MessageBox.Show("Imate Cheat! Izbrisite ga!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true).SetValue("PlayerName", textBox1.Text);
                Process.Start(GTAPath + "samp.exe", ServerIP + SPHash);
            }
        }

        private void Form1_Load(object sender, EventArgs e) //Gleda registry i proverava da li korisnik ima samp i gta sa. Takodje odatle uzima nick igraca koji se cuva tamo. Kao kada otvorite samp i stoji vam odredjeni nick
        {
            string myRegistryKey = Registry.CurrentUser.OpenSubKey(@"Software\\SAMP").GetValue("gta_sa_exe").ToString();
            myRegistryKey = myRegistryKey.Substring(0, myRegistryKey.LastIndexOf(@"\") + 1);
            label1.Text = myRegistryKey + "samp.exe";
            textBox1.Text = Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true).GetValue("PlayerName").ToString();
            if (!File.Exists(myRegistryKey + "gta_sa.exe"))
            {
                MessageBox.Show("Nemate gta_sa.exe! Instalirajte igricu ili ukoliko je vec imate reinstalirajte je!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.Close();
                Application.Exit();
            }
            else if (!File.Exists(myRegistryKey + "samp.exe"))
            {
                MessageBox.Show("Unutar Gta Sa foldera nemate samp.exe! Reinstalirajte SAMP!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.Close();
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e) //Dugme X za izlazak iz aplikacije
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e) //Ovo je moje nesto, Creator Info, da se zna samo :/
        {
            this.Hide();
            Form2 showForm = new Form2();
            showForm.ShowDialog();
        }
    }
}
