using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spells : MonoBehaviour
{
    // spells to choose from during levelUp (including ranks)
    private List<string> availableSpells;
    // spells the player already knows
    private List<string> learnedSpells;
    private int MAX_RANK_SPELL = 4;

    private void Start()
    {
        availableSpells = SpellsData.GetDefaultSpells();
        learnedSpells = new List<string>();
    }
    public List<string> GetAvailableSpells(){
        return availableSpells;
    }
    public void SetAvailableSpells(List<string> newAvailableSpells){
        availableSpells = newAvailableSpells;
    }

    public List<string> GetLearnedSpells(){
        return learnedSpells;
    }

    public void LearnNewSpell(string newSpellWithoutRank){
        string newSpell = GetSpellWithRank(newSpellWithoutRank);
        // remove rank
        string spellToLearn = newSpell.Substring(0,  newSpell.Length - 1);

        bool spellAdded = false;
        string removedSpell = "";
        // check if player already knows this spell (diffrent rank)
        for (int i = 0; i < learnedSpells.Count; i++)
        {
            string spell = learnedSpells[i]; // FireBall_1
            string spellToCheck = spell.Substring(0,  spell.Length - 1); 

            if(spellToCheck == spellToLearn){
                //remove old one and add spell with bigger rank
                removedSpell = learnedSpells[i]; 
                learnedSpells.Remove(learnedSpells[i]); 
                learnedSpells.Add(newSpell); 
                spellAdded = true;
                break;
            }
        }
        // its new spell 
        if(!spellAdded) learnedSpells.Add(newSpell);

        UpdateAvailableSpells(newSpell);
        transform.GetComponent<HandlePlayerAttacks>().AddSpellToSpellBook(newSpell, removedSpell);
    }

    private void UpdateAvailableSpells(string learnedSpellArg){
        int learnedSpellRank = Int32.Parse(learnedSpellArg[learnedSpellArg.Length - 1].ToString());
        // remove rank
        string learnedSpell = learnedSpellArg.Substring(0,  learnedSpellArg.Length - 1);
        int newRank = learnedSpellRank + 1;
        // remove old spell
        availableSpells.Remove(learnedSpellArg);

        // check if it is already max rank
        if(newRank <= MAX_RANK_SPELL){
            // add new spell with new rank
            availableSpells.Add(learnedSpell + newRank);
        }
    }

    // find in availableSpells spell with this name and return it
    private string GetSpellWithRank(string spell){
        for (int i = 0; i < availableSpells.Count; i++)
        {
            string spellToCheck = availableSpells[i].Substring(0,  availableSpells[i].Length - 2);
            if(spell == spellToCheck){
                return availableSpells[i];
            }
        }
        return "";
    }
}
        

