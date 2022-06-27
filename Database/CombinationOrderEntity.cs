using System.ComponentModel.DataAnnotations.Schema;
using BusinessLogic;

namespace Database;

[Table("CombinationOrderEntities")]
internal class CombinationOrderEntity
{
    public int Id { get; set; }
    public List<Combination> Combinations { get; set; }
    public string Name { get; set; }
}

