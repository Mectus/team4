using UnityEngine;

public class TransparencySwitch : MonoBehaviour
{
    public Material transparentMaterial; // 투명한 Material
    public Material opaqueMaterial; // 반투명한 Material

    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = opaqueMaterial; // 초기에는 반투명한 Material로 설정
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mop"))
        {
            renderer.material = transparentMaterial; // 특정 물체와 충돌 시 투명한 Material로 변경
        }
    }

}
