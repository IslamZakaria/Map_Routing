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
        public homepage()
        {
            InitializeComponent();
        }

        private void homepage_Load(object sender, EventArgs e)
        {
            Map map = new Map();
            map.LoadMap("Map_File.txt");
            int c = map.MapEdges.Count();
            for (int i = 0; i < c; i++)
            {
                Edge v = map.MapEdges.Dequeue();
                dataGridView1.Rows.Add(new object[] {v.point1,v.point2, v.speed , v.Length, v.time });
            }
        }
    }
}
