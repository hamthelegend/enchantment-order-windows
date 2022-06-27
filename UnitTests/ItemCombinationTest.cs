using BusinessLogic;

namespace UnitTests;

[TestClass]
public class ItemCombinationTest
{
    
    [TestMethod]
    public void RegularCombination()
    {
        var combination = ItemType.Pickaxe.ToNewItem() +
                          new List<Enchantment> { new(EnchantmentType.Fortune, 3) }
                              .ToEnchantedBook();
        combination.Assert(
            6, 
            ItemType.Pickaxe, 
            new Enchantment(EnchantmentType.Fortune, 3));
    }

    [TestMethod]
    public void ChainedCombination()
    {
        var combination1 = ItemType.Pickaxe.ToNewItem() +
                           new List<Enchantment> { new(EnchantmentType.Fortune, 3) }
                               .ToEnchantedBook();
        combination1.Assert(
            6,
            ItemType.Pickaxe,
            new Enchantment(EnchantmentType.Fortune, 3));

        var combination2 = combination1.Product +
                           new List<Enchantment> { new Enchantment(EnchantmentType.Mending) }
                               .ToEnchantedBook();
        combination2.Assert(
            3,
            ItemType.Pickaxe,
            new Enchantment(EnchantmentType.Fortune, 3),
            new Enchantment(EnchantmentType.Mending));
        
        // TODO: Write combination3 and combination4 along with their respective assertions 
        
          var combination3 = combination2.Product +
                           new List<Enchantment> { new(EnchantmentType.Unbreaking, 3) }
                               .ToEnchantedBook();
        combination3.Assert(
            6,
            ItemType.Pickaxe,
            new Enchantment(EnchantmentType.Fortune, 3),
            new Enchantment(EnchantmentType.Mending),
            new Enchantment(EnchantmentType.Unbreaking, 3));

        var combination4 = combination3.Product +
                           new List<Enchantment> { new(EnchantmentType.Efficiency, 5) }
                               .ToEnchantedBook();
        combination4.Assert(
            12,
            ItemType.Pickaxe,
            new Enchantment(EnchantmentType.Efficiency, 5),
            new Enchantment(EnchantmentType.Fortune, 3),
            new Enchantment(EnchantmentType.Mending),
            new Enchantment(EnchantmentType.Unbreaking, 3));
            
    }

    [TestMethod]
    public void NoCompatibleEnchantments1()
    {
        UnitTestExtensions.Assert<NoCompatibleEnchantmentsException>(() => 
            ItemType.Pickaxe.ToNewItem() +
            new List<Enchantment>
            {
                new(EnchantmentType.Protection, 4),
                new(EnchantmentType.FrostWalker, 2)
            }.ToEnchantedBook());
    }
    
    // TODO: Write the remaining test functions from the Kotlin file

    public void NoCompatibleEnchantments2()
    {
        UnitTestExtensions.Assert<NoCompatibleEnchantmentsException>(() =>
            ItemType.Pickaxe.ToNewItem(new List<Enchantment> { new(EnchantmentType.Unbreaking, 3) }) +
            new List<Enchantment>
            {
                new(EnchantmentType.Protection, 4),
                new(EnchantmentType.FrostWalker, 2)
            }.ToEnchantedBook());
    }

    public void incompatibleItemTypes1()
    {
        UnitTestExtensions.Assert<IncompatibleItemTypesException>(() =>
            ItemType.Pickaxe.ToNewItem(new List<Enchantment> { new(EnchantmentType.Mending) }) +
            ItemType.Shovel.ToNewItem(new List<Enchantment> { new(EnchantmentType.Fortune, 3) }));
    }

    public void incompatibleItemTypes2()
    {
        UnitTestExtensions.Assert<NoCompatibleEnchantmentsException>(() =>
            ItemType.EnchantedBook.ToNewItem(new List<Enchantment> { new(EnchantmentType.Mending) }) +
            ItemType.Shovel.ToNewItem(new List<Enchantment> { new(EnchantmentType.Fortune, 3) }));
    }

    public void hasEnchantmentsIncompatbileWithItemType1()
    {
        var combination = ItemType.Pickaxe.ToNewItem(new List<Enchantment> { new(EnchantmentType.Mending) }) +
            new List<Enchantment>
            {
                new(EnchantmentType.Fortune, 3),
                new(EnchantmentType.Protection, 4)
            }.ToEnchantedBook(); 
        combination.Assert(
            6,
            ItemType.Pickaxe,
            new Enchantment(EnchantmentType.Fortune, 3),
            new Enchantment(EnchantmentType.Mending));
    }

