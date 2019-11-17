using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScript : MonoBehaviour
{
    private static List<UserConstants> userConstants = new List<UserConstants>();
    public void InitValues()
     {
        InitAllConstants();
        InitPlants();
        InitTimers();
        InitWTimers();
        InitCTimersFactory();
        InitCTimerBakery();
        //InitUserPrefs();
        InitWorkers();
        InitTractors();
        InitCrafts1();
     }

     private void InitCrafts1()
     {
         List<Recipes> crafts = RecipesArray.GetRecipes();
         if (crafts.Count == 0)
         {
             RecipesArray.AddRecipes();
         }
         for (int i = 0; i < crafts.Count; i++)
         {
             bool isPresent = Convert.ToBoolean(PlayerPrefs.GetInt(crafts[i].getNameRecipes()));
             int startValue = 0;
             if (!isPresent)
             {
                 PlayerPrefs.SetInt(crafts[i].getNameRecipes(), startValue);
             }
         }
     }
     private void InitPlants()
     {
         List<Plant> plants = PlantsArray.GetPlants();
         if (plants.Count == 0)
         {
             PlantsArray.AddPlants();
         }
         for (int i = 0; i < plants.Count; i++)
         {
             float plantCount = PlayerPrefs.GetFloat(plants[i].getIndex());
             bool isPresent = Convert.ToBoolean(plantCount);
             float startValue = 0;
             if (!isPresent)
             {
                 PlayerPrefs.SetFloat(plants[i].getIndex(), startValue);
             }
         }
     }

     private void InitTractors()
     {
         List<Machinery> tractors = MachineryArray.GetMachinery();
         if (tractors.Count == 0)
         {
             MachineryArray.AddMachinery();
         }
         for(int i = 0; i < tractors.Count; i++)
         {
             bool isPresent = Convert.ToBoolean(PlayerPrefs.GetInt(tractors[i].getIndex()));
             int startValue = 0;
             if (!isPresent)
             {
                 PlayerPrefs.SetInt(tractors[i].getIndex(), startValue);
             }
         }
     }

     private void InitWorkers()
     {
         List<Workers> workers = ImprovememtsArray.GetWorkers();
         if (workers.Count == 0)
         {
             ImprovememtsArray.AddWorker();
         }
         for (int i = 0; i < workers.Count; i++)
         {
             bool isPresent = Convert.ToBoolean(PlayerPrefs.GetInt(workers[i].getwlevel()));
             int startValue = 0;
             if (!isPresent)
             {
                 PlayerPrefs.SetInt(workers[i].getwlevel(), startValue);
             }
         }
     }
     private void InitTimers()
     {
         bool TimerPlantsIsPresent = Convert.ToBoolean(PlayerPrefs.GetInt(UserConstants.TimerPlants));
         float startValue = 0f;
         if (!TimerPlantsIsPresent)
         {
             PlayerPrefs.SetFloat(UserConstants.TimerPlants, startValue);
         }
     }
     private void InitWTimers()
     {
         bool TimerWorkerIsPresent = Convert.ToBoolean(PlayerPrefs.GetFloat(UserConstants.TimerWorkers));
         float startValue = 0f;
         if (!TimerWorkerIsPresent)
         {
             PlayerPrefs.SetFloat(UserConstants.TimerWorkers, startValue);
         }
     }
     private void InitCTimersFactory()
     {
         bool TimerCraftsIsPsesent = Convert.ToBoolean(PlayerPrefs.GetFloat(UserConstants.TimerCraftsFactory));
         float startValue = 0;
         if (!TimerCraftsIsPsesent)
         {
             PlayerPrefs.SetFloat(UserConstants.TimerCraftsFactory, startValue);
         }
     }
      private void InitCTimerBakery()
     {
         bool TimerCraftsIsPresent = Convert.ToBoolean(PlayerPrefs.GetFloat(UserConstants.TimerCraftsBakery));
         float startValue = 0;
         if (!TimerCraftsIsPresent)
         {
             PlayerPrefs.SetFloat(UserConstants.TimerCraftsBakery, startValue);
         }
     }

    private static void AddUserConstants()
    {
        userConstants.Add(new UserConstants(UserConstants.SelectedPlant, "grass"));
        userConstants.Add(new UserConstants(UserConstants.FieldsCount, 1));
        userConstants.Add(new UserConstants(UserConstants.SelectedWorker, "gamer"));
        userConstants.Add(new UserConstants(UserConstants.TractorsCount, 0));
        userConstants.Add(new UserConstants(UserConstants.SelectedCraftFactory, "0"));
        userConstants.Add(new UserConstants(UserConstants.SelectedCraftBakery, "0"));
        userConstants.Add(new UserConstants(UserConstants.CountFactory, 0));
        userConstants.Add(new UserConstants(UserConstants.CountBakery, 0));
        userConstants.Add(new UserConstants(UserConstants.LevelStorage, 100));
    }

    public void InitAllConstants()
    {
        AddUserConstants();
        userConstants.ForEach((item) =>
        {
            switch (item.getValueType())
            {
                case "string":
                    Debug.Log(item.getNameConstant());
                    string StringValueIsPresent = PlayerPrefs.GetString(item.getNameConstant());
                    Debug.Log(StringValueIsPresent);
                    Debug.Log(StringValueIsPresent.Length);
                    if (StringValueIsPresent.Length == 0)
                    {
                        PlayerPrefs.SetString(item.getNameConstant(), item.getStringValue());
                    }
                    break;
                case "int":
                    bool IntValueIsPresent = Convert.ToBoolean(PlayerPrefs.GetInt(item.getNameConstant()));
                    if (!IntValueIsPresent)
                    {
                        PlayerPrefs.SetInt(item.getNameConstant(), item.getIntValue());
                    }
                    break;
                case "float":
                    bool FloatValueIsPresent = Convert.ToBoolean(PlayerPrefs.GetFloat(item.getNameConstant()));
                    if (!FloatValueIsPresent)
                    {
                        PlayerPrefs.SetFloat(item.getNameConstant(), item.getFloatValue());
                    }
                    break;
            }
        });
    }
}

