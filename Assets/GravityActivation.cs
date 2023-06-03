using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityActivation : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool isColliding = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Right Hand" || collision.gameObject.name == "Left Hand")
            isColliding = true;
            rigidbody.useGravity = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Right Hand" || collision.gameObject.name == "Left Hand")
            isColliding = false;
            rigidbody.useGravity = false;
    }
}