using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField]
    private float myJumpForce = 10f;
    [SerializeField]
    private float myDirectionForce = 10f;
    [SerializeField]
    private float myMaxVelocity = 10f;

    Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
            myRigidbody.AddForce(new Vector2(0, myJumpForce), ForceMode2D.Impulse);
        }
        myRigidbody.velocity = new Vector2(
            Mathf.Clamp(myRigidbody.velocity.x, -myMaxVelocity, myMaxVelocity),
            myRigidbody.velocity.y);
    }

}
