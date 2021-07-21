using UnityEngine;

public class SwordRotation : MonoBehaviour
{
    [SerializeField]
    private float mydistance = 1.5f;

    void Update()
    {
        Vector2 parentPos = transform.parent.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - parentPos;
        float angleNew = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleNew, Vector3.forward);

        transform.position = parentPos + (mydistance * direction.normalized);
    }
}
