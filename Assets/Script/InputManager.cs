using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Singleton
    private static InputManager _instance;
    public static InputManager Instance => _instance;

    // References
    private PlayerMotor _playerMotor;
    private PlayerLook _playerLook;

    // Input system
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    public PlayerInput.UIActions onUI;

    // State
    public bool MenuOpenInput { get; private set; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        // Initialize input
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onUI = playerInput.UI;

        // Components
        _playerMotor = GetComponent<PlayerMotor>();
        _playerLook = GetComponent<PlayerLook>();

        // Input Events
        onFoot.Jump.performed += ctx => _playerMotor.Jump();
        onFoot.OpenPause.performed += ctx => TogglePause();
        onUI.ClosePause.performed += ctx => ToggleUnpause();
    }

    private void Start()
    {
        EnableGameplayInputs();
    }

    private void FixedUpdate()
    {
        _playerMotor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        if (!PanelManager.instance.GetIsPanelOpen())
            _playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    public Vector2 GetMouseDelta()
    {
        return onFoot.Look.ReadValue<Vector2>();
    }

    public void TogglePause()
    {
        PanelManager.instance.OpenPausePanel();

        bool isPanelOpen = PanelManager.instance.GetIsPanelOpen();

        if (isPanelOpen)
            EnableUIInputs();
        else
            EnableGameplayInputs();
    }

    private void ToggleUnpause()
    {
        PanelManager.instance.ClosePausePanel();

        bool isPanelOpen = PanelManager.instance.GetIsPanelOpen();
        SaveSystem.Save();

        if (isPanelOpen)
            EnableUIInputs();
        else
            EnableGameplayInputs();
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }

    public void EnableGameplayInputs()
    {
        Debug.Log("EnableGameplayInputs Get called");

        onUI.Disable();
        onFoot.Enable();
    }

    public void EnableUIInputs()
    {
        onFoot.Disable();
        onUI.Enable();
    }

    private void DisableAllInputs()
    {
        onFoot.Disable();
        onUI.Disable();
    }
}
