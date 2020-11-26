using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpaqueShaderManager : MonoBehaviour
{
    public Material monMaterial;
    [HideInInspector] public Renderer monRenderer;

    #region Textures
    public Texture albedoTexture;
    public Texture normalTexture;
    public Texture metalTexture;
    public Texture emissionTexture;
    #endregion

    #region Paramètres
    public float normalCoefficient;
    public float metallicCoefficient;
    public float smoothnessCoefficient;
    public float occlusionCoefficient;
    #endregion

    #region Color
    public Color albedoColor;
    [ColorUsage(true, true)]
    public Color emissionColor;
    #endregion


    private void Awake()
    {
        monRenderer = this.GetComponent<Renderer>();
        monRenderer.material = monMaterial;

        AttributionOpaqueProperties();
    }


    public void AttributionOpaqueProperties()
    {
        #region Attribution Textures
        monRenderer.material.SetTexture("AlbedoTexture", albedoTexture);
        monRenderer.material.SetTexture("NormalTexture", normalTexture);
        monRenderer.material.SetTexture("MetalSmoothOccluTexture", metalTexture);
        monRenderer.material.SetTexture("EmissionTexture", emissionTexture);
        #endregion

        #region Attribution Paramètres
        monRenderer.material.SetFloat("NormalCoefficient", normalCoefficient);
        monRenderer.material.SetFloat("MetallicCoefficient", metallicCoefficient);
        monRenderer.material.SetFloat("SmoothnessCoefficient", smoothnessCoefficient);
        monRenderer.material.SetFloat("OcclusionCoefficient", occlusionCoefficient);
        #endregion

        #region Attribution Color
        monRenderer.material.SetColor("AlbedoColor", albedoColor);
        monRenderer.material.SetColor("EmissionColor", emissionColor);
        #endregion
    }
}
