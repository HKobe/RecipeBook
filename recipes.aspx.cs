using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

public partial class recipes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Ingredient> ingredients = (List<Ingredient>)Application["ingredinets"];
        string connectionstring =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionstring;
        OracleCommand comm = conn.CreateCommand();

        comm.CommandType = CommandType.Text;
        comm.CommandText = "select * from recipes";
        /*ling liu 300855329
         * lab 3 COMP229
         */
        DataTable table;
        try
        {
            //Open the data connection
            comm.Connection.Open();
            //Execute the command and save the results in a DataTable
            OracleDataReader reader = comm.ExecuteReader();
            table = new DataTable(); 
            table.Load(reader);
            GridView1.DataSource = table;
            GridView1.DataBind();
            reader.Close();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            comm.Connection.Close();
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        switch ((string)Session["theme"])
        {
            case "dark":
                Page.Theme = "Dark";
                break;
            case "light":
                Page.Theme = "Light";
                break;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["selectedRecipeID"] = GridView1.DataKeys[GridView1.SelectedIndex].Value;
        GridViewRow row = GridView1.Rows[GridView1.SelectedIndex];
        int recipeID = Convert.ToInt32(row.Cells[0].Text);
        Session["selectedRecipeID"] = recipeID;
        //Label1.Text = recipeID;-- Ling Liu 300855329
        Response.Redirect("recipeDetails.aspx");
    }
}