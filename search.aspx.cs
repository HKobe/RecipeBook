using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

public partial class search : System.Web.UI.Page
{
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

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connectionstring;
            OracleCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;
            try
            {

                comm.CommandText = "select distinct recipeOwner from recipes";
                /*ling liu 300855329
                 * lab 3 COMP229
                 */
                DataTable table;

                comm.Connection.Open();
                OracleDataReader reader = comm.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                ddlOwner.DataSource = table;
                ddlOwner.DataTextField = "recipeOwner";
                ddlOwner.DataValueField = "recipeOwner";
                ddlOwner.DataBind();
                reader.Close();

                comm.CommandText = "select distinct category from recipes";
                OracleDataReader reader3 = comm.ExecuteReader();
                table = new DataTable();
                table.Load(reader3);
                ddlCtgry.DataSource = table;
                ddlCtgry.DataTextField = "category";
                ddlCtgry.DataValueField = "category";
                ddlCtgry.DataBind();
                reader3.Close();

                comm.CommandText = "select * from ingredients";
                OracleDataReader reader2 = comm.ExecuteReader();
                table = new DataTable();
                table.Load(reader2);
                ddlIngredient.DataSource = table;
                ddlIngredient.DataTextField = "ingredientName";
                ddlIngredient.DataValueField = "ingredientID";
                ddlIngredient.DataBind();
                reader2.Close();

                ddlOwner.Items.Insert(0, "All");
                ddlCtgry.Items.Insert(0, "All");
                ddlIngredient.Items.Insert(0, "All");

            }
            catch (Exception ex)
            {
                lbl.Text = "We have some problem, please visit later.";
            }
            finally
            {
                comm.Connection.Close();
                conn.Close();
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string connectionstring =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionstring;
        OracleCommand comm = conn.CreateCommand();
        comm.CommandType = CommandType.Text;

        try
        {
            OracleParameter paramOwner = new OracleParameter("owner", OracleDbType.NVarchar2, ParameterDirection.Input);
            paramOwner.Value = ddlOwner.SelectedItem.Text;
            comm.Parameters.Add(paramOwner);
            OracleParameter paramCategory = new OracleParameter("category", OracleDbType.NVarchar2, ParameterDirection.Input);
            paramCategory.Value = ddlCtgry.SelectedItem.Text;
            comm.Parameters.Add(paramCategory);
            OracleParameter paramIngr = new OracleParameter("ingredientID", OracleDbType.Int32, ParameterDirection.Input);
            paramIngr.Value = ddlIngredient.SelectedItem.Value.ToString();
            comm.Parameters.Add(paramIngr);
            // lbl.Text = paramIngr.Value.ToString();


            //all
            if (ddlOwner.SelectedValue == "All" && ddlCtgry.SelectedValue == "All" && ddlIngredient.SelectedValue == "All")
                comm.CommandText = "select * from recipes";
            //only owner
            if (ddlOwner.SelectedValue != "All" && ddlCtgry.SelectedValue == "All" && ddlIngredient.SelectedValue == "All")
                comm.CommandText = "select * from recipes where recipeOwner = '" + paramOwner.Value + "'";
            //owner & category
            if (ddlOwner.SelectedValue != "All" && ddlCtgry.SelectedValue != "All" && ddlIngredient.SelectedValue == "All")
                comm.CommandText = "select * from recipes where recipeOwner = '" + paramOwner.Value + "' and category = '" + paramCategory.Value + "'";
            // owner & ingredient
            if (ddlOwner.SelectedValue != "All" && ddlCtgry.SelectedValue == "All" && ddlIngredient.SelectedValue != "All")
                comm.CommandText = "select * from recipes where recipeOwner = '" + paramOwner.Value + "' and recipeid in (select recipeID from recipe_ingredients where ingredientID = " + paramIngr.Value + ")";
            // category
            if (ddlOwner.SelectedValue == "All" && ddlCtgry.SelectedValue != "All" && ddlIngredient.SelectedValue == "All")
                comm.CommandText = "select * from recipes where category = '" + paramCategory.Value + "'";
            //category & ingredient
            if (ddlOwner.SelectedValue == "All" && ddlCtgry.SelectedValue != "All" && ddlIngredient.SelectedValue != "All")
                comm.CommandText = "select * from recipes where category = :category and recipeid in (select recipeID from recipe_ingredients where ingredientID = " + paramIngr.Value + ")";
            // ingredient
            if (ddlOwner.SelectedValue == "All" && ddlCtgry.SelectedValue == "All" && ddlIngredient.SelectedValue != "All")
                comm.CommandText = "select * from recipes join recipe_ingredients using (recipeID) where ingredientID = " + paramIngr.Value;
            // owner + category + ingredient
            if (ddlOwner.SelectedValue != "All" && ddlCtgry.SelectedValue != "All" && ddlIngredient.SelectedValue != "All")
                comm.CommandText = "select * from recipes where recipeOwner = '" + paramOwner.Value + "' and category = '" + paramCategory.Value + "' and recipeid in (select recipeID from recipe_ingredients where ingredientID = " + paramIngr.Value + ")";
            // lbl.Text += comm.CommandText; //for debugging

            DataTable table;
            comm.Connection.Open();
            OracleDataReader reader = comm.ExecuteReader();
            table = new DataTable();
            table.Load(reader);
            gvSearchedRecipes.DataSource = table;
            gvSearchedRecipes.DataBind();
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
    protected void gvSearchedRecipes_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //Session["selectedRecipeID"] = GridView1.DataKeys[GridView1.SelectedIndex].Value;
        GridViewRow row = gvSearchedRecipes.Rows[gvSearchedRecipes.SelectedIndex];
        int recipeID = Convert.ToInt32(row.Cells[0].Text);
        Session["selectedRecipeID"] = recipeID;
        //Label1.Text = recipeID;-- Ling Liu 300855329
        Response.Redirect("recipeDetails.aspx");
    }
}