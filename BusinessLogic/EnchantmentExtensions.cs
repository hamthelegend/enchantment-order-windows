﻿namespace BusinessLogic;

public static class EnchantmentExtensions
{
    public static Item ToNewItem(this ItemType itemType, List<Enchantment>? enchantments = null) =>
        new(Type: itemType, Enchantments: enchantments ?? new List<Enchantment>(), AnvilUseCount: 0);
    
    public static Item ToEnchantedBook(this IEnumerable<Enchantment> enchantments) =>
        new(ItemType.EnchantedBook, enchantments.ToList());
    
    public static int AnvilUseCountToCost(this int anvilUseCount) => Convert.ToInt32(Math.Pow(2, anvilUseCount)) - 1;

    public static int CostToAnvilUseCount(this int cost) => Convert.ToInt32(Math.Log(cost + 1) / Math.Log(2));

    public static int RenameCostToAnvilUseCount(this int renameCost) => (renameCost - 1).CostToAnvilUseCount();

    public static bool IsCostTooExpensive(this int cost) => cost >= 40;

}