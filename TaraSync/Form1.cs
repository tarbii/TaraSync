using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaraSync.Model;
using TaraSync.Presenter;

namespace TaraSync
{
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
            listBoxFilesA.DataSource = EditingFiles.GetFiles(textBoxPathA.Text).ToList();
            listBoxFilesB.DataSource = EditingFiles.GetFiles(textBoxPathB.Text).ToList();
        }

        void IView.ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void UpdateProgress(string stage, int progress, int count)
        {
            if (count == 0)
            {
                toolStripStatusLabel1.Text = stage;
            }
            else
            {
                toolStripStatusLabel1.Text =
                    string.Format("{0}: {1}/{2}", stage, progress, count);
            }
        }

        public event EventHandler<SyncRequestEventArgs> SyncRequested;

        private void buttonSync_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPathA.Text))
            {
                MessageBox.Show("Enter first folder to synchronize.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxPathB.Text))
            {
                MessageBox.Show("Enter second folder to synchronize.");
                return;
            }

            var args = new SyncRequestEventArgs(textBoxPathA.Text, textBoxPathB.Text);

            var handler = SyncRequested;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public void RepresentFiles(IEnumerable<FileInfo> filesList)
        {
            
        }

        private void textBoxPathA_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxPathA.Text))
            {
                listBoxFilesA.DataSource = EditingFiles.GetFiles(textBoxPathA.Text).ToList(); 
            }
        }

        private void textBoxPathB_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxPathB.Text))
            {
                listBoxFilesB.DataSource = EditingFiles.GetFiles(textBoxPathB.Text).ToList();
            }
        }

        private void buttonOpenA_Click(object sender, EventArgs e)
        {
            EditingFiles.EditFile(((FileInfo)listBoxFilesA.SelectedItem).FullName);
        }

        private void buttonOpenB_Click(object sender, EventArgs e)
        {
            EditingFiles.EditFile(((FileInfo)listBoxFilesB.SelectedItem).FullName);
        }

        private void buttonDeleteA_Click(object sender, EventArgs e)
        {
            EditingFiles.RemoveFile(((FileInfo)listBoxFilesA.SelectedItem).FullName);
        }
        private void buttonDeleteB_Click(object sender, EventArgs e)
        {
            EditingFiles.RemoveFile(((FileInfo)listBoxFilesB.SelectedItem).FullName);
        }
    }
}
