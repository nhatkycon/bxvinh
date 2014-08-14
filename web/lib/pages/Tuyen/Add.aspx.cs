using System;
using docsoft.entities;

public partial class lib_pages_Tuyen_Add : System.Web.UI.Page
{
    public Tuyen Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        Item = string.IsNullOrEmpty(id) ? new Tuyen() : TuyenDal.SelectById(Convert.ToInt32(id));
        Add.Item = Item;
        var diaDiem = DanhMucDal.SelectByLDMMa("BenXe");
        Add.DiaDiem = diaDiem;
    }
}