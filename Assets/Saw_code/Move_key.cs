﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// 23/2/13
/// 수정사항
/// 페널티 방식 수정 -3 => 시간가속
/// </summary>
public class Move_key : MonoBehaviour
{
    public float speed;
    public bool isCollision = false;
    public bool limit_trigger = false;
    public bool limit_trigger2 = false;
    public bool limit_trigger3 = false;
    
    //게임진행 조건설정
    public static bool round1_end = false;
    public static bool round2_end = false;
    public static bool round3_end = false;

    public static bool isround1 = true;
    public static bool isround2;
    public static bool isround3;

    public static bool camera1 = false;
    public static bool camera2 = false;
    
    public static float count_time = 0; //수정필요

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        isround2 = false;
        isround3 = false;
    }
    private void Update()
    {
        if(isround1 == true) round1();
        if(isround2 == true) round2();
        if(isround3 == true) round3();
    }
    private void FixedUpdate()
    {
        Move();
        Game_rule();
    }

    void Move() //메인 오브젝트 이동함수
    {
        if (Input.GetKey(KeyCode.UpArrow)) transform.Translate(Vector3.forward * speed * Time.unscaledDeltaTime);
        if (Input.GetKey(KeyCode.DownArrow)) transform.Translate(Vector3.back * speed * Time.unscaledDeltaTime);
        if (Input.GetKey(KeyCode.A)) transform.Translate(Vector3.left * speed * Time.unscaledDeltaTime);
        if (Input.GetKey(KeyCode.D)) transform.Translate(Vector3.right * speed * Time.unscaledDeltaTime);
    }

    private void OnTriggerEnter(Collider other) //충돌감지 함수
    {
        //게임완료 조건
        if (other.tag == "end_point") round1_end = true;
        if (other.tag == "end_map2") round2_end = true;
        if(other.tag == "end_map3") round3_end = true;
        ///맵 탈출방지, 충돌확인
        if (other.tag == "wall") isCollision = true;
        if (other.tag == "saw_limit") limit_trigger = true;
        if (other.tag == "saw_limit2") limit_trigger2 = true;
        if (other.tag == "saw_limit3") limit_trigger3= true;
    }
    /// <summary>
    //게임 라운드 함수
    //3라운드로 구성되며 라운드 시작 및 종료 확인 bool함수를 사용하여 성공, 실패, 타임아웃 조건에 맞게 다음 라운드로 이동
    //다음 라운드로 넘어간 경우 이전 라운드 변수값(시간제한, 성공여부)을 모두 초기화 하여 원활한 게임진행 가능
    public void round1()
    {
        if (UI_control.playtime <= 0 && isround1 == true)
        {
            round1_end = true;
            isround2 = true;
        }
        if (round1_end == true) isround2 = true;
    }

    public void round2() //2라운드
    {
        isround1 = false;
        if (round1_end == true)
        {
            //Debug.Log("round2 start");
            transform.position = new Vector3(-35.253f, 4.8321f, 25.077f);
            UI_control.playtime = 30;
            camera1 = true;
            round1_end = false;

        }
        if (round2_end == true) isround3 = true;

        if (UI_control.playtime <= 0 && isround2 == true)
        {
            round2_end = true;
            isround3 = true;
        }
    }

    public void round3() //3라운드
    {
        isround2 = false;
        if (round2_end == true)
        {
            transform.position = new Vector3(-53.2738f, 9.0114f, 41.6798f);
            UI_control.playtime = 30;
            camera2 = true;
            round2_end = false;
        }
        if (UI_control.playtime <= 0 && isround3 == true)
        {
            SceneManager.LoadScene("Main_menu", LoadSceneMode.Single);
            round3_end = false;
            isround1 = true;
        }
        if (round3_end == true)
        {
            SceneManager.LoadScene("Main_menu", LoadSceneMode.Single);
            round3_end = false;
            isround1 = true;
        }
    }
    /// </summary>



    /// <summary>
    /// 페널티 및 게임 조건함수
    /// 라인을 이탈하는 경우 위치 초기화 및 시간 페널티(3초) 부과

    public void Game_rule() //벽에 닿으면 시간가속 및 위치 초기화
    {
        if(isCollision == true)
        {
            StartCoroutine(Tigger_start(3.0f));
            isCollision = false;
        }
        if(limit_trigger == true)
        {
            transform.position = new Vector3(-60.3598f, 14.071f, 33.196f);
            limit_trigger = false;
        }
        if(limit_trigger2 == true)
        {
            transform.position = new Vector3(-35.253f, 4.8321f, 25.077f);
            limit_trigger2 = false;
        }
        if(limit_trigger3 == true)
        {
            transform.position = new Vector3(-53.2738f, 9.0114f, 41.6798f);
            limit_trigger3 = false;
        }
    }

    IEnumerator Tigger_start(float delay)
    {
        Time.timeScale = 4;
        while (delay > 1.0f)
        {
            delay -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        Time.timeScale = 1;
    }

    /// </summary>
}
