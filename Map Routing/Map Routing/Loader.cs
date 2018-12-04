using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Map_Routing
{
    class Loader
    {
        public FileStream File;
        public StreamReader Reader;
        public StreamWriter Writter;
        public Loader()
        {
        }
        public Loader(string FileName , FileMode Mode)
        {
            this.File = new FileStream(FileName , Mode);
            this.Reader = new StreamReader(this.File);
            this.Writter = new StreamWriter(this.File);
        }
        public void Intialize_Streams()
        {
            this.Reader = new StreamReader(this.File);
            this.Writter = new StreamWriter(this.File);
        }
        public void CloseReader()
        {
            this.Reader.Close();
        }
        public void CloseWritter()
        {
            this.Writter.Close();
        }


    }
}
