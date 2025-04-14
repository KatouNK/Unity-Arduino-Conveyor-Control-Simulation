using UnityEngine;

public class SpinInPlace : MonoBehaviour
{
    public float speed = 90f; // Derajat per detik
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        transform.localRotation = initialRotation * Quaternion.Euler(Vector3.forward * speed * Time.time);
    }
}