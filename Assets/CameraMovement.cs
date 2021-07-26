using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float distance = 10.0f;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -distance);
    }
}
