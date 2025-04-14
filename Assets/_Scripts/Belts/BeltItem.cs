using System;
using UnityEngine;

public class BeltItem : MonoBehaviour
{
    public GameObject item;
    private Rigidbody rb;

    private void Awake()
    {
        item = gameObject;
        rb = item.GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = item.AddComponent<Rigidbody>();
            rb.useGravity = false; // Matikan gravitasi biar ga jatuh
            rb.isKinematic = true; // Supaya physics tetap dikontrol skrip
        }
    }
}
