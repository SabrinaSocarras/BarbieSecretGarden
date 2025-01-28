using System;
using AtrapaABarbie;

namespace AtrapaABarbie
{
    public class Skill
    {
        public string Name { get; set; }
        public int Cooldown { get; set; }
        public string Description { get; set; } // Nueva propiedad Description
        public bool Used { get; set; } = false;

        public Skill(string name, int cooldown, string description)
        {
            Name = name;
            Cooldown = cooldown;
            Description = description;
        }
    

    }
}