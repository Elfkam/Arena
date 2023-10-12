using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPHeart : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        CheckDespawn();
    }

    private void CheckDespawn(){
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if(distance > 20f){
            Destroy(gameObject);
        }
    }
}
