using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadTest
{
    public partial class MainForm : Form
    {
        private bool wordWrap;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            wordWrap = documentTextBox.WordWrap;
            wordWrapToolStripMenuItem.Checked = wordWrap;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void documentTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentTextBox.Cut();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            documentTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentTextBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentTextBox.SelectedText.Replace(documentTextBox.SelectedText, "");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                documentTextBox.Font = fontDialog1.Font;
            }
        }
    }
}
