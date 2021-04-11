﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PboneUtils.Items.Tools
{
    public class TerraTreasureMagnet : RightClickToggleItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(0, 15, 0, 0);
        }

        public override void UpdateInventory(Player player)
        {
            base.UpdateInventory(player);
            player.GetModPlayer<PbonePlayer>().TerraTreasureMagnet = Enabled;
        }

        public override void AddRecipes()
        {
            base.AddRecipes();
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DeluxeTreasureMagnet>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}