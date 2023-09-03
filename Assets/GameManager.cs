using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float speedMultiplier;
    private float distance;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        distance = 0f;
        speedMultiplier = 1f;
        // player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // distance += Time.deltaTime * speedMultiplier;
        // if (distance % 10 == 0)
        // {
        //     speedMultiplier += 0.5f;
        // }
        // float rs = player.GetComponent<Player>().runSpeed;
        // player.GetComponent<Player>().runSpeed = rs * speedMultiplier;

    }
}
