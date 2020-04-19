using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace TrayIconTest
{
    class MyApplicationContext : ApplicationContext
    {
        //Component declarations
        private NotifyIcon TrayIcon;
        private ContextMenuStrip TrayIconContextMenu;
        private ToolStripMenuItem CloseMenuItem;
        string inputLanguage = System.Windows.Forms.InputLanguage.CurrentInputLanguage.LayoutName;


        public MyApplicationContext()
        {
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            InitializeComponent();
            TrayIcon.Visible = true;
            //Application.InputLanguageChanging += new InputLanguageChangingEventHandler(LanguageChanged);

            Microsoft.Win32.SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);


        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
            
        {
            //throw new NotImplementedException();
            System.Console.WriteLine(inputLanguage);

        }

        private void InitializeComponent()
        {
            TrayIcon = new NotifyIcon();

            TrayIcon.BalloonTipIcon = ToolTipIcon.Info;
            TrayIcon.BalloonTipText =
              "I noticed that you double-clicked me! What can I do for you?";
            TrayIcon.BalloonTipTitle = "You called Master?";
            TrayIcon.Text = "My fabulous tray icon demo application";

            //The icon is added to the project resources.
            //Here I assume that the name of the file is 'TrayIcon.ico'
            //TrayIcon.Icon = Properties.Resources.TrayIcon2;
            TrayIcon.Icon = new Icon("TrayIcon2.ico");
            //TrayIcon.Icon = new Icon(this.GetType(), "C:/Users/igorm/Source/Repos/WindowsFormsApp3/WindowsFormsApp3/Resources/TrayIcon2.bmp");

            //Optional - handle doubleclicks on the icon:
            TrayIcon.DoubleClick += TrayIcon_DoubleClick;

            //Optional - Add a context menu to the TrayIcon:
            TrayIconContextMenu = new ContextMenuStrip();
            CloseMenuItem = new ToolStripMenuItem();
            TrayIconContextMenu.SuspendLayout();

            // 
            // TrayIconContextMenu
            // 
            this.TrayIconContextMenu.Items.AddRange(new ToolStripItem[] {
            this.CloseMenuItem});
            this.TrayIconContextMenu.Name = "TrayIconContextMenu";
            this.TrayIconContextMenu.Size = new Size(153, 70);
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new Size(152, 22);
            this.CloseMenuItem.Text = "Close the tray icon program";
            this.CloseMenuItem.Click += new EventHandler(this.CloseMenuItem_Click);

            TrayIconContextMenu.ResumeLayout(false);
            TrayIcon.ContextMenuStrip = TrayIconContextMenu;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Cleanup so that the icon will be removed when the application is closed
            TrayIcon.Visible = false;
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            //Here you can do stuff if the tray icon is doubleclicked
            TrayIcon.ShowBalloonTip(10000);
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to close me?",
                    "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //klcpublic event System.Windows.Forms.InputLanguageChangingEventHandler InputLanguageChanging;

        protected virtual void LanguageChanged (InputLanguageChangingEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "InputLanguage", e.InputLanguage);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Culture", e.Culture);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "SysCharSet", e.SysCharSet);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "InputLanguageChanging Event");
        }
    }
}