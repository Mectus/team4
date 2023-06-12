using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public GameObject YouDiedUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Debris"))
        {
            Debug.Log("Debris collided!"); // ����� �α� �߰�
            YouDiedUI.SetActive(true); // GameEnding Canvas Ȱ��ȭ
            Time.timeScale = 0.1f; // ���� �Ͻ� ����
        }
    }
}