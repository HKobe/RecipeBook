using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IngredientRepository
/// </summary>
public class IngredientRepository
{
	public IngredientRepository()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<Ingredient> GetIngredients()
    {
        HttpApplication webApp = HttpContext.Current.ApplicationInstance;
        return (List<Ingredient>)webApp.Application["ingredients"];
    }
}