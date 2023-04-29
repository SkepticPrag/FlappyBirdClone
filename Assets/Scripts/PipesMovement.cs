using System.Collections;
using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        StartCoroutine("DeactivatePipes");
    }

    private IEnumerator DeactivatePipes()
    {
        yield return new WaitForSeconds(10f);

        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
