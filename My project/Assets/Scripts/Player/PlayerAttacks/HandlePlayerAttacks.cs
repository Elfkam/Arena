using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerAttacks : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] arrayEnemies;
    private float timeUntilAttack = 2f;
    private float currTimeUntilAttack;
    void Start()
    {
        currTimeUntilAttack = timeUntilAttack;
    }

    // Update is called once per frame
    void Update()
    {
        arrayEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Attack();
    }

    private void Attack(){
        currTimeUntilAttack -= Time.deltaTime;
        if(currTimeUntilAttack < 0){    
            if(!IsEnemy()) return;
            PlayerChainAttack.Create(transform.position, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 2, 4, 10f);
            //PlayerBasicAttack.Create(transform.position, GameAssets.i.BasicFireBall, 5, PlayerAttacks.TypeSpellElement.Fire, 1f);
            //PlayerBasicAttack.Create(transform.position, GameAssets.i.BasicFrostBall, 3, PlayerAttacks.TypeSpellElement.Frost, 1f);
            //PlayerExplosionAttack.Create(transform.position, GameAssets.i.FireBall, PlayerAttacks.TypeSpellElement.Fire, 3f, GameAssets.i.FireBallExplosion, 10, PlayerAttacks.TypeSpellElement.Fire);
            currTimeUntilAttack = timeUntilAttack;
        }
    }

    private bool IsEnemy(){
        return arrayEnemies.Length > 0;
    }
}
