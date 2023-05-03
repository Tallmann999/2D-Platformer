using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const string Fire = "Fire1";

    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        MoveControl();
        JumpControl();
        Attack();
    }

    private void MoveControl()
    {
        if (Input.GetAxis(Horizontal) == 0)
        {
            _playerMover.AnimationIdle();
        }
        else
        {
            _playerMover.AnimationRun();
        }
    }

    private void JumpControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMover.AnimationJump();
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown(Fire))
        {
            _playerMover.AnimationAttack();
        }
    }
}
