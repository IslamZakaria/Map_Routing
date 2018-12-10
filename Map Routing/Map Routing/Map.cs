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
        //
        public Dictionary<int, List<Edge>> MapEdges;
        public Dictionary<int, Vertics> VertData;
        public SortedDictionary<int, Vertics> MapVertics;
        public SortedDictionary<Vertics, float> MapVertics1;
        public SortedDictionary<VerticsNumircal, float> MapVertics2;
        public List<Vertics> vertex;
        public List<Person> QueryList;
        public string MapFile , QueryFile;
        private Loader loader;
        public Map(string MapFile, string QueryFile)
        {
            this.MapEdges = new Dictionary<int, List<Edge>>();
            this.MapVertics2 = new SortedDictionary<VerticsNumircal, float>();
            this.MapVertics = new SortedDictionary<int, Vertics>();
            this.MapVertics1 = new SortedDictionary<Vertics, float>();
            this.QueryList = new List<Person>();
            this.VertData = new Dictionary<int, Vertics>();
            this.MapFile = MapFile;
            this.QueryFile = QueryFile;
            this.vertex = new List<Vertics>();
            this.Load();
        }
        public void LoadMap()
        {
            loader = new Loader(MapFile, FileMode.Open);
            loader.Intialize_Streams();
            while (loader.Reader.Peek() != -1)
            {
                /* Start Reading Vertices*/
                int vertCount = int.Parse(loader.Reader.ReadLine());
                float x=0;
                for (int i = 0; i < vertCount; i++)
                {
                    string[] line = loader.Reader.ReadLine().Split(' ');
                    Vertics verticsTemp = new Vertics(9999990+x, int.Parse(line[0]), float.Parse(line[1]), float.Parse(line[2]));
                    VerticsNumircal vt2 = new VerticsNumircal(float.MaxValue, int.Parse(line[0]), float.Parse(line[1]), float.Parse(line[2]));
                    this.MapVertics.Add(verticsTemp.Number, verticsTemp);
                    this.MapVertics1.Add(verticsTemp, verticsTemp.time);
                    this.MapVertics2.Add(vt2, float.MaxValue);
                    this.VertData.Add(verticsTemp.Number, verticsTemp);
                    this.MapEdges.Add(verticsTemp.Number, new List<Edge>());
                    this.vertex.Add(verticsTemp);
                    x++;
                }
                /* Start Reading Edges*/
                int EdgeCount = int.Parse(loader.Reader.ReadLine());
                for (int i = 0; i < EdgeCount; i++)
                {
                    string[] line = loader.Reader.ReadLine().Split(' ');
                    // point1 , point 2 , len , speed
                    Edge edgeTemp = new Edge(int.Parse(line[0]), int.Parse(line[1]), float.Parse(line[2]), int.Parse(line[3]));
                    this.MapEdges[edgeTemp.point1].Add(edgeTemp);
                    Edge edgeTemp1 = new Edge(int.Parse(line[1]), int.Parse(line[0]), float.Parse(line[2]), int.Parse(line[3]));
                    this.MapEdges[edgeTemp.point2].Add(edgeTemp1);
                }
            }//end while loop
            loader.CloseReader();
        }
        public void LoadQuery()
        {
            loader = new Loader(QueryFile, FileMode.Open);
            loader.Intialize_Streams();
            while (loader.Reader.Peek() != -1)
            {
                int QueryCount = int.Parse(loader.Reader.ReadLine());
                for (int i = 0; i < QueryCount; i++)
                {
                    string[] line = loader.Reader.ReadLine().Split(' ');
                    Vertics vert1 = new Vertics();
                    vert1.x = float.Parse(line[0]);
                    vert1.y = float.Parse(line[1]);
                    Vertics vert2 = new Vertics();
                    vert2.x = float.Parse(line[2]);
                    vert2.y = float.Parse(line[3]);
                    Person pTemp = new Person(vert1, vert2, float.Parse(line[4]));
                    QueryList.Add(pTemp);
                }
            }
            loader.CloseReader();
        }
        public void Load()
        {
            this.LoadMap();
            this.LoadQuery();
        }
        public void ResetDate()
        {
            this.VertData.Clear();
            loader = new Loader(MapFile ,FileMode.Open);
            loader.Intialize_Streams();
            int vertCount = int.Parse(loader.Reader.ReadLine());
            for (int i = 0; i < vertCount; i++)
            {
                string[] line = loader.Reader.ReadLine().Split(' ');
                Vertics verticsTemp = new Vertics(float.MaxValue, int.Parse(line[0]), float.Parse(line[1]), float.Parse(line[2]));
                this.VertData.Add(verticsTemp.Number, verticsTemp);
            }
            loader.CloseReader();
        }
    }
}