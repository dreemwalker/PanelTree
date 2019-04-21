using System.Drawing;
namespace PanelTree.Models
{
    class PanelContext
    {
        public PanelsContainer panelsContainer { get; set; }
        public XMLReader reader { get; set; }
        public ImageGenerator imageGenerator { get; set;}
        public void Init()
        {
            XMLReader r = new XMLReader("assets/");
            panelsContainer=r.GetPanels("BeerPack.xml");
            imageGenerator = new ImageGenerator();
        }
        public Image GetImage()
        {
            Image img= imageGenerator.DrawScene(panelsContainer);
            return img;
        }
    }
}
