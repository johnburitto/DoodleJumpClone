using System;
using UnityEngine;

namespace Assets.Extentions
{
    public static class Collision2DExtention
    {
        public static bool JumpCondition(this Collision2D collision, Player player)
        {
            RaycastHit2D hit = Physics2D.Raycast(collision.otherCollider.transform.position, Vector2.up, 0.001f);
            var boxCollider2D = player.gameObject.GetComponent<BoxCollider2D>();
            float shielHeight = boxCollider2D.bounds.size.y / 2;

            return hit.transform.position.y + shielHeight <= player.transform.position.y;
        }
    }
}
