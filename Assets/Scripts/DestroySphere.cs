using UnityEngine;
using TMPro;

public class DestroySphere : MonoBehaviour
{
    public int sphereCount = 6;
    public float fixedX = 18f;
    public GameObject spherePrefab;
    public GameObject gameClearCanvas; // 게임 클리어 Canvas
    public TextMeshProUGUI counterText; // 카운터를 표시할 TextMeshProUGUI 요소

    private GameObject suctionCupPlane;
    private Renderer suctionCupPlaneRenderer;
    private Bounds suctionCupPlaneBounds;

    private static int collisionCount = 0;

    private void Start()
    {
        collisionCount = 0;

        suctionCupPlane = GameObject.FindWithTag("suctionCupPlane");
        if (suctionCupPlane != null)
        {
            suctionCupPlaneRenderer = suctionCupPlane.GetComponent<Renderer>();
            if (suctionCupPlaneRenderer != null)
            {
                suctionCupPlaneBounds = suctionCupPlaneRenderer.bounds;
            }
            else
            {
                Debug.LogWarning("SuctionCupPlane 객체에 Renderer 컴포넌트가 없습니다.");
            }
        }
        else
        {
            Debug.LogWarning("SuctionCupPlane 객체를 찾을 수 없습니다.");
        }

        for (int i = 0; i < sphereCount; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            GameObject sphere = Instantiate(spherePrefab, randomPosition, Quaternion.identity);
            sphere.tag = "Sphere";
            Collider collider = sphere.AddComponent<SphereCollider>();
            collider.isTrigger = true;
            sphere.AddComponent<SphereCollisionHandler>(); // Sphere에 SphereCollisionHandler 스크립트 추가
        }

        // 초기 카운터 텍스트 설정
        counterText.text = "0/" + sphereCount*2;

    }

    private Vector3 GetRandomPosition()
    {
        if (suctionCupPlaneBounds == null)
        {
            Debug.LogWarning("SuctionCupPlane 객체의 사이즈를 가져올 수 없습니다.");
            return Vector3.zero;
        }

        float minY = suctionCupPlaneBounds.min.y;
        float maxY = suctionCupPlaneBounds.max.y;
        float minZ = suctionCupPlaneBounds.min.z;
        float maxZ = suctionCupPlaneBounds.max.z;

        Vector3 randomPosition = new Vector3(fixedX, Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        return randomPosition;
    }

    private void Update()
    {
        // 카운터 업데이트
        counterText.text = collisionCount + "/" + sphereCount*2;

        // 게임 클리어 체크
        if (collisionCount >= sphereCount*2)
        {
            // 게임 클리어 Canvas 활성화
            gameClearCanvas.SetActive(true);
        }
    }

    public static void incrementCollisionCount()
    {
        collisionCount++;
    }
}
