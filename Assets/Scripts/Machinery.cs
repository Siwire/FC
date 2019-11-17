 public class Machinery
 {
    public string index;
    private string type;
    private int level;
    private float improve;
    private float price;

    public Machinery(string index, string type, int level, float improve, float price)
    {
        this.index = index;
        this.type = type;
        this.level = level;
        this.improve = improve;
        this.price = price;
    }
    public string getIndex()
    {
        return index;
    }
    public string getType()
    {
        return type;
    }
    public int getLevel()
    {
        return level;
    }
    public float getImprove()
    {
        return improve;
    }
    public float getPrice()
    {
        return price;
    }
    
 }
