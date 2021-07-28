using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordRotation : MonoBehaviour
{
    [SerializeField]
    private float mydistance = 1.5f;

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
        SetPositionAndRotation();
        HandleAttack();
    }

    private void SetPositionAndRotation()
    {
        Vector2 parentPos = transform.parent.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - parentPos;
        float angleNew = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.SetPositionAndRotation(parentPos + (mydistance * direction.normalized),
            Quaternion.AngleAxis(angleNew, Vector3.forward));
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
