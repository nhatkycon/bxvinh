using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;

namespace appStore.commonStore.commonControls
{
    public class Footer : PlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            var sb = new StringBuilder();
            var listDm = GetTree(DanhMucDal.SelectByLDMMa(con, "MENU"));
            var list1 = from p in listDm
                        where p.Level == 1
                        orderby p.ThuTu ascending
                        select p;

            sb.AppendFormat(@"
<div class=""bodyGlobal footer"">
    <div class=""boxGlobal"">
        <div class=""box1Global"">");
            var itemDm = DanhMucDal.SelectByMa("HETHONG-FOOTER", con);
            sb.Append(itemDm.Description);

            sb.AppendFormat(@"</div>                
    </div>
</div>");
            Html = sb.ToString();
            base.KhoiTao(con);
        }
        public string GetSub(List<DanhMuc> list, DanhMuc pitem)
        {
            var sb = new StringBuilder();
            var list1 = from p in list
                        where p.PID == pitem.ID
                        orderby p.ThuTu ascending
                        select p;
            if (list1.Count() > 0)
            {
                sb.Append(@"<div class=""menu-flyOut"">");
                foreach (DanhMuc item in list1)
                {
                    sb.AppendFormat(@"<a title=""{1}"" class=""navi-top-subItem"" href=""{0}"">{1}</a>"
                        , string.Format(item.GiaTri, domain)
                        , item.Ten);
                }
                sb.Append("</div>");
            }
            return sb.ToString();
        }
        #region TreeProcess
        List<DanhMuc> GetTree(List<DanhMuc> inputList)
        {
            var list = new List<DanhMuc>();
            var plist = from c in buildTree(inputList)
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<DanhMuc> item in plist)
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        List<DanhMuc> GetTreeTop(List<DanhMuc> inputList)
        {
            var list = new List<DanhMuc>();
            foreach (HierarchyNode<DanhMuc> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                break;
            }
            return list;
        }
        void buildChild(HierarchyNode<DanhMuc> item, List<DanhMuc> list)
        {
            var plist = from c in item.ChildNodes
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<DanhMuc> _item in plist)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<DanhMuc>> buildTree(List<DanhMuc> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ID).ToList().AsHierarchy(e => e.ID, e => e.PID);
            return tree.ToList();
        }
        #endregion
    }
}
