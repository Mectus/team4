using UnityEngine;

public class SuctionCupCollision : MonoBehaviour
{
    public string suctionCupPlaneTag = "suctionCupPlane";
    private GameObject suctionCupPlane;
    public static bool isColliding = false;
    public static bool isSwept = false;
    public static Vector3 start;
    public static Vector3 end;

    private void Start()
    {
        suctionCupPlane = GameObject.FindGameObjectWithTag(suctionCupPlaneTag);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == suctionCupPlane)
        {
            Debug.Log("is colliding");
            isColliding = true;
            isSwept = false;
            start = this.transform.position;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == suctionCupPlane)
        {
            Debug.Log("is not colliding");
            isColliding = false;
            isSwept = true;
            end = this.transform.position;
        }
    }
}
