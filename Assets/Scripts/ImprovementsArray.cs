using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovememtsArray : MonoBehaviour
{
    public static List<Workers> workers = new List<Workers>();

    public static void AddWorker()
    {
        workers.Add(new Workers(0, "gamer", 0, 0.0f));
        workers.Add(new Workers(1, "first", 100, 0.3f));
        workers.Add(new Workers(2, "second", 200, 0.6f));
        workers.Add(new Workers(3, "third", 300, 0.9f));
    }
    public static List<Workers> GetWorkers()
    {
        return workers;
    }
    public static Workers GetWorkersByLevel(string wlevel)
    {
        return workers.Find(element => element.wlevel == wlevel);
    }
}
