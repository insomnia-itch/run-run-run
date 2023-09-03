using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DestroyObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            StartCoroutine(RestartAfterDeath());
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            // Debug.Log("colliding...");
            // Debug.Log(other.gameObject);
        }
        Destroy(other.gameObject);
    }

    public IEnumerator RestartAfterDeath()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.55f);
        Time.timeScale = 0f;
        SceneManager.LoadSceneAsync(0);
    }
}
