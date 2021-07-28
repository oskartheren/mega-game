using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordRotation : MonoBehaviour
{
    [SerializeField]
    private float mydistance = 1.5f;

    private readonly List<GameObject> collidingObjects = new List<GameObject>();

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
        }
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
