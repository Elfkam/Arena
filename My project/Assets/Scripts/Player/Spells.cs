using System;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    private List<string> spells;
    private void Start()
    {
        spells = GetDefaultSpells();
    }
    private List<string> GetDefaultSpells(){
        List<string> defaultS = new List<string> {"Fireball", "Frostball", "ChainLightning", "QuickHands", "FrostLighing", "GlassCannon", "Multicast"};
        return defaultS;
    }

    private void SetButtons(){
        List<string> spellsToButtons = new List<string>();        
        // Get 3 random spells
        for (int i = 0; i < 3; i++)
        {
            if(spells.Count == 0 ) return;
            int index = UnityEngine.Random.Range(0, spells.Count);
            spellsToButtons.Add(spells[index]);
            spells.RemoveAt(index);
        }
        // Put back increased ranks of that spells
        for (int i = 0; i < 3; i++)
        {
            string spell = spells[i];
            char lastChar = spell[spell.Length - 1];
            // selected spell has already rank
            if(Char.IsNumber(lastChar)){
                int rankOfSpell = int.Parse(lastChar.ToString());
                // its not max rank -> increase it
                if(rankOfSpell < 4){
                    string newRank = (rankOfSpell + 1).ToString();
                    string newSpell =  spells[i].Substring(0,  spells[i].Length - 1);
                    spells.Add(newSpell + newRank);
                }
            }else{
                spells.Add(spells[i] + "1");
            }
        }
    }
}
