using System.Collections.Generic;
using UnityEngine;

public class CustomXRGrabInteractable : MonoBehaviour
{
    public float movementSpeed = 1; // Speed of movement

    private GameObject suctionCup;
    private Vector3 previousPosition; // The position of the controller on the previous frame
    private GameObject playerObject;
    private Vector3 originalPosition;
    private bool isColliding = false;


    private void Start()
    {
        suctionCup = GameObject.FindGameObjectWithTag("suctionCup");
        playerObject = GameObject.FindGameObjectWithTag("MainCamera"); // This should now be the XROrigin

        if (playerObject == null)
        {
            Debug.LogWarning("Player object not found. Make sure it is tagged with 'MainCamera'.");
        }

    }

    private void Update()
    {

        // Check if the SuctionCupCollision script is present and if isColliding is true
        SuctionCupCollision suctionCupCollision = suctionCup.GetComponent<SuctionCupCollision>();
        if (suctionCupCollision != null && !SuctionCupCollision.isColliding && SuctionCupCollision.isSwept)
        {
            Vector3 offset = SuctionCupCollision.start - SuctionCupCollision.end;

            MovePlayer(offset);

        }
    }


    private void MovePlayer(Vector3 offset)
    {
        Vector3 movement = offset * movementSpeed; // reverse the direction of movement
        movement.y = 0;
        movement.z = 0;

        if (playerObject != null)
        {
            playerObject.transform.position += movement;
            SuctionCupCollision.start = SuctionCupCollision.end;
        }
    }


}
