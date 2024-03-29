using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float myJumpForce = 10f;
    [SerializeField]
    private float myDirectionForce = 10f;
    [SerializeField]
    private float myMaxVelocity = 10f;

    Rigidbody2D myRigidbody;
    private Dictionary<GameObject, ContactPoint2D> groundContacts
        = new Dictionary<GameObject, ContactPoint2D>();
    private bool hasDoubleJumped = false;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.AddForce(new Vector2(-myDirectionForce, 0), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.AddForce(new Vector2(myDirectionForce, 0), ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        myRigidbody.velocity = new Vector2(
            Mathf.Clamp(myRigidbody.velocity.x, -myMaxVelocity, myMaxVelocity),
            myRigidbody.velocity.y);
    }

    private void Jump()
    {
        if (groundContacts.Any(a => a.Value.normal.y > 0))
        {
            Jump(0);
        }
        else if (groundContacts.Any(a => a.Value.normal.x < 0))
        {
            Jump(-1);
        }
        else if (groundContacts.Any(a => a.Value.normal.x > 0))
        {
            Jump(1);
        }
        else if (!hasDoubleJumped)
        {
            Jump(0);
            hasDoubleJumped = true;
        }
    }

    private void Jump(int xDirection)
    {
        myRigidbody.AddForce(new Vector2(xDirection * myJumpForce, myJumpForce), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContacts.Add(collision.gameObject, collision.GetContact(0));
            hasDoubleJumped = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        groundContacts.Remove(collision.gameObject);
    }
}
