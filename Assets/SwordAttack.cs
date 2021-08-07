using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private readonly List<GameObject> collidingObjects = new List<GameObject>();
    private readonly int colorFillDelay = 20;

    private int currentColorFillDelay = 0;
    private Material material;

    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
    }

    void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E))
        {
            collidingObjects.Select(o => o.GetComponent<Health>()).Where(h => h != null).ToList()
                .ForEach(h => h.TakeDamage(100));

            ChangeAlpha(1.0f);
            currentColorFillDelay = colorFillDelay;
        }
        else if (currentColorFillDelay-- == 0)
        {
            ChangeAlpha(0.5f);
        }
    }

    void ChangeAlpha(float alphaVal)
    {
        material.SetColor("_Color", new Color(material.color.r, material.color.g, material.color.b, alphaVal));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidingObjects.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidingObjects.Remove(collision.gameObject);
    }
}
