using System;
class UserConstants
{
    public static string money = "money";
    public static string TimerPlants = "TimerPlants";
    public static string TimerWorkers = "TimerWorkers";
    public static string SelectedPlant = "SelectedPlant";
    public static string SelectedWorker = "SelectedWorker";
    public static string SelectedCraftFactory = "SelectedCraftFactory";
    public static string SelectedCraftBakery = "SelectedCraftBakery";
    public static string FieldsCount = "FieldsCount";
    public static string TractorsCount = "TractorsCount";
    public static string CountFactory = "CountFactory";
    public static string CountBakery = "CountBakery";
    public static string TimerCraftsFactory = "TimerCraftsFactory";
    public static string TimerCraftsBakery = "TimerCraftsBakery";
    public static string LevelStorage = "LevelStorage";

    public string nameConstant;
    string stringValue;
    float floatValue;
    int intValue;
    string valueType;

    public UserConstants(string nameConstant, string stringValue)
    {
        this.nameConstant = nameConstant;
        this.stringValue = stringValue;
        valueType = "string";
    }
    public UserConstants(string nameConstant, float floatValue)
    {
        this.nameConstant = nameConstant;
        this.floatValue = floatValue;
        valueType = "float";
    }
    public UserConstants(string nameConstant, int intValue)
    {
        this.nameConstant = nameConstant;
        this.intValue = intValue;
        valueType = "int";
    }
    public string getNameConstant()
    {
        return nameConstant;
    }
    public string getStringValue()
    {
        return stringValue;
    }
    public int getIntValue()
    {
        return intValue;
    }
    public float getFloatValue()
    {
        return floatValue;
    }
    public string getValueType()
    {
        return valueType;
    }
}

