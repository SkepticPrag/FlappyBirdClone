using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    private Vector3 _startingPosition;
    protected Rigidbody _rigidbody;
    protected PlayerInputActions _playerInputAction;

    #region Delegates
    public delegate void OnGameStartedEnablePlayer();
    public static OnGameStartedEnablePlayer onGameStartedEnablePlayer;

    public delegate void OnGameFinishedDisablePlayer();
    public static OnGameFinishedDisablePlayer onGameFinishedDisablePlayer;

    public delegate void OnGameRestartedResetPlayer();
    public static OnGameRestartedResetPlayer onGameRestartedResetPlayer;
    #endregion

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startingPosition = GetComponent<Transform>().position;

        PlayerInput = GetComponent<PlayerInput>();
        _playerInputAction = new PlayerInputActions();

        onGameStartedEnablePlayer += EnablePlayer;
        onGameFinishedDisablePlayer += DisablePlayer;
        onGameRestartedResetPlayer += ResetPlayer;
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

    private void OnDestroy()
    {
        onGameStartedEnablePlayer -= EnablePlayer;
        onGameFinishedDisablePlayer -= DisablePlayer;
        onGameRestartedResetPlayer -= ResetPlayer;
    }
}
