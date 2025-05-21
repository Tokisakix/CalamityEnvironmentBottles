using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityEnvironmentBottles.Players;
using CalamityMod;

namespace CalamityEnvironmentBottles.Items
{
    public class SunkenBottle : ModItem
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

        public override bool? UseItem(Player player)
        {
            var envPlayer = player.GetModPlayer<CalamityEnvironmentPlayer>();
            envPlayer.IsSunkenEffectActive = !envPlayer.IsSunkenEffectActive;
            Main.NewText(envPlayer.IsSunkenEffectActive ? "Sunken Sea effect activated!" : "Sunken Sea effect deactivated!", 255, 255, 0);
            return true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var envPlayer = Main.LocalPlayer.GetModPlayer<CalamityEnvironmentPlayer>();
            foreach (TooltipLine line in tooltips)
            {
                if (line.Mod == "Terraria" && line.Name == "ItemName")
                {
                    line.Text = envPlayer.IsSunkenEffectActive ? "Sunken Bottle (Activated)" : "Sunken Bottle";
                }
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddCondition(new Condition("In Sunken Sea", () => Main.LocalPlayer.Calamity().ZoneSunkenSea));
            recipe.Register();
        }
    }
}