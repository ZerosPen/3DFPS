using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    private PlayerMotor _playerMotor;
    private PlayerLook _playerLook;
    private PlayerInput playerInput;
    private InputAction _menuOpenAction;

    public static InputManager Instance
    {
        get { return _instance; }
    }
    public bool MenuOpenInput { get; private set; }
    public PlayerInput.OnFootActions onFoot;

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

        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        _playerMotor = GetComponent<PlayerMotor>();
        _playerLook = GetComponent<PlayerLook>();
        onFoot.Jump.performed += ctx => _playerMotor.Jump();
    }

    private void FixedUpdate()
    {
        _playerMotor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    public Vector2 GetMouseDelta()
    {
        return onFoot.Look.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
