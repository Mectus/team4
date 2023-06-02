using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderChange : MonoBehaviour
{
    public Material material;  //Blur Material
    public Color baseColor= new Color(222 / 225f, 108 / 225f, 20 / 225f, 1.0f);
    public Color changeColor= new Color(203 / 225f, 203 / 225f, 203 / 225f, 1.0f);
    public float emission = 5.0f;
    public float blurLevel = 0.03f;

    // Start is called before the first frame update
    void Start()
    {

        material.SetColor("_BaseColor", baseColor);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            baseColor.r=(baseColor.r + Time.deltaTime >=changeColor.r) ? changeColor.r : baseColor.r + Time.deltaTime;
            baseColor.g = (baseColor.g + Time.deltaTime >= changeColor.g) ? changeColor.g : baseColor.g +Time.deltaTime;
            baseColor.b = (baseColor.b + Time.deltaTime >= changeColor.b) ? changeColor.b : baseColor.b +Time.deltaTime;
            material.SetColor("_BaseColor", baseColor);

            emission =(emission+2*Time.deltaTime>=10f) ? 10f : 2*emission+Time.deltaTime;
            material.SetFloat("_Emission",emission);

            blurLevel = (blurLevel - 0.1f*Time.deltaTime <=0f) ? 0f : blurLevel - 0.1f * Time.deltaTime;
            material.SetFloat("_BlurLevel", blurLevel);
        }
    }
}
