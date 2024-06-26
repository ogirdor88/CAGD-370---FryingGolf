using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//Author: Jackson, Katherine  ,Uribe-Hernandez,Fernando(edited)
//Date: 03/14/2024
//Allows the player to switch between scenes

//Future Note: Don'tDestroyOnLoad and arrays will need to be used in the future to store player information

public class Sceneswitch : MonoBehaviour
{
    //player gameobject
    public GameObject player;
    public void Update()
    {
        
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SwitchScene();
            print("Scene has been changed");
            //DestroyImmediate(player);

        }
        //Player does spawn, but goes out of bounds if a spawnPoint is not set 

    }
    private void Awake()
    {
       
        /*GameObject[]golfball=GameObject.FindGameObjectsWithTag("Player");
        if(golfball.Length> 1)
        {
            Destroy(player);
        }
        else
        {
            DontDestroyOnLoad(player);
        }*/
    }
    //Handles what scene the player is placed into next.
    //Is placed on the Goal Check GameObject in the Golf goal post Prefab
    public int newSceneIndex;

    //used to switch to the next depending on what newSceneIndex is
    public void SwitchScene()
    {
        //load the build index that we set newSceneIndex to in Unity
        SceneManager.LoadScene(newSceneIndex);
    }
}
