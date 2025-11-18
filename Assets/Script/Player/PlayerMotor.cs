using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterDataSO _characterData;

    [Header("")]
    [SerializeField] private bool isGrounded;

    private CharacterController controller;
    public float gravity = -9.8f;
    private Vector3 _playerVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        _characterData = GetComponent<PlayerData>().CharacterData;
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y; 
        controller.Move(transform.TransformDirection(moveDirection) * _characterData.walkSpeedCharacter * Time.deltaTime);
        _playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y = -2f;

        controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_characterData.jumpHeightCharacter * -3f * gravity);
        }
    }
}
