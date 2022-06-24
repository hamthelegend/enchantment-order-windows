package com.hamthelegend.enchantmentorder.android.domain.model.item

import androidx.annotation.DrawableRes
import com.hamthelegend.enchantmentorder.android.R
import com.hamthelegend.enchantmentorder.android.domain.calculator.plus
import com.hamthelegend.enchantmentorder.android.domain.model.enchantment.EnchantmentType
import com.hamthelegend.enchantmentorder.android.domain.model.enchantment.EnchantmentType.*

enum class ItemType(
    val friendlyName: String,
    val compatibleEnchantmentTypes: Set<EnchantmentType>,
    val defaultEnchantmentTypes: Set<EnchantmentType>,
    val itemCategory: ItemCategory,
    @DrawableRes val iconResource: Int,
) {
    EnchantedBook(
        friendlyName = "Enchanted Book",
        compatibleEnchantmentTypes = EnchantmentType.values().toSet(),
        defaultEnchantmentTypes = setOf(),
        itemCategory = ItemCategory.ENCHANTED_BOOK,
        iconResource = R.drawable.book_enchanted,
    ),
    Helmet(
        friendlyName = "Helmet",
        compatibleEnchantmentTypes = setOf(
            AquaAffinity,
            BlastProtection,
            CurseOfBinding,
            CurseOfVanishing,
            FireProtection,
            Mending,
            ProjectileProtection,
            Protection,
            Respiration,
            Thorns,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            AquaAffinity,
            Mending,
            Protection,
            Respiration,
            Thorns,
            Unbreaking,
        ),
        itemCategory = ItemCategory.WEARABLE,
        iconResource = R.drawable.helmet,
    ),
    Chestplate(
        friendlyName = "Chestplate",
        compatibleEnchantmentTypes = setOf(
            BlastProtection,
            CurseOfBinding,
            CurseOfVanishing,
            FireProtection,
            Mending,
            ProjectileProtection,
            Protection,
            Thorns,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Mending,
            Protection,
            Thorns,
            Unbreaking,
        ),
        itemCategory = ItemCategory.WEARABLE,
        iconResource = R.drawable.chestplate,
    ),
    Leggings(
        friendlyName = "Leggings",
        compatibleEnchantmentTypes = setOf(
            BlastProtection,
            CurseOfBinding,
            CurseOfVanishing,
            FireProtection,
            Mending,
            ProjectileProtection,
            Protection,
            Thorns,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Mending,
            Protection,
            SwiftSneak,
            Thorns,
            Unbreaking,
        ),
        itemCategory = ItemCategory.WEARABLE,
        iconResource = R.drawable.leggings,
    ),
    Boots(
        friendlyName = "Boots",
        compatibleEnchantmentTypes = setOf(
            BlastProtection,
            CurseOfBinding,
            CurseOfVanishing,
            DepthStrider,
            FeatherFalling,
            FireProtection,
            FrostWalker,
            Mending,
            ProjectileProtection,
            Protection,
            SoulSpeed,
            Thorns,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            DepthStrider,
            FeatherFalling,
            Mending,
            Protection,
            SoulSpeed,
            Thorns,
            Unbreaking,
        ),
        itemCategory = ItemCategory.WEARABLE,
        iconResource = R.drawable.boots,
    ),
    Elytra(
        friendlyName = "Elytra",
        compatibleEnchantmentTypes = setOf(
            CurseOfBinding,
            CurseOfVanishing,
            Mending,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Mending,
            Unbreaking,
        ),
        itemCategory = ItemCategory.WEARABLE,
        iconResource = R.drawable.elytra,
    ),
    Head(
        friendlyName = "Head",
        compatibleEnchantmentTypes = setOf(
            CurseOfBinding,
            CurseOfVanishing,
        ),
        defaultEnchantmentTypes = setOf(
            CurseOfBinding,
        ),
        itemCategory = ItemCategory.WEARABLE,
        iconResource = R.drawable.head,
    ),
    Sword(
        friendlyName = "Sword",
        compatibleEnchantmentTypes = setOf(
            BaneOfArthropods,
            CurseOfVanishing,
            FireAspect,
            Knockback,
            Looting,
            Mending,
            Sharpness,
            Smite,
            SweepingEdge,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            FireAspect,
            Knockback,
            Looting,
            Mending,
            Sharpness,
            SweepingEdge,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.sword,
    ),
    Axe(
        friendlyName = "Axe",
        compatibleEnchantmentTypes = setOf(
            BaneOfArthropods,
            CurseOfVanishing,
            Efficiency,
            Fortune,
            Mending,
            Sharpness,
            SilkTouch,
            Smite,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Efficiency,
            Mending,
            Sharpness,
            SilkTouch,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.axe,
    ),
    Pickaxe(
        friendlyName = "Pickaxe",
        compatibleEnchantmentTypes = setOf(
            CurseOfVanishing,
            Efficiency,
            Fortune,
            Mending,
            SilkTouch,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Efficiency,
            Mending,
            SilkTouch,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.pickaxe,
    ),
    Shovel(
        friendlyName = "Shovel",
        compatibleEnchantmentTypes = setOf(
            CurseOfVanishing,
            Efficiency,
            Fortune,
            Mending,
            SilkTouch,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Efficiency,
            Mending,
            SilkTouch,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.shovel,
    ),
    Hoe(
        friendlyName = "Hoe",
        compatibleEnchantmentTypes = setOf(
            CurseOfVanishing,
            Efficiency,
            Fortune,
            Mending,
            SilkTouch,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Efficiency,
            Mending,
            SilkTouch,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.hoe,
    ),
    Bow(
        friendlyName = "Bow",
        compatibleEnchantmentTypes = setOf(
            CurseOfVanishing,
            Flame,
            Infinity,
            Mending,
            Power,
            Punch,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Flame,
            Infinity,
            Power,
            Punch,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.bow,
    ),
    FishingRod(
        friendlyName = "Fishing Rod",
        compatibleEnchantmentTypes = setOf(
            CurseOfVanishing,
            LuckOfTheSea,
            Lure,
            Mending,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            LuckOfTheSea,
            Lure,
            Mending,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.fishing_rod,
    ),
    Trident(
        friendlyName = "Trident",
        compatibleEnchantmentTypes = setOf(
            Channeling,
            CurseOfVanishing,
            Impaling,
            Loyalty,
            Mending,
            Riptide,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Channeling,
            Impaling,
            Loyalty,
            Mending,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.trident,
    ),
    Crossbow(
        friendlyName = "Crossbow",
        compatibleEnchantmentTypes = setOf(
            CurseOfVanishing,
            Mending,
            Multishot,
            Piercing,
            QuickCharge,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Mending,
            Multishot,
            QuickCharge,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.crossbow,
    ),
    Shears(
        friendlyName = "Shears",
        compatibleEnchantmentTypes = setOf(
            CurseOfVanishing,
            Efficiency,
            Mending,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Efficiency,
            Mending,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.shears,
    ),
    FlintAndSteel(
        friendlyName = "Flint and Steel",
        compatibleEnchantmentTypes = setOf(
            CurseOfVanishing,
            Mending,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Mending,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.flint_and_steel,
    ),
    CarrotOnAStick(
        friendlyName = "Carrot on a Stick",
        compatibleEnchantmentTypes = setOf(
            CurseOfVanishing,
            Mending,
            Unbreaking,
        ),
        defaultEnchantmentTypes = setOf(
            Mending,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.carrot_on_a_stick,
    ),
    WarpedFungusOnAStick(
        friendlyName = "Warped Fungus on a Stick",
        compatibleEnchantmentTypes = setOf(
            CurseOfVanishing,
            Mending,
            Unbreaking
        ),
        defaultEnchantmentTypes = setOf(
            Mending,
            Unbreaking,
        ),
        itemCategory = ItemCategory.TOOL,
        iconResource = R.drawable.warped_fungus_on_a_stick,
    ),
    ;

    infix fun isCompatibleWith(target: ItemType): Boolean {
        val sacrifice = this
        return target == sacrifice || sacrifice == EnchantedBook
    }

    infix fun isIncompatibleWith(target: ItemType) = !isCompatibleWith(target)

    fun supposedProduct(books: List<Item>): Item {
        var item = new(this)
        for (book in books) {
            val product = (item + book).product
            item = product
        }
        return item
    }

}

val targetableItemTypes = ItemType.values().filter {
    (it.itemCategory == ItemCategory.TOOL || it.itemCategory == ItemCategory.WEARABLE)
}