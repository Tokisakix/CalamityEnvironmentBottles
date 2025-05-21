using Terraria;
using Terraria.ModLoader;

using CalamityMod;
using CalamityMod.Systems;

namespace CalamityEnvironmentBottles.Players
{
    public class CalamityEnvironmentPlayer : ModPlayer
    {
        public bool IsSunkenEffectActive { get; set; } = false;

        public override void PostUpdateMiscEffects()
        {
            if (IsSunkenEffectActive)
            {
                BiomeTileCounterSystem.SunkenSeaTiles = 151;
            }
            else if (BiomeTileCounterSystem.SunkenSeaTiles > 150 && !Main.LocalPlayer.Calamity().ZoneSunkenSea)
            {
                BiomeTileCounterSystem.SunkenSeaTiles = 0;
            }
        }
    }
}