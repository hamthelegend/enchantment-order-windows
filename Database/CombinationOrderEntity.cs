using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessLogic;

namespace Database;

[Table("CombinationOrderEntities")]
internal class CombinationOrderEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    internal List<CombinationEntity> Combinations { get; set; }
    internal string Name { get; set; }
}

internal class CombinationEntity
{

    internal ItemEntity Target { get; set; }
    internal ItemEntity Sacrifice { get; set; }
    internal ItemEntity Product { get; set; }
    internal int Cost { get; set; }

}

internal class ItemEntity
{
    internal ItemTypeEntity Type { get; set; }
    internal List<EnchantmentEntity> Enchantments { get; set; }
    internal int AnvilUseCount { get; set; }
}

internal class ItemTypeEntity
{
    internal string FriendlyName { get; set; }
}

internal class EnchantmentEntity
{
    internal EnchantmentTypeEntity Type { get; set; }
    internal int Level { get; set; }
}

internal class EnchantmentTypeEntity
{
    internal string FriendlyName { get; set; }
}