using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

//Author(s): Jackson, Katherine
//Updated: 04/09/24
//This script executes all code relevant to player information between levels.

public class UIManager : MonoBehaviour
{
    //GameObject strokeCounter;  
    public TextMeshProUGUI strokeText;
    private int stroke;

    //Referencing LineForce script and Golfball prefab GameObject for variables
    LineForce updateStrokeOnHit;
    [SerializeField] GameObject strokeInt;

    private void Awake()
    {
        strokeText.text = "Strokes 0";
        //to get the stroke from GameObject containing LineForce script
        updateStrokeOnHit = strokeInt.GetComponent<LineForce>();
    }

    private void Update()
    {
        SetUIText();
    }

    public void SetUIText()
    {
        stroke = updateStrokeOnHit.strokeCount;
        strokeText.text = "Strokes " + stroke.ToString();
    }
}
