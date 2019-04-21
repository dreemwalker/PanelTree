namespace PanelTree.Models
{
    public class PanelsContainer
    {
        public Preview pw { get; set; }
        public PanelItem panels { get; set; }
        public PanelsContainer()
        {
            pw = new Preview();
            panels = new PanelItem();
        }
    }
}
