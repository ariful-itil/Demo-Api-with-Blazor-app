using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class TreeItems
    {
        public string Id { get; set; }
        public string Text { get; set; }


    }
    public class TreeItemsModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public string parentId { get; set; }
        public List<TreeItemsModel> children { get; set; }
        public string codes { get; set; }
    }
    public class TreeItemView
    {
        public string id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public List<TreeItemView> children { get; set; }

    }

}
