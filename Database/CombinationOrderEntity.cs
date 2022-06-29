using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessLogic;

namespace Database;

[Table("CombinationOrderEntities")]
public class CombinationOrderEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Combinations { get; set; }
    public string Name { get; set; }
}

public class CombinationEntity
{

    public ItemEntity Target { get; set; }
    public ItemEntity Sacrifice { get; set; }
    public ItemEntity Product { get; set; }
    public int Cost { get; set; }

}

public class ItemEntity
{
    public ItemTypeEntity Type { get; set; }
    public List<EnchantmentEntity> Enchantments { get; set; }
    public int AnvilUseCount { get; set; }
}

public class ItemTypeEntity
{
    public string FriendlyName { get; set; }
}

public class EnchantmentEntity
{
    public EnchantmentTypeEntity Type { get; set; }
    public int Level { get; set; }
}

public class EnchantmentTypeEntity
{
    public string FriendlyName { get; set; }
}