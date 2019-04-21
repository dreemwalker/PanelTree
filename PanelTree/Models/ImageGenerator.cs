using System.Collections.Generic;
using System.Drawing;

namespace PanelTree.Models
{
    public class ImageGenerator
    {
        DrawdPanel dp;
        List<DrawdPanel> dwdList;


        public Image DrawScene(PanelsContainer container)
        {
            int width = container.pw.originalDocumentWidth;
            int height  = container.pw.originalDocumentHeight;

            Bitmap image = new Bitmap(width, height);

            Pen pen = new Pen(Brushes.Black, 3);

            Graphics g = Graphics.FromImage(image);

            RectangleF[] rt = createRectangles(container);
            g.DrawRectangles(pen,rt);
    
            return image;
        }
    



        private RectangleF[] createRectangles (PanelsContainer c)
            {
                PanelItem p = c.panels;
                
                List<RectangleF> rectangles = new List<RectangleF>();

                /*Create root panel*/
                int rootX = (int)c.pw.rootX;
                int rootY = (int)c.pw.rootY;
                Point rootPoint = new Point(rootX, rootY);
            
                /*Create root rotation*/
                DimensionsStructure dimension = new DimensionsStructure();
            
                dp = new DrawdPanel();
                dp.CurrentRootPoint = rootPoint;
                dp.Rotation = dimension;
                dp.width = (int)p.panelWidth;
                dp.height = (int)p.panelHeight;
                dp.CalculateCoordinates();

                dwdList = new List<DrawdPanel>();
                dwdList.Add(dp);

                GetAll(p.AttachedPanels, dp,ref dwdList);

                foreach(DrawdPanel drawitem in dwdList)
                {
                    rectangles.Add(drawitem.createRectangle());
                }
                return rectangles.ToArray();
            }
        private void GetAll(List<PanelItem> pl, DrawdPanel parent, ref List<DrawdPanel> drawdPanels)
        {
            
            foreach (PanelItem p in pl)
            {
                DimensionsStructure parentRotation = parent.Rotation;
                int r = p.attachedToSide;
                DrawdPanel tmp = CreateDrawPanel(p,parent,r);
                drawdPanels.Add(tmp);
                if (p.AttachedPanels != null)
                {
                    GetAll(p.AttachedPanels, tmp, ref drawdPanels);
                }
            }
        }


        private DrawdPanel CreateDrawPanel(PanelItem p, DrawdPanel parent, int attachedToSide)
        {
            DrawdPanel dp = new DrawdPanel();

            dp.height =p.panelHeight;
            dp.width = p.panelWidth;
            dp.offset = p.hingeOffset;
            dp.Rotation = RotateNew(parent.Rotation, attachedToSide);
          
            dp.CurrentRootPoint = parent.GetRootPoint(dp.Rotation.Value, p.hingeOffset);
           
            dp.CalculateCoordinates();
            return dp;
        }
      

        private DimensionsStructure RotateNew(DimensionsStructure parentRotation, int attachedToSide)
        {
            DimensionsStructure newRotation;
            switch (attachedToSide)
            {
                case 1:
                    {
                        newRotation = parentRotation.Right;
                    }
                    break;
                case 3:
                    {
                        newRotation = parentRotation.Left;
                    }
                    break;
                case 0:
                    {
                        newRotation = parentRotation.Reverse;
                    }
                    break;
                default:
                    {
                        newRotation = parentRotation;
                    }
                    break;

            }
            return newRotation;
        }



    }
}
