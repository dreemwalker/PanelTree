using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelTree.Models
{
    public class DimensionsStructure
    {
        public int Value { get; set; }
        public DimensionsStructure Left { get; set; }
        public DimensionsStructure Right { get; set; }
        public DimensionsStructure Reverse { get; set; }

        //init for root panel
        private void Inint()
        {
            Value = 2;

            Left = new DimensionsStructure(3);
            Right = new DimensionsStructure(1);
            Reverse = new DimensionsStructure(0);

            Left.Left = Reverse;
            Left.Right = this;
            Left.Reverse = Right;

            Right.Left = this;
            Right.Right = Reverse;
            Right.Reverse = Left;

            Reverse.Right = Left;
            Reverse.Left = Right;
            Reverse.Reverse = this;

        }
        private DimensionsStructure(int value)
        {
            Value = value;
        }

        public DimensionsStructure()
        {
            Inint();
        }
    }
}
