using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out Player player))
        {
            if (player.transform.position.y - collision.otherCollider.transform.position.y > 0)
            {
                player.DoJump();
            }
        }
    }
}
