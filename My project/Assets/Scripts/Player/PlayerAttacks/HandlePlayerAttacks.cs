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
       // Attack();
    }

    private void Attack(){
        currTimeUntilAttack -= Time.deltaTime;
        if(currTimeUntilAttack < 0){    
            if(!IsEnemy()) return;        
            Instantiate(GameAssets.i.BasicPlayerAttack, transform.position, Quaternion.identity);
            currTimeUntilAttack = timeUntilAttack;
        }
    }

    private bool IsEnemy(){
        return arrayEnemies.Length > 0;
    }
}
