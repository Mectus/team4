using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSeat : MonoBehaviour
{
    [SerializeField] private GameObject Descender;
    [SerializeField] private float _offset = 0.5f;
    [SerializeField] Vector2 xyPos = new Vector2(0.75f, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Descender.transform.position - Vector3.up * _offset + new Vector3(xyPos.x, 0, xyPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Descender.transform.position - Vector3.up * _offset + new Vector3(xyPos.x, 0, xyPos.y);
    }
}
