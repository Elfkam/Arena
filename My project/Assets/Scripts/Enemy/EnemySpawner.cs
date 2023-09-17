using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private GameObject player;
    private float timeFromStart = 0;
    private float distanceFromPlayer = 4f;
    // time until the new wave will be spawned
    private float timeUntilSpawn;
    // curr time until the new wave will be spawned
    private float currTimeUntilSpawn;
    // time between spawns
    private float spawnSpeed;
    private int spawnCount;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnSpeed = 2f;
        spawnCount = 2;
        timeUntilSpawn = 1f;
        currTimeUntilSpawn = timeUntilSpawn;        
    }

    void Update()
    {
        SpawnEnemies();
    }
/*
    StartCoroutine(spawnEnemy(5, GameAssets.i.UndeadSkeleton));
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
*/
    private void SpawnEnemies(){
        currTimeUntilSpawn -= Time.deltaTime;
        timeFromStart += Time.deltaTime;

        if(currTimeUntilSpawn < 0){
            SpawnEnemiesAroundPlayer(spawnCount);
            timeUntilSpawn = spawnSpeed;
            currTimeUntilSpawn = timeUntilSpawn;
           // increaseDifficulty();            
        }
    }
    private void SpawnEnemiesAroundPlayer(int count){
        Vector3 center = player.transform.position;
        for (int i = 0; i < count; i++){
            float ang = i * (360/count);
            Vector3 pos = RandomCircle(center, distanceFromPlayer, ang);
            pos.x = pos.x + Random.Range(-distanceFromPlayer/2, distanceFromPlayer/2);
            pos.y = pos.y + Random.Range(-distanceFromPlayer/2, distanceFromPlayer/2);
            SpawnEnemyAccordingToTime(pos);
            
        }
    }

    private Vector3 RandomCircle(Vector3 center, float radius, float ang)    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    private void SpawnEnemyAccordingToTime(Vector3 pos){
        SpawnUndeadSkeleton(pos);
    }

    private void increaseDifficulty(){        
        if(timeFromStart > 60){
            timeFromStart = 0;
            spawnCount += 10;
            spawnSpeed -= 0.5f;
        }
    }

    private void SpawnUndeadSkeleton(Vector3 pos){
        BasicEnemy.Create(pos, GameAssets.i.UndeadSkeleton, 50, 2f, 1f, 2, 1); // attackSpeed is based on animations
    } 
    private void SpawnUndeadZombie(Vector3 pos){
        BasicEnemy.Create(pos, GameAssets.i.UndeadZombie, 10, 1.75f, 1f, 3, 1);
    }
    private void SpawnUndeadGhost(Vector3 pos){
        CasterEnemy.Create(pos, GameAssets.i.UndeadGhost, 10, 1.75f, 2f, 5, 3f, 3);
    }
    private void SpawnUndeadVampire(Vector3 pos){
        ChargeEnemy.Create(pos, GameAssets.i.UndeadVampire, 10, 1.6f, 1.5f, 3, 3f, 1);
    } 
    private void SpawnUndeadBlackKnight(Vector3 pos){
        ChargeEnemy.Create(pos, GameAssets.i.UndeadBlackKnight, 30, 3f, 1.5f, 5, 3f, 1);
    } 
}
