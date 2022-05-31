using System;
using System.Collections.Generic;

namespace Heist
{
        public class Member
    {
        public string Name {get; set;}
        public int SkillLevel {get; set;}
        public double CourageFactor {get; set;}

        public Member(string name, int skill, double courage)
        {
            Name = name;
            SkillLevel = skill;
            CourageFactor = courage;
        }
        
        public int GetSkillLevel()
        {
            return SkillLevel;
        }

        public override string ToString()
        {
            return @$"
Member name: {Name}
Skill level: {SkillLevel}
Courage Factor: {CourageFactor}";
        }

    }
}