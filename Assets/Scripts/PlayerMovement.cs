using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private PlayerInputActions _playerInputAction;
    private PlayerInput _playerInput;
    private float _velocity = 3.5f;
    private float _rotationSpeed = 10f;

    private Vector3 _startingPosition;

    private Vector3 _currentPosition;

    #region Delegates;
    public delegate void OnGameStartedEnablePlayer();
    public static OnGameStartedEnablePlayer onGameStartedEnablePlayer;

    public delegate void OnGameFinishedDisablePlayer();
    public static OnGameFinishedDisablePlayer onGameFinishedDisablePlayer;

    public delegate void OnGameRestartedResetPlayer();
    public static OnGameRestartedResetPlayer onGameRestartedResetPlayer;
    #endregion

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            _playerInput.SwitchCurrentActionMap("Mobile");

        onGameStartedEnablePlayer += EnablePlayer;
        onGameFinishedDisablePlayer += DisablePlayer;
        onGameRestartedResetPlayer += ResetPlayer;

        _rigidbody = GetComponent<Rigidbody>();

        _playerInputAction = new PlayerInputActions();
        _playerInputAction.Player.Jump.performed += Jump;

        _startingPosition = GetComponent<Transform>().position;
    }

    private void Update()
    {
        _currentPosition = transform.position;
        _currentPosition.y = Mathf.Clamp(_currentPosition.y, 0, 7.75f);
        transform.position = _currentPosition;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameplayOn)
            transform.rotation = Quaternion.Euler(0, 0, _rigidbody.velocity.y * _rotationSpeed);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        _rigidbody.velocity = Vector3.up * _velocity;
    }

    private void ResetPlayer()
    {
        transform.position = _startingPosition;
        transform.rotation = Quaternion.identity;
    }

    private void EnablePlayer()
    {
        _rigidbody.isKinematic = false;
        _playerInputAction.Player.Enable();
    }

    private void DisablePlayer()
    {
        _rigidbody.isKinematic = true;
        _playerInputAction.Player.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.ScoreUp();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.GameOver();
    }

    private void OnDestroy()
    {
        onGameStartedEnablePlayer -= EnablePlayer;
        onGameFinishedDisablePlayer -= DisablePlayer;
        onGameRestartedResetPlayer -= ResetPlayer;
    }
}
