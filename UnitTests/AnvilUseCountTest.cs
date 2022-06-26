using BusinessLogic;

namespace UnitTests;

[TestClass]
public class AnvilUseCountTest
{

    [TestMethod] 
    public void AnvilUseCount1()
    {
        var anvilUseCount = 1;
        var cost = anvilUseCount.AnvilUseCountToCost();
        var calculatedAnvilUseCount = cost.CostToAnvilUseCount();
        Assert.IsTrue(anvilUseCount == calculatedAnvilUseCount);
    }
    
    [TestMethod] 
    public void AnvilUseCount2()
    {
        var anvilUseCount = 2;
        var cost = anvilUseCount.AnvilUseCountToCost();
        var calculatedAnvilUseCount = cost.CostToAnvilUseCount();
        Assert.IsTrue(anvilUseCount == calculatedAnvilUseCount);
    }
    
    [TestMethod] 
    public void AnvilUseCount3()
    {
        var anvilUseCount = 3;
        var cost = anvilUseCount.AnvilUseCountToCost();
        var calculatedAnvilUseCount = cost.CostToAnvilUseCount();
        Assert.IsTrue(anvilUseCount == calculatedAnvilUseCount);
    }
    
    [TestMethod] 
    public void AnvilUseCount4()
    {
        var anvilUseCount = 4;
        var cost = anvilUseCount.AnvilUseCountToCost();
        var calculatedAnvilUseCount = cost.CostToAnvilUseCount();
        Assert.IsTrue(anvilUseCount == calculatedAnvilUseCount);
    }
    
}