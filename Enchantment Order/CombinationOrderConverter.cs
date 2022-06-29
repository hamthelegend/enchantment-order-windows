using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;

namespace Enchantment_Order;

internal static class CombinationOrderConverter
{
    
    internal static CombinationOrderPresentation ToCombinationOrderPresentation(this CombinationOrder combinationOrder) =>
        new()
        {
            Id = combinationOrder.Id,
            Combinations = combinationOrder.Combinations.Select(combination => combination.ToCombinationPresentation()).ToList(),
            Name = combinationOrder.Name
        };

    internal static CombinationOrder ToCombinationOrder(this CombinationOrderPresentation combinationOrderPresentation) =>
        new(
            id: combinationOrderPresentation.Id,
            combinations: combinationOrderPresentation.Combinations.Select(combinationPresentation => combinationPresentation.ToCombination()).ToList(),
            name: combinationOrderPresentation.Name);
    
    internal static List<CombinationOrderPresentation> ToCombinationOrderPresentations(this List<CombinationOrder> combinationOrders) =>
        combinationOrders
            .Select(combinationOrder => combinationOrder.ToCombinationOrderPresentation())
            .ToList();
    
    internal static List<CombinationOrder> ToCombinationOrderPresentations(this List<CombinationOrderPresentation> combinationOrderPresentations) =>
        combinationOrderPresentations
            .Select(combinationOrderPresentation => combinationOrderPresentation.ToCombinationOrder())
            .ToList();

    internal static CombinationPresentation ToCombinationPresentation(this Combination combination) =>
        new()
        {
            Target = combination.Target.ToItemPresentation(),
            Sacrifice = combination.Sacrifice.ToItemPresentation(),
            Product = combination.Product.ToItemPresentation(),
            Cost = combination.Cost
        };

    internal static Combination ToCombination(this CombinationPresentation combinationPresentation) =>
        new(
            Target: combinationPresentation.Target.ToItem(),
            Sacrifice: combinationPresentation.Sacrifice.ToItem(),
            Product: combinationPresentation.Product.ToItem(),
            Cost: combinationPresentation.Cost);
    
    internal static List<CombinationPresentation> ToCombinationPresentations(this List<Combination> combinations) =>
        combinations
            .Select(combination => combination.ToCombinationPresentation())
            .ToList();
    
    internal static List<Combination> ToCombinationPresentations(this List<CombinationPresentation> combinationPresentations) =>
        combinationPresentations
            .Select(combinationPresentation => combinationPresentation.ToCombination())
            .ToList();
    
    internal static ItemPresentation ToItemPresentation(this Item item) =>
        new()
        {
            Type = item.Type.ToItemTypePresentation(),
            Enchantments = item.Enchantments.Select(enchantment => enchantment.ToEnchantmentPresentation()).ToList(),
            AnvilUseCount = item.AnvilUseCount
        };

    internal static Item ToItem(this ItemPresentation itemPresentation) =>
        new(
            Type: itemPresentation.Type.ToItemType(),
            Enchantments: itemPresentation.Enchantments.Select(enchantment => enchantment.ToEnchantment()).ToList(),
            AnvilUseCount: itemPresentation.AnvilUseCount);
    
    internal static List<ItemPresentation> ToItemPresentations(this List<Item> items) =>
        items
            .Select(item => item.ToItemPresentation())
            .ToList();
    
    internal static List<Item> ToItemPresentations(this List<ItemPresentation> itemPresentations) =>
        itemPresentations
            .Select(itemPresentation => itemPresentation.ToItem())
            .ToList();
    
