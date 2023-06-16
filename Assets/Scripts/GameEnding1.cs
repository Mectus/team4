using UnityEngine;

public class GameEnding1 : MonoBehaviour
{
    public GameObject YouDiedUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Origin"))
        {
            Debug.Log("Debris collided!"); // 디버깅 로그 추가
            YouDiedUI.SetActive(true); // GameEnding Canvas 활성화
            Time.timeScale = 0.1f; // 게임 일시 정지
        }
    }
}