using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerAttacks : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] arrayEnemies;
    // contains all spells with timers
    private List<SpellsData.SpellInfo> spellBook;

    void Start()
    {
        spellBook = new List<SpellsData.SpellInfo>{};
    }

    // Update is called once per frame
    void Update()
    {
        arrayEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Attack();
    }

    private void Attack(){
        for (int i = 0; i < spellBook.Count; i++)
        {
            spellBook[i].TimeUntilCast -= Time.deltaTime;
            if(spellBook[i].TimeUntilCast < 0){
                if(!IsEnemy()) return;
                spellBook[i].SpawnSpell(transform.position);
                spellBook[i].TimeUntilCast = spellBook[i].CastTime;
            }
        }
    }

    public void AddSpellToSpellBook(string spellName, string removedSpell){
        // remove lower rank of this spell
        for (int i = 0; i < spellBook.Count; i++)
        {
            if(spellBook[i].SpellName == removedSpell){
                spellBook.Remove(spellBook[i]);
                break;
            }
        }
        spellBook.Add(SpellsData.GetSpellInfo(spellName));
    }

    private bool IsEnemy(){
        return arrayEnemies.Length > 0;
    }
}
