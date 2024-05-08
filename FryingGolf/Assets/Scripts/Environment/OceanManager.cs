using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

//Author(s): Jackson, Katherine
//Updated: 05/05/24
//This script simulates ... (Water physics)

public class OceanManager : MonoBehaviour
{
    public float wavesHeight = 20f;
    public float wavesFrequency = 1f;
    public float wavesSpeed = 100f;

    public GameObject ocean;

    Material oceanMat;
    Texture2D wavesDisplacement;
    // Start is called before the first frame update
    void Start()
    {
        SetVariables();
    }

    void SetVariables()
    {
        oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        //wavesDisplacement = (Texture2D)oceanMat.GetTexture("_WavesDisplacement");
    }

    public float WaterHeightAtPosition(Vector3 position)
    {
        return ocean.transform.position.y + wavesDisplacement.GetPixelBilinear(position.x * wavesFrequency * ocean.transform.localScale.x,
            (position.z * wavesFrequency + Time.time * wavesSpeed) * ocean.transform.localScale.z).g * wavesHeight;
    }

    private void OnValidate()
    {
        if (!oceanMat)
            SetVariables();

        UpdateMaterial();
    }

     void UpdateMaterial()
    {
        oceanMat.SetFloat("_WavesFrequency", wavesFrequency);
        oceanMat.SetFloat("_WavesSpeed", wavesSpeed);
        oceanMat.SetFloat("_WavesHeight", wavesHeight);
    }
}
