using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, Controls.IPlayerActions, Controls.IUIActions
{
    public event Action AttackEvent;
    public event Action JumpEvent;
    public event Action DashEvent;
    public event Action FireSkillEvent;
    public event Action Skill1Event, Skill2Event, Skill3Event;
    public event Action InteractionEvent;
    public Vector2 AimPosition { get; private set; }
    public float xInput { get; private set; }
    public float yInput { get; private set; }

    public event Action OpenMenuEvent;

    private Controls _controls;

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
            _controls.UI.SetCallbacks(this);
        }

        _controls.Player.Enable();
        _controls.UI.Enable();
    }

    public void SetPlayerInputEnable(bool value)
    {
        if (value)
            _controls.Player.Enable();
        else
            _controls.Player.Disable();
    }

    public void OnXMovement(InputAction.CallbackContext context)
    {
        xInput = context.ReadValue<float>();
    }

    public void OnYMovement(InputAction.CallbackContext context)
    {
        yInput = context.ReadValue<float>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AttackEvent?.Invoke();
        }
    }

    public void OnFireSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FireSkillEvent?.Invoke();
        }
    }

    public void OnSkill1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Skill1Event?.Invoke();
        }
    }

    public void OnSkill2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Skill2Event?.Invoke();
        }
    }

    public void OnSkill3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Skill3Event?.Invoke();
        }
    }


    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InteractionEvent?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpEvent?.Invoke();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DashEvent?.Invoke();
        }
    }


    public void OnOpenUI(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OpenMenuEvent?.Invoke();
        }
    }
}