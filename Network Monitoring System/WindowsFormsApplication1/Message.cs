using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MessageForm : Form
    {
        NetworkMonitoringSystem MonitoringSystem;
        Device local;
        public MessageForm(NetworkMonitoringSystem monitoringsystem)
        {
            InitializeComponent();
            MonitoringSystem = monitoringsystem;
        }
        private void Message_Load(object sender, EventArgs e)
        {
            List<Device> netdevices = MonitoringSystem.GetNetworkDevice();
            local = MonitoringSystem.GetUserNetworkParametres();
            comboBox1.DataSource = netdevices;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int time;
            if (radioButton1.Checked==true)
                time = MonitoringSystem.SendPingPackage(local, comboBox1.SelectedItem as NetworkDevice, "");
            else
                time = MonitoringSystem.SendMessagePackage(local, comboBox1.SelectedItem as NetworkDevice, textBox1.Text);
            if (time > 0)
                textBox2.Text = "Узел доступен. Пакет доставлен";
            else
                textBox2.Text = "Узел не доступен. Пакет не доставлен";
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Enabled = textBox1.Enabled = false;
            textBox2.Clear();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Enabled = textBox1.Enabled = true;
            textBox2.Clear();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
