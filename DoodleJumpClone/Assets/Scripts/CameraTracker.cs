using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _player.transform.position.y + 1, -10);
    }
}
