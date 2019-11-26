using UnityEngine;

public class Workers
{
    public int index;
    public string wlevel;
    public float wprice;
    public float autocollect;
    public Workers(int index, string wlevel, float wprice, float autocollect)
    {
        this.index = index;
        this.wlevel = wlevel;
        this.wprice = wprice;
        this.autocollect = autocollect;
    }
    public int getindex()
    {
        return index;
    }
    public string getwlevel()
    {
        return wlevel;
    }
    public float getwprice()
    {
        return wprice= wprice*(1+(PlayerPrefs.GetFloat(UserConstants.FieldsCount)/50));
    }
    public float getautocollect()
    {
        return autocollect;
    }
}

