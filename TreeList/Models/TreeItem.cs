using System.Collections.Generic;

namespace TreeList.Models
{
    public class TreeItem
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string NodeData { get; set; }
        public List<TreeItem> Children { get; internal set; }
    }
}