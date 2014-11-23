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
            textBoxPathA.Tag = FolderRepresentPosition.Left;
            textBoxPathB.Tag = FolderRepresentPosition.Right;

            UpdateFileList(FolderRepresentPosition.Left,
                FileEditor.GetFiles(textBoxPathA.Text));
            UpdateFileList(FolderRepresentPosition.Right,
                 FileEditor.GetFiles(textBoxPathB.Text));
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
        public event EventHandler<FileListUpdateRequstedEventArgs> FileListUpdateRequsted;
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

        public void UpdateFileList(FolderRepresentPosition position,
            IEnumerable<FileInfo> fileList)
        {
            ListBox listBox;

            switch (position)
            {
                case FolderRepresentPosition.Left:
                    listBox = listBoxFilesA;
                    break;

                case FolderRepresentPosition.Right:
                    listBox = listBoxFilesB;
                    break;

                default:
                    return;
            }

            listBox.DataSource = fileList == null ? null : fileList
                .Select(x => x.FullName).ToList();
        }
        
        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
            {
                return;
            }

            OnFileListUpdateRequest(textBox.Text, (FolderRepresentPosition)textBox.Tag);
        }

        private void OnFileListUpdateRequest(string path, 
            FolderRepresentPosition position)
        {
            var args = new FileListUpdateRequstedEventArgs(path, position);

            var handler = FileListUpdateRequsted;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void buttonOpenA_Click(object sender, EventArgs e)
        {
            FileEditor.EditFile((string)listBoxFilesA.SelectedItem);
        }

        private void buttonOpenB_Click(object sender, EventArgs e)
        {
            FileEditor.EditFile((string)listBoxFilesB.SelectedItem);
        }

        private void buttonDeleteA_Click(object sender, EventArgs e)
        {
            FileEditor.RemoveFile((string)listBoxFilesA.SelectedItem);
            if (Directory.Exists(textBoxPathA.Text))
            {
                listBoxFilesA.DataSource = FileEditor.GetFiles(textBoxPathA.Text).ToList();
            }
        }
        private void buttonDeleteB_Click(object sender, EventArgs e)
        {
            FileEditor.RemoveFile((string)listBoxFilesB.SelectedItem);
            if (Directory.Exists(textBoxPathB.Text))
            {
                listBoxFilesB.DataSource = FileEditor.GetFiles(textBoxPathB.Text).ToList();
            }
        }
    }
}
