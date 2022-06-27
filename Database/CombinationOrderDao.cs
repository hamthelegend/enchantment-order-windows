using BusinessLogic;

namespace Database;

public static class CombinationOrderDao
{

    public static List<CombinationOrder> GetAll()
    {
        using var context = new CombinationOrderContext();
        return context.CombinationOrderEntities.Select(entity => 
            entity.ToCombinationOrder())
            .ToList();
    }

    public static void Add(CombinationOrder combinationOrder)
    {
        using var context = new CombinationOrderContext();
        context.Add(combinationOrder.ToCombinationOrderEntity());
        context.SaveChanges();
    }

    public static void Update(CombinationOrder combinationOrder)
    {
        using var context = new CombinationOrderContext();
        var entity = context.CombinationOrderEntities.FirstOrDefault(entity => entity.Id == combinationOrder.Id);
        if (entity == null) throw new EntityDoesNotExistException(combinationOrder.Id);
        entity.Combinations = combinationOrder.Combinations;
        entity.Name = combinationOrder.Name;
        context.SaveChanges();
    }

    public static void Remove(CombinationOrder combinationOrder)
    {
        using var context = new CombinationOrderContext();
        var entity = context.CombinationOrderEntities.FirstOrDefault(entity => entity.Id == combinationOrder.Id);
        if (entity == null) throw new EntityDoesNotExistException(combinationOrder.Id);
        context.Remove(entity);
        context.SaveChanges();
    }
    
}