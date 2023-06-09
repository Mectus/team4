using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesB : MonoBehaviour
{
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LevelExit")
        {
            SceneManager.LoadScene(1);
        }
    }
}
