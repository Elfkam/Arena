using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private GameObject player;
    private float distanceFromPlayer = 5f;
    private float timeUntilSpawn = 2f;

    private float currTimeUntilSpawn;

    private int spawnCount;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(spawnEnemy(5, GameAssets.i.UndeadSkeleton));
        currTimeUntilSpawn = timeUntilSpawn;
        spawnCount = 12; // TODO: increase with time
    }

    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    private void SpawnEnemies(){
        currTimeUntilSpawn -= Time.deltaTime;
        if(currTimeUntilSpawn < 0){
            SpawnEnemiesAroundPlayer(spawnCount);
            currTimeUntilSpawn = timeUntilSpawn;
        }
    }    

    private void SpawnEnemyOnce(GameObject enemy, Vector3 pos){
        Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6), 0), Quaternion.identity);
    }

    private void SpawnEnemiesAroundPlayer(int count){
        Vector3 center = player.transform.position;
        for (int i = 0; i < count; i++){
            float ang = i * (360/count);
            Vector3 pos = RandomCircle(center, distanceFromPlayer, ang);
            SpawnEnemyOnce(GameAssets.i.UndeadSkeleton, pos);
        }
    }

    private Vector3 RandomCircle(Vector3 center, float radius, float ang)    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
