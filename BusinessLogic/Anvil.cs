namespace BusinessLogic;

public static class Anvil
{

    public static Combination Combine(
        Item target,
        Item sacrifice)
    {
        sacrifice.CheckIsCompatibleWith(target);
        var combiningCost = target.AnvilUseCount.AnvilUseCountToCost() + sacrifice.AnvilUseCount.AnvilUseCountToCost();
        var productEnchantments = new List<Enchantment>(target.Enchantments);
        var targetEnchantmentTypes = target.Enchantments.Select(x => x.Type).ToList();
        foreach (var sacrificeEnchantment in sacrifice.Enchantments)
        {
            var sacrificeEnchantmentIndexInTarget = targetEnchantmentTypes.IndexOf(sacrificeEnchantment.Type);
            var sacrificeEnchantmentNotInTarget = sacrificeEnchantmentIndexInTarget == -1;
            var costMultiplier = sacrificeEnchantment.Type.GetMultiplier(sacrifice.Type);
            if (sacrificeEnchantment.Type.IsIncompatibleWith(target.Type))
            {
                continue;
            }

            if (sacrificeEnchantment.Type.IsIncompatibleWith(targetEnchantmentTypes))
            {
                combiningCost += 1;
                continue;
            }

            if (sacrificeEnchantmentNotInTarget)
            {
                productEnchantments.Add(sacrificeEnchantment);
                combiningCost += sacrificeEnchantment.Level * costMultiplier;
                continue;
            }

            var targetEnchantment = target.Enchantments[sacrificeEnchantmentIndexInTarget];
            if (sacrificeEnchantment.Level > targetEnchantment.Level)
            {
                productEnchantments[sacrificeEnchantmentIndexInTarget] = sacrificeEnchantment;
                combiningCost += sacrificeEnchantment.Level * costMultiplier;
            }
            else if (sacrificeEnchantment.Level == targetEnchantment.Level &&
                     targetEnchantment.Level < targetEnchantment.Type.MaxLevel)
            {
                var upgradedEnchantment = targetEnchantment.UpgradeBy(1);
                productEnchantments[sacrificeEnchantmentIndexInTarget] = upgradedEnchantment;
                combiningCost += upgradedEnchantment.Level * costMultiplier;
            }
            else
            {
                combiningCost += targetEnchantment.Level * costMultiplier;
            }
        }

        productEnchantments = productEnchantments.OrderBy(x => x.Type.FriendlyName).ToList();
        var productAnvilUseCount = Math.Max(target.AnvilUseCount, sacrifice.AnvilUseCount) + 1;
        var productItem = new Item(target.Type, productEnchantments, productAnvilUseCount);
        return new Combination(target, sacrifice, productItem, combiningCost);
    }

    public static CombinationOrder GetBestOrder(
        Item target,
        List<Enchantment> enchantments)
    {
        var items = enchantments.Select(enchantment =>
            new Item(ItemType.EnchantedBook, new List<Enchantment> { enchantment })).ToList();
        return GetBestOrder(target, items);
    }

    public static CombinationOrder GetBestOrder(Item target, List<Item> items)
    {
        CombinationOrder? bestCombinationOrder = null;

        void GeneratePermutation(List<Item> items, int k)
        {
            if (k == 1) {
                try
                {
                    var currentBestCombinationOrder = bestCombinationOrder;
                    var itemsToCombine = new List<Item> { target };
                    itemsToCombine.AddRange(items);
                    var combinationOrder = itemsToCombine.Combine();
                    if (currentBestCombinationOrder == null)
                    {
                        bestCombinationOrder = combinationOrder;
                    } 
                    else if (combinationOrder.TotalCost < currentBestCombinationOrder.TotalCost)
                    {
                        bestCombinationOrder = combinationOrder;
                    }
                } catch (AnvilException) {  }
            } else {
                for (var i = 0; i < k; i++)
                {
                    GeneratePermutation(items, k - 1);
                    if (k % 2 == 0)
                    {
                        var indexA = i;
                        var indexB = k - 1;
                        var a = items[indexA];
                        var b = items[indexB];
                        items[indexA] = b;
                        items[indexA] = a;
                    } else
                    {
                        const int indexA = 0;
                        var indexB = k - 1;
                        var a = items[indexA];
                        var b = items[indexB];
                        items[indexA] = b;
                        items[indexA] = a;
                    }
                }
            }
        }
        
        GeneratePermutation(new List<Item>(items), items.Count);
        return bestCombinationOrder ?? throw new AnvilException("There is an incompatible book.");
    }

    public static CombinationOrder Combine(this List<Item> items)
    {
        var combinations = new List<Combination>();
        var currentItems = items;
        while (currentItems.Count > 1)
        {
            var nextItems = new List<Item>();
            for (var index = 0; index < currentItems.Count; index += 2)
            {
                if (index + 1 <= currentItems.Count - 1)
                {
                    var target = currentItems[index];
                    var sacrifice = currentItems[index + 1];
                    var combinationResult = target + sacrifice;
                    combinations.Add(combinationResult);
                    nextItems.Add(combinationResult.Product);
                }
                else nextItems.Add(currentItems[index]);
            }

            currentItems = nextItems;
        }

        return new CombinationOrder(combinations);
    }

}