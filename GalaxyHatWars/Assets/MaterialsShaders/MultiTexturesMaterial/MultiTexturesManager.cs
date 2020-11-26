using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTexturesManager : MonoBehaviour
{
    public Material monMaterial;
    [HideInInspector] public Renderer monRenderer;

    public Texture maskTexture;

    #region Texture1
    public float mask1Coefficient_R;
    public Vector2 tilling1;
    public Vector2 offset1;
    public Texture albedoTexture1;
    public Color albedoColor1;
    public float normalCoefficient1;
    public Texture normalTexture1;
    public Texture metalSmoothOcclTexture1;
    public float metalCoefficient1;
    public float smoothCoefficient1;
    public float occlCoefficient1;
    public float emissionCoefficient1;
    #endregion

    #region Texture2
    public float mask2Coefficient_G;
    public Vector2 tilling2;
    public Vector2 offset2;
    public Texture albedoTexture2;
    public Color albedoColor2;
    public float normalCoefficient2;
    public Texture normalTexture2;
    public Texture metalSmoothOcclTexture2;
    public float metalCoefficient2;
    public float smoothCoefficient2;
    public float occlCoefficient2;
    public float emissionCoefficient2;
    #endregion


    #region Texture3
    public float mask3Coefficient_B;
    public Vector2 tilling3;
    public Vector2 offset3;
    public Texture albedoTexture3;
    public Color albedoColor3;
    public float normalCoefficient3;
    public Texture normalTexture3;
    public Texture metalSmoothOcclTexture3;
    public float metalCoefficient3;
    public float smoothCoefficient3;
    public float occlCoefficient3;
    public float emissionCoefficient3;
    #endregion


    // Start is called before the first frame update
    void Awake()
    {
        monRenderer = this.GetComponent<Renderer>();
        monRenderer.material = monMaterial;

        monRenderer.material.SetTexture("TextureMask", maskTexture);

        #region Texture1
        monRenderer.material.SetFloat("Mask1Coefficient_R", mask1Coefficient_R);
        monRenderer.material.SetVector("Tilling1", tilling1);
        monRenderer.material.SetVector("Offset1", offset1);
        monRenderer.material.SetTexture("AlbedoTexture1", albedoTexture1);
        monRenderer.material.SetColor("AlbedoColor1", albedoColor1);
        monRenderer.material.SetFloat("NormalCoeficient1", normalCoefficient1);
        monRenderer.material.SetTexture("NormalTexture1", normalTexture1);
        monRenderer.material.SetTexture("MetalSmoothOcclTexture1", metalSmoothOcclTexture1);
        monRenderer.material.SetFloat("MetalCoefficient1", metalCoefficient1);
        monRenderer.material.SetFloat("SmoothCoefficient1", smoothCoefficient1);
        monRenderer.material.SetFloat("OcclusionCoefficient1", occlCoefficient1);
        monRenderer.material.SetFloat("EmissionCoefficient1", emissionCoefficient1);
        #endregion

        #region Texture2
        monRenderer.material.SetFloat("Mask2Coefficient_G", mask2Coefficient_G);
        monRenderer.material.SetVector("Tilling2", tilling2);
        monRenderer.material.SetVector("Offset2", offset2);
        monRenderer.material.SetTexture("AlbedoTexture2", albedoTexture2);
        monRenderer.material.SetColor("AlbedoColor2", albedoColor2);
        monRenderer.material.SetFloat("NormalCoeficient2", normalCoefficient2);
        monRenderer.material.SetTexture("NormalTexture2", normalTexture2);
        monRenderer.material.SetTexture("MetalSmoothOcclTexture2", metalSmoothOcclTexture2);
        monRenderer.material.SetFloat("MetalCoefficient2", metalCoefficient2);
        monRenderer.material.SetFloat("SmoothCoefficient2", smoothCoefficient2);
        monRenderer.material.SetFloat("OcclusionCoefficient2", occlCoefficient2);
        monRenderer.material.SetFloat("EmissionCoefficient2", emissionCoefficient2);
        #endregion

        #region Texture3
        monRenderer.material.SetFloat("Mask3Coefficient_B", mask3Coefficient_B);
        monRenderer.material.SetVector("Tilling3", tilling3);
        monRenderer.material.SetVector("Offset3", offset3);
        monRenderer.material.SetTexture("AlbedoTexture3", albedoTexture3);
        monRenderer.material.SetColor("AlbedoColor3", albedoColor3);
        monRenderer.material.SetFloat("NormalCoeficient3", normalCoefficient3);
        monRenderer.material.SetTexture("NormalTexture3", normalTexture3);
        monRenderer.material.SetTexture("MetalSmoothOcclTexture3", metalSmoothOcclTexture3);
        monRenderer.material.SetFloat("MetalCoefficient3", metalCoefficient3);
        monRenderer.material.SetFloat("SmoothCoefficient3", smoothCoefficient3);
        monRenderer.material.SetFloat("OcclusionCoefficient3", occlCoefficient3);
        monRenderer.material.SetFloat("EmissionCoefficient3", emissionCoefficient3);
        #endregion
    }


}
