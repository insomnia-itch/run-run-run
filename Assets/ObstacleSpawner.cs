using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    private float spawnInterval = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle() {
        Debug.Log("----");
        Debug.Log(obstacles.Length -1);
        Debug.Log("----");
        int rand = UnityEngine.Random.Range(0, obstacles.Length -1);
        GameObject obstacleToSpawn = obstacles[rand];
        Vector3 spawnPosition = new Vector3(transform.position.x, -0.4f, 0);
        Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
    }

    IEnumerator SpawnObstacles() {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
