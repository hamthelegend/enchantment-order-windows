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
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(combination.Product.Type == itemType);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(combination.Product.Enchantments == enchantments.ToList());
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(combination.Cost == cost);
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