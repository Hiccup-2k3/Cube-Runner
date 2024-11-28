using Unity.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public AudioSource aus;
    public AudioClip hitObstacle;
    public float moveMentStep;

    public AudioClip jump;
    Collider m_collider;
    GameController p_gameController;
    Rigidbody2D m_rb;
    bool m_isGrounded = true;
    float xDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        p_gameController = FindObjectOfType<GameController>();
        m_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Moving();
    }

    public void SetTrigger(bool state)
    {
        m_collider.isTrigger = state;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            m_isGrounded=true;
    }

    void Moving()
    {
        Jump();
        MoveLeftOrRight();
    }

    void MoveLeftOrRight()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        float tempStep = moveMentStep * xDir * Time.deltaTime;
        if ((transform.position.x >= -10.58f && xDir > 0) || (transform.position.x <= 10.67f && xDir < 0))
        {
            transform.position += new Vector3(tempStep, 0, 0);
            
        }
    }

    void Jump()
    {
        bool isSpaceBarPressed = Input.GetKeyDown(KeyCode.Space);
        if (isSpaceBarPressed && m_isGrounded)
        {
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGrounded = false;
            if (aus && jump)
                aus.PlayOneShot(jump);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obtacle"))
        {
            aus.PlayOneShot(hitObstacle);
            p_gameController.SetGamePlay(false);
           
        }
    }
}


