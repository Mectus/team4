using UnityEngine;

public class SphereCollisionHandler : MonoBehaviour
{
    private bool isCollided = false; // 충돌 여부를 확인하기 위한 변수

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollided && other.CompareTag("Mop")) // 한 번의 충돌만 처리
        {
            isCollided = true;
            Destroy(gameObject); // 구체 삭제
            DestroySphere.incrementCollisionCount(); // 카운트 증가
        }
    }
}
