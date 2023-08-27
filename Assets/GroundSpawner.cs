using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject ground1, ground2, ground3;
    public bool hasGround = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            hasGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("should spawn");
            hasGround = false;
        }
    }

    public void SpawnGround() {
        int rand = UnityEngine.Random.Range(0, 3);
        float[] heights = new float[] {-2, -1.4f, -0.5f};
        GameObject[] grounds = new GameObject[] { ground1, ground2, ground3 };
        GameObject randGround = grounds[rand];

        float xOffset = randGround.transform.localScale.x / 2;
        // The distance (in units) I want the jump to be
        xOffset += 5; 
        int currentX = Mathf.FloorToInt(transform.position.x);
        Vector3 spawnPosition = new Vector3(currentX + xOffset, heights[rand], 0);
        Instantiate(randGround, spawnPosition, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGround)
        {
            SpawnGround();
            hasGround = true;
        }   
    }
}
