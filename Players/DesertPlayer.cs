using Terraria;
using Terraria.ModLoader;

namespace CalamityEnvironmentBottles.Players
{
    public class DesertPlayer : ModPlayer
    {
        public bool IsDesertEffectActive { get; set; } = false;

        public override void PostUpdateMiscEffects()
        {
            if (IsDesertEffectActive)
            {
                Player.ZoneDesert = true;
            }
        }
    }
}