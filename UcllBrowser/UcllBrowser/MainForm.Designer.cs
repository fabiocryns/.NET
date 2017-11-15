using System.Collections.Generic;
using System.Windows.Forms;

namespace UcllBrowser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null; 

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.previousButton = new System.Windows.Forms.ToolStripButton();
            this.nextButton = new System.Windows.Forms.ToolStripButton();
            this.urlComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.homeButton = new System.Windows.Forms.ToolStripButton();
            this.favoritesButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.favoritesPanel = new System.Windows.Forms.Panel();
            this.browserTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.favoritesPanel.SuspendLayout();
            this.browserTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previousButton,
            this.nextButton,
            this.urlComboBox,
            this.refreshButton,
            this.homeButton,
            this.favoritesButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(892, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // previousButton
            // 
            this.previousButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previousButton.Image = global::UcllBrowser.Properties.Resources.GoToPrevious;
            this.previousButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(23, 22);
            this.previousButton.Text = "previousButton";
            // 
            // nextButton
            // 
            this.nextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextButton.Image = global::UcllBrowser.Properties.Resources.GoToNextHS;
            this.nextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(23, 22);
            this.nextButton.Text = "nextButton";
            // 
            // urlComboBox
            // 
            this.urlComboBox.Name = "urlComboBox";
            this.urlComboBox.Size = new System.Drawing.Size(121, 25);
            this.urlComboBox.Text = "urlComboBox";
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton.Image = global::UcllBrowser.Properties.Resources.RepeatHS;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(23, 22);
            this.refreshButton.Text = "refreshButton";
            // 
            // homeButton
            // 
            this.homeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.homeButton.Image = global::UcllBrowser.Properties.Resources.HomeHS;
            this.homeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(23, 22);
            this.homeButton.Text = "homeButton";
            // 
            // favoritesButton
            // 
            this.favoritesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.favoritesButton.Image = global::UcllBrowser.Properties.Resources.WebInsertHyperlinkHS;
            this.favoritesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.favoritesButton.Name = "favoritesButton";
            this.favoritesButton.Size = new System.Drawing.Size(23, 22);
            this.favoritesButton.Text = "favoritesButton";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusProgressBar,
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 437);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(892, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(66, 17);
            this.statusLabel.Text = "statusLabel";
            // 
            // favoritesPanel
            // 
            this.favoritesPanel.Controls.Add(this.browserTabs);
            this.favoritesPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.favoritesPanel.Location = new System.Drawing.Point(348, 25);
            this.favoritesPanel.Name = "favoritesPanel";
            this.favoritesPanel.Size = new System.Drawing.Size(544, 412);
            this.favoritesPanel.TabIndex = 2;
            // 
            // browserTabs
            // 
            this.browserTabs.Controls.Add(this.tabPage1);
            this.browserTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserTabs.Location = new System.Drawing.Point(0, 0);
            this.browserTabs.Name = "browserTabs";
            this.browserTabs.SelectedIndex = 0;
            this.browserTabs.Size = new System.Drawing.Size(544, 412);
            this.browserTabs.TabIndex = 0;
            this.browserTabs.SelectedIndexChanged += new System.EventHandler(this.browserTabs_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(536, 386);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "[new]";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 459);
            this.Controls.Add(this.favoritesPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.favoritesPanel.ResumeLayout(false);
            this.browserTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel favoritesPanel;
        private System.Windows.Forms.TabControl browserTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripButton previousButton;
        private System.Windows.Forms.ToolStripButton nextButton;
        private System.Windows.Forms.ToolStripComboBox urlComboBox;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.ToolStripButton homeButton;
        private System.Windows.Forms.ToolStripButton favoritesButton;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

