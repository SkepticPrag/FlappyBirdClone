using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerMovement : PlayerStateManager
{
    private float _velocity = 3.5f;
    private float _rotationSpeed = 10f;

    private Vector3 _currentPosition;

    private void Start()
    {
        _playerInputAction.Player.Jump.performed += Jump;
    }
    private void FixedUpdate()
    {
        _currentPosition = transform.position;
        _currentPosition.y = Mathf.Clamp(_currentPosition.y, 0, 7.75f);
        transform.position = _currentPosition;

        if (GameManager.Instance.IsGameplayOn)
            transform.rotation = Quaternion.Euler(0, 0, _rigidbody.velocity.y * _rotationSpeed);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            _rigidbody.velocity = Vector3.up * _velocity;
    }

    private void OnTriggerExit(Collider other)
    {
        ScoreManager.Instance.ScoreUp();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.GameOver();
    }
}
