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
    public partial class StructureFrom : Form
    {
        NetworkMonitoringSystem monitoringsystem;
        public StructureFrom(NetworkMonitoringSystem system)
        {
            InitializeComponent();
            monitoringsystem = system;
        }
        private void Struct_Load(object sender, EventArgs e)
        {
            monitoringsystem.Repository = new DeviceRepository(monitoringsystem.GetStructDevice());
            UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            Query queryIP = new IPQuery(ipTextBox1.Text);
            Query queryType = new TypeQuery(textBox2.Text);
            List<Device> query = monitoringsystem.Repository.GetStructure(queryIP.And(queryType));
            dataGridView1.Rows.Clear();
            foreach (Device inquery in query)
                dataGridView1.Rows.Add(inquery.Name, inquery.IP, inquery.Type);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }
    }
}
