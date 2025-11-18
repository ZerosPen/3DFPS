using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor _playerMotor;
    private PlayerLook _playerLook;

    private void Awake()
    {
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

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
