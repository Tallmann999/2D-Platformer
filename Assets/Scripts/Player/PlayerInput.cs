using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{  
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
        const string Horizontal = "Horizontal";

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
        if (Input.GetKeyDown(KeyCode.Space) && _playerMover.IsGrounded && _playerMover.IsMoving)
        {
            _playerMover.AnimationJump();
        }
    }

    private void Attack()
    {
        const string Fire = "Fire1";

        if (Input.GetButtonDown(Fire))
        {
            _playerMover.AnimationAttack();
        }
    }
}
