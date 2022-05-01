using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class InputsControl : MonoBehaviour
{
    public UnityEvent<Vector2> Event_Movement;
    //public UnityEvent<> Event_MovementButtons;

    public static InputsControl instance = null;
    
   // private TouchControls m_TouchControls;
    private PCControls m_PCControls;



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
        //m_TouchControls = new TouchControls();
        m_PCControls =  new PCControls();
    }

    private void OnEnable()
    {
       //m_TouchControls.Enable();
       m_PCControls?.Enable();
    }

    private void OnDisable()
    {
       //m_TouchControls?.Disable();
       m_PCControls?.Disable();
    }

    private void Start()
    {
        //m_TouchControls.InGame.TouchInputs.started += ctx => StartTouch(ctx);
        //m_TouchControls.InGame.TouchInputs.canceled += ctx => EndTouch(ctx);
        m_PCControls.InGame.Movement.started += ctx => MovementStarted(ctx);

    }

    private void MovementStarted(InputAction.CallbackContext ctx)
    {
        Event_Movement?.Invoke(ctx.ReadValue<Vector2>());
    }
}
