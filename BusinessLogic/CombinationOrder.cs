namespace BusinessLogic;

public class CombinationOrder
{
    
    public List<Combination> Combinations { get; }
    public string Name { get; }
    public int Id { get; }
    
    public int TotalCost { get; }
    public Item FinalProduct { get; }
    
    public CombinationOrder(List<Combination> combinations, string? name = null, int id = -1)
    {
        Combinations = combinations;
        Name = name ?? combinations.Last().Target.Type.FriendlyName;
        Id = id;
        TotalCost = combinations.Sum(combination => combination.Cost);
        FinalProduct = Combinations.Last().Product;
    }
}