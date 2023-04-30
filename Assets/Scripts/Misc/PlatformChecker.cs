using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    private MenuManager _menuManager;

    private void Awake()
    {
        _menuManager = GetComponent<MenuManager>();

        if (Application.platform != RuntimePlatform.WindowsPlayer)
            _menuManager.ExitButton.SetActive(true);
    }

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            PlayerStateManager.PlayerInput.SwitchCurrentActionMap("Mobile");
    }

}
