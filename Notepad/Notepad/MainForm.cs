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

namespace Notepad
{
    public partial class MainForm : Form
    {

        private bool _dirty;
        private string _file;
        private string _title;

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateTitle()
        {
            if (_file == null)
            {
                _title = "Untitled";
            }
            else
            {
                _title = (new FileInfo(_file)).Name;
            }
            this.Text = _title + " - Notepad";
        }

        private void CreateNewDocument()
        {
            documentTextBox.Text = "";
            _dirty = false;
            _file = null;
            UpdateTitle();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateNewDocument();
            if (documentTextBox.WordWrap == true)
            {
                wordWrapToolStripMenuItem.Checked = true;
            } else
            {
                wordWrapToolStripMenuItem.Checked = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (verifySafe())
            {
                CreateNewDocument();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsDocument();
        }

        private bool saveAsDocument()
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                File.WriteAllText(Path.GetFullPath(saveFileDialog1.FileName), documentTextBox.Text);
                _file = saveFileDialog1.FileName;
                _dirty = false;
                UpdateTitle();
                return true;
            }
            return false;
        }

        private bool saveDocument()
        {
            if(_file == null || _file == "Untitled")
            {
                saveAsDocument();
                return true;
            } else
            {
                File.WriteAllText(_file, documentTextBox.Text);
                _dirty = false;
                return true;
            }
        }

        private bool verifySafe()
        {
            if (_dirty)
            {
                DialogResult result = MessageBox.Show(this, string.Format("Do you want to save changes to {0}?", _title), "Notepad", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                    return false;
                if (result == DialogResult.Yes)
                {
                    if (!saveDocument())
                        return false;
                }
            }
            return true;
        }

        private void documentTextBox_TextChanged(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentTextBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentTextBox.SelectedText = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                documentTextBox.Font = fontDialog1.Font;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (verifySafe())
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    documentTextBox.Text = File.ReadAllText(Path.GetFullPath(openFileDialog1.FileName));
                    _file = openFileDialog1.FileName;
                    _dirty = false;
                    UpdateTitle();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!verifySafe())
            {
                e.Cancel = true;
            }
        }
    }
}
