using BusinessLogic;

namespace Database;

internal static class CombinationOrderConverter
{

    internal static CombinationOrderEntity ToCombinationOrderEntity(this CombinationOrder combinationOrder) 
    {
        var entity = new CombinationOrderEntity
        {
            Combinations = combinationOrder.Combinations.Select(combination => combination.ToCombinationEntity())
                .ToList(),
            Name = combinationOrder.Name
        };
        if (combinationOrder.Id != -1)
        {
            entity.Id = combinationOrder.Id;
        }
        return entity;
    }

    internal static CombinationOrder ToCombinationOrder(this CombinationOrderEntity combinationOrderEntity) =>
        new(
            id: combinationOrderEntity.Id,
            combinations: combinationOrderEntity.Combinations.Select(combinationEntity => combinationEntity.ToCombination()).ToList(),
            name: combinationOrderEntity.Name);
    
    internal static CombinationEntity ToCombinationEntity(this Combination combination) =>
        new()
        {
            Target = combination.Target.ToItemEntity(),
            Sacrifice = combination.Sacrifice.ToItemEntity(),
            Product = combination.Product.ToItemEntity(),
            Cost = combination.Cost
        };

    private static Combination ToCombination(this CombinationEntity combinationEntity) =>
        new(
            Target: combinationEntity.Target.ToItem(),
            Sacrifice: combinationEntity.Sacrifice.ToItem(),
            Product: combinationEntity.Product.ToItem(),
            Cost: combinationEntity.Cost);
    
    private static ItemEntity ToItemEntity(this Item item) =>
        new()
        {
            Type = item.Type.ToItemTypeEntity(),
            Enchantments = item.Enchantments.Select(enchantment => enchantment.ToEnchantmentEntity()).ToList(),
            AnvilUseCount = item.AnvilUseCount
        };

    private static Item ToItem(this ItemEntity itemEntity) =>
        new(
            Type: itemEntity.Type.ToItemType(),
            Enchantments: itemEntity.Enchantments.Select(enchantment => enchantment.ToEnchantment()).ToList(),
            AnvilUseCount: itemEntity.AnvilUseCount);
    
    
    private static ItemTypeEntity ToItemTypeEntity(this ItemType itemType) =>
        new()
        {
            FriendlyName = itemType.FriendlyName
        };

    private static ItemType ToItemType(this ItemTypeEntity itemTypeEntity) =>
        ItemType.All.First(itemType => itemType.FriendlyName == itemTypeEntity.FriendlyName);

    private static EnchantmentEntity ToEnchantmentEntity(this Enchantment enchantment) =>
        new()
        {
            Type = enchantment.Type.ToEnchantmentTypeEntity(),
            Level = enchantment.Level
        };

    private static Enchantment ToEnchantment(this EnchantmentEntity enchantmentEntity) =>
        new(
            Type: enchantmentEntity.Type.ToEnchantmentType(), 
            Level: enchantmentEntity.Level);
    
    private static EnchantmentTypeEntity ToEnchantmentTypeEntity(this EnchantmentType enchantmentType) =>
        new()
        {
            FriendlyName = enchantmentType.FriendlyName
        };

    private static EnchantmentType ToEnchantmentType(this EnchantmentTypeEntity enchantmentTypeEntity) =>
        EnchantmentType.All.First(enchantmentType => enchantmentType.FriendlyName == enchantmentTypeEntity.FriendlyName);

}