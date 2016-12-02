using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

public partial class recipeDetails : System.Web.UI.Page
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

    private void BindDetails()
    {
        int selectedRecipeID = (int)Session["selectedRecipeID"];
        string connectionstring =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionstring;
        OracleCommand comm = conn.CreateCommand();
        try
        {
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from recipes where recipeID = :selectedRecipeID";
            comm.Parameters.Add("selectedRecipeId", OracleDbType.Int32, ParameterDirection.Input);
            comm.Parameters["selectedRecipeID"].Value = selectedRecipeID;
            DataTable table;
            comm.Connection.Open();
            OracleDataReader reader = comm.ExecuteReader();
            table = new DataTable();
            table.Load(reader);
            DetailsView1.DataSource = table;
            DetailsView1.DataKeyNames = new string[] { "recipeId" };
            DetailsView1.DataBind();
            reader.Close();
            comm.CommandText = "select ingredientName, quantity, unit from recipe_ingredients ri, ingredients i where recipeID = :selectedRecipeID and ri.ingredientid = i.ingredientid";
            OracleDataReader reader2 = comm.ExecuteReader();
            table = new DataTable();
            table.Load(reader2);
            gvIngredient.DataSource = table;
            gvIngredient.DataBind();
            reader2.Close();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            comm.Connection.Close();
        }
    }

    private void BindIngrediant()
    {
        int selectedRecipeID = (int)Session["selectedRecipeID"];
        string connectionstring =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionstring;
        OracleCommand comm = conn.CreateCommand();
        try
        {
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select ingredientName, quantity, unit from recipe_ingredients ri, ingredients i where recipeID = :selectedRecipeID and ri.ingredientid = i.ingredientid";
            comm.Parameters.Add("selectedRecipeId", OracleDbType.Int32, ParameterDirection.Input);
            comm.Parameters["selectedRecipeID"].Value = selectedRecipeID;
            DataTable table;
            comm.Connection.Open();
            OracleDataReader reader = comm.ExecuteReader();
            table = new DataTable();
            table.Load(reader);
            gvIngredient.DataSource = table;
            gvIngredient.DataBind();
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

    protected void Page_Load(object sender, EventArgs e)
    {
        BindDetails();
    }

    protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        int recipeId = Convert.ToInt32(DetailsView1.DataKey.Value);
        string connectionstring =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionstring;
        OracleCommand comm = conn.CreateCommand();
        comm.CommandType = CommandType.Text;
        comm.CommandText = "delete from recipes where recipeID = :selected_recipe";
        OracleParameter param = comm.Parameters.Add("selected_recipe", OracleDbType.Int32, ParameterDirection.Input);
        param.Value = recipeId;
        try
        {
            comm.Connection.Open();
            OracleDataReader reader = comm.ExecuteReader();
            reader.Close();
            Response.Redirect("recipes.aspx");
        }
        catch (Exception ex)
        {

        }
        finally
        {
            comm.Connection.Close();
        }
    }
    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        int recipeID = Convert.ToInt32(DetailsView1.DataKey.Value);

        string connectionstring =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionstring;
        OracleCommand comm = conn.CreateCommand();
        comm.CommandType = CommandType.StoredProcedure;
        comm.CommandText = "UpdateRecipeName";

        string newName = ((TextBox)DetailsView1.FindControl("txtNewOwner")).Text;
        lbl.Text = newName;
        //string newOwner = ((TextBox)DetailsView1.FindControl("txtNewOwner")).Text;
        //string newCategory = ((TextBox)DetailsView1.FindControl("txtNewCategory")).Text;
        //string newCookingTime = ((TextBox)DetailsView1.FindControl("txtNewCookingTime")).Text;
        //string newServings = ((TextBox)DetailsView1.FindControl("txtNewServings")).Text;
        //string newDesc = ((TextBox)DetailsView1.FindControl("txtNewInstruction")).Text;

        comm.Parameters.Add("idselected", OracleDbType.Int32, ParameterDirection.Input);
        comm.Parameters["idselected"].Value = recipeID;
        comm.Parameters.Add("newName", OracleDbType.Varchar2, ParameterDirection.Input);
        comm.Parameters["newName"].Value = newName;
        //comm.Parameters.Add("newOwner", OracleDbType.Varchar2, ParameterDirection.Input);
        //comm.Parameters["newOwner"].Value = newOwner;
        //comm.Parameters.Add("newCategory", OracleDbType.Int32, ParameterDirection.Input);
        //comm.Parameters["newCategory"].Value = newCategory;
        //comm.Parameters.Add("newCookingTime", OracleDbType.Int32, ParameterDirection.Input);
        //comm.Parameters["newCookingTime"].Value = newCookingTime;
        //comm.Parameters.Add("newServings", OracleDbType.Int32, ParameterDirection.Input);
        //comm.Parameters["newServings"].Value = newServings;
        //comm.Parameters.Add("newDesc", OracleDbType.Varchar2, ParameterDirection.Input);
        //comm.Parameters["newDesc"].Value = newDesc;

        try
        {
            //DataTable table;
            comm.Connection.Open();
            comm.ExecuteNonQuery();
            //DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            //OracleDataReader reader = comm.ExecuteReader();
            //table = new DataTable();
            //table.Load(reader);
            //DetailsView1.DataSource = table;
            //DetailsView1.DataKeyNames = new string[] { "recipeId" };
            //DetailsView1.DataBind();
            //reader.Close();
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            BindDetails();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        DetailsView1.ChangeMode(e.NewMode);
        BindDetails();
    }
    protected void gvIngredient_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvIngredient.EditIndex = e.NewEditIndex; // index of the row is going to be edited
        BindIngrediant();
    }

    protected void gvIngredient_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvIngredient.EditIndex = -1; // index of the row is going to be edited
        BindIngrediant();
    }
}