using UnityEngine;

public class DebrisManager : MonoBehaviour
{
    public GameObject debrisPrefab;
    public float minDelay = 2f; // 최소 딜레이 시간
    public float maxDelay = 5f; // 최대 딜레이 시간

    private void Start()
    {
        // 경보가 랜덤 타이밍에 울린 후 일정 시간(4초)이 지난 후에 Debris 오브젝트를 생성하는 메서드를 호출
        float randomDelay = Random.Range(minDelay, maxDelay);
        Invoke("DropDebris", randomDelay + 4f);
    }

    private void DropDebris()
    {
        // Debris 오브젝트 생성 및 필요한 설정
        Instantiate(debrisPrefab, transform.position, Quaternion.identity);
    }
}
