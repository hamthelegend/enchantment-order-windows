namespace BusinessLogic;

public record class EnchantmentType(
    string FriendlyName,
    string AbbreviatedName,
    int MaxLevel,
    int ItemMultiplier,
    int BookMultiplier)
{
    public static readonly EnchantmentType AquaAffinity =
        new(
            FriendlyName: "Aqua Affinity",
            AbbreviatedName: "AA",
            MaxLevel: 1,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    // TODO: Encode the remaining enchantment types from the Kotlin file

    public static readonly List<EnchantmentType> All = new()
    {
        AquaAffinity,
        // TODO: Enumerate all the enchantment types here
    };

    public List<EnchantmentType> IncompatibleEnchantmentTypes => new List<EnchantmentType>();

    public bool IsIncompatibleWith(EnchantmentType target)
    {
        var sacrificeEnchantmentType = this;
        return target.IncompatibleEnchantmentTypes.Contains(sacrificeEnchantmentType);
    }

    public bool IsCompatibleWith(EnchantmentType target) => !IsIncompatibleWith(target);

    public bool IsCompatibleWith(ItemType targetItemType)
    {
        var sacrificeEnchantmentType = this;
        return targetItemType.CompatibleEnchantmentTypes.Contains(sacrificeEnchantmentType);
    }

    public bool IsIncompatibleWith(ItemType target) => !IsCompatibleWith(target);

    public bool IsIncompatibleWith(List<EnchantmentType> targetEnchantmentTypes)
    {
        var sacrificeEnchantmentType = this;
        return targetEnchantmentTypes.Any(targetEnchantmentType =>
            sacrificeEnchantmentType.IsIncompatibleWith(targetEnchantmentType));
    }

    public bool IsCompatibleWith(List<EnchantmentType> targetEnchantmentTypes) => !IsIncompatibleWith(targetEnchantmentTypes);

    public int GetMultiplier(ItemType itemType) => itemType == ItemType.EnchantedBook ? BookMultiplier : ItemMultiplier;
}