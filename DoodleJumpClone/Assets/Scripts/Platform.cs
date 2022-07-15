using UnityEngine;
using Assets.Extentions;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out Player player))
        {
            if (collision.JumpCondition(player))
            {
                player.DoJump();
            }
        }
    }
}
