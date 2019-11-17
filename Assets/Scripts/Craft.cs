using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Craft : MonoBehaviour
{
    //public int colvoFactory;
    //public int colvoBakery;
    List<Recipes> product = RecipesArray.GetRecipes();
    public GameObject[] CraftsSprite;
    public Text text_timerBakery, text_timerFactory, text_countFactory, text_countBakery;
    public Text[] text_Ingredients1, text_Ingredients2, text_storageProduct;
    public GameObject FactorySprite;
   
    
    public void Update()
    {

        text_timerBakery.text = PlayerPrefs.GetFloat(UserConstants.TimerCraftsBakery) + "";
        text_countFactory.text = "x" + PlayerPrefs.GetFloat(UserConstants.CountBakery);
        text_timerFactory.text = PlayerPrefs.GetFloat(UserConstants.TimerCraftsFactory) + "";
        text_countBakery.text ="x" + PlayerPrefs.GetFloat(UserConstants.CountFactory);
        for(int i = 0; i <= product.Count; i++)
        {
            text_storageProduct[i].text = PlayerPrefs.GetFloat(product[i].getIndex()) + "";
            text_Ingredients1[i].text = PlayerPrefs.GetFloat(product[i].getNameIngredients1()) + "";
            if (product[i].getNameIngredients2() != "No")
            {
                text_Ingredients2[i].text = PlayerPrefs.GetFloat(product[i].getNameIngredients2()) + "";
            }
            else if (product[i].getNameIngredients2() == "No")
            {
                text_Ingredients2[i].text = ""; 
            }
        }

        PlayerPrefs.SetFloat(UserConstants.TimerCraftsFactory, PlayerPrefs.GetFloat(UserConstants.TimerCraftsFactory) - Time.deltaTime);
        if (PlayerPrefs.GetFloat(UserConstants.TimerCraftsFactory) <= 0)
        {
            PlayerPrefs.SetFloat(UserConstants.TimerCraftsFactory, 0);
            if (PlayerPrefs.GetInt(UserConstants.CountFactory) > 0)
            {
                string SelectedCraft = PlayerPrefs.GetString(UserConstants.SelectedCraftFactory);
                int ItemCount = PlayerPrefs.GetInt(SelectedCraft);
                PlayerPrefs.SetInt(SelectedCraft, ItemCount + 1);
                PlayerPrefs.SetInt(UserConstants.CountFactory, PlayerPrefs.GetInt(UserConstants.CountFactory)-1);
                Debug.Log(PlayerPrefs.GetInt("wheatflower"));
            }
        }
        PlayerPrefs.SetFloat(UserConstants.TimerCraftsBakery, PlayerPrefs.GetFloat(UserConstants.TimerCraftsBakery) - Time.deltaTime);
        if (PlayerPrefs.GetFloat(UserConstants.TimerCraftsBakery) <= 0)
        {
            PlayerPrefs.SetFloat(UserConstants.TimerCraftsBakery, 0);
            if (PlayerPrefs.GetInt(UserConstants.CountBakery) > 0)
            {
                string SelectedCraft = PlayerPrefs.GetString(UserConstants.SelectedCraftBakery);
                int ItemCount = PlayerPrefs.GetInt(SelectedCraft);
                PlayerPrefs.SetInt(SelectedCraft, ItemCount + 1);
                PlayerPrefs.SetInt(UserConstants.CountBakery, (PlayerPrefs.GetInt(UserConstants.CountBakery) -1));
                Debug.Log(PlayerPrefs.GetInt(UserConstants.SelectedCraftBakery));
            }
        }
    }
    public void Factory(string index)
    {
        string NameIngredient1 = RecipesArray.GetRecipes1ByIndex(index).getNameIngredients1();
        string NameIngredient2 = RecipesArray.GetRecipes1ByIndex(index).getNameIngredients2();
        
        if (PlayerPrefs.GetFloat(NameIngredient1) >= RecipesArray.GetRecipes1ByIndex(index).getCountforCraft1() && PlayerPrefs.GetFloat(NameIngredient2) >= RecipesArray.GetRecipes1ByIndex(index).getCountforCraft2())
        {
            if (PlayerPrefs.GetFloat(UserConstants.TimerCraftsFactory) == 0)
            {
                PlayerPrefs.SetFloat(UserConstants.TimerCraftsFactory, PlayerPrefs.GetFloat(UserConstants.TimerCraftsFactory) + RecipesArray.GetRecipes1ByIndex(index).getTimeforCraft());
                if (PlayerPrefs.GetInt(UserConstants.CountFactory) == 0)
                {
                    int FactorySpriteIndex = RecipesArray.GetRecipes1ByIndex(index).getCraftsSprite();
                    GameObject FactorySpriteGenerate = Instantiate(CraftsSprite[FactorySpriteIndex]) as GameObject;
                    FactorySpriteGenerate.transform.SetParent(FactorySprite.transform);
                }
                PlayerPrefs.SetInt(UserConstants.CountFactory, PlayerPrefs.GetInt(UserConstants.CountFactory) + 1);
            }
            else
            {
                if (PlayerPrefs.GetString(UserConstants.SelectedCraftFactory) == index)
                {
                    PlayerPrefs.SetFloat(UserConstants.TimerCraftsFactory, PlayerPrefs.GetFloat(UserConstants.TimerCraftsFactory) + RecipesArray.GetRecipes1ByIndex(index).getTimeforCraft());
                    PlayerPrefs.SetInt(UserConstants.CountFactory, PlayerPrefs.GetInt(UserConstants.CountFactory)+1);
                }
                else
                {
                    Debug.Log("Дождитесь завершения");
                }
            }
            PlayerPrefs.SetFloat(NameIngredient1, PlayerPrefs.GetFloat(NameIngredient1) - RecipesArray.GetRecipes1ByIndex(index).getCountforCraft1());
            PlayerPrefs.SetFloat(NameIngredient2, PlayerPrefs.GetFloat(NameIngredient2) - RecipesArray.GetRecipes1ByIndex(index).getCountforCraft2());
            PlayerPrefs.SetString(UserConstants.SelectedCraftFactory, index);
        }
        else
        {
            Debug.Log("Недостаточно ресурсов");
        }
    }
    public void Bakery(string index)
    {
        string NameIngredient1 = RecipesArray.GetRecipes1ByIndex(index).getNameIngredients1();
        string NameIngredient2 = RecipesArray.GetRecipes1ByIndex(index).getNameIngredients2();
        if (PlayerPrefs.GetFloat(NameIngredient1) >= RecipesArray.GetRecipes1ByIndex(index).getCountforCraft1() && (PlayerPrefs.GetFloat(NameIngredient2) >= RecipesArray.GetRecipes1ByIndex(index).getCountforCraft1() || RecipesArray.GetRecipes1ByIndex(index).getNameIngredients2() == "No"))
        {
            if (PlayerPrefs.GetFloat(UserConstants.TimerCraftsBakery) == 0)
            {
                PlayerPrefs.SetFloat(UserConstants.TimerCraftsBakery, PlayerPrefs.GetFloat(UserConstants.TimerCraftsBakery) + RecipesArray.GetRecipes1ByIndex(index).getTimeforCraft());
                if (PlayerPrefs.GetInt(UserConstants.CountBakery) == 0)
                {
                    int BakerySpriteIndex = RecipesArray.GetRecipes1ByIndex(index).getCraftsSprite();
                    GameObject BakerySpriteGenerate = Instantiate(CraftsSprite[BakerySpriteIndex]) as GameObject;
                    BakerySpriteGenerate.transform.SetParent(FactorySprite.transform);
                }
                PlayerPrefs.SetInt(UserConstants.CountBakery, PlayerPrefs.GetInt(UserConstants.CountBakery) + 1);
            }
            else
            {
                if (PlayerPrefs.GetString(UserConstants.SelectedCraftBakery) == index)
                {
                    PlayerPrefs.SetFloat(UserConstants.TimerCraftsBakery, PlayerPrefs.GetFloat(UserConstants.TimerCraftsBakery) + RecipesArray.GetRecipes1ByIndex(index).getTimeforCraft());
                    PlayerPrefs.SetInt(UserConstants.CountBakery, PlayerPrefs.GetInt(UserConstants.CountBakery) + 1);
                }
                else
                {
                    Debug.Log("Дождитесь завершения");
                }
            }
            PlayerPrefs.SetFloat(NameIngredient1, PlayerPrefs.GetFloat(NameIngredient1) - RecipesArray.GetRecipes1ByIndex(index).getCountforCraft1());
            PlayerPrefs.SetFloat(NameIngredient2, PlayerPrefs.GetFloat(NameIngredient2) - RecipesArray.GetRecipes1ByIndex(index).getCountforCraft2());
            PlayerPrefs.SetString(UserConstants.SelectedCraftBakery, index);
        }
        else
        {
            Debug.Log("Недостаточно ресурсов");
        }

    }

}

