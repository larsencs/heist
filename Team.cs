using System;
using System.Collections.Generic;

namespace Heist
{
        public class Team
    {
        public List<Member> Members {get; set;}
        public int TeamSkill {get; set;}


        public Team(List<Member> members)
        {
            Members = members;
            foreach(Member member in members)
            {
                TeamSkill += member.SkillLevel;
            }

        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public void Description()
        {
            foreach(Member member in Members)
            {
                Console.WriteLine(member);
            }
        }

    }
}