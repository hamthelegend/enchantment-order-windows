namespace BusinessLogic;

public class AnvilException : ArgumentException
{
    public AnvilException(string message) : base(message) {}
}

public class IncompatibleItemTypesException: AnvilException
{
    public IncompatibleItemTypesException(ItemType target, ItemType sacrifice) :
        base($"You cannot combine a/an {target.FriendlyName} with a/an {sacrifice.FriendlyName}.") {}
}

public class NoCompatibleEnchantmentsException : AnvilException
{
    public NoCompatibleEnchantmentsException(Item target, Item sacrifice) :
        base($"There are no enchantments in {sacrifice} that are compatible with {target}.") {}
}