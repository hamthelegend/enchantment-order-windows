﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Extensions;

namespace Enchantment_Order;

public class CombinationOrderPresentation
{
    public int Id { get; set; }
    public List<CombinationPresentation> Combinations { get; set; }
    public string Name { get; set; }
}

public class CombinationPresentation
{

    public ItemPresentation Target { get; set; }
    public ItemPresentation Sacrifice { get; set; }
    public ItemPresentation Product { get; set; }
    public int Cost { get; set; }

}

public class ItemPresentation
{
    public ItemTypePresentation Type { get; set; }
    public List<EnchantmentPresentation> Enchantments { get; set; }
    public int AnvilUseCount { get; set; }
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