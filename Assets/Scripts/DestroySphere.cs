using UnityEngine;
using TMPro;

public class DestroySphere : MonoBehaviour
{
    public int sphereCount = 6;
    public float fixedX = 18f;
    public GameObject spherePrefab;
    public GameObject gameClearCanvas; // ���� Ŭ���� Canvas
    public TextMeshProUGUI counterText; // ī���͸� ǥ���� TextMeshProUGUI ���

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
                Debug.LogWarning("SuctionCupPlane ��ü�� Renderer ������Ʈ�� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogWarning("SuctionCupPlane ��ü�� ã�� �� �����ϴ�.");
        }

        for (int i = 0; i < sphereCount; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            GameObject sphere = Instantiate(spherePrefab, randomPosition, Quaternion.identity);
            sphere.tag = "Sphere";
            Collider collider = sphere.AddComponent<SphereCollider>();
            collider.isTrigger = true;
            sphere.AddComponent<SphereCollisionHandler>(); // Sphere�� SphereCollisionHandler ��ũ��Ʈ �߰�
        }

        // �ʱ� ī���� �ؽ�Ʈ ����
        counterText.text = "0/" + sphereCount*2;

    }

    private Vector3 GetRandomPosition()
    {
        if (suctionCupPlaneBounds == null)
        {
            Debug.LogWarning("SuctionCupPlane ��ü�� ����� ������ �� �����ϴ�.");
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
        // ī���� ������Ʈ
        counterText.text = collisionCount + "/" + sphereCount*2;

        // ���� Ŭ���� üũ
        if (collisionCount >= sphereCount*2)
        {
            // ���� Ŭ���� Canvas Ȱ��ȭ
            gameClearCanvas.SetActive(true);
        }
    }

    public static void incrementCollisionCount()
    {
        collisionCount++;
    }
}
