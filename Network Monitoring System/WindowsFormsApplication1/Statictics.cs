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
    public partial class StatisticForm : Form
    {
        NetworkMonitoringSystem MonitoringSystem;
        public StatisticForm(NetworkMonitoringSystem monitoringsystem)
        {
            InitializeComponent();
            MonitoringSystem = monitoringsystem;
        }
        private void Statistics_Load(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            Query querySource = new SourceQuery(ipTextBox1.Text);
            Query queryDest = new DestQuery(ipTextBox2.Text);
            Query queryProtocol = new ProtocolQuery(textBox3.Text);
            List<Parametres> query = MonitoringSystem.Statistic.GetStatistic(queryProtocol.And(queryDest.And(querySource)));
            dataGridView1.Rows.Clear();
            foreach (Parametres inquery in query)
                dataGridView1.Rows.Add(inquery.SourceAddress, inquery.DestAddress, inquery.Time, inquery.Protocol, inquery.Message);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }
    }
}
