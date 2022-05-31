using System;
using System.Collections.Generic;

namespace Heist
{
    public class Bank
    {
        public int DifficultyLevel {get; set;}

        public Bank(int diff)
        {
            DifficultyLevel = diff;
        }
    }
}