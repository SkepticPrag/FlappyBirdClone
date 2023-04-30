using UnityEngine;

public class EventManager : MonoBehaviour
{
    public void EnableGameplay()
    {
        PlayerStateManager.onGameStartedEnablePlayer?.Invoke();
        PipesSpawner.onGameStartedEnableSpawner?.Invoke();
    }

    public void DisableGameplay()
    {
        PlayerStateManager.onGameFinishedDisablePlayer?.Invoke();
        PipesSpawner.onGameFinishedDisableSpawner?.Invoke();
        PipesStateManager.onGameFinishedDisablePipes?.Invoke();
    }

    public void ResetGameplay()
    {
        PlayerStateManager.onGameRestartedResetPlayer?.Invoke();
        PlayerStateManager.onGameFinishedDisablePlayer?.Invoke();
        PipesSpawner.onGameFinishedDisableSpawner?.Invoke();
        PipesStateManager.onGameFinishedDisablePipes?.Invoke();
    }

    public void RestartGameplay()
    {
        PlayerStateManager.onGameRestartedResetPlayer?.Invoke();
        PlayerStateManager.onGameStartedEnablePlayer?.Invoke();
        PipesSpawner.onGameStartedEnableSpawner?.Invoke();
    }
}

