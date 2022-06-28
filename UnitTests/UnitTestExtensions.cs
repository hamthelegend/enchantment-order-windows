using BusinessLogic;

namespace UnitTests;

public static class UnitTestExtensions
{
    public static void Assert(
        this Combination combination, 
        int cost, ItemType itemType, 
        params Enchantment[] enchantments)
    {
        Console.WriteLine(combination);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(itemType == combination.Product.Type );
        Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreEquivalent(enchantments, combination.Product.Enchantments);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(cost == combination.Cost);
    }

    public static void Assert<E>(Func<Combination> combinationBlock) where E : Exception
    {
        try
        {
            var combination = combinationBlock();
            Console.WriteLine(combination);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(false);
        }
        catch (Exception e)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(e is E);
        }
    }
}