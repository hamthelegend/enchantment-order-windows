using BusinessLogic;

namespace Database;

internal static class CombinationOrderConverter
{
    
    internal static CombinationOrderEntity ToCombinationOrderEntity(this CombinationOrder combinationOrder) =>
        new()
        {
            Id = combinationOrder.Id,
            Combinations = combinationOrder.Combinations,
            Name = combinationOrder.Name
        };

    internal static CombinationOrder ToCombinationOrder(this CombinationOrderEntity combinationOrderEntity) =>
        new(
            id: combinationOrderEntity.Id,
            combinations: combinationOrderEntity.Combinations,
            name: combinationOrderEntity.Name);

}