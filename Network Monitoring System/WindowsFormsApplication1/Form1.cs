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
    public partial class FormSystem : Form
    {
        public FormSystem()
        {
            InitializeComponent();
        }
        Network Net;
        NetworkMonitoringSystem MonitoringSystem;
        private void Form1_Load(object sender, EventArgs e)
        {
            Net=new Network();
            MonitoringSystem=new NetworkMonitoringSystem(Net);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            UserNetworkParametres parametres = new UserNetworkParametres(MonitoringSystem);
            parametres.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StructureFrom structure= new StructureFrom(MonitoringSystem);
            structure.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageForm message = new MessageForm(MonitoringSystem);
            message.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StatisticForm statistics = new StatisticForm(MonitoringSystem);
            statistics.Show();
        }
    }
}
