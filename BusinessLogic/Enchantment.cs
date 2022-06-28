using Extensions;

namespace BusinessLogic;

public record Enchantment(
    EnchantmentType Type,
    int Level = 1)
{
    
    public override string ToString() => $"{Type.FriendlyName} {Level.ToRomanNumerals()}";

    public string ToAbbreviatedString() => $"{Type.AbbreviatedName} {Level}";

    public string ToArabicLevelString() => $"{Type.FriendlyName} {Level}";

    public Enchantment UpgradeBy(int level) => UpgradeTo(Level + level);

    public Enchantment UpgradeTo(int level) => new Enchantment(Type, level);

    public bool IsCompatibleWith(Enchantment target)
    {
        var sacrifice = this;
        bool compatible;
        
        if (sacrifice.Type == target.Type)
        {
            if (sacrifice.Level < target.Level) compatible = false;
            else if (sacrifice.Level == target.Level &&
                     sacrifice.Level >= sacrifice.Type.MaxLevel) compatible = false;
            else compatible = true;
        }
        else
        {
            compatible = sacrifice.Type.IsCompatibleWith(target.Type);
        }

        return compatible;
    }

    public bool IsIncompatibleWith(Enchantment target) => !IsCompatibleWith(target);
    
}