using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private readonly float myDirectionForce = 6f;
    private readonly float myMaxVelocity = 6f;
    private Rigidbody2D myRigidbody;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x - player.transform.position.x > 0)
        {
            myRigidbody.AddForce(new Vector2(-myDirectionForce, 0), ForceMode2D.Force);
        }
        else
        {
            myRigidbody.AddForce(new Vector2(myDirectionForce, 0), ForceMode2D.Force);
        }

        myRigidbody.velocity = new Vector2(
            Mathf.Clamp(myRigidbody.velocity.x, -myMaxVelocity, myMaxVelocity),
            myRigidbody.velocity.y);
    }
}
