using HarmonyLib;
using NeosModLoader;

namespace ModNameGoesHere
{
    public class ModNameGoesHere : NeosMod
    {
        public override string Name => "ModNameGoesHere";
        public override string Author => "username";
        public override string Version => "0.0.1";
        public override string Link => "https://github.com/GithubUsername/RepoName/";
	
	[AutoRegisterConfigKey] private static readonly ModConfigurationKey<bool> Enabled = new ModConfigurationKey<bool>("Enabled", "Enable/Disable the Mod", () => true);
	
        public override void OnEngineInit()
        {
	    Config = GetConfiguration();
            Config.Save(true);
            Harmony harmony = new Harmony("net.username.Template");
            harmony.PatchAll();
        }
	
		
        [HarmonyPatch(typeof(class you want to patch), "name of method you want to patch")]
        class ModNameGoesHerePatch
        {
            static bool Prefix()
            {
                if (!Config.GetValue(Enabled)) { return true; }

                return false;
            }
        }
		
        [HarmonyPatch(typeof(class you want to patch), "name of method you want to patch")]
        class ModNameGoesHerePatch
        {
            static void Postfix()
            {
                if (Config.GetValue(Enabled) )
                {
                    node.Up = __instance.Slot.ActiveUserRoot.Slot.Up;
                }
            }
        }
	
        [HarmonyPatch(typeof(class you want to patch), "name of method you want to patch")]
	public class Player_beeType_Patcher
	{
	    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
	    {
		var code = new List<CodeInstruction>(instructions);
		// We'll need to modify code here.
		return code;
            }  
	}
    }
}
