using Verse;
using HarmonyLib;
using RimWorld;
//you can change this to whatever you want
namespace Runescape
{
    [StaticConstructorOnStartup]
    public static class Patch
    {
        static Patch()
        {
            //you can change the string in this as well (the "Runescape.patches" part)
            Harmony harmony = new Harmony("Runescape.patches");
            harmony.Patch(AccessTools.Method(typeof(EquipmentUtility), "CanEquip", new[] { typeof(Thing), typeof(Pawn), typeof(string).MakeByRefType(), typeof(bool) }), postfix: new HarmonyMethod(typeof(EquipPatch), nameof(EquipPatch.Postfix)));
            Log.Message($"<color=orange>[Runescape]</color> Hello world!");
        }
    }
    
    public static class EquipPatch
    {
        //so this is the code where we actually do stuff...
        // __result is if the pawn can or cant pick something up.
        //thing is the thing the pawn wants to pick up
        //pawn is the pawn
        //and cantReason is.. the reason it cant
        public static void Postfix(ref bool __result, Thing thing, Pawn pawn, ref string cantReason)
        {
            SkillComp comp = thing.TryGetComp<SkillComp>();
            if (comp == null)
                return;

            if (pawn.skills.GetSkill(comp.Props.skillDef).Level < comp.Props.level)
            {
                __result = false;
                cantReason = $"{comp.Props.skillDef.label} is too low. Requires {comp.Props.skillDef.label} level {comp.Props.level}";
            }
        }
    }
}
