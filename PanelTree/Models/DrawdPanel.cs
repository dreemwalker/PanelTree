using System.Drawing;
namespace PanelTree.Models
{
    public class DrawdPanel
    {
        
        public float width { get; set; }
        public float height { get; set; }
        public float offset { get; set; }

        public PointF CurrentRootPoint { get; set; }

        public DimensionsStructure Rotation { get; set; }

        /*coordinates of the angles clockwise from the bottom left */
        public PointF[] Coordinates { get; set; }
       
        //public int rotation { get; set; }
        public DrawdPanel()
        {
            Coordinates = new PointF[4];
          
        }

        private void PrepareStats()
        {
           

            //adaptation for rotation
            if(Rotation.Value==3||Rotation.Value==1)
            {
                float tmp = height;
                height = width;
                width = tmp;
            }
        }
        public void CalculateCoordinates()
        {
            PrepareStats();
            switch (Rotation.Value)
            {
                case 1:
                    {
                        Coordinates[0].X = CurrentRootPoint.X ;
                        Coordinates[0].Y = CurrentRootPoint.Y + (height / 2);
                    }
                    break;
                case 2:
                    {
                        Coordinates[0].X = CurrentRootPoint.X - (width / 2);
                        Coordinates[0].Y = CurrentRootPoint.Y;

                    }
                    break;
                case 3:
                    {
                        Coordinates[0].X = CurrentRootPoint.X -width;
                        Coordinates[0].Y = CurrentRootPoint.Y+ (height / 2);

                    }
                    break;
                case 0:
                    {
                        Coordinates[0].X = CurrentRootPoint.X - (width / 2);
                        Coordinates[0].Y = CurrentRootPoint.Y+height;

                    
                    }
                    break;
            }
            Coordinates[1].X = Coordinates[0].X;
            Coordinates[1].Y = Coordinates[0].Y - height;

            Coordinates[2].X = Coordinates[1].X + width;
            Coordinates[2].Y = Coordinates[1].Y;

            Coordinates[3].X = Coordinates[0].X + width;
            Coordinates[3].Y = Coordinates[0].Y;

        }

        public PointF GetRootPoint(int side,float offset)
        {
            float x=0;
            float y=0;
            switch(side)
            {
                case 0:
                    {
                        x = Coordinates[0].X+width/2 + offset;
                        y = Coordinates[0].Y;
                    }
                    break;
                case 1:
                    {
                        x = Coordinates[3].X;
                        y = Coordinates[3].Y - (height / 2)+offset;
                    }break;
                case 2:
                    {
                        x = Coordinates[1].X+width/2+offset;
                        y = Coordinates[1].Y;
                    }break;
                case 3:
                    {
                        x = Coordinates[0].X;
                        y = Coordinates[0].Y - height / 2-offset;
                    }break;
            }
            PointF res = new PointF(x,y);
            return res;
        }
        public RectangleF createRectangle()
        {
            
            RectangleF r = new RectangleF(Coordinates[1].X,Coordinates[1].Y,width,height);
            return r;
        }


    }
}
