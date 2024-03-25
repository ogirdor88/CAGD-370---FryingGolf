using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//Author: Jackson, Katherine
//Date: 03/14/2024
//Allows the player to switch between scenes

//Future Note: Don'tDestroyOnLoad and arrays will need to be used in the future to store player information

public class Sceneswitch : MonoBehaviour
{
    //player gameobject
    public GameObject player;
    public void Update()
    {
        DontDestroyOnLoad(player);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            SwitchScene();
            print("scene has been changed");
        }
        //player does switch scenes he just goes Out of bounds setting a spawn point might work 

    }
    //handles what scene the player will go into next
    public int newSceneIndex;

    //used to switch to the next depending on what newSceneIndex is
    public void SwitchScene()
    {
        //load the build index that we set newSceneIndex to in Unity
        SceneManager.LoadScene(newSceneIndex);
    }
}
