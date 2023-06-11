using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace SkillRestrictions
{
    public class SkillCompProperties : CompProperties
    {
        public SkillDef skillDef;
        public int level;
    }

    public class SkillComp : ThingComp
    {
        public SkillCompProperties Props
        {
            get
            {
                return props as SkillCompProperties;
            }
        }
    }
}
