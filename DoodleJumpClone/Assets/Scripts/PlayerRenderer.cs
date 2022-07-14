using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerRenderer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _player.Jump += OnJump;
        _player.Rotate += OnRotate;
    }

    private void OnDisable()
    {
        _player.Jump -= OnJump;
        _player.Rotate -= OnRotate;
    }

    private void OnJump() 
    {
        _animator.SetTrigger("Jump");
    }

    private void OnRotate(float direction)
    {
        if (direction >= 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }
}
