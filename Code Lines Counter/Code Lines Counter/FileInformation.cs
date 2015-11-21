using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Lines_Counter
{
   public class FileInformation
    {
        private string name;
        private string extension;
        private long size;
        private long lines;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Extension
        {
            get
            {
                return extension;
            }

            set
            {
                extension = value;
            }
        }

        public long Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public long Lines
        {
            get
            {
                return lines;
            }

            set
            {
                lines = value;
            }

        }
        public FileInformation(string name, long size, long lines)
        {
            this.name = name;
            this.size = size;
            this.lines = lines;
        }
    }
}
