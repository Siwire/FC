using UnityEngine;

public class Workers
{
    public string wlevel;
    public int wprice;
    public float autocollect;
    public Workers(string wlevel, int wprice, float autocollect)
    {
        this.wlevel = wlevel;
        this.wprice = wprice;
        this.autocollect = autocollect;
    }
    public string getwlevel()
    {
        return wlevel;
    }
    public int getwprice()
    {
        return wprice=wprice*(1+(PlayerPrefs.GetInt(UserConstants.FieldsCount)/50));
    }
    public float getautocollect()
    {
        return autocollect;
    }
}

