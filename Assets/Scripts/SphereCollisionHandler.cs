using UnityEngine;

public class SphereCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mop"))
        {
            Destroy(this.gameObject);
            DestroySphere.collisionCount = DestroySphere.collisionCount + 1;

        }
    }
}
