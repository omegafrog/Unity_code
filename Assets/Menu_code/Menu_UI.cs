using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_UI : MonoBehaviour
{
    public GameObject Panel;
    public Text Maze_output;
    public Text Saw_counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Maze_OP();
        Saw_OP();
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// Maze 기능메뉴
    /// </summary>
    public void Menu_Maze()
    {
        Panel.SetActive(false);
        SceneManager.LoadScene("Maze_test", LoadSceneMode.Single);   
    }
    public void Maze_tuto() {
        Panel.SetActive(false);
        SceneManager.LoadScene("Maze_tuto", LoadSceneMode.Single);
    }
    public void Menu_Saw()
    {
        Panel.SetActive(false);
        SceneManager.LoadScene("Saw_test", LoadSceneMode.Single);
    }
    public void Maze_OP()
    {
        Maze_output.text = "충돌횟수: " + Maze_move.Trigger_Count + "번";
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 
    public void Saw_OP()
    {
        Saw_counter.text = "진행시간: " + Move_key.count_time + "초";
    }
    public void Saw_tuto()
    {
        Panel.SetActive(false);
        SceneManager.LoadScene("Saw_tuto",LoadSceneMode.Single);
    }
}
