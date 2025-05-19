using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using CalamityEnvironmentBottles.Players;

namespace CalamityEnvironmentBottles.Items
{
    public class DesertBottle : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Green;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useTurn = true;
            Item.autoReuse = false;
            Item.consumable = false;
            Item.maxStack = 1;
            Item.UseSound = SoundID.Item4;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            var desertPlayer = player.GetModPlayer<DesertPlayer>();
            desertPlayer.IsDesertEffectActive = !desertPlayer.IsDesertEffectActive;
            // Main.NewText(desertPlayer.IsDesertEffectActive ? "Desert environment effect activated!" : "Desert environment effect deactivated!", 255, 255, 0);
            return true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var desertPlayer = Main.LocalPlayer.GetModPlayer<DesertPlayer>();
            foreach (TooltipLine line in tooltips)
            {
                if (line.Mod == "Terraria" && line.Name == "ItemName")
                {
                    line.Text = desertPlayer.IsDesertEffectActive ? "Desert Bottle (Activated)" : "Desert Bottle";
                }
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddCondition(Condition.InDesert);
            recipe.Register();
        }
    }
}