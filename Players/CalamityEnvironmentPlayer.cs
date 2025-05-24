using Terraria;
using Terraria.ModLoader;

using CalamityMod;
using CalamityMod.Systems;

namespace CalamityEnvironmentBottles.Players
{
    public class CalamityEnvironmentPlayer : ModPlayer
    {
        public bool IsSunkenEffectActive { get; set; } = false;
        public bool IsAstralEffectActive { get; set; } = false;

        public override void PostUpdateMiscEffects()
        {
            UpdateSunkenEffect();
            UpdateAstralEffect();
        }

        void UpdateSunkenEffect()
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

        void UpdateAstralEffect()
        { 
            if (IsAstralEffectActive)
            {
                BiomeTileCounterSystem.AstralTiles = 951;
            }
            else if (BiomeTileCounterSystem.SunkenSeaTiles > 950 && !Main.LocalPlayer.Calamity().ZoneAstral)
            {
                BiomeTileCounterSystem.AstralTiles = 0;
            }
        }
    }
}