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

    private void Awake()
    {
        strokeText.text = "Strokes 0";
    }

    public void SetUIText()
    {
        stroke++;
        strokeText.text = "Strokes " + stroke.ToString();
        //strokeText.text = newText;
    }
}
