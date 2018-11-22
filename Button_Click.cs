using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Button_Click : MonoBehaviour {

    //private GameObject gameObject;
    private void Start()
    {
        
        GameObject gameObject = GameObject.Find("GameData");
        GameData gamedata = gameObject.GetComponent<GameData>();
        if (gamedata.flag == true)
        {
            gamedata.ReadCharts();
            gamedata.flag = false;
        }
    }
    public void OnStartGame(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void OnQuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void OnCharts(string scene)
    {
        Application.LoadLevel(scene);
    }

   
}
