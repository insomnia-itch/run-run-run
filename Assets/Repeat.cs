using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Repeat : MonoBehaviour
{
    public GameObject gameCamera;
    public float parallax;
    private float width, xPosition;
    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float parallaxDistance = gameCamera.transform.position.x * parallax;
        float remainingDistance = gameCamera.transform.position.x * (1 - parallax);

        transform.position = new Vector3(xPosition + parallaxDistance, transform.position.y, transform.position.z);

        if (remainingDistance > xPosition + width)
        {
            xPosition += width;
        }
    }
}
