using System.Collections.Generic;

namespace PanelTree.Models
{
    
    public class PanelItem
    {
        public string panelId { get; set; }
        public string panelName { get; set; }

        public int minRot { get; set; }
        public int maxRot { get; set; }
        public int initialRot { get; set; }
        public int startRot { get; set; }
        public int endRot { get; set; }

        public float hingeOffset { get; set; }

        public float panelWidth { get; set; }
        public float panelHeight { get; set; }

        public int attachedToSide { get; set; }

        public float creaseBottom { get; set; }
        public float creaseTop { get; set; }
        public float creaseLeft { get; set; }
        public float creaseRight { get; set; }

        public bool ignoreCollisions { get; set; }
        public bool mouseEnabled { get; set; }

        public List<PanelItem> AttachedPanels { get; set; }

        public PanelItem()
        {
         
        }
    }
}
