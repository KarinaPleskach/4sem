using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Archive
    {
        public IZipStrategy Strategy { private get; set; }
        public void operate(String from, String into)
        {
            Strategy.operate(from, into);
        }

        private Archive() { }

        public static Archive getInstance()
        {
            return ArchiveHolder.INSTANCE;
        }

        private static class ArchiveHolder 
        { 
            internal static readonly Archive INSTANCE = new Archive();
        }
    }
}
