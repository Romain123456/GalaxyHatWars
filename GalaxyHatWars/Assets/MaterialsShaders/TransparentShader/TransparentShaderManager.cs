using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentShaderManager : OpaqueShaderManager
{
    public float transparentCoefficient;

    private void Awake()
    {
        monRenderer = this.GetComponent<Renderer>();
        monRenderer.material = monMaterial;

        AttributionOpaqueProperties();

        #region Metal Texture
        monRenderer.material.SetTexture("MetalSmoothOccluTranspTexture", metalTexture);
        #endregion

        #region Transparent
        monRenderer.material.SetFloat("TransparentCoefficient", transparentCoefficient);
        #endregion
    }
}
