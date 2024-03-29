using UnityEngine;

public class SwordRotation : MonoBehaviour
{
    [SerializeField]
    private float mydistance = 1.5f;

    void Update()
    {
        SetPositionAndRotation();
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
}
