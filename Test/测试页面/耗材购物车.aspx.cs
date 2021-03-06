using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test.测试页面
{
    public partial class 耗材购物车 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bindData();

        }

        private void bindData()
        {
            if (Session["haocai"] == null)
                return;
            Card card = Session["haocai"] as Card;
            GridView1.DataSource = (Session["haocai"] as Card).haocaiInCard;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TextBox1.Text);
            string name = TextBox2.Text;
            int number = int.Parse(TextBox3.Text);
            if (Session["haocai"] == null)
                Session["haocai"] = new Card();
            Card card = Session["haocai"] as Card;
            card.addHaoCai(id, number, name);
            bindData();
             
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string strTempValue = string.Empty;
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)gvr.FindControl("CheckBox1");  //CheckBoxId为选择框的id
                if (cb.Checked)
                {
                    if (Session["haocai"] == null)
                        Session["haocai"] = new Card();
                    Card card = Session["haocai"] as Card;
                    strTempValue = GridView1.DataKeys[gvr.RowIndex].Value.ToString();
                    card.addHaoCai(Convert.ToInt32(strTempValue), -1, "0");
                }
            }
            bindData();
        }
    }
}