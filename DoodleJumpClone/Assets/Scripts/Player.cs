using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private int _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _xMin;
    [SerializeField] private float _xMax;

    private Rigidbody2D _rigidbody2D;

    public float Height => transform.position.y;

    public event UnityAction Jump;
    public event UnityAction<float> Rotate;
    public event UnityAction Die;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        ResetPlayer();
    }

    private void Update()
    {
        if (_rigidbody2D.velocity.y < -20)
        {
            Die?.Invoke();
        } 

#if UNITY_ANDROID && !UNITY_EDITOR
        float direction = Input.acceleration.x;
#else
        float direction = Input.GetAxis("Horizontal"); 
#endif
        Rotate?.Invoke(direction);
        _rigidbody2D.velocity = new Vector2(direction * _speed, _rigidbody2D.velocity.y);
        ReturnInGameField();
    }

    public void ResetPlayer()
    {
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = _startPosition.position;
    }

    public void DoJump()
    {
        Jump?.Invoke();
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
    }

    private void ReturnInGameField()
    {
        if (transform.position.x > _xMax && _rigidbody2D.velocity.x > 0)
        {
            transform.position = new Vector2(_xMin, transform.position.y);
        }
        else if (transform.position.x < _xMin && _rigidbody2D.velocity.x < 0)
        {
            transform.position = new Vector2(_xMax, transform.position.y);
        }
    }
}
