using UnityEngine;

[RequireComponent(typeof(ConveyorBelt))]
public class BeltTextureScroll : MonoBehaviour
{
    public float speed = 0.5f;
    public bool reverseScroll = false;  // Menentukan apakah animasi mundur
    private Renderer rend;
    private ConveyorBelt conveyor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        conveyor = GetComponent<ConveyorBelt>();
    }

    void Update()
    {
        if (conveyor == null) return;

        // Arah conveyor dalam lokal (agar sesuai UV)
        Vector3 localDir = transform.InverseTransformDirection(conveyor.direction.normalized);
        Vector2 uvDir = new Vector2(localDir.x, localDir.z).normalized;

        // Offset berdasarkan waktu
        float offset = Time.time * speed;

        // Jika reverseScroll true, balikkan offset (terbalikkan pergerakan tekstur)
        if (reverseScroll)
        {
            offset = -offset;
        }

        // Terapkan offset ke arah UV, pastikan mengikuti arah conveyor
        rend.material.mainTextureOffset = uvDir * offset;
    }
}
