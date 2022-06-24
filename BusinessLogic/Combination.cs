namespace BusinessLogic;

public record Combination(
    Item Target,
    Item Sacrifice,
    Item Product,
    int Cost)
{
    public override string ToString() => $"{Target} + {Sacrifice} = {Product}; Cost = {Cost}";
}