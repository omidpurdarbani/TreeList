using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TreeList.Models;

namespace TreeList.Controllers
{
    public class TreeController : Controller
    {
        private readonly TreeDbContext _context;

        public TreeController()
        {
            _context = new TreeDbContext();
        }

        public ActionResult Index()
        {
            var treeItems = _context.TreeItems.ToList();
            var treeList = BuildTree(treeItems);
            return View(treeList);
        }

        private List<TreeItem> BuildTree(List<TreeItem> treeItems)
        {
            var treeList = new List<TreeItem>();

            foreach (var item in treeItems.Where(x => x.ParentID == null))
            {
                item.Children = GetChildren(item.ID, treeItems);
                treeList.Add(item);
            }

            return treeList;
        }

        private List<TreeItem> GetChildren(int parentID, List<TreeItem> treeItems)
        {
            var children = new List<TreeItem>();

            foreach (var item in treeItems.Where(x => x.ParentID == parentID))
            {
                item.Children = GetChildren(item.ID, treeItems);
                children.Add(item);
            }

            return children;
        }
    }


}