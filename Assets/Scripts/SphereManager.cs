using UnityEngine;
using TMPro;

public class SphereManager : MonoBehaviour
{
    public GameObject spherePrefab; // 생성할 구체 프리팹
    public int sphereCount = 10; // 생성할 구체의 개수
    public GameObject gameClearCanvas; // 게임 클리어 Canvas
    public TextMeshProUGUI counterText; // 카운터를 표시할 TextMeshProUGUI 요소
    public float fixedXPosition = 0f; // x축 고정 위치

    private int collisionCount = 0; // 충돌한 구체의 개수

    private void Start()
    {
        // 구체 생성
        for (int i = 0; i < sphereCount; i++)
        {
            // 랜덤한 Y, Z 축 위치 계산
            float y = Random.Range(20f, 85f);
            float z = Random.Range(45f, 65f);
            // 구체 생성
            GameObject sphere = Instantiate(spherePrefab, new Vector3(fixedXPosition, y, z), Quaternion.identity);
        }

        // 초기 카운터 텍스트 설정
        counterText.text = "0/" + sphereCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 Mop 태그를 가지고 있는지 확인
        if (other.gameObject.CompareTag("Mop"))
        {
            // 충돌한 구체 제거
            Destroy(other.gameObject);
            // 충돌 카운트 증가
            collisionCount++;

            // 카운터 업데이트
            counterText.text = collisionCount + "/" + sphereCount;

            // 게임 클리어 체크
            if (collisionCount >= sphereCount)
            {
                // 게임 클리어 Canvas 활성화
                gameClearCanvas.SetActive(true);
                Time.timeScale = 0.1f; // 게임 일시 정지
            }
        }
    }
}
