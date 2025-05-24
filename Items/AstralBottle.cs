using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityEnvironmentBottles.Players;
using CalamityMod;

namespace CalamityEnvironmentBottles.Items
{
    public class AstralBottle : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 71;
            Item.value = Item.sellPrice(copper: 4);
            Item.rare = ItemRarityID.Green;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useTurn = false;
            Item.autoReuse = false;
            Item.consumable = false;
            Item.maxStack = 1;
            Item.UseSound = SoundID.Item4;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var envPlayer = Main.LocalPlayer.GetModPlayer<CalamityEnvironmentPlayer>();
            foreach (TooltipLine line in tooltips)
            {
                if (line.Mod == "Terraria" && line.Name == "ItemName")
                {
                    line.Text = envPlayer.IsAstralEffectActive ? "Astral Bottle (Activated)" : "Astral Bottle";
                }
            }
            tooltips.Add(new TooltipLine(Mod, "Tooltip0", "Contains a piece of Starblight Soot"));
            tooltips.Add(new TooltipLine(Mod, "Tooltip1", "Carrying it in your inventory feels like being in the Astral Infection"));
            tooltips.Add(new TooltipLine(Mod, "Tooltip2", "Right-click to toggle on/off"));
        }

        public override void RightClick(Player player)
        {
            var envPlayer = player.GetModPlayer<CalamityEnvironmentPlayer>();
            envPlayer.IsAstralEffectActive = !envPlayer.IsAstralEffectActive;
        }

        public override bool ConsumeItem(Player player) => false;

        public override bool CanRightClick() => true;

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddCondition(new Condition("In Astral Infection", () => Main.LocalPlayer.Calamity().ZoneAstral));
            recipe.Register();
        }
    }
}