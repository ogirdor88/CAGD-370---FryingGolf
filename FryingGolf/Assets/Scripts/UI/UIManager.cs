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
    [SerializeField] int LevelOne = 1;
    [SerializeField] int LevelTwo = 1;
    [SerializeField] int LevelThree = 1;
    [SerializeField] int LevelFour = 1;
    [SerializeField] int LevelFive = 6;

    //Warning variables
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject golfBallIdle;
    private bool isBallIdle;
    public Text warningText;
    public Text warningText2;
    public Text warningText3;
    public Text warningText4;
    public Text warningText5;
    [SerializeField] string WarningStroke1 = "Strokes 0";
    [SerializeField] string WarningStroke2 = "Strokes 1";
    [SerializeField] string WarningStroke3 = "Strokes 2";
    [SerializeField] string WarningStroke4 = "Strokes 3";
    [SerializeField] string WarningStroke5 = "Strokes 4";
    [SerializeField] string WarningStrokeDeath = "Strokes 5";
    public TextMeshProUGUI _maxStrokeLimit;

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
        _maxStrokeLimit.text = "Level Limit: " + WarningStrokeDeath;

        //intializing the starting total collectible count
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            eggText.text = "Sunny-Side Up Eggs Found 0/" + LevelOne;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            eggText.text = "Sunny-Side Up Eggs Found 0/" + LevelTwo;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            eggText.text = "Sunny-Side Up Eggs Found 0/" + LevelThree;
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            eggText.text = "Sunny-Side Up Eggs Found 0/" + LevelFour;
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            eggText.text = "Sunny-Side Up Eggs Found 0/" + LevelFive;
        }
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
        isBallIdle = golfBallIdle.GetComponent<LineForce>()._isIdle;
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
        if (SceneManager.GetActiveScene().buildIndex == 5)
            eggText.text = "Sunny-Side Up Eggs Found " + eggCollected.ToString() + "/" + LevelFour;
        if (SceneManager.GetActiveScene().buildIndex == 6)
            eggText.text = "Sunny-Side Up Eggs Found " + eggCollected.ToString() + "/" + LevelFive;
    }
  private void Warnings()
    {
        if(SceneManager.GetActiveScene().buildIndex != 6)
        {
            //First Warning
            if (strokeText.text == WarningStroke1)//&& true
            {
                warningText.enabled = true;
            }
            else
            {
                warningText.enabled = false;

            }
            //Second Warning
            if (strokeText.text == WarningStroke2)
            {
                warningText2.enabled = true;
            }
            else
            {
                warningText2.enabled = false;
            }
            //Third Warning
            if (strokeText.text == WarningStroke3)
            {
                warningText3.enabled = true;
                //print("text was enabled");

            }
            else
            {
                warningText3.enabled = false;
            }
            //Fourth Warning
            if (strokeText.text == WarningStroke4)
            {
                warningText4.enabled = true;
            }
            else
            {
                warningText4.enabled = false;
            }
            //Fifth Warning
            if (strokeText.text == WarningStroke5)
            {
                warningText5.enabled = true;
            }
            else
            {
                warningText5.enabled = false;
            }

            //Last stroke (Death upon returning to idle)
            if (strokeText.text == WarningStrokeDeath && isBallIdle == true)
            {
                deathMenu.SetActive(true);
                Time.timeScale = 0f;
            }
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
