using UnityEngine;

public class DebrisManager : MonoBehaviour
{
    public GameObject debrisPrefab;
    public float minDelay = 30f; // �ּ� ������ �ð�
    public float maxDelay = 60f; // �ִ� ������ �ð�
    public float flickerDuration = 0.2f; // �ø�Ŀ�� ���� �ð�
    public float flickerInterval = 0.1f; // �ø�Ŀ ����
    public Color flickerColor = Color.red; // �ø�Ŀ�� ����
    public Transform playerHead; // �÷��̾� �Ӹ� ��ġ
    public Light directionalLight; // Directional Light

    private void Start()
    {
        StartCoroutine(DebrisRoutine());
    }

    private System.Collections.IEnumerator DebrisRoutine()
    {
        while (true)
        {
            // ���� ������ �ð�
            float randomDelay = Random.Range(minDelay, maxDelay);

            // �ø�Ŀ�� ����
            StartCoroutine(FlickerLightRoutine());

            yield return new WaitForSeconds(flickerDuration);

            // �ø�Ŀ�� ����
            SetLightColor(Color.white);

            // 4�� �Ŀ� Debris ������Ʈ ���� �� �ʿ��� ����
            yield return new WaitForSeconds(4f);
            Vector3 debrisPosition = playerHead.position + Vector3.up * 20f; // �÷��̾� �Ӹ� ��ġ���� 20m ���� �̵�
            Instantiate(debrisPrefab, debrisPosition, Quaternion.identity);

            // ���� ���Ϲ��� ���� ���� ������ ���
            yield return new WaitForSeconds(randomDelay);
        }
    }

    private System.Collections.IEnumerator FlickerLightRoutine()
    {
        float timer = 0f;
        while (timer < flickerDuration)
        {
            // �ø�Ŀ ���ݸ��� ���� ����
            if (timer % (flickerInterval * 2f) < flickerInterval)
            {
                SetLightColor(flickerColor);
            }
            else
            {
                SetLightColor(Color.white);
            }

            timer += Time.deltaTime;
            yield return null;
        }
    }

    private void SetLightColor(Color color)
    {
        // Directional Light�� ���� ����
        directionalLight.color = color;
    }
}
