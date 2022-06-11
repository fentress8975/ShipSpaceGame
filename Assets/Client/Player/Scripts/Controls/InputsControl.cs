using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class InputsControl : MonoBehaviour
{
    public UnityEvent<Vector2, bool> Event_Movement;
    public UnityEvent<Vector2> Event_MousePosition;
    public UnityEvent<bool> Event_WeaponUse;
    public UnityEvent Event_EngineStabilizationChange;

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
        m_PCControls = new PCControls();
        m_PCControls.Enable();
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

        m_PCControls.InGame.FireWeapon.performed += ctx => WeaponUse(true);
        m_PCControls.InGame.FireWeapon.canceled += ctx => WeaponUse(false);

        m_PCControls.InGame.ChangeStabilization.performed += ctx => EngineStabilizationChange();
    }

    private void MousePosition(InputAction.CallbackContext ctx)
    {
        //Debug.Log(ctx.ReadValue<Vector2>());
        m_MousePosition = ctx.ReadValue<Vector2>();
        Event_MousePosition?.Invoke(m_MousePosition);
    }

    private void MousePosition()
    {
        Event_MousePosition?.Invoke(m_MousePosition);
    }

    private void MovementStarted(InputAction.CallbackContext ctx, bool isMoving)
    {
        //Debug.Log($"x = {ctx.ReadValue<Vector2>().x}, y = {ctx.ReadValue<Vector2>().y}");
        Event_Movement?.Invoke(ctx.ReadValue<Vector2>(), isMoving);
    }

    private void WeaponUse(bool isFiring)
    {
        Event_WeaponUse?.Invoke(isFiring);
    }

    private void EngineStabilizationChange()
    {
        Event_EngineStabilizationChange?.Invoke();
    }
    private void Update()
    {
        MousePosition();
    }
}
