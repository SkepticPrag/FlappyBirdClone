using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    private void Start()
    {
        if (Application.platform != RuntimePlatform.WindowsPlayer)
            MenuController.Instance.ExitButton.SetActive(true);

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            PlayerStateManager.PlayerInput.SwitchCurrentActionMap("Mobile");
    }

}
