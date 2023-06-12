using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderChange : MonoBehaviour
{
    [SerializeField] private Material material;  //Blur Material
    [SerializeField] private Color baseColor= new Color(142 / 255f, 125 / 255f, 40 / 255f, 75/255f);
    [SerializeField] private Color changeColor= new Color(255/ 255f, 255 / 255f, 255 / 255f, 25/255f);
    [SerializeField] private float blurLevel = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        material.SetColor("_Color", baseColor);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            baseColor.r=(baseColor.r + Time.deltaTime >=changeColor.r) ? changeColor.r : baseColor.r + Time.deltaTime;
            baseColor.g = (baseColor.g + Time.deltaTime >= changeColor.g) ? changeColor.g : baseColor.g +Time.deltaTime;
            baseColor.b = (baseColor.b + Time.deltaTime >= changeColor.b) ? changeColor.b : baseColor.b +Time.deltaTime;
            material.SetColor("_Color", baseColor);

            blurLevel = (blurLevel + 0.1f*Time.deltaTime >=3f) ? 3f : blurLevel +  Time.deltaTime;
            material.SetFloat("_EdgeThickness", blurLevel);
        }
    }
}
