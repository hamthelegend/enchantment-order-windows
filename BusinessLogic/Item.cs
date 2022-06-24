namespace BusinessLogic;

public record Item(
    ItemType Type,
    List<Enchantment> Enchantments,
    int AnvilUseCount = 0)
{
    public override string ToString()
    {
        return $"{Type.FriendlyName}: {Enchantments}";
    }

    public static Combination operator +(Item target, Item sacrifice) => Anvil.Combine(target, sacrifice);

    public void CheckIsCompatibleWith(Item target)
    {
        var sacrifice = this;
        sacrifice.CheckItemTypeCompatibilityWith(target);
        sacrifice.CheckEnchantmentsCompatibleWith(target);
    }

    private void CheckItemTypeCompatibilityWith(Item target)
    {
        var sacrifice = this;
        if (sacrifice.Type.IsIncompatibleWith(target.Type))
        {
            throw new IncompatibleItemTypesException(target.Type, sacrifice.Type);
        }
    }

    private void CheckEnchantmentsCompatibleWith(Item target)
    {
        var sacrifice = this;
        if (sacrifice.HasNoCompatibleEnchantmentsWith(target))
        {
            throw new NoCompatibleEnchantmentsException(target, sacrifice);
        }
    }

    public bool HasCompatibleEnchantmentsWith(Item target)
    {
        
        var sacrifice = this;
        return (from sacrificeEnchantment in sacrifice.Enchantments let sacrificeEnchantmentCompatible = target.Enchantments.All(targetEnchantment => !sacrificeEnchantment.IsIncompatibleWith(targetEnchantment)) where sacrificeEnchantmentCompatible && sacrificeEnchantment.Type.IsCompatibleWith(target.Type) select sacrificeEnchantment).Any();

        // Original non-LINQ
        // var sacrifice = this;
        // foreach (var sacrificeEnchantment in sacrifice.Enchantments)
        // {
        //     var sacrificeEnchantmentCompatible = true;
        //     foreach (var targetEnchantment in target.Enchantments)
        //     {
        //         if (sacrificeEnchantment.IsIncompatibleWith(targetEnchantment))
        //         {
        //             sacrificeEnchantmentCompatible = false;
        //             break;
        //         }
        //     }
        //     
        //     if (sacrificeEnchantmentCompatible &&
        //         sacrificeEnchantment.Type.IsCompatibleWith(target.Type))
        //     {
        //         return true;
        //     }
        // }
    }

    public bool HasNoCompatibleEnchantmentsWith(Item target) => !HasCompatibleEnchantmentsWith(target);
    
}