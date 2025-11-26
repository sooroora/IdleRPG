public class PlayerInfo
{
    public int Level => _level;
    private int _level;
    public Inventory Inventory=>_inventory;
    Inventory _inventory = new Inventory();

    public int CurrentStage;
    private int currentStage;

}
