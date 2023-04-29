using System;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private PlayerInputActions _playerInputAction;
    private float _velocity = 3.5f;
    private float _rotationSpeed = 10f;

    public static PlayerInput playerInput;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        playerInput = GetComponent<PlayerInput>();

        _playerInputAction = new PlayerInputActions();
        _playerInputAction.Player.Enable();
        _playerInputAction.Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rigidbody.velocity.y * _rotationSpeed);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        _rigidbody.velocity = Vector3.up * _velocity;
    }
}
