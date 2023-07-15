using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerAttacks : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] arrayEnemies;    
    private float timeUntilAttack = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arrayEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Attack();
    }

    private void Attack(){
        timeUntilAttack -= Time.deltaTime;
        if(timeUntilAttack < 0){    
            if(!IsEnemy()) return;        
            Instantiate(GameAssets.i.BasicPlayerAttack, transform.position, Quaternion.identity);
            timeUntilAttack = 2f;
        }
    }

    private bool IsEnemy(){
        return arrayEnemies.Length > 0;
    }
}