    public void hasEnchantmentsIncompatbileWithItemType2()
    {
        var combination1 = ItemType.Pickaxe.ToNewItem(new List<Enchantment> { new(EnchantmentType.Mending) }) +
            new List<Enchantment>
            {
                new(EnchantmentType.Fortune, 3),
                new(EnchantmentType.Protection, 4)
            }.ToEnchantedBook();
        combination1.Assert(
            6,
            ItemType.Pickaxe,
            new Enchantment(EnchantmentType.Mending),
            new Enchantment(EnchantmentType.Fortune, 3));

        var combination2 = combination1.Product + 
        new List<Enchantment>
        {
                new(EnchantmentType.Efficiency, 5),
                new(EnchantmentType.SilkTouch)
        }.ToEnchantedBook();
        combination1.Assert(
            7,
            ItemType.Pickaxe,
            new Enchantment(EnchantmentType.Mending),
            new Enchantment(EnchantmentType.Fortune, 3),
            new Enchantment(EnchantmentType.Efficiency, 5));
    }

    public void hasEnchantmentsIncompatibleWithTargetEnchantments1()
    {
        var combination = ItemType.Pickaxe.ToNewItem(new List<Enchantment> { new(EnchantmentType.Fortune, 3) }) +
            new List<Enchantment>
            {
                new(EnchantmentType.SilkTouch),
                new(EnchantmentType.Unbreaking, 3)
            }.ToEnchantedBook();
        combination.Assert(
            4,
            ItemType.Pickaxe,
            new Enchantment(EnchantmentType.Fortune, 3),
            new Enchantment(EnchantmentType.Unbreaking, 3));
    }

    public void hasEnchantmentsIncompatibleWithTargetEnchantments2()
    {
        var combination = ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 4) }) +
            new List<Enchantment>
            {
                new(EnchantmentType.Unbreaking, 2),
                new(EnchantmentType.BlastProtection, 3)
            }.ToEnchantedBook();
        combination.Assert(
            3,
            ItemType.Chestplate,
            new Enchantment(EnchantmentType.Protection, 4),
            new Enchantment(EnchantmentType.Unbreaking, 2));
    }

    public void hasUpgradableDuplicate1()
    {
        var combination = ItemType.Chestplate.ToNewItem(
            new List<Enchantment> { new(EnchantmentType.Protection, 2) }) + 
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 3) });
        combination.Assert(
            3,
            ItemType.Chestplate,
            new Enchantment(EnchantmentType.Protection, 3));
    }

    public void hasUpgradableDuplicate2()
    {
        var combination = ItemType.Chestplate.ToNewItem(
            new List<Enchantment> { new Enchantment(EnchantmentType.Protection, 2), new Enchantment(EnchantmentType.Unbreaking, 3) }) + 
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new Enchantment(EnchantmentType.Mending), new Enchantment
            (EnchantmentType.Protection, 3) });
            
        combination.Assert(
            7,
            ItemType.Chestplate,
            new Enchantment(EnchantmentType.Mending),
            new Enchantment(EnchantmentType.Protection, 3),
            new Enchantment(EnchantmentType.Unbreaking, 3));
    }

    public void hasUpgradableDuplicate3()
    {
        var combination = ItemType.Chestplate.ToNewItem(
            new List<Enchantment> { new(EnchantmentType.Protection, 3) }) +
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 3) });
        combination.Assert(
            4,
            ItemType.Chestplate,
            new Enchantment(EnchantmentType.Protection, 4));
    }

    public void hasUpgradableDuplicate4()
    {
        var combination = ItemType.Chestplate.ToNewItem(
            new List<Enchantment> { new(EnchantmentType.Protection, 3) }) +
            new List<Enchantment>
            {
               new(EnchantmentType.Protection, 3)
            }.ToEnchantedBook();

        combination.Assert(
            4,
            ItemType.Chestplate,
            new Enchantment(EnchantmentType.Protection, 4));
    }

    public void hasUpgradableDuplicate5()
    {
        var combination = ItemType.Chestplate.ToNewItem(
            new List<Enchantment> { new Enchantment(EnchantmentType.Protection, 3), new Enchantment(EnchantmentType.Unbreaking, 3) }) +

            new List<Enchantment>
            {
               new(EnchantmentType.Mending),
               new(EnchantmentType.Protection, 3)
            }.ToEnchantedBook();

        combination.Assert(
            6,
            ItemType.Chestplate,
            new Enchantment(EnchantmentType.Mending),
            new Enchantment(EnchantmentType.Protection, 4),
            new Enchantment(EnchantmentType.Unbreaking, 3));
    }

    public void onlyHasNonUpgradableDuplicate1()
    {
        UnitTestExtensions.Assert<NoCompatibleEnchantmentsException>(() =>
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 4) }) +
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 4) }));


    }

    public void onlyHasNonUpgradableDuplicate2()
    {
        UnitTestExtensions.Assert<NoCompatibleEnchantmentsException>(() =>
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 4), new(EnchantmentType.Unbreaking, 3) })  +
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 4) }));

    }

    
}
