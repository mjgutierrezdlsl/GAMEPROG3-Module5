using UnityEngine;

public class CubeSpinner : MonoBehaviour
{
    [SerializeField] private float minSpeed = 5f, maxSpeed = 20f;
    private float _spinSpeed;
    private Vector3 _spinAxis = Vector3.up;

    private void Start()
    {
        _spinSpeed = Random.Range(minSpeed, maxSpeed);
        _spinAxis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    void Update()
    {
        transform.Rotate(_spinAxis, _spinSpeed * Time.deltaTime);
    }
}
