using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private GameObject player;
    private float distanceFromPlayer = 5f;
    private float timeUntilSpawn = 5f;
    private float currTimeUntilSpawn;
    private int spawnCount;
    public LineRenderer circleRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        currTimeUntilSpawn = timeUntilSpawn;
        spawnCount = 1; // TODO: increase with time

        circleRenderer = transform.GetComponent<LineRenderer>();
    }

    void Update()
    {
        SpawnEnemies();
        DrawCircle();
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
        if(currTimeUntilSpawn < 0){
            SpawnEnemiesAroundPlayer(spawnCount);
            timeUntilSpawn = 100f;
            currTimeUntilSpawn = timeUntilSpawn;
            
        }
    }

    private void DrawCircle()
    {
        circleRenderer.loop = true;  // Cela ferme le cercle
        circleRenderer.positionCount = 100;

        float angle = 0f;
        Vector3 center = player.transform.position;

        for (int i = 0; i < 100; i++)
        {
            float x = center.x + distanceFromPlayer * Mathf.Cos(angle);
            float y = center.y + distanceFromPlayer * Mathf.Sin(angle);

            circleRenderer.SetPosition(i, new Vector3(x, y, 0f));

            angle += 2f * Mathf.PI / 100;
        }
    }

    private void SpawnEnemiesAroundPlayer(int count){
        Vector3 center = player.transform.position;
        for (int i = 0; i < count; i++){
            float ang = i * (360/count);
            Vector3 pos = RandomCircle(center, distanceFromPlayer, ang);
            SpawnUndeadVampire(pos);
        }
    }

    private Vector3 RandomCircle(Vector3 center, float radius, float ang)    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    private void diffTable(){
        // 0s  SpawnUndeadSkeleton
        // 20s pridat SpawnUndeadGhost
        // 40s pridat SpawnUndeadVampire
        // idk vyresit podle sily spellu
    }

    private void SpawnUndeadSkeleton(Vector3 pos){
        BasicEnemy.Create(pos, GameAssets.i.UndeadSkeleton, 10, 2f, 2f, 5, 1); // attackSpeed is based on animations
    } 
    private void SpawnUndeadZombie(Vector3 pos){
        BasicEnemy.Create(pos, GameAssets.i.UndeadZombie, 20, 1.75f, 0.5f, 10, 2);
    }
    private void SpawnUndeadGhost(Vector3 pos){
        CasterEnemy.Create(pos, GameAssets.i.UndeadGhost, 10, 1.75f, 2f, 5, 3f, 3);
    }
    private void SpawnUndeadVampire(Vector3 pos){
        ChargeEnemy.Create(pos, GameAssets.i.UndeadVampire, 20, 1.6f, 1.5f, 10, 3f, 3);
    } 
    private void SpawnUndeadBlackKnight(Vector3 pos){
        ChargeEnemy.Create(pos, GameAssets.i.UndeadBlackKnight, 30, 3f, 2f, 20, 3f, 5);
    } 
}
