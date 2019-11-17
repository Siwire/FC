using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MachineryArray : MonoBehaviour
{
    public static List<Machinery> machinery = new List<Machinery>();

    public static void AddMachinery()
    {
        machinery.Add(new Machinery("tractor_1", "tractor", 1, 1.2f, 200));
        machinery.Add(new Machinery("tractor_2", "tractor", 2, 1.4f, 300));
        machinery.Add(new Machinery("tractor_3", "tractor", 3, 1.6f, 400));
        machinery.Add(new Machinery("combine_1", "combine", 1, 1.2f, 500));
        machinery.Add(new Machinery("combine_2", "combine", 2, 1.4f, 700));
        machinery.Add(new Machinery("combine_3", "combine", 3, 1.6f, 900));
    }
    public static List<Machinery> GetMachinery()
    {
        return machinery;
    }
    public static Machinery GetMachineryByIndex(string index)
    {
        return machinery.Find(element => element.index == index);
    }
    public static IEnumerable<Machinery> GetMachineryByType(string type)
    {
        return machinery.Where(i => i.getType() == type);
    }
}
