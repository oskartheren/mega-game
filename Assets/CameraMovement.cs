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
        transform.position =  new Vector3(player.transform.position.x, 3, -distance);
    }
}
