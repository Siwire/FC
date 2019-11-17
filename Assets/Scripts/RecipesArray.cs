using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecipesArray : MonoBehaviour
{
    public static List<Recipes> recipes = new List<Recipes>();
    public static void AddRecipes()
    {
        recipes.Add(new Recipes("wheatflour", "wheatflour", "wheat", "No", 1, 0, 5, 0, 10));
        recipes.Add(new Recipes("cornflour", "cornflour", "corn", "No", 1, 0, 5, 1, 15));
        recipes.Add(new Recipes("cannedcorn", "cannedcorn", "corn", "No", 10, 0, 5, 2, 20));
        recipes.Add(new Recipes("cannedtomato", "cannedtomato", "tomato", "No", 10, 0, 5, 3, 40));
        recipes.Add(new Recipes("cannedbeans", "cannedbeans", "beans", "No", 10, 0, 5, 4, 60));
        recipes.Add(new Recipes("wheatbread", "wheatbread", "wheatflour", "No", 10, 0, 5, 5, 100));
        recipes.Add(new Recipes("cornbread", "cornbread", "cornflour", "No", 10, 0, 5, 6, 120));
        recipes.Add(new Recipes("strawberrypie", "strawberrypie", "wheatflour", "strawberry", 10, 0, 5, 7, 150));
        recipes.Add(new Recipes("pumpkinpie", "pumpkinpie", "wheatflour", "pumpkin", 10, 0, 5, 8, 200));
    }
    public static List<Recipes> GetRecipes()
    {
        return recipes;
    }

    public static Recipes GetRecipes1ByIndex(string index)
    {
        return recipes.Find(element => element.index == index);
    }
}
