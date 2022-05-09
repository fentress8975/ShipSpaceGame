using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class InputsControl : MonoBehaviour
{
    public UnityEvent<Vector2, bool> Event_Movement;
    public UnityEvent<Vector2> Event_MousePosition;

    public static InputsControl instance = null;
    
    private PCControls m_PCControls;
    private Vector2 m_MousePosition;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        m_PCControls =  new PCControls();
    }

    private void OnEnable()
    {
       m_PCControls?.Enable();
    }

    private void OnDisable()
    {
       m_PCControls?.Disable();
    }

    private void Start()
    {
        m_PCControls.InGame.Movement.performed += ctx => MovementStarted(ctx, true);
        m_PCControls.InGame.Movement.canceled += ctx => MovementStarted(ctx, false);
        m_PCControls.InGame.MousePosition.performed += ctx => MousePosition(ctx);

    }

    private void MousePosition(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.ReadValue<Vector2>());
        m_MousePosition = ctx.ReadValue<Vector2>();
        Event_MousePosition?.Invoke(m_MousePosition);
    }

    private void MovementStarted(InputAction.CallbackContext ctx, bool isMoving)
    {
        Debug.Log($"x = {ctx.ReadValue<Vector2>().x}, y = {ctx.ReadValue<Vector2>().y}");
        Event_Movement?.Invoke(ctx.ReadValue<Vector2>(), isMoving);
    }
}
