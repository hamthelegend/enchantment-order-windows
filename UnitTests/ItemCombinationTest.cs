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
                           new List<Enchantment> { new(EnchantmentType.Mending) }
                               .ToEnchantedBook();
        combination2.Assert(
            3,
            ItemType.Pickaxe,
            new Enchantment(EnchantmentType.Fortune, 3),
            new Enchantment(EnchantmentType.Mending));
        
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
                new(EnchantmentType.Protection, 4)
            }.ToEnchantedBook());
    }

    [TestMethod]
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

    [TestMethod]
    public void IncompatibleItemTypes1()
    {
        UnitTestExtensions.Assert<IncompatibleItemTypesException>(() =>
            ItemType.Pickaxe.ToNewItem(new List<Enchantment> { new(EnchantmentType.Mending) }) +
            ItemType.Shovel.ToNewItem(new List<Enchantment> { new(EnchantmentType.Fortune, 3) }));
    }

    [TestMethod]
    public void IncompatibleItemTypes2()
    {
        UnitTestExtensions.Assert<IncompatibleItemTypesException>(() =>
            ItemType.EnchantedBook.ToNewItem(new List<Enchantment> { new(EnchantmentType.Mending) }) +
            ItemType.Shovel.ToNewItem(new List<Enchantment> { new(EnchantmentType.Fortune, 3) }));
    }

    [TestMethod]
    public void HasEnchantmentsIncompatibleWithItemType1()
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

    [TestMethod]
    public void HasEnchantmentsIncompatibleWithItemType2()
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
        combination2.Assert(
            7,
            ItemType.Pickaxe,
            new Enchantment(EnchantmentType.Mending),
            new Enchantment(EnchantmentType.Fortune, 3),
            new Enchantment(EnchantmentType.Efficiency, 5));
    }

    [TestMethod]
    public void HasEnchantmentsIncompatibleWithTargetEnchantments1()
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

    [TestMethod]
    public void HasEnchantmentsIncompatibleWithTargetEnchantments2()
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

    [TestMethod]
    public void HasUpgradableDuplicate1()
    {
        var combination = ItemType.Chestplate.ToNewItem(
            new List<Enchantment> { new(EnchantmentType.Protection, 2) }) + 
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 3) });
        combination.Assert(
            3,
            ItemType.Chestplate,
            new Enchantment(EnchantmentType.Protection, 3));
    }

    [TestMethod]
    public void HasUpgradableDuplicate2()
    {
        var combination = ItemType.Chestplate.ToNewItem(
            new List<Enchantment> { new(EnchantmentType.Protection, 2), new(EnchantmentType.Unbreaking, 3) }) + 
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Mending), new(EnchantmentType.Protection, 3) });
            
        combination.Assert(
            7,
            ItemType.Chestplate,
            new Enchantment(EnchantmentType.Mending),
            new Enchantment(EnchantmentType.Protection, 3),
            new Enchantment(EnchantmentType.Unbreaking, 3));
    }

    [TestMethod]
    public void HasUpgradableDuplicate3()
    {
        var combination = ItemType.Chestplate.ToNewItem(
            new List<Enchantment> { new(EnchantmentType.Protection, 3) }) +
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 3) });
        combination.Assert(
            4,
            ItemType.Chestplate,
            new Enchantment(EnchantmentType.Protection, 4));
    }

    [TestMethod]
    public void HasUpgradableDuplicate4()
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

    [TestMethod]
    public void HasUpgradableDuplicate5()
    {
        var combination = ItemType.Chestplate.ToNewItem(
            new List<Enchantment> { new(EnchantmentType.Protection, 3), new(EnchantmentType.Unbreaking, 3) }) +

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

    [TestMethod]
    public void OnlyHasNonUpgradableDuplicate1()
    {
        UnitTestExtensions.Assert<NoCompatibleEnchantmentsException>(() =>
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 4) }) +
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 4) }));


    }

    [TestMethod]
    public void OnlyHasNonUpgradableDuplicate2()
    {
        UnitTestExtensions.Assert<NoCompatibleEnchantmentsException>(() =>
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 4), new(EnchantmentType.Unbreaking, 3) })  +
            ItemType.Chestplate.ToNewItem(new List<Enchantment> { new(EnchantmentType.Protection, 4) }));

    }

    
}
