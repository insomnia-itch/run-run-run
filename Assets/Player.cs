using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float runSpeed;
    public float jumpForce;
    private bool isGrounded;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        // TODO need to somehow do the:
        //  jump higher while button is held down thing
        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (!isGrounded && rb.velocity.y <= 0)
        {
            rb.gravityScale = 3f;
        } else {
            rb.gravityScale = 1;
        }
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        } else if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Destroyer")) {
            StartCoroutine(RestartAfterDeath());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }    
    }
    
    public IEnumerator RestartAfterDeath()
    {
        anim.SetTrigger("Death");
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(0.55f);
        Time.timeScale = 0f;
        SceneManager.LoadSceneAsync(0);
    }
}
