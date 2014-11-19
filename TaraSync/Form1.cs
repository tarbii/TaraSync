using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaraSync.Presenter;

namespace TaraSync
{
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
        }

        void IView.ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public event EventHandler<SyncRequestEventArgs> SyncRequested;

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Enter first folder to synchronize.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Enter second folder to synchronize.");
                return;
            }

            var args = new SyncRequestEventArgs(textBox1.Text, textBox2.Text);

            var handler = SyncRequested;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
