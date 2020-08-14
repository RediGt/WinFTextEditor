using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFTextEditor
{
    public partial class Form1 : Form
    {
        string saveFilePath;
        string lastSaved;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tBoxMain.Text = "";
            tBoxAddString.Text = "";
            saveFilePath = null;
            lastSaved = "";
        }

        private void btnAddString_Click(object sender, EventArgs e)
        {
            if (tBoxMain.Text != "")
                tBoxMain.Text += "\n";
            tBoxMain.Text += tBoxAddString.Text;
            tBoxAddString.Text = "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Filter = "Text Files|*.txt|All Files|*.*";
            if (openFD.ShowDialog() != DialogResult.OK)
                return;
           
            sb = FileIO.Read(openFD.FileName);
            tBoxMain.Text = sb.ToString();
            saveFilePath = openFD.FileName;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFilePath != null)
                FileIO.Write(tBoxMain, saveFilePath);
            else
                SaveFile();
        }

        private void SaveFile()
        {
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFD.RestoreDirectory = true;

            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                FileIO.Write(tBoxMain, saveFD.FileName);
                lastSaved = tBoxMain.Text;
                saveFilePath = saveFD.FileName;
            }          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
