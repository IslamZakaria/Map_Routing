using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Map_Routing
{
    public partial class homepage : Form
    {

            Graph graph = new Graph("Map_File.txt", "Person.txt");
        static int i = 0;
        public homepage()
        {
            InitializeComponent();
        }
        
        private void homepage_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); 
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if(i < graph.map.QueryList.Count)
            {

            DateTime s = DateTime.Now;
            graph.shortestPath(i);
            TimeSpan t = DateTime.Now.Subtract(s);
            dataGridView1.Rows.Add(new object[] { graph.Shortest_Time * 60, graph.Total_Walking_Distance, graph.Total_Roads_Length, t.Milliseconds });
            i++;
            }
        }
    }
}
