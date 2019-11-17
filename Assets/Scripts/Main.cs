using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Main : MonoBehaviour
    
{
    public float money, storage;
    public Text text_money, text_storage, text_fields, text_timerplant;
    public Text[] text_plant;
    private static List<Plant> plants = PlantsArray.GetPlants();
    public GameObject[] plantSprite;
    public GameObject Massage;
    public void Start()
    {
        money = PlayerPrefs.GetFloat(UserConstants.money);
        //objs = (GameObject[])Resources.LoadAll("Plants");
    }

    public void Update()
    {
        storage = PlayerPrefs.GetFloat("grass") + PlayerPrefs.GetFloat("corn") + PlayerPrefs.GetFloat("wheat") + PlayerPrefs.GetFloat("tomato") + PlayerPrefs.GetFloat("potato") + PlayerPrefs.GetFloat("beans") + PlayerPrefs.GetFloat("strawberry") + PlayerPrefs.GetFloat("pumpkin");
        float timerText = PlayerPrefs.GetFloat(UserConstants.TimerPlants);
        text_timerplant.text = Math.Round(timerText) + " s   " + PlayerPrefs.GetString(UserConstants.SelectedPlant);
        text_storage.text = storage + "/" + PlayerPrefs.GetInt(UserConstants.LevelStorage);
        text_fields.text = "Fields count: " + PlayerPrefs.GetInt(UserConstants.FieldsCount);
        text_money.text = money + "$";
        PlayerPrefs.SetFloat(UserConstants.money, money);

        for (int i = 0; i < plants.Count; i++)
        {
            text_plant[i].text = PlayerPrefs.GetFloat(plants[i].getIndex()) + "/100";
        }

        float TimerPlants = PlayerPrefs.GetFloat(UserConstants.TimerPlants);
        PlayerPrefs.SetFloat(UserConstants.TimerPlants, TimerPlants - Time.deltaTime);
        if (TimerPlants <= 0.0f)
        {
            PlayerPrefs.SetFloat(UserConstants.TimerPlants, 0);
            PlayerPrefs.SetString(UserConstants.SelectedPlant, "grass");
        }

        float TimerWorkers = PlayerPrefs.GetFloat(UserConstants.TimerWorkers);
        PlayerPrefs.SetFloat(UserConstants.TimerWorkers, TimerWorkers - Time.deltaTime);
        if (TimerWorkers <= 0.0f)
        {
            PlayerPrefs.SetFloat(UserConstants.TimerWorkers, 0);
            PlayerPrefs.SetString(UserConstants.TimerWorkers, "gamer");
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
                PlayerPrefs.SetInt(UserConstants.CountBakery, PlayerPrefs.GetInt(UserConstants.CountFactory)-1);
            }
        }

        string selectedPlantIndex = PlayerPrefs.GetString(UserConstants.SelectedPlant);
        float fieldsCount = PlayerPrefs.GetFloat(UserConstants.FieldsCount);
        Plant selectedPlant = PlantsArray.GetPlantByIndex(selectedPlantIndex);
        string wlevel = PlayerPrefs.GetString(UserConstants.SelectedWorker);
        Workers autocollect = ImprovememtsArray.GetWorkersByLevel(wlevel);
        float amountautocollect = selectedPlant.getCountChange() * fieldsCount * autocollect.getautocollect();
        if (storage + amountautocollect < PlayerPrefs.GetInt(UserConstants.LevelStorage))
        {
            PlayerPrefs.SetFloat(selectedPlantIndex, PlayerPrefs.GetFloat(selectedPlantIndex) + (amountautocollect * Time.deltaTime));
        }
        else if (storage + amountautocollect < PlayerPrefs.GetInt(UserConstants.LevelStorage))
        {
            PlayerPrefs.SetFloat(selectedPlantIndex, PlayerPrefs.GetFloat(selectedPlantIndex) - ((storage - amountautocollect * Time.deltaTime)));
        }
        else if (storage == PlayerPrefs.GetInt(UserConstants.LevelStorage))
        {
            PlayerPrefs.SetFloat(selectedPlantIndex, PlayerPrefs.GetFloat(selectedPlantIndex) + 0);
        }
        
    }
    public void OnMouseDown()
    {
        string selectedPlantIndex = PlayerPrefs.GetString(UserConstants.SelectedPlant);
        int fieldsCount = PlayerPrefs.GetInt(UserConstants.FieldsCount);
        Plant selectedPlant = PlantsArray.GetPlantByIndex(selectedPlantIndex);
        if (storage + (selectedPlant.getCountChange() * fieldsCount) <= PlayerPrefs.GetInt(UserConstants.LevelStorage))
        {
            
            PlayerPrefs.SetFloat(selectedPlantIndex, PlayerPrefs.GetFloat(selectedPlantIndex) + selectedPlant.getCountChange() * fieldsCount);
            Instantiate(plantSprite[selectedPlant.getPlantSprite()]);
            float camWidth = Camera.main.orthographicSize * Camera.main.aspect;
        }
        else if (storage + (selectedPlant.getCountChange() * fieldsCount) > PlayerPrefs.GetInt(UserConstants.LevelStorage))
        {
            PlayerPrefs.SetFloat(selectedPlantIndex, PlayerPrefs.GetFloat(selectedPlantIndex) - (storage - PlayerPrefs.GetInt(UserConstants.LevelStorage)));
            Massage.SetActive(true);
        }
        else if (storage == PlayerPrefs.GetInt(UserConstants.LevelStorage))
        {
            Massage.SetActive(true);
        }
        }
        public void MassageClose()
    {
        Massage.SetActive(false);
    }
}

