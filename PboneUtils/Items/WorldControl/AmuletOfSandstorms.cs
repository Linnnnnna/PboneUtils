﻿using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace PboneUtils.Items.WorldControl
{
    public class AmuletOfSandstorms : PItem
    {
        public override bool AutoloadCondition => PboneUtilsConfig.Instance.WorldControlItemsToggle;

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.autoReuse = false;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(0, 7, 50, 0);
        }

        public override bool UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (Sandstorm.Happening)
                    PboneWorld.StopStandstorm();
                else
                    PboneWorld.StartSandstorm();

                // Same case as amulet of rain syncing, just hope it works
                if (Main.netMode == NetmodeID.MultiplayerClient)
                    NetMessage.SendData(MessageID.WorldData);

                return true;
            }

            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            base.AddRecipes();
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1); // AKA forbidden fragment
            recipe.AddRecipeGroup(PboneUtils.Recipes.AnyAdamantite, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
