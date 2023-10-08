using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private GameObject player;
    private float timeUntilHealthIncrease = 0;
    private float timeUntilSpawnCountIncrease = 0;
    private float distanceFromPlayer = 4f;
    // time until the new wave will be spawned
    private float timeUntilSpawn;
    // curr time until the new wave will be spawned
    private float currTimeUntilSpawn;
    // time between spawns
    private float spawnSpeed;
    private int spawnCount;
    private int EnemyHealthBonus;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnSpeed = 3f;
        spawnCount = 5;
        timeUntilSpawn = 1f;
        currTimeUntilSpawn = timeUntilSpawn;
        EnemyHealthBonus = 1;       
    }

    void Update()
    {
        SpawnEnemies();
        IncreaseSpawnCount();
        IncreaseHealthBonus();
    }
    private void SpawnEnemies(){
        currTimeUntilSpawn -= Time.deltaTime;
        if(currTimeUntilSpawn < 0){
            SpawnEnemiesAroundPlayer(spawnCount);
            timeUntilSpawn = spawnSpeed;
            currTimeUntilSpawn = timeUntilSpawn;
        }
    }
    private void SpawnEnemiesAroundPlayer(int count){
        Vector3 center = player.transform.position;
        for (int i = 0; i < count; i++){
            float ang = i * (360/count);
            Vector3 pos = RandomCircle(center, distanceFromPlayer, ang);
            pos.x = pos.x + Random.Range(0, distanceFromPlayer/2);
            pos.y = pos.y + Random.Range(0, distanceFromPlayer/2);
            SpawnRandomEnemy(pos);
            
        }
    }

    private Vector3 RandomCircle(Vector3 center, float radius, float ang)    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    private void SpawnRandomEnemy(Vector3 pos){
        int randomNum = Random.Range(0, 100);
        switch(randomNum){
            case < 50:
                SpawnUndeadSkeleton(pos);
                return;
            case < 80:
                SpawnUndeadZombie(pos);
                return;
            case < 95:
                if(EnemyHealthBonus < 2) SpawnUndeadSkeleton(pos); // TODO: make function for this
                else SpawnUndeadVampire(pos);
                return;
            default:
                if(EnemyHealthBonus < 3) SpawnUndeadSkeleton(pos); // TODO: make function for this
                else SpawnUndeadBlackKnight(pos);
                return;
        }        
    }

    private void IncreaseSpawnCount(){       
        timeUntilSpawnCountIncrease += Time.deltaTime;
        if(timeUntilSpawnCountIncrease > 30 / GameData.GetDiffLevel()){
            timeUntilSpawnCountIncrease = 0;
            spawnCount += 5;
        }        
    }
    private void IncreaseHealthBonus(){
        timeUntilHealthIncrease += Time.deltaTime;    
        if(timeUntilHealthIncrease > 60 / GameData.GetDiffLevel()){
            timeUntilHealthIncrease = 0;
            EnemyHealthBonus += 1;
        }        
    }

    private void SpawnUndeadSkeleton(Vector3 pos){
        BasicEnemy.Create(pos, GameAssets.i.UndeadSkeleton, 5 * EnemyHealthBonus, 2f, 0.8f + 0.25f * (GameData.GetDiffLevel() - 1), 2 * GameData.GetDiffLevel()); // attackSpeed is based on animations
    } 
    private void SpawnUndeadZombie(Vector3 pos){
        BasicEnemy.Create(pos, GameAssets.i.UndeadZombie, 10 * EnemyHealthBonus, 1.75f, 0.8f + 0.25f * (GameData.GetDiffLevel() - 1), 3 * GameData.GetDiffLevel());
    }
    private void SpawnUndeadVampire(Vector3 pos){
        ChargeEnemy.Create(pos, GameAssets.i.UndeadVampire, 10 * EnemyHealthBonus, 1.6f, 0.9f + 0.25f * (GameData.GetDiffLevel() - 1), 3 * GameData.GetDiffLevel(), 3f);
    } 
    private void SpawnUndeadBlackKnight(Vector3 pos){
        ChargeEnemy.Create(pos, GameAssets.i.UndeadBlackKnight, 30 * EnemyHealthBonus, 3f, 1f + 0.25f * (GameData.GetDiffLevel() - 1), 5 * GameData.GetDiffLevel(), 3f);
    } 
    private void SpawnUndeadGhost(Vector3 pos){
        CasterEnemy.Create(pos, GameAssets.i.UndeadGhost, 10 * EnemyHealthBonus, 1.75f, 2f, 5, 3f);
    }
}
