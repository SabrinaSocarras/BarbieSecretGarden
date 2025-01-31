using System;
using BarbieSecretGarden;

namespace BarbieSecretGarden
{
    public class Skill
    {
        public string Name { get; set; } = null!;
        public int Cooldown { get; set; }
        public string Description { get; set; } = null!;// Nueva propiedad Description
        public bool Used { get; set; } = false;

        public SkillType Type { get; set; }

        public virtual void Execute(Game game) { }

    }
}