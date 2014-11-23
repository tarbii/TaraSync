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
        }

        void IView.ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void UpdateProgress(string stage, int progress, int count)
        {
            var text = count == 0 ? stage : string.Format("{0}: {1}/{2}", stage, progress, count);

            if (InvokeRequired)
            {
                Invoke((Action)(() => toolStripStatusLabel1.Text = text));
            }
            else
            {
                toolStripStatusLabel1.Text = text;
            }
        }

        public event EventHandler<SyncRequestEventArgs> SyncRequested;
        public event EventHandler<FileListUpdateRequstedEventArgs> FileListUpdateRequsted;
        public event EventHandler<FileOpenEventArgs> FileOpen;
        public event EventHandler<FileDeleteEventArgs> FileDelete;
        public event EventHandler<FileCreateEventArgs> FileCreate;

        private void OnFileCreate(string path)
        {
            var args = new FileCreateEventArgs(path);

            var handler = FileCreate;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        private void OnFileDelete(string path)
        {
            var args = new FileDeleteEventArgs(path);

            var handler = FileDelete;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnFileOpen(string path)
        {
            var args = new FileOpenEventArgs(path);

            var handler = FileOpen;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnFileListUpdateRequest(string path, FolderRepresentPosition position)
        {
            var args = new FileListUpdateRequstedEventArgs(path, position);

            var handler = FileListUpdateRequsted;
            if (handler != null)
            {
                handler(this, args);
            }
        }

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
            var dataSource = fileList == null
                ? null
                : fileList
                    .Select(x => x.FullName).ToList();
            if (InvokeRequired)
            {
                Invoke((Action)(() => listBox.DataSource = dataSource));
            }
            else
            {
                listBox.DataSource = dataSource; 
            }
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

        private void buttonOpenA_Click(object sender, EventArgs e)
        {
            OnFileOpen((string)listBoxFilesA.SelectedItem);
        }

        private void buttonOpenB_Click(object sender, EventArgs e)
        {
            OnFileOpen((string)listBoxFilesB.SelectedItem);
        }

        private void buttonDeleteA_Click(object sender, EventArgs e)
        {
            OnFileDelete((string)listBoxFilesA.SelectedItem);
            OnFileListUpdateRequest(textBoxPathA.Text, FolderRepresentPosition.A);
        }
        private void buttonDeleteB_Click(object sender, EventArgs e)
        {
            OnFileDelete((string)listBoxFilesB.SelectedItem);
            OnFileListUpdateRequest(textBoxPathB.Text, FolderRepresentPosition.B);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnFileListUpdateRequest(textBoxPathA.Text, FolderRepresentPosition.A);
            OnFileListUpdateRequest(textBoxPathB.Text, FolderRepresentPosition.B);
        }

        private void buttonCreateA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCreateA.Text))
            {
                MessageBox.Show("Enter file name.");
                return;
            }

            var path = Path.Combine(textBoxPathA.Text, textBoxCreateA.Text);
            OnFileCreate(path);
            OnFileListUpdateRequest(textBoxPathA.Text, FolderRepresentPosition.A);
        }

        private void buttonCreateB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCreateB.Text))
            {
                MessageBox.Show("Enter file name.");
                return;
            }

            var path = Path.Combine(textBoxPathB.Text, textBoxCreateB.Text);
            OnFileCreate(path);
            OnFileListUpdateRequest(textBoxPathB.Text, FolderRepresentPosition.B);
        }
    }
}
