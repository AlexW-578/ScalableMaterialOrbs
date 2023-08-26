using HarmonyLib;
using NeosModLoader;
using FrooxEngine;

namespace ScalableMaterialOrbs
{
    public class ScalableMaterialOrbs : NeosMod
    {
        public override string Name => "ScalableMaterialOrbs";
        public override string Author => "AlexW-578";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/AlexW-578/ScalableMaterialOrbs/";
        private static ModConfiguration Config;
	
	    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<bool> Enabled = new ModConfigurationKey<bool>("Enabled", "Enable/Disable the Mod", () => true);
	
        public override void OnEngineInit()
        {
	        Config = GetConfiguration();
            Config.Save(true);
            Harmony harmony = new Harmony("co.uk.AlexW-578.ScalableMaterialOrbs");
            harmony.PatchAll();
        }
	

		
        // https://harmony.pardeike.net/articles/patching-postfix.html
        [HarmonyPatch(typeof(MaterialOrb), "ConstructMaterialOrb",typeof(IAssetProvider<Material>),typeof(Slot),typeof(float))]
        class ScalableMaterialOrbs_Postfix_Patch
        {
            static void Postfix(Slot slot)
            {
                if (!Config.GetValue(Enabled) )
                {
                    return;
                }
                slot.GetComponent<Grabbable>().Scalable.Value = true;
            }
        }

    }
}
