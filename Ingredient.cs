using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Ingredient
/// </summary>
public class Ingredient
{
	public Ingredient()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string recipeName;
    public string RecipeName
    {
        get
        {
            return recipeName;
        }
        set
        {
            recipeName = value;
        }
    }

    private string recipeOwner;
    public string RecipeOwner
    {
        get { return recipeOwner; }
        set { recipeOwner = value; }
    }

    private int cookingTime;
    public int CookingTime
    {
        get { return cookingTime; }
        set { cookingTime = value; }
    } 
}