using UnityEngine;

public class StartTiles : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0.5f, 0));

        if (transform.position.y < disablePoint.y)
        {
            gameObject.SetActive(false);
        }
    }
}
