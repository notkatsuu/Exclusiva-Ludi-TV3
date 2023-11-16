using System.Collections;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float waitTime = 1f;
    private bool movingRight = true;
    private bool movingUp = true;
    private Rigidbody2D rb;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        // Randomly decide whether to move
        if (!isMoving && Random.Range(0, 100) < 5) // 5% chance to move each frame
        {
            StartCoroutine(MoveAndWait());
        }
    }IEnumerator MoveAndWait()
{
    isMoving = true;

    float angle = 30; // Angle in degrees
    float angleRad = angle * Mathf.Deg2Rad; // Convert to radians

    // Calculate move direction
    Vector2 moveDirection = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    if (!movingRight)
    {
        moveDirection.x *= -1; // Flip direction if moving left
    }
    if (!movingUp)
    {
        moveDirection.y *= -1; // Flip direction if moving down
    }

    // Move
    rb.velocity = moveDirection * moveSpeed;

    // Jump
    float jumpForce = 1f; // Adjust this value to change the height of the jump
    StartCoroutine(Jump(jumpForce));

    // Wait while moving
    yield return new WaitForSeconds(waitTime);

    // Stop moving
    rb.velocity = Vector2.zero;

    // Randomly decide whether to flip direction
    if (Random.Range(0, 100) < 50) // 50% chance to flip direction
    {
        Vector3 theScale = transform.localScale;
        movingRight = !movingRight;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    if (Random.Range(0, 100) < 50) // 50% chance to flip direction
    {
        movingUp = !movingUp;
    }

    isMoving = false;
}

IEnumerator Jump(float force)
{
    // Apply upward force
    rb.velocity += new Vector2(0, force);

    // Wait for the sprite to reach the peak of its jump
    yield return new WaitUntil(() => rb.velocity.y <= 0);

    // Apply downward force
    rb.velocity -= new Vector2(0, force);
}



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EdgeCollider2D>() != null)
        {
            // Flip direction when colliding with an EdgeCollider2D
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        movingRight = !movingRight;
        movingUp = !movingUp;

        // Flip the sprite's x-scale and y-scale to mirror it
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
