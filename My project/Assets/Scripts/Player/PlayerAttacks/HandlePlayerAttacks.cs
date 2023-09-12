using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerAttacks : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] arrayEnemies;
    // contains all spells with timers
    private List<SpellInfo> spellBook;

    public class SpellInfo
    {
        public string SpellName { get; set; }
        public float CastTime { get; set; }
        public float TimeUntilCast { get; set; }
    }

    void Start()
    {
        spellBook = new List<SpellInfo>{};
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
                CastSpell(spellBook[i].SpellName);
                spellBook[i].TimeUntilCast = spellBook[i].CastTime;
            }
        }
    }

    public void AddSpellToSpellBook(string spellName){
        spellBook.Add(GetSpellCastTime(spellName));
    }

    private bool IsEnemy(){
        return arrayEnemies.Length > 0;
    }

    private void CastSpell(string spellName){
        switch(spellName){
        case "FireBall_1":
            PlayerBasicAttack.Create(transform.position, GameAssets.i.BasicFireBall, 5, PlayerAttacks.TypeSpellElement.Fire, 1f);
            break;
        case "FrostBall_1":
            PlayerBasicAttack.Create(transform.position, GameAssets.i.BasicFrostBall, 3, PlayerAttacks.TypeSpellElement.Frost, 1f);
            break;
        case "ChainLightning_1":
            PlayerChainAttack.Create(transform.position, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 2, 4, 10f);
            break;
        default:
            break;
        }
        //PlayerChainAttack.Create(transform.position, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 2, 4, 10f);
        //PlayerBasicAttack.Create(transform.position, GameAssets.i.BasicFireBall, 5, PlayerAttacks.TypeSpellElement.Fire, 1f);
        //PlayerBasicAttack.Create(transform.position, GameAssets.i.BasicFrostBall, 3, PlayerAttacks.TypeSpellElement.Frost, 1f);
        //PlayerExplosionAttack.Create(transform.position, GameAssets.i.FireBall, PlayerAttacks.TypeSpellElement.Fire, 3f, GameAssets.i.FireBallExplosion, 10, PlayerAttacks.TypeSpellElement.Fire);
    }

    private SpellInfo GetSpellCastTime(string spellName){
        // TODO: switch na vsechny druhy spellu
        switch(spellName){
        case "FireBall_1":
            return new SpellInfo { SpellName = "FireBall_1", CastTime = 2f,  TimeUntilCast= 2f};
        case "FireBall_2":
            return new SpellInfo { SpellName = "FireBall_2", CastTime = 2f,  TimeUntilCast= 2f};
        case "FireBall_3":
            return new SpellInfo { SpellName = "FireBall_3", CastTime = 2f,  TimeUntilCast= 2f};
        case "FireBall_4":
            return new SpellInfo { SpellName = "FireBall_4", CastTime = 2f,  TimeUntilCast= 2f};
        case "FrostBall_1":
            return new SpellInfo { SpellName = "FrostBall_1", CastTime = 1.5f,  TimeUntilCast= 1.5f};
        case "FrostBall_2":
            return new SpellInfo { SpellName = "FrostBall_2", CastTime = 1.5f,  TimeUntilCast= 1.5f};
        case "FrostBall_3":
            return new SpellInfo { SpellName = "FrostBall_3", CastTime = 1.5f,  TimeUntilCast= 1.5f};
        case "FrostBall_4":
            return new SpellInfo { SpellName = "FrostBall_4", CastTime = 1.5f,  TimeUntilCast= 1.5f};
        case "ChainLightning_1":
            return new SpellInfo { SpellName = "ChainLightning_1", CastTime = 1f,  TimeUntilCast= 1};
        case "ChainLightning_2":
            return new SpellInfo { SpellName = "ChainLightning_2", CastTime = 1f,  TimeUntilCast= 1f};  
        case "ChainLightning_3":
            return new SpellInfo { SpellName = "ChainLightning_3", CastTime = 1f,  TimeUntilCast= 1f};  
        case "ChainLightning_4":
            return new SpellInfo { SpellName = "ChainLightning_4", CastTime = 1f,  TimeUntilCast= 1f};                                              
        default:
            return new SpellInfo { SpellName = "FireBall_1", CastTime = 2f,  TimeUntilCast= 2f};
        }        
    }


}
