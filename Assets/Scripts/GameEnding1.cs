using UnityEngine;

public class GameEnding1 : MonoBehaviour
{
    public GameObject YouDiedUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Origin"))
        {
            Debug.Log("Debris collided!"); // ����� �α� �߰�
            YouDiedUI.SetActive(true); // GameEnding Canvas Ȱ��ȭ
            Time.timeScale = 0.1f; // ���� �Ͻ� ����
        }
    }
}