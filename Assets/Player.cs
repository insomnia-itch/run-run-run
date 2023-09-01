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


    public float buttonTime = 0.5f;
    public float jumpHeight = 5;
    public float cancelRate = 100;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
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
        // transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        // TODO need to somehow do the:
        //  jump higher while button is held down thing
        // if (Input.GetButtonDown("Jump") && isGrounded) {
        //     rb.AddForce(Vector2.up * jumpForce);
        // }
        Jump();
        // if (!isGrounded && rb.velocity.y <= 0)
        // {
        //     rb.gravityScale = 3f;
        // } else {
        //     rb.gravityScale = 1;
        // }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x < runSpeed)
        {
            rb.AddForce(Vector2.right * runSpeed);
        }

        if(jumpCancelled && !isGrounded)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }   
    
    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            // rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
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
