using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace notepad_ödev
{
    public partial class Form1 : Form
    {
        public string dosyayolu = null;
       

        public Form1()
        {
            InitializeComponent();
        }
       
        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaAc();
            dosyayolu = ofd.FileName;
        }
        public void DosyaAc()
        {
            ofd.ShowDialog(); // dosya açma nesnesine göstermek için
            if (File.Exists(ofd.FileName))
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                yaziAlani.Text = sr.ReadToEnd();
                this.Text = "Not Defteri - " + Path.GetFileName(ofd.FileName);
                // openedFile = ofd.FileName;
                sr.Close();
                
            }
        }
        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            farklikaydet();
        }
        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dosyayolu != null) //Bir dosya açılmışsa
            {
                StreamWriter strWrt = new StreamWriter(dosyayolu);

                strWrt.WriteLine(yaziAlani.Text);
                strWrt.Close();
                

            }
            else //dosya açılmamışsa 
                farklıKaydetToolStripMenuItem_Click(sender,e);
                 //SaveDialog penceresi ile dosya adı sor
              /*  if   (sfd.ShowDialog() == DialogResult.OK){
                //O adla kaydet
                yaziAlani.SaveFile(sfd.FileName,
                 RichTextBoxStreamType.RichText);*/
            

        }
        public void farklikaydet()
        {
            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    
                   // dosyayolu = null;
                    dosyayolu =sfd.FileName ;
                  
                    StreamWriter strWrt = new StreamWriter(dosyayolu, false, Encoding.GetEncoding("ISO-8859-9"));
                    strWrt.WriteLine(yaziAlani.Text);
                    strWrt.Close();
                    this.Text = "Not Defteri - " + Path.GetFileName(sfd.FileName);
                    //  ofd.FileName = sfd.FileName;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya kaydedilemedi.Oluşan hata:" + ex.Message, "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Not defteri -adsız";
            yaziAlani.Text = "";
        }
        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yaziAlani.Copy();
            // Clipboard.SetDataObject(yaziAlani.SelectedText, true);
        }
        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yaziAlani.Cut();
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yaziAlani.Clear();
        }
        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yaziAlani.Undo();
            //tamamı silinmişse nasıl geri alıcak? siz bulun
        }
        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //kopyalanını yapıştır- siz bulun anahtar kelime "Clipboard"
            yaziAlani.Paste();
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void özelleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fd.Font = yaziAlani.Font;

            if (fd.ShowDialog() == DialogResult.OK)
                yaziAlani.Font = fd.Font;
        }

        private void yazıRengiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            yaziAlani.ForeColor = colorDialog1.Color; // yazı rengi
        }

        private void kopyalaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            yaziAlani.Copy();
        }

        private void yapıştırToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            yaziAlani.Paste();
        }

        private void kesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            yaziAlani.Cut();
       
        }

        private void temizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yaziAlani.Undo();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yaziAlani.SelectAll();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



