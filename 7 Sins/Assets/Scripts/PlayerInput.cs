using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   [SerializeField] private Hero _hero;
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
}
