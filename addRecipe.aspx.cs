
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addRecipe : System.Web.UI.Page
{
    ASP.Ingredient newIng;
    protected void Page_Load(object sender, EventArgs e)
    {
        newIng = (ASP.Ingredient)LoadControl("~/Ingredient.ascx");
    }
   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCategory.Text = "";
        txtDesc.Text = "";
        txtOwner.Text = "";
        txtRecipeName.Text = "";
        txtServings.Text = "";
        txtTime.Text = "";
        Ingredient.IngNameText = "";
        Ingredient.IngQtyText = "";
        Ingredient.UnitText = "";
        Ingredient1.IngNameText = "";
        Ingredient1.IngQtyText = "";
        Ingredient1.UnitText = "";
        Ingredient2.IngNameText = "";
        Ingredient2.IngQtyText = "";
        Ingredient2.UnitText = "";
        Ingredient3.IngNameText = "";
        Ingredient3.IngQtyText = "";
        Ingredient3.UnitText = "";
        Ingredient4.IngNameText = "";
        Ingredient4.IngQtyText = "";
        Ingredient4.UnitText = "";
        Ingredient5.IngNameText = "";
        Ingredient5.IngQtyText = "";
        Ingredient5.UnitText = "";
        Ingredient6.IngNameText = "";
        Ingredient6.IngQtyText = "";
        Ingredient6.UnitText = "";
        Ingredient7.IngNameText = "";
        Ingredient7.IngQtyText = "";
        Ingredient7.UnitText = "";
        Ingredient8.IngNameText = "";
        Ingredient8.IngQtyText = "";
        Ingredient8.UnitText = "";
        Ingredient9.IngNameText = "";
        Ingredient9.IngQtyText = "";
        Ingredient9.UnitText = "";
        Ingredient10.IngNameText = "";
        Ingredient10.IngQtyText = "";
        Ingredient10.UnitText = "";
        Ingredient11.IngNameText = "";
        Ingredient11.IngQtyText = "";
        Ingredient11.UnitText = "";
        Ingredient12.IngNameText = "";
        Ingredient12.IngQtyText = "";
        Ingredient12.UnitText = "";
        Ingredient13.IngNameText = "";
        Ingredient13.IngQtyText = "";
        Ingredient13.UnitText = "";
        Ingredient14.IngNameText = "";
        Ingredient14.IngQtyText = "";
        Ingredient14.UnitText = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ((List<Ingredient>)Application["ingredients"]).Add(new Ingredient
        {

            RecipeName = txtRecipeName.Text,
            RecipeOwner = txtOwner.Text,
            CookingTime = Convert.ToInt32(txtTime.Text)
        });


        Response.Redirect("recipes.aspx");
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
    
}