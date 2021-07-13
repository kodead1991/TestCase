using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseWinforms
{
    public class FrameViewInfo
    {
        private ushort _mask;
        private ushort _offset;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public ushort Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }
        public ushort Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }
        public FrameViewInfo(string name, ushort mask, ushort offset)
        {
            Name = name;
            Mask = mask;
            Offset = offset;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
