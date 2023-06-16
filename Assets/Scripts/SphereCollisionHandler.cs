using UnityEngine;

public class SphereCollisionHandler : MonoBehaviour
{
    private bool isCollided = false; // �浹 ���θ� Ȯ���ϱ� ���� ����

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollided && other.CompareTag("Mop")) // �� ���� �浹�� ó��
        {
            isCollided = true;
            Destroy(gameObject); // ��ü ����
            DestroySphere.incrementCollisionCount(); // ī��Ʈ ����
        }
    }
}
