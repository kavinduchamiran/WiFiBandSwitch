using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;

namespace WiFiBandSwitch
{
    public partial class Form1 : Form
    {
        String key = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\0002";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void wifi24_Click(object sender, EventArgs e)
        {
            Registry.SetValue(key, "WirelessMode", "34");

            ResetNetworkAdaptor();

            connectWiFi("UoM_Wireless");
        }

        private void wifi5_Click(object sender, EventArgs e)
        {
            Registry.SetValue(key, "WirelessMode", "17");

            ResetNetworkAdaptor();

            connectWiFi("UoM_Wireless");
        }

        public void ResetNetworkAdaptor()
        {
            String query = "interface set interface \"Wi-Fi\" Disable";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "netsh.exe";
            startInfo.Arguments = query;
            process.StartInfo = startInfo;
            process.Start();

            System.Threading.Thread.Sleep(2500);

            query = "interface set interface \"Wi-Fi\" Enable";

            process = new System.Diagnostics.Process();
            startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "netsh.exe";
            startInfo.Arguments = query;
            process.StartInfo = startInfo;
            process.Start();
        }

        public void connectWiFi(String name)
        {
            System.Threading.Thread.Sleep(1000);
            String query = "wlan connect name=" + name;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "netsh.exe";
            startInfo.Arguments = query;
            process.StartInfo = startInfo;
            process.Start();
        }

        private void ni_Click(object sender, EventArgs e)
        {

           // cms.Show(this, Control.MousePosition); // Or any other overload
            cms.Show(Control.MousePosition);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
