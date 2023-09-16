using UnityEngine.InputSystem;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerInput : MonoBehaviour
{
     private Hero _hero;
    private void Awake()
    {
        _hero = GetComponent<Hero>();
    }
    public void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _hero.SetDirection(direction);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hero.Jump();
            _hero.isJumpButtonPressed = true;
        }
        if (context.canceled)
        {
            _hero.isJumpButtonPressed = false;
        }
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hero.isShootingButtonPressed = true;

            StartCoroutine(_hero.Shoot());
        }
        if (context.canceled)
        {
            _hero.isShootingButtonPressed = false;
        }
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(_hero.Dash());
        }

    }
}

