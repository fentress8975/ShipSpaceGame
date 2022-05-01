using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputsControl : MonoBehaviour
{
    public UnityEvent<Vector2,bool> Event_MousePosition;
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


    }

    
}