    internal static ItemTypePresentation ToItemTypePresentation(this ItemType itemType) =>
        new()
        {
            FriendlyName = itemType.FriendlyName,
            CompatibleEnchantmentTypes = itemType.CompatibleEnchantmentTypes.ToEnchantmentTypePresentations(),
            DefaultEnchantmentTypes = itemType.DefaultEnchantmentTypes.ToEnchantmentTypePresentations(),
            ImageUri = 
                itemType == ItemType.EnchantedBook ? new Uri("ms-appx:///Assets/book_enchanted.png") : 
                itemType == ItemType.Helmet ? new Uri("ms-appx:///Assets/helmet.png") :
                itemType == ItemType.Chestplate ? new Uri("ms-appx:///Assets/chestplate.png") :
                itemType == ItemType.Leggings ? new Uri("ms-appx:///Assets/leggings.png") :
                itemType == ItemType.Boots ? new Uri("ms-appx:///Assets/boots.png") :
                itemType == ItemType.Elytra ? new Uri("ms-appx:///Assets/elytra.png") :
                itemType == ItemType.Head ? new Uri("ms-appx:///Assets/head.png") :
                itemType == ItemType.Sword ? new Uri("ms-appx:///Assets/sword.png") :
                itemType == ItemType.Axe ? new Uri("ms-appx:///Assets/axe.png") :
                itemType == ItemType.Pickaxe ? new Uri("ms-appx:///Assets/pickaxe.png") :
                itemType == ItemType.Shovel ? new Uri("ms-appx:///Assets/shovel.png") :
                itemType == ItemType.Hoe ? new Uri("ms-appx:///Assets/hoe.png") :
                itemType == ItemType.Bow ? new Uri("ms-appx:///Assets/bow.png") :
                itemType == ItemType.FishingRod ? new Uri("ms-appx:///Assets/fishing_rod.png") :
                itemType == ItemType.Trident ? new Uri("ms-appx:///Assets/trident.png") :
                itemType == ItemType.Crossbow ? new Uri("ms-appx:///Assets/crossbow.png") :
                itemType == ItemType.Shears ? new Uri("ms-appx:///Assets/shears.png") :
                itemType == ItemType.FlintAndSteel ? new Uri("ms-appx:///Assets/flint_and_steel.png") :
                itemType == ItemType.CarrotOnAStick ? new Uri("ms-appx:///Assets/carrot_on_a_stick.png") :
                itemType == ItemType.WarpedFungusOnAStick ? new Uri("ms-appx:///Assets/warped_fungus_on_a_stick.png") :
                new Uri("ms-appx:///Assets/xp.png")
        };

    internal static ItemType ToItemType(this ItemTypePresentation itemTypePresentation) =>
        ItemType.All.First(itemType => itemType.FriendlyName == itemTypePresentation.FriendlyName);
    
    internal static List<ItemTypePresentation> ToItemTypePresentations(this List<ItemType> itemTypes) =>
        itemTypes
            .Select(itemType => itemType.ToItemTypePresentation())
            .ToList();
    
    internal static List<ItemType> ToItemTypePresentations(this List<ItemTypePresentation> itemTypePresentations) =>
        itemTypePresentations
            .Select(itemTypePresentation => itemTypePresentation.ToItemType())
            .ToList();

    internal static EnchantmentPresentation ToEnchantmentPresentation(this Enchantment enchantment) =>
        new()
        {
            Type = enchantment.Type.ToEnchantmentTypePresentation(),
            Level = enchantment.Level
        };

    internal static Enchantment ToEnchantment(this EnchantmentPresentation enchantmentPresentation) =>
        new(
            Type: enchantmentPresentation.Type.ToEnchantmentType(), 
            Level: enchantmentPresentation.Level);
    
    internal static List<EnchantmentPresentation> ToEnchantmentPresentations(this List<Enchantment> enchantments) =>
        enchantments
            .Select(enchantment => enchantment.ToEnchantmentPresentation())
            .ToList();
    
    internal static List<Enchantment> ToEnchantmentPresentations(this List<EnchantmentPresentation> enchantmentPresentations) =>
        enchantmentPresentations
            .Select(enchantmentPresentation => enchantmentPresentation.ToEnchantment())
            .ToList();
    
    internal static EnchantmentTypePresentation ToEnchantmentTypePresentation(this EnchantmentType enchantmentType) =>
        new()
        {
            FriendlyName = enchantmentType.FriendlyName,
            AbbreviatedName = enchantmentType.AbbreviatedName,
            BookMultiplier = enchantmentType.BookMultiplier,
            ItemMultiplier = enchantmentType.ItemMultiplier,
            MaxLevel = enchantmentType.MaxLevel
        };

    internal static EnchantmentType ToEnchantmentType(this EnchantmentTypePresentation enchantmentTypePresentation) =>
        EnchantmentType.All.First(enchantmentType => enchantmentType.FriendlyName == enchantmentTypePresentation.FriendlyName);
    
    internal static List<EnchantmentTypePresentation> ToEnchantmentTypePresentations(this List<EnchantmentType> enchantmentTypes) =>
        enchantmentTypes
            .Select(enchantmentType => enchantmentType.ToEnchantmentTypePresentation())
            .ToList();
    
    internal static List<EnchantmentType> ToEnchantmentTypePresentations(this List<EnchantmentTypePresentation> enchantmentTypePresentations) =>
        enchantmentTypePresentations
            .Select(enchantmentTypePresentation => enchantmentTypePresentation.ToEnchantmentType())
            .ToList();

}
