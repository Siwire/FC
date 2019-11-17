using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class PlantsArray : MonoBehaviour
{
    public static List<Plant> plants = new List<Plant>();
    
    public static void AddPlants()
    {
        plants.Add(new Plant("grass", "grass", 0, 1f, 100f, 0));
        plants.Add(new Plant("wheat", "wheat", 20, 1f, 5f, 1));
        plants.Add(new Plant("corn", "corn", 30, 1f, 10f, 2));
        plants.Add(new Plant("tomato", "tomato", 40, 1f, 10f, 3));
        plants.Add(new Plant("beans", "beans", 50, 1f, 10f, 4));
        plants.Add(new Plant("potato", "potato", 60, 1f, 10f, 5));
        plants.Add(new Plant("strawberry", "strawberry", 70, 1f, 10f, 6));
        plants.Add(new Plant("pumpkin", "pumpkin", 80, 1f, 10f, 7));
    }
    public static List<Plant> GetPlants()
    {
        return plants;
    }
    public static Plant GetPlantByIndex(string index)
    {
        return plants.Find(element => element.index == index);
    }
}
