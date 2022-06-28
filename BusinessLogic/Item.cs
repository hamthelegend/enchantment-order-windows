using System.Text;

namespace BusinessLogic;

public record Item(
    ItemType Type,
    List<Enchantment> Enchantments,
    int AnvilUseCount = 0)
{
    public override string ToString()
    {
        var stringBuilder = new StringBuilder($"{Type.FriendlyName}: [");
        
        for (var i = 0; i < Enchantments.Count; i++)
        {
            if (i != 0)
            {
                stringBuilder.Append($", ");
            }
            stringBuilder.Append(Enchantments[i]);
        }

        stringBuilder.Append(']');

        return stringBuilder.ToString();
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
        foreach (var sacrificeEnchantment in sacrifice.Enchantments)
        {
            var sacrificeEnchantmentCompatible = true;
            foreach (var targetEnchantment in target.Enchantments)
            {
                if (sacrificeEnchantment.IsIncompatibleWith(targetEnchantment))
                {
                    sacrificeEnchantmentCompatible = false;
                    break;
                }
            }
            
            if (sacrificeEnchantmentCompatible &&
                sacrificeEnchantment.Type.IsCompatibleWith(target.Type))
            {
                return true;
            }
        }
        return false;
    }

    public bool HasNoCompatibleEnchantmentsWith(Item target) => !HasCompatibleEnchantmentsWith(target);
    
}