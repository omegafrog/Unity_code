using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_UI : MonoBehaviour
{
    public GameObject Panel;

    public Text user_ID;

    public Text Maze_count;
    public Text Maze_opt;
    public Text Maze_time;

    public Text Saw_counter;
    public Text Saw_opt;

    public Text Cov_count;
    public Text Cov_opt;
    public Text Cov_avr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        menu_ID();
        Maze_OP();
        Saw_OP();
        Conveyor_OP();
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
    public void Saw_tuto()
    {
        Panel.SetActive(false);
        SceneManager.LoadScene("Saw_tuto", LoadSceneMode.Single);
    }

    public void Menu_Conveyor()
    {
        Panel.SetActive(false);
        SceneManager.LoadScene("Conveyor_test", LoadSceneMode.Single);
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 

    public void menu_ID()
    {
        user_ID.text = "ID: 2017112234";
    }

    /// <summary>
    ///
    /// 메뉴 결과창
    public void Maze_OP()
    {
        Maze_count.text = "충돌횟수: " + Maze_move.Trigger_Count + "번";
        Maze_time.text = "진행시간: " + Mathf.Round(Maze_UI.Maze_timer) + "초";
        if (Maze_move.Trigger_Count < 2 && Maze_move.Trigger_Count == 0) Maze_opt.text = "결과: 통과";
        else Maze_opt.text = "결과: 실패";
    }
    public void Saw_OP()
    {
        Saw_counter.text = "진행시간: " + Mathf.Floor(Move_key.avr_time / 3f * 100f) / 100f + "초";
        if (Move_key.timeout < 1) Saw_opt.text = "결과: 통과";
        else Saw_opt.text = "결과: 실패";
    }
    public void Conveyor_OP()
    {
        Cov_count.text = "실패횟수: " + Conveyor_button.err_count + "번";
        Cov_avr.text = "평균 반응속도: " + Conveyor_button.save_time + "ms";
        Cov_opt.text = "결과: 통과";
    }
    /// </summary>
    

}
