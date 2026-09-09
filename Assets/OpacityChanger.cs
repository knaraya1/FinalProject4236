using UnityEngine;

public class OpacityChanger : MonoBehaviour
{
    public Renderer targetRenderer;   // assign in Inspector
    [Range(0f, 1f)]
    public float opacity = 1f;        // 1 = fully visible, 0 = invisible

    void Start()
    {
        Material mat = targetRenderer.material;
        mat.SetFloat("_Mode", 3); // 3 = Transparent
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;
    }
    void Update()
    {
        Color c = targetRenderer.material.color;
        c.a = opacity;                // change alpha
        targetRenderer.material.color = c;
    }
}
