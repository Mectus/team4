using UnityEngine;

public class Elevater : MonoBehaviour
{
    public GameObject righthandObject;
    public GameObject lefthandObject;
    public float speed = 1f;

    private bool isMoving = false;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
        {
            return;
        }
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == righthandObject || lefthandObject)
        {
            isMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == righthandObject || lefthandObject)
        {
            isMoving = false;
        }
    }
}