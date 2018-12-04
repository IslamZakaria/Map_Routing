using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;

using System.IO;

namespace Map_Routing
{
    class Map
    {
        public PriorityQueue<Edge> MapEdges;
        public PriorityQueue<Vertics> MapVertics;
        private Loader loader;
        public Map()
        {
            this.MapEdges = new PriorityQueue<Edge>();
            this.MapVertics = new PriorityQueue<Vertics>();
        }
        public void LoadMap(string File_Name)
        {
            loader = new Loader(File_Name ,FileMode.Open);
            loader.Intialize_Streams();
            while (loader.Reader.Peek() != -1)
            {
                /* Start Reading Vertices*/
                int vertCount = int.Parse(loader.Reader.ReadLine());
                for (int i = 0; i < vertCount; i++)
                {
                    string[] line = loader.Reader.ReadLine().Split(' ');
                    Vertics verticsTemp = new Vertics(int.Parse(line[0]), float.Parse(line[1]), float.Parse(line[2]));
                    this.MapVertics.Enqueue(verticsTemp);////////////////////////
                }
                /* Start Reading Edges*/
                int EdgeCount = int.Parse(loader.Reader.ReadLine());
                for (int i = 0; i < EdgeCount; i++)
                {
                    string[] line = loader.Reader.ReadLine().Split(' ');
                    // point1 , point 2 , len , speed
                    Edge edgeTemp = new Edge(int.Parse(line[0]), int.Parse(line[1]) ,float.Parse(line[2]),int.Parse(line[3]));
                    this.MapEdges.Enqueue(edgeTemp);/////////////////////////
                }
            }//end while loop
            loader.CloseReader();
        }
    }
}
