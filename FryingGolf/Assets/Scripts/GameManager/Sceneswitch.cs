using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneswitch : MonoBehaviour
{
    public GameObject Player;
    public GameObject Canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(Canvas);
    }
    private void OnCollisionEnter(Collision collision)
    {
if(collision.gameObject.tag=="Player")
        {
            SceneSwitch( 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneSwitch(int level)
    {
        SceneManager.LoadScene(level);
    }
}
