using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAnimation : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float OffsetX;
    [SerializeField] private float OffsetY;

    private void FixedUpdate()
    {
        OffsetX = Time.time / 10;
        OffsetY = Time.time / 10;
        material.mainTextureOffset = new Vector2 (OffsetX, OffsetY);
    }
}
