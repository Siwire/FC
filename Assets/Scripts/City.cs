using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    
    public string index;
    List<Plant> plants = PlantsArray.GetPlants();
    List<Recipes> product = RecipesArray.GetRecipes();
    public Text[] text_plantPrice, text_storageHarvest, text_storageProduct, text_productPrice;
    public GameObject MassageMoney, MassageItems;
    public void Update()
    {
        for (int i = 0; i < plants.Count; i++)
        {
            text_storageHarvest[i].text = Math.Round(PlayerPrefs.GetFloat(plants[i].getIndex())) + "";
            text_plantPrice[i].text = PlantsArray.GetPlants()[i].getSellPrice() + "";
        }
        for (int i = 0; i < product.Count; i++)
        {
            text_storageProduct[i].text = PlayerPrefs.GetInt(product[i].getIndex()) + "";
            text_productPrice[i].text = RecipesArray.GetRecipes()[i].getProductPrice() + "";
        }
        float TimerPlants = PlayerPrefs.GetFloat(UserConstants.TimerPlants);
        TimerPlants -= Time.deltaTime;
        if (TimerPlants <= 0.0f)
        {
            TimerPlants = 0;
            PlayerPrefs.SetInt(UserConstants.SelectedPlant, 0);
            PlayerPrefs.SetString(UserConstants.SelectedPlant, "grass");
        } 
        PlayerPrefs.SetFloat(UserConstants.TimerPlants, TimerPlants);
        float timerText = PlayerPrefs.GetFloat(UserConstants.TimerPlants);
    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene("GameFarm");
    }
    public void buyPlant(string index)
    {
        Plant byingPlant = PlantsArray.GetPlantByIndex(index);
        if (PlayerPrefs.GetFloat(UserConstants.money) >= byingPlant.getPrice())
        {
            string SelectedPlant = PlayerPrefs.GetString(UserConstants.SelectedPlant);
            PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) - byingPlant.getPrice());
            float TimerPlants = PlayerPrefs.GetFloat(UserConstants.TimerPlants);
            if (SelectedPlant == index)
            {
                PlayerPrefs.SetFloat(UserConstants.TimerPlants, TimerPlants += 30.0f);
            }
            else
            {
                PlayerPrefs.SetFloat(UserConstants.TimerPlants, 30.0f);
            }
            PlayerPrefs.SetString(UserConstants.SelectedPlant, index);
        }
        else
            { 
            Debug.Log("You have not enough money");
            MassageMoney.SetActive(true);
            }
    }
    public void MassageMoneyClose()
    {
        MassageMoney.SetActive(false);
    }
    public void SellTenPlants(string index)
    {
        int ten = 10;
        float plantCount = PlayerPrefs.GetFloat(index);
        if (plantCount >= 10)
        {   

            PlayerPrefs.SetFloat(index, plantCount - ten);
            PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) + (PlantsArray.GetPlantByIndex(index).getSellPrice() * ten));
        }
        else if (plantCount < 10)
        {
            Debug.Log("You have not enough items");
            MassageItems.SetActive(true);
        }
    }
    public void SellTenProducts(string index)
    {
        int ten = 10;
        int productCount = PlayerPrefs.GetInt(index);
        if (productCount >= 10)
        {
            PlayerPrefs.SetInt(index, productCount - ten);
            PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) + (RecipesArray.GetRecipes1ByIndex(index).getProductPrice()));
        }
        else if (productCount < 10)
        {
            MassageItems.SetActive(true);
        }
    }

    public void MasssageItemsClose()
    {
        MassageItems.SetActive(false);
    }
}
