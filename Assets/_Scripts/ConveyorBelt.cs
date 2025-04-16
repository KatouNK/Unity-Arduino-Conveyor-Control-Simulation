using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public Vector3 direction = Vector3.forward; 
    public float speed = 2f;

    void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            // Hapus komponen velocity hanya pada arah horizontal conveyor
            Vector3 conveyorVel = direction.normalized * speed;

            // Gabungkan dengan kecepatan vertical (agar gravity tetap jalan)
            Vector3 newVelocity = new Vector3(
                conveyorVel.x,
                rb.linearVelocity.y,
                conveyorVel.z
            );

            rb.linearVelocity = newVelocity;
        }
    }


}