using UnityEngine;

public class DebrisManager : MonoBehaviour
{
    public GameObject debrisPrefab;
    public float minDelay = 30f; // 최소 딜레이 시간
    public float maxDelay = 60f; // 최대 딜레이 시간
    public float flickerDuration = 0.2f; // 플리커링 지속 시간
    public float flickerInterval = 0.1f; // 플리커 간격
    public Color flickerColor = Color.red; // 플리커링 색상
    public Transform playerHead; // 플레이어 머리 위치
    public Light directionalLight; // Directional Light

    private void Start()
    {
        StartCoroutine(DebrisRoutine());
    }

    private System.Collections.IEnumerator DebrisRoutine()
    {
        while (true)
        {
            // 랜덤 딜레이 시간
            float randomDelay = Random.Range(minDelay, maxDelay);

            // 플리커링 시작
            StartCoroutine(FlickerLightRoutine());

            yield return new WaitForSeconds(flickerDuration);

            // 플리커링 종료
            SetLightColor(Color.white);

            // 4초 후에 Debris 오브젝트 생성 및 필요한 설정
            yield return new WaitForSeconds(4f);
            Vector3 debrisPosition = playerHead.position + Vector3.up * 20f; // 플레이어 머리 위치에서 20m 위로 이동
            Instantiate(debrisPrefab, debrisPosition, Quaternion.identity);

            // 다음 낙하물을 위해 랜덤 딜레이 대기
            yield return new WaitForSeconds(randomDelay);
        }
    }

    private System.Collections.IEnumerator FlickerLightRoutine()
    {
        float timer = 0f;
        while (timer < flickerDuration)
        {
            // 플리커 간격마다 색상 변경
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
        // Directional Light의 색상 변경
        directionalLight.color = color;
    }
}
