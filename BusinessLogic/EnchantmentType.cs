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

    public static readonly EnchantmentType BaneOfArthropods =
        new(
            FriendlyName: "Bane of Arthropods",
            AbbreviatedName: "BoA",
            MaxLevel: 5,
            ItemMultiplier: 2,
            BookMultiplier: 1);

    public static readonly EnchantmentType BlastProtection =
        new(
            FriendlyName: "Blast Protection",
            AbbreviatedName: "BP",
            MaxLevel: 4,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Channeling =
        new(
            FriendlyName: "Channeling",
            AbbreviatedName: "Ch",
            MaxLevel: 1,
            ItemMultiplier: 8,
            BookMultiplier: 4);

    public static readonly EnchantmentType CurseOfBinding =
        new(
            FriendlyName: "Curse of Binding",
            AbbreviatedName: "CoB",
            MaxLevel: 1,
            ItemMultiplier: 8,
            BookMultiplier: 4);

    public static readonly EnchantmentType CurseOfVanishing =
        new(
            FriendlyName: "Curse of Vanishing",
            AbbreviatedName: "CoV",
            MaxLevel: 1,
            ItemMultiplier: 8,
            BookMultiplier: 4);

    public static readonly EnchantmentType DepthStrider =
        new(
            FriendlyName: "Depth Strider",
            AbbreviatedName: "DS",
            MaxLevel: 3,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Efficiency =
        new(
            FriendlyName: "Efficiency",
            AbbreviatedName: "Ef",
            MaxLevel: 5,
            ItemMultiplier: 1,
            BookMultiplier: 1);

    public static readonly EnchantmentType FeatherFalling =
        new(
            FriendlyName: "Feather Falling",
            AbbreviatedName: "FF",
            MaxLevel: 4,
            ItemMultiplier: 2,
            BookMultiplier: 1);

    public static readonly EnchantmentType FireAspect =
        new(
            FriendlyName: "Fire Aspect",
            AbbreviatedName: "FA",
            MaxLevel: 2,
            ItemMultiplier: 2,
            BookMultiplier: 2);

    public static readonly EnchantmentType FireProtection =
        new(
            FriendlyName: "Fire Protection",
            AbbreviatedName: "FP",
            MaxLevel: 4,
            ItemMultiplier: 2,
            BookMultiplier: 1);

    public static readonly EnchantmentType Flame =
        new(
            FriendlyName: "Flame",
            AbbreviatedName: "Fl",
            MaxLevel: 1,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Fortune =
        new(
            FriendlyName: "Fortune",
            AbbreviatedName: "Fo",
            MaxLevel: 3,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType FrostWalker =
        new(
            FriendlyName: "Frost Walker",
            AbbreviatedName: "FW",
            MaxLevel: 2,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Impaling =
        new(
            FriendlyName: "Impaling",
            AbbreviatedName: "Im",
            MaxLevel: 5,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Infinity =
        new(
            FriendlyName: "Infinity",
            AbbreviatedName: "In",
            MaxLevel: 1,
            ItemMultiplier: 8,
            BookMultiplier: 4);

    public static readonly EnchantmentType Knockback =
        new(
            FriendlyName: "Knockback",
            AbbreviatedName: "Kn",
            MaxLevel: 2,
            ItemMultiplier: 2,
            BookMultiplier: 1);

    public static readonly EnchantmentType Looting =
        new(
            FriendlyName: "Looting",
            AbbreviatedName: "Loo",
            MaxLevel: 3,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Loyalty =
        new(
            FriendlyName: "Loyalty",
            AbbreviatedName: "Loy",
            MaxLevel: 3,
            ItemMultiplier: 1,
            BookMultiplier: 1);

    public static readonly EnchantmentType LuckOfTheSea =
        new(
            FriendlyName: "Luck of the Sea",
            AbbreviatedName: "LotS",
            MaxLevel: 3,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Lure =
        new(
            FriendlyName: "Lure",
            AbbreviatedName: "Lu",
            MaxLevel: 3,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Mending =
        new(
            FriendlyName: "Mending",
            AbbreviatedName: "Me",
            MaxLevel: 1,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Multishot =
        new(
            FriendlyName: "Multishot",
            AbbreviatedName: "Mu",
            MaxLevel: 1,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Piercing =
        new(
            FriendlyName: "Piercing",
            AbbreviatedName: "Pi",
            MaxLevel: 4,
            ItemMultiplier: 1,
            BookMultiplier: 1);

    public static readonly EnchantmentType Power =
        new(
            FriendlyName: "Power",
            AbbreviatedName: "Po",
            MaxLevel: 5,
            ItemMultiplier: 1,
            BookMultiplier: 1);

    public static readonly EnchantmentType ProjectileProtection =
        new(
            FriendlyName: "Projectile Protection",
            AbbreviatedName: "PP",
            MaxLevel: 4,
            ItemMultiplier: 2,
            BookMultiplier: 1);

    public static readonly EnchantmentType Protection =
        new(
            FriendlyName: "Protection",
            AbbreviatedName: "Pr",
            MaxLevel: 4,
            ItemMultiplier: 1,
            BookMultiplier: 1);

    public static readonly EnchantmentType Punch =
        new(
            FriendlyName: "Punch",
            AbbreviatedName: "Pu",
            MaxLevel: 2,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType QuickCharge =
        new(
            FriendlyName: "Quick Charge",
            AbbreviatedName: "QC",
            MaxLevel: 3,
            ItemMultiplier: 2,
            BookMultiplier: 1);

    public static readonly EnchantmentType Respiration =
        new(
            FriendlyName: "Respiration",
            AbbreviatedName: "Re",
            MaxLevel: 3,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Riptide =
        new(
            FriendlyName: "Riptide",
            AbbreviatedName: "Ri",
            MaxLevel: 3,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType Sharpness =
        new(
            FriendlyName: "Sharpness",
            AbbreviatedName: "Sh",
            MaxLevel: 5,
            ItemMultiplier: 1,
            BookMultiplier: 1);

    public static readonly EnchantmentType SilkTouch =
        new(
            FriendlyName: "Silk Touch",
            AbbreviatedName: "ST",
            MaxLevel: 1,
            ItemMultiplier: 8,
            BookMultiplier: 4);

    public static readonly EnchantmentType Smite =
        new(
            FriendlyName: "Smite",
            AbbreviatedName: "Sm",
            MaxLevel: 5,
            ItemMultiplier: 2,
            BookMultiplier: 1);

    public static readonly EnchantmentType SoulSpeed =
        new(
            FriendlyName: "Soul Speed",
            AbbreviatedName: "SSp",
            MaxLevel: 3,
            ItemMultiplier: 8,
            BookMultiplier: 4);

    public static readonly EnchantmentType SweepingEdge =
        new(
            FriendlyName: "Sweeping Edge",
            AbbreviatedName: "SE",
            MaxLevel: 3,
            ItemMultiplier: 4,
            BookMultiplier: 2);

    public static readonly EnchantmentType SwiftSneak =
        new(
            FriendlyName: "Swift Sneak",
            AbbreviatedName: "SSn",
            MaxLevel: 3,
            ItemMultiplier: 8,
            BookMultiplier: 4);

    public static readonly EnchantmentType Thorns =
        new(
            FriendlyName: "Thorns",
            AbbreviatedName: "Th",
            MaxLevel: 3,
            ItemMultiplier: 8,
            BookMultiplier: 4);

    public static readonly EnchantmentType Unbreaking =
        new(
            FriendlyName: "Unbreaking",
            AbbreviatedName: "Un",
            MaxLevel: 3,
            ItemMultiplier: 2,
            BookMultiplier: 1);

    public static readonly List<EnchantmentType> All = new()
    {
        AquaAffinity,
        BaneOfArthropods,
        BlastProtection,
        Channeling,
        CurseOfBinding,
        CurseOfVanishing,
        DepthStrider,
        Efficiency,
        FeatherFalling,
        FireAspect,
        FireProtection,
        Flame,
        Fortune,
        FrostWalker,
        Impaling,
        Infinity,
        Knockback,
        Looting,
        Loyalty,
        LuckOfTheSea,
        Lure,
        Mending,
        Multishot,
        Piercing,
        Power,
        ProjectileProtection,
        Protection,
        Punch,
        QuickCharge,
        Respiration,
        Riptide,
        Sharpness,
        SilkTouch,
        Smite,
        SoulSpeed,
        SweepingEdge,
        SwiftSneak,
        Thorns,
        Unbreaking
    };

    public List<EnchantmentType> IncompatibleEnchantmentTypes =>
        this == AquaAffinity ? new List<EnchantmentType>() :
        this == BaneOfArthropods ? new List<EnchantmentType> { Sharpness, Smite } :
        this == BlastProtection ? new List<EnchantmentType> { FireProtection, ProjectileProtection, Protection } :
        // TODO: Enumerate the remain incompatible enchantment types
        this == Channeling ? new List<EnchantmentType> {Riptide} :
        this == CurseOfBinding ? new List<EnchantmentType>() :
        this == CurseOfVanishing ? new List<EnchantmentType>() :
        this == DepthStrider ? new List<EnchantmentType> { FrostWalker } :
        this == Efficiency ? new List<EnchantmentType>() :
        this == FeatherFalling ? new List<EnchantmentType>() :
        this == FireAspect ? new List<EnchantmentType>():
        this == FireProtection ? new List<EnchantmentType> {BlastProtection, ProjectileProtection, Protection } :
        this == Flame ? new List<EnchantmentType>() :
        this == Fortune ? new List<EnchantmentType> { SilkTouch } :
        this == FrostWalker ? new List<EnchantmentType> { DepthStrider } :
        this == Impaling ? new List<EnchantmentType>() :
        this == Infinity ? new List<EnchantmentType> { Mending } :
        this == Knockback ? new List<EnchantmentType>() :
        this == Looting ? new List<EnchantmentType>() :
        this == Loyalty ? new List<EnchantmentType> { Riptide } :
        this == LuckOfTheSea ? new List<EnchantmentType>() :
        this == Lure ? new List<EnchantmentType>() :
        this == Mending ? new List<EnchantmentType> { Infinity } :
        this == Multishot ? new List<EnchantmentType> { Piercing } :
        this == Power ? new List<EnchantmentType>() :
        this == ProjectileProtection ? new List<EnchantmentType> { BlastProtection, FireProtection, Protection } :
        this == Protection ? new List<EnchantmentType> { BlastProtection, FireProtection, ProjectileProtection } :
        this == Punch ? new List<EnchantmentType>() :
        this == QuickCharge ? new List<EnchantmentType>() :
        this == Respiration ? new List<EnchantmentType>() :
        this == Riptide ? new List<EnchantmentType> { Channeling, Loyalty } :
        this == Sharpness ? new List<EnchantmentType> { BaneOfArthropods, Smite } :
        this == SilkTouch ? new List<EnchantmentType> { Fortune } :
        this == Smite ? new List<EnchantmentType> { BaneOfArthropods, Sharpness } :
        this == SoulSpeed ? new List<EnchantmentType>() :
        this == SweepingEdge ? new List<EnchantmentType>() :
        this == SwiftSneak ? new List<EnchantmentType>() :
        this == Thorns ? new List<EnchantmentType>() :
        this == Unbreaking ? new List<EnchantmentType>() : throw new AnvilException("Unknown enchantment");

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
