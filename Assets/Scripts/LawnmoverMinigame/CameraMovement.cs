using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Vector3 cameraPosition;

    void Update()
    {
        cameraPosition = gameObject.transform.position;
        cameraPosition.x = player.transform.position.x;
        cameraPosition.y = player.transform.position.y;
        gameObject.transform.position = cameraPosition;
    }
}
