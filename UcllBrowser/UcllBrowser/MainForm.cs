using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcllBrowser
{
    public partial class MainForm : Form
    {
        //custom vars
        private Dictionary<TabPage, WebBrowser> browserWindows;
        private const string homeUrl = "http://www.ucll.be/";

        public MainForm()
        {
            InitializeComponent();
            //browserWindows
            this.browserWindows = new Dictionary<TabPage, WebBrowser>();
        }

        private void CreateTab()
        {
            TabPage tab = new TabPage(homeUrl);
            WebBrowser browser = new WebBrowser();
            browser.Navigate(homeUrl);
            browser.Dock = DockStyle.Fill;
            tab.Controls.Add(browser);
            browserWindows.Add(tab, browser);
            browserTabs.TabPages.Insert(browserTabs.TabCount - 1, tab);
            browserTabs.SelectedTab = tab;
            ActivateBrowser(browser);
        }
        private void ActivateBrowser(WebBrowser browser)
        {
            statusLabel.Text = browser.StatusText;
            if (browser.Url != null)
                urlComboBox.Text = browser.Url.ToString();
            previousButton.Enabled = browser.CanGoBack;
            nextButton.Enabled = browser.CanGoForward;
        }
        private WebBrowser ActiveBrowser
        {
            get
            {
                return browserWindows[browserTabs.SelectedTab];
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateTab();
        }

        private void browserTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (browserTabs.SelectedIndex == browserTabs.TabCount - 1)
            {
                CreateTab();
            }
            else
            {
                ActivateBrowser(ActiveBrowser);
            }
        }
    }
}
