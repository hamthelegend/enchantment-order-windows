namespace BusinessLogic;

public record ItemType(
    string FriendlyName,
    List<EnchantmentType> CompatibleEnchantmentTypes,
    List<EnchantmentType> DefaultEnchantmentTypes,
    Uri ImageUri)
{
    public static readonly ItemType EnchantedBook = new(
        FriendlyName: "Enchanted Book",
        CompatibleEnchantmentTypes: EnchantmentType.All,
        DefaultEnchantmentTypes: new List<EnchantmentType>(),
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    // TODO: Change the image URIs to match the actual images under the Assets folder that represent the items

    public static readonly ItemType Helmet = new(
       FriendlyName: "Helmet",
       CompatibleEnchantmentTypes: new List<EnchantmentType>
       {
            EnchantmentType.AquaAffinity,
            EnchantmentType.BlastProtection,
            EnchantmentType.CurseOfBinding,
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.FireProtection,
            EnchantmentType.Mending,
            EnchantmentType.ProjectileProtection,
            EnchantmentType.Protection,
            EnchantmentType.Respiration,
            EnchantmentType.Thorns,
            EnchantmentType.Unbreaking
       },
       DefaultEnchantmentTypes: new List<EnchantmentType>
       {
            EnchantmentType.AquaAffinity,
            EnchantmentType.Mending,
            EnchantmentType.Protection,
            EnchantmentType.Respiration,
            EnchantmentType.Thorns,
            EnchantmentType.Unbreaking
       },
       ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Chestplate = new(
       FriendlyName: "Chestplate",
       CompatibleEnchantmentTypes: new List<EnchantmentType>
       {
            EnchantmentType.BlastProtection,
            EnchantmentType.CurseOfBinding,
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.FireProtection,
            EnchantmentType.Mending,
            EnchantmentType.ProjectileProtection,
            EnchantmentType.Protection,
            EnchantmentType.Thorns,
            EnchantmentType.Unbreaking
       },
       DefaultEnchantmentTypes: new List<EnchantmentType>
       {
            EnchantmentType.Mending,
            EnchantmentType.Protection,
            EnchantmentType.Thorns,
            EnchantmentType.Unbreaking
       },
       ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Leggings = new(
       FriendlyName: "Leggins",
       CompatibleEnchantmentTypes: new List<EnchantmentType>
       {
                EnchantmentType.BlastProtection,
                EnchantmentType.CurseOfBinding,
                EnchantmentType.CurseOfVanishing,
                EnchantmentType.FireProtection,
                EnchantmentType.Mending,
                EnchantmentType.ProjectileProtection,
                EnchantmentType.Protection,
                EnchantmentType.Thorns,
                EnchantmentType.Unbreaking,
                EnchantmentType.SwiftSneak
       },
       DefaultEnchantmentTypes: new List<EnchantmentType>
       {
                EnchantmentType.Mending,
                EnchantmentType.Protection,
                EnchantmentType.SwiftSneak,
                EnchantmentType.Thorns,
                EnchantmentType.Unbreaking
       },
       ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Boots = new(
       FriendlyName: "Boots",
       CompatibleEnchantmentTypes: new List<EnchantmentType>
       {
                EnchantmentType.BlastProtection,
                EnchantmentType.CurseOfBinding,
                EnchantmentType.CurseOfVanishing,
                EnchantmentType.DepthStrider,
                EnchantmentType.FeatherFalling,
                EnchantmentType.FireProtection,
                EnchantmentType.FrostWalker,
                EnchantmentType.Mending,
                EnchantmentType.ProjectileProtection,
                EnchantmentType.Protection,
                EnchantmentType.SoulSpeed,
                EnchantmentType.Thorns,
                EnchantmentType.Unbreaking
       },
       DefaultEnchantmentTypes: new List<EnchantmentType>
       {
                EnchantmentType.DepthStrider,
                EnchantmentType.FeatherFalling,
                EnchantmentType.Mending,
                EnchantmentType.Protection,
                EnchantmentType.SoulSpeed,
                EnchantmentType.Thorns,
                EnchantmentType.Unbreaking
       },
       ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Elytra = new(
       FriendlyName: "Elytra",
       CompatibleEnchantmentTypes: new List<EnchantmentType>
       {
                EnchantmentType.CurseOfBinding,
                EnchantmentType.CurseOfVanishing,
                EnchantmentType.Mending,
                EnchantmentType.Unbreaking
       },
       DefaultEnchantmentTypes: new List<EnchantmentType>
       {
                EnchantmentType.Mending,
                EnchantmentType.Unbreaking
       },
       ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Head = new(
       FriendlyName: "Head",
       CompatibleEnchantmentTypes: new List<EnchantmentType>
       {
                EnchantmentType.CurseOfBinding,
                EnchantmentType.CurseOfVanishing,

       },
   DefaultEnchantmentTypes: new List<EnchantmentType>
       {
                EnchantmentType.CurseOfBinding,
       },
       ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));
    
    public static readonly ItemType Sword = new(
        FriendlyName: "Sword",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.BaneOfArthropods,
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.FireAspect,
            EnchantmentType.Knockback,
            EnchantmentType.Looting,
            EnchantmentType.Mending,
            EnchantmentType.Sharpness,
            EnchantmentType.Smite,
            EnchantmentType.SweepingEdge,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.FireAspect,
            EnchantmentType.Knockback,
            EnchantmentType.Looting,
            EnchantmentType.Mending,
            EnchantmentType.Sharpness,
            EnchantmentType.SweepingEdge,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Axe = new(
        FriendlyName: "Axe",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.BaneOfArthropods,
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.Efficiency,
            EnchantmentType.Fortune,
            EnchantmentType.Mending,
            EnchantmentType.Sharpness,
            EnchantmentType.SilkTouch,
            EnchantmentType.Smite,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Efficiency,
            EnchantmentType.Mending,
            EnchantmentType.Sharpness,
            EnchantmentType.SilkTouch,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Pickaxe = new(
        FriendlyName: "Pickaxe",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
             EnchantmentType.CurseOfVanishing,
             EnchantmentType.Efficiency,
             EnchantmentType.Fortune,
             EnchantmentType.Mending,
             EnchantmentType.SilkTouch,
             EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
             EnchantmentType.Efficiency,
             EnchantmentType.Mending,
             EnchantmentType.SilkTouch,
             EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Shovel = new(
        FriendlyName: "Shovel",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.Efficiency,
            EnchantmentType.Fortune,
            EnchantmentType.Mending,
            EnchantmentType.SilkTouch,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Efficiency,
            EnchantmentType.Mending,
            EnchantmentType.SilkTouch,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Hoe = new(
        FriendlyName: "Hoe",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
             EnchantmentType.CurseOfVanishing,
             EnchantmentType.Efficiency,
             EnchantmentType.Fortune,
             EnchantmentType.Mending,
             EnchantmentType.SilkTouch,
             EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Efficiency,
             EnchantmentType.Mending,
             EnchantmentType.SilkTouch,
             EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Bow = new(
        FriendlyName: "Bow",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.Flame,
            EnchantmentType.Infinity,
            EnchantmentType.Mending,
            EnchantmentType.Power,
            EnchantmentType.Punch,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Flame,
            EnchantmentType.Infinity,
            EnchantmentType.Power,
            EnchantmentType.Punch,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType FishingRod = new(
        FriendlyName: "FishingRod",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.LuckOfTheSea,
            EnchantmentType.Lure,
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.LuckOfTheSea,
            EnchantmentType.Lure,
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Trident = new(
        FriendlyName: "Trident",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Channeling,
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.Impaling,
            EnchantmentType.Loyalty,
            EnchantmentType.Mending,
            EnchantmentType.Riptide,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Channeling,
            EnchantmentType.Impaling,
            EnchantmentType.Loyalty,
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Crossbow = new(
        FriendlyName: "Crossbow",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.Mending,
            EnchantmentType.Multishot,
            EnchantmentType.Piercing,
            EnchantmentType.QuickCharge,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Mending,
            EnchantmentType.Multishot,
            EnchantmentType.QuickCharge,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType Shears = new(
        FriendlyName: "Shears",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.Efficiency,
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Efficiency,
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType FlintAndSteel = new(
        FriendlyName: "FlintAndSteel",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType CarrotOnAStick = new(
        FriendlyName: "CarrotOnAStick",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly ItemType WarpedFungusOnAStick = new(
        FriendlyName: "WarpedFungusOnAStick",
        CompatibleEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.CurseOfVanishing,
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        DefaultEnchantmentTypes: new List<EnchantmentType>
        {
            EnchantmentType.Mending,
            EnchantmentType.Unbreaking
        },
        ImageUri: new Uri("ms-appx:///Assets/book_enchanted.png"));

    public static readonly List<ItemType> All = new()
    {
        EnchantedBook,
        Helmet,
        Chestplate,
        Leggings,
        Boots,
        Elytra,
        Head,
        Sword,
        Axe,
        Pickaxe,
        Shovel,
        Hoe,
        Bow,
        FishingRod,
        Trident,
        Crossbow,
        Shears,
        FlintAndSteel,
        CarrotOnAStick,
        WarpedFungusOnAStick,
    };
    
    public bool IsCompatibleWith(ItemType target)
    {
        var sacrifice = this;
        return target == sacrifice || sacrifice == EnchantedBook;
    }

    public bool IsIncompatibleWith(ItemType target) => !IsCompatibleWith(target);

    public Item SupposedProduct(List<Item> books)
    {
        var item = this.ToNewItem();
        foreach (var book in books)
        {
            var product = (item + book).Product;
            item = product;
        }

        return item;
    }

    public static List<ItemType> Targetable = ItemType.All.Where(item => item != EnchantedBook).ToList();

}
