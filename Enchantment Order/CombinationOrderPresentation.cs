using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Extensions;

namespace Enchantment_Order;

public class CombinationOrderPresentation
{
    public int Id { get; set; }
    public List<CombinationPresentation> Combinations { get; set; }
    public string Name { get; set; }
    public ItemPresentation FinalProduct { get; set; }
}

public class CombinationPresentation
{

    public ItemPresentation Target { get; set; }
    public Uri TargetTypeImageUri => Target.Type.ImageUri;
    public string TargetTypeName => Target.Type.FriendlyName;
    public string TargetEnchantmentsString => Target.AbbreviatedEnchantmentsString;
    public ItemPresentation Sacrifice { get; set; }
    public Uri SacrificeTypeImageUri => Sacrifice.Type.ImageUri;
    public string SacrificeTypeName => Sacrifice.Type.FriendlyName;
    public string SacrificeEnchantmentsString => Sacrifice.AbbreviatedEnchantmentsString;
    public ItemPresentation Product { get; set; }
    public int Cost { get; set; }

}

public class ItemPresentation
{
    public ItemTypePresentation Type { get; set; }
    public List<EnchantmentPresentation> Enchantments { get; set; }
    public int AnvilUseCount { get; set; }

    public string EnchantmentsString
    {
        get
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < Enchantments.Count; i++)
            {
                if (i != 0)
                {
                    stringBuilder.Append(", ");
                }
                stringBuilder.Append(Enchantments[i]);
            }
            return stringBuilder.ToString();
        }
    }

    public string AbbreviatedEnchantmentsString
    {
        get
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < Enchantments.Count; i++)
            {
                if (i != 0)
                {
                    stringBuilder.Append(", ");
                }
                stringBuilder.Append(Enchantments[i].AbbreviatedString);
            }
            return stringBuilder.ToString();
        }
    }
}

public class ItemTypePresentation
{
    public string FriendlyName { get; set; }
    public List<EnchantmentTypePresentation> CompatibleEnchantmentTypes { get; set; }
    public List<EnchantmentTypePresentation> DefaultEnchantmentTypes  { get; set; }
    public Uri ImageUri { get; set; }
}

public class EnchantmentPresentation
{
    public EnchantmentTypePresentation Type { get; set; }
    public int Level { get; set; }

    public override string ToString() => $"{Type.FriendlyName} {Level.ToRomanNumerals()}";

    public string String => ToString();

    public string AbbreviatedString => $"{Type.AbbreviatedName} {Level}";

    public string ArabicLevelString => $"{Type.FriendlyName} {Level}";

}

public class EnchantmentTypePresentation
{
    public string FriendlyName { get; set; }
    public string AbbreviatedName { get; set; }
    public int MaxLevel { get; set; }
    public int ItemMultiplier { get; set; }
    public int BookMultiplier { get; set; }
}