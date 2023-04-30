using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    [SerializeField] private float _speed;


    void FixedUpdate()
    {
        if (GameManager.Instance.IsGameplayOn)
            transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
