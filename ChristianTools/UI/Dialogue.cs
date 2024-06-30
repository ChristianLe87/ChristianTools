namespace ChristianTools.UI
{
    public class Dialogue : IUI
    {
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; }
        public string tag { get; }
        private List<TextSet> branches;

        public Dialogue(Alignment UI_Position, int width, int height, List<List<TextSet>> branches, int margin = 0, Alignment textAlignment = Alignment.Midle_Center, Texture2D texture = null, string tag = "", bool isActive = true)
        {
        }
        
        public void UpdateOnGameWindowSizeChangeEvent()
        {
        }
    }

    public class TextSet
    {
        private List<TextNode> textNodes;
    }

    public class TextNode
    {
        private string text;
    }
    
    public class Yes_No_TextNode
    {
        private string text;
        //private Guid nodeID;
        private TextNode nextNode;

        private TextNode yesVertex;
        private TextNode noVertex;
    }
    
    
    
}