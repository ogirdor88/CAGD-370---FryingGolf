using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
//using UnityEditor.Experimental.GraphView;

//Author(s): Jackson, Katherine; Uribe-Hernandez, Fernando
//Updated: 04/24/24
//This script executes all code relevant to player information between levels.

public class UIManager : MonoBehaviour
{
    //GameObject strokeCounter;  
    public TextMeshProUGUI strokeText;
    private int stroke;
    public TextMeshProUGUI eggText;
    private int eggCollected;

    //Referencing LineForce script on Golfball prefab GameObject for variables
    LineForce updateStrokeOnHit;
    [SerializeField] GameObject strokeInt;

    //Referencing Player script on Golfball GameObject for variables
    Player updateCollectibleCount;
    [SerializeField] GameObject eggInt;

    //variables storing the total collectible count by scene
    private int TestScene = 1;
    [SerializeField] int LevelOne = 2;
    [SerializeField] int LevelTwo = 3;
    [SerializeField] int LevelThree = 4;
    [SerializeField] int LevelFour = 5;

    //Warning Text variables
    public Text warningText;
    public Text warningText2;
    public Text warningText3;
    public Text warningText4;
    public Text warningText5;
    //private float timeappear = 6f;
    //private float disapear;

    private void Awake()
    {
        strokeText.text = "Strokes 0";
        //to get the stroke from GameObject containing LineForce script
        updateStrokeOnHit = strokeInt.GetComponent<LineForce>();

        //to get the egg collected count from GameObject containing Player script
        updateCollectibleCount = eggInt.GetComponent<Player>();

        eggText.text = "Sunny-Side Up Eggs Found 0/" + TestScene;

        //intializing the starting total collectible count
        if (SceneManager.GetActiveScene().buildIndex == 2)
            eggText.text = "Sunny-Side Up Eggs Found 0/" + LevelOne;
        if (SceneManager.GetActiveScene().buildIndex == 3)
            eggText.text = "Sunny-Side Up Eggs Found 0/" + LevelTwo;
        if (SceneManager.GetActiveScene().buildIndex == 4)
            eggText.text = "Sunny-Side Up Eggs Found 0/" + LevelThree;
        /*if (SceneManager.GetActiveScene().buildIndex == 5)
            eggText.text = "Sunny-Side Up Eggs Found 0/" + LevelFour;*/
    }

    private void Start()
    {
        warningText.enabled = false;
        warningText2.enabled = false;
        warningText3.enabled = false;
        warningText4.enabled = false;
        warningText5.enabled = false;   
    }

    private void Update()
    {
        SetUIText();
        Warnings();
    }

    public void SetUIText()
    {
        stroke = updateStrokeOnHit.strokeCount;
        strokeText.text = "Strokes " + stroke.ToString();

        eggCollected = updateCollectibleCount.eggCount;

        eggText.text = "Sunny-Side Up Eggs Found " + eggCollected.ToString() + "/" + TestScene;

        //updates collectibles with max collectibles based on current buildIndex
        if (SceneManager.GetActiveScene().buildIndex == 2)
            eggText.text = "Sunny-Side Up Eggs Found " + eggCollected.ToString() + "/" + LevelOne;
        if (SceneManager.GetActiveScene().buildIndex == 3)
            eggText.text = "Sunny-Side Up Eggs Found " + eggCollected.ToString() + "/" + LevelTwo;
        if (SceneManager.GetActiveScene().buildIndex == 4)
            eggText.text = "Sunny-Side Up Eggs Found " + eggCollected.ToString() + "/" + LevelThree;
        /*if (SceneManager.GetActiveScene().buildIndex == 5)
            eggText.text = "Sunny-Side Up Eggs Found " + eggCollected.ToString() + "/" + LevelFour;*/
    }
  private void Warnings()
    {
        if (strokeText.text == "Strokes 10")//&& true
        {
            warningText.enabled = true;
            print("text was enabled");
            //Invoke("Disapearableation", 6f);
   
            //warningText.enabled= false;
        }
        else
        {
            warningText.enabled = false;
            print("Text was disabled");
        }
        
        if (strokeText.text == "Strokes 11")
        {
            warningText2.enabled = true;
            print("text was enabled");
            
        }
        else
        {
            warningText2.enabled = false;
            print("Text was disabled");
        }
        if (strokeText.text == "Strokes 12")
        {
            warningText3.enabled = true;
            print("text was enabled");
            
        }
        else
        {
            warningText3.enabled = false;
            print("Text was disabled");
        }
        if (strokeText.text == "Strokes 13")
        {
            warningText4.enabled = true;
            print("text was enabled");
            
        }
        else
        {
            warningText4.enabled = false;
            print("Text was disabled");
        }
        if (strokeText.text == "Strokes 14")
        {
            warningText5.enabled = true;
            print("text was enabled");
           

        }
        else
        {
            warningText5.enabled = false;
            print("Text was disabled");
        }

    }
    public void Disapearableation()
    {
        if(warningText.enabled==true)
        {
            warningText.enabled = false;
        }
        
    }
    public void Disapearableation2()
    {
        warningText2.enabled = false;
    }
    public void Disapearableation3()
    {
        warningText3.enabled = false;

    }
    public void Disapearableation4()
    {
        warningText4.enabled = false;
    }
    public void Disapearableation5()
    {
        warningText5.enabled = false;
    }
}
