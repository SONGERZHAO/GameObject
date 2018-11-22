using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;// 此引用是用于数据的写入与读取 
using System.Text;
using UnityEngine.UI;




public class Charts : MonoBehaviour {
    //1song0'1'23'234
    public Text charts1;
    public Text charts2;
    public Text charts3;

    private void Start()
    {
        GameObject gameobject = GameObject.Find("GameData");
        GameData gamedata = gameobject.GetComponent<GameData>();
        int i = 1;
        string input1 = "";
        string input2 = "";
        string input3 = "";
        int minute = 0;
        int second = 0;
        int millisecond = 0;
        while (i <= gamedata.scorelist.Count)
        {
            input1 += i.ToString();
            input1 += "\n";
            input2 += gamedata.scorelist[i - 1].player;
            input2 += "\n";
            float time = gamedata.scorelist[i - 1].time;
            minute = (int)time / 60;
            second = (int)time - minute * 60;
            millisecond = (int)((time - (int)time) * 100);
            input3 += minute.ToString() + "'" + second.ToString() + "'" + millisecond.ToString();
            input3 += "\n";
            i++;
        }
        charts1.text = input1;
        charts2.text = input2;
        charts3.text = input3;
    }
    public void OnBack(string scene)
    {
        Application.LoadLevel(scene);
    }
    



}
