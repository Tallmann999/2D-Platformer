using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const string Speed = "Speed";
    public const string JumpOne = "Jump";
    public const string Attack = "Attack";

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private Transform _groundCheck;

    private bool _isGrounded;
    private Vector2 _direction;
    private float _rayLength = 0.2f;
    private float _maxMovingValue = 1;
    private float _minMovingValue = 0;

    public bool IsGrounded => _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _rayLength);
        _isGrounded = colliders.Length > 1;
    }

    public void Move()
    {
        _direction.x = Input.GetAxis(Horizontal);
        _rigidbody.velocity = new Vector2(_direction.x * _currentSpeed, _rigidbody.velocity.y);
        FLip();
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpHeight, ForceMode2D.Impulse);
    }

    public void AnimationRun()
    {
        Move();
        _animator.SetFloat(Speed, _maxMovingValue);
    }

    public void AnimationIdle()
    {
        _animator.SetFloat(Speed, _minMovingValue);
    }

    public void AnimationJump()
    {
        if (_isGrounded)
        {
            _animator.SetTrigger(JumpOne);
            Jump();
        }
    }

    private void FLip()
    {
        if (_direction.x < _minMovingValue)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }

    public void AnimationAttack()
    {
        _animator.SetTrigger(Attack);
    }
}
