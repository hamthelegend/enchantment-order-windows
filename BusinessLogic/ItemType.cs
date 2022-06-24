namespace BusinessLogic;

public record ItemType(
    string FriendlyName,
    List<EnchantmentType> CompatibleEnchantmentTypes,
    List<EnchantmentType> DefaultEnchantmentTypes)
{
    public static ItemType EnchantedBook = new(
        FriendlyName: "Enchanted Book",
        CompatibleEnchantmentTypes: EnchantmentType.All,
        DefaultEnchantmentTypes: new List<EnchantmentType>());
    
    // TODO: Encode the remaining item types from the Kotlin file
    // Note: You do not have to encode the fields "itemCategory" and "iconResource"

    public static readonly List<ItemType> All = new()
    {
        EnchantedBook,
        // TODO: Enumerate all the enchantment types here
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