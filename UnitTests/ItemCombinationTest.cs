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
    
}