using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubicArtillery
{
    class Program
    {
        static void Main()
        {
            int storageCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            var bunkers = new Dictionary<string, List<int>>();
            string bunkersPattern = "[a-zA-Z]";
            string weaponsPattern = "\\d+";
            MatchCollection bunkerMatches = Regex.Matches(input, bunkersPattern);
            MatchCollection weaponMatches = Regex.Matches(input, weaponsPattern);
            List<string> bunkerList = new List<string>();
            foreach (Match bunkerMatch in bunkerMatches)
            {
                bunkers.Add(bunkerMatch.Value, new List<int>());
                bunkerList.Add(bunkerMatch.Value);
            }
            foreach (Match weaponMatch in weaponMatches)
            {
                int currentWeapon = int.Parse(weaponMatch.Value);
                if (currentWeapon <= storageCapacity)
                {
                    if (storageCapacity - bunkers[bunkerList[0]].Sum() >= currentWeapon)
                    {
                        bunkers[bunkerList[0]].Add(currentWeapon);
                    }
                }            
            }     
        }
    }
}
