using UnityEngine;
using TMPro;

public class SphereManager : MonoBehaviour
{
    public GameObject spherePrefab; // ������ ��ü ������
    public int sphereCount = 10; // ������ ��ü�� ����
    public GameObject gameClearCanvas; // ���� Ŭ���� Canvas
    public TextMeshProUGUI counterText; // ī���͸� ǥ���� TextMeshProUGUI ���
    public float fixedXPosition = 0f; // x�� ���� ��ġ

    private int collisionCount = 0; // �浹�� ��ü�� ����

    private void Start()
    {
        // ��ü ����
        for (int i = 0; i < sphereCount; i++)
        {
            // ������ Y, Z �� ��ġ ���
            float y = Random.Range(20f, 85f);
            float z = Random.Range(45f, 65f);
            // ��ü ����
            GameObject sphere = Instantiate(spherePrefab, new Vector3(fixedXPosition, y, z), Quaternion.identity);
        }

        // �ʱ� ī���� �ؽ�Ʈ ����
        counterText.text = "0/" + sphereCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� Mop �±׸� ������ �ִ��� Ȯ��
        if (other.gameObject.CompareTag("Mop"))
        {
            // �浹�� ��ü ����
            Destroy(other.gameObject);
            // �浹 ī��Ʈ ����
            collisionCount++;

            // ī���� ������Ʈ
            counterText.text = collisionCount + "/" + sphereCount;

            // ���� Ŭ���� üũ
            if (collisionCount >= sphereCount)
            {
                // ���� Ŭ���� Canvas Ȱ��ȭ
                gameClearCanvas.SetActive(true);
                Time.timeScale = 0.1f; // ���� �Ͻ� ����
            }
        }
    }
}
