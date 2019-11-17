public class Recipes
{
    public string index;
    public string nameRecipes;
    public string nameIngredients1;
    public string nameIngredients2;
    public int countforCraft1;
    public int countforCraft2;
    public int timeforCraft;
    public int craftsSprite;
    public int productPrice;
    public Recipes(string index, string nameRecipes, string nameIngredients1, string nameIngredients2, int countforCraft1, int countforCraft2, int timeforCraft, int craftsSprite, int productPrice)
    {
        this.index = index; 
        this.nameRecipes = nameRecipes;
        this.nameIngredients1 = nameIngredients1;
        this.nameIngredients2 = nameIngredients2;
        this.countforCraft1 = countforCraft1;
        this.countforCraft2 = countforCraft2;
        this.timeforCraft = timeforCraft;
        this.craftsSprite = craftsSprite;
        this.productPrice = productPrice;
    }

    public string getIndex()
    {
        return index;
    }
    public string getNameRecipes()
    {
        return nameRecipes;
    }
    public string getNameIngredients1()
    {
        return nameIngredients1;
    }
    public string getNameIngredients2()
    {
        return nameIngredients2;
    }
    public int getCountforCraft1()
    {
        return countforCraft1;
    }
    public int getCountforCraft2()
    {
        return countforCraft2;
    }
    public int getTimeforCraft()
    {
        return timeforCraft;
    }
    public int getCraftsSprite()
    {
        return craftsSprite;
    }
    public int getProductPrice()
    {
        return productPrice;
    }
}
