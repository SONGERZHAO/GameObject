using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;



public class PlayerScript : MonoBehaviour {

    private Rigidbody player;
    private int mark;
    private float time;
    private GameObject gameobject;
    private GameData gamedata;
    private int minute = 0;
    private int second = 0;
    private int millisecond = 0;
    private Score tmp;


    public float speed;
    public Text mark_text;
    public Text game_over;
    public Text game_time;

    public GameObject pause1;
    public GameObject pause2;
    public GameObject button_back;
    public GameObject button_retnum;
    public GameObject button_quit;
    public GameObject panel_breakcharts;
    public GameObject inputfile;
    public GameObject button_add;
    public GameObject button_retnum2;





    void Start ()
    {

        player = GetComponent<Rigidbody>();
        mark = 0;
        tmp.player = "";
        tmp.time = 0.0f;
        mark_text.text ="Mark : " + mark.ToString();
        game_over.text = "";

        time = 0.0f;
        game_time.text = "Time : " + minute.ToString() + "'" + second.ToString() + "'" 
            + millisecond.ToString();
        gameobject = GameObject.Find("GameData");
        gamedata = gameobject.GetComponent<GameData>();
        pause1.SetActive(false);
        pause2.SetActive(false);
        button_back.SetActive(false);
        button_quit.SetActive(false);
        button_retnum.SetActive(false);


        panel_breakcharts.SetActive(false);
        inputfile.SetActive(false);
        button_add.SetActive(false);
        button_retnum2.SetActive(false);



    }


    void Update()
    {
        
        float left_right = Input.GetAxis("Horizontal");//水平方向移动
        float front_back = Input.GetAxis("Vertical");//竖直方向移动
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC");
            pause1.SetActive(true);
            pause2.SetActive(true);
            button_back.SetActive(true);
            button_quit.SetActive(true);
            button_retnum.SetActive(true);
            Time.timeScale = 0;
        }
        Vector3 position = new Vector3(left_right,0.0f,front_back);
        player.AddForce(position * speed);


        time += Time.deltaTime;
        minute = (int)time / 60;
        second = (int)time - minute * 60;
        millisecond = (int)((time - (int)time) * 100);
        game_time.text = "Time : " + minute.ToString() + "'" + second.ToString() + "'"
                        + millisecond.ToString();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("food"))
        {
            other.gameObject.SetActive(false);
            mark++;
            mark_text.text = "Mark : " + mark.ToString();
            if (mark >= 1)
            {
                Time.timeScale = 0;
                SortCharts(); 
            }
        }
    }


    private void SortCharts()
    {
        if (gamedata.scorelist.Count < 10)
        {
            GetName();
        }
        else
        {
            Score last = gamedata.scorelist[9];
            if (time < last.time)
            {
                GetName();
            }
            else
            {
                game_over.text = "You Are Winer";
                button_retnum2.SetActive(true);
            }
        }
    }

    private void GetName()
    {
        pause1.SetActive(true);
        panel_breakcharts.SetActive(true);
        inputfile.SetActive(true);
        button_add.SetActive(true);
    }

    public void OnButtonAdd()
    {
        tmp.player += inputfile.GetComponent<InputField>().text;
        tmp.time = time;
        if (gamedata.scorelist.Count == 10)
        {
            gamedata.scorelist[9] = tmp;
        }
        else
        {
            gamedata.scorelist.Add(tmp);
        }
        gamedata.Sort_sez();
        gamedata.WriteCharts();
        Time.timeScale = 1;
        Application.LoadLevel("Start");
    }
    public void OnButtonQuit()
    {
        Application.Quit();
    }
    public void OnButtonBack()
    {
        pause1.SetActive(false);
        pause2.SetActive(false);
        button_back.SetActive(false);
        button_quit.SetActive(false);
        button_retnum.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnButtonRetnum()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Start");
    }
}


