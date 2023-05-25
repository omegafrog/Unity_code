using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor_move : MonoBehaviour
{
    // Start is called before the first frame update
    public float object_speed;
    public int i;
    public static float count;

    public static bool Squence_run;
    public bool object_tr;
    public static bool timer_start;

    void Start()
    {
        i = 10;
        count = 0;
        object_speed = 3.0f;
        object_tr = false;
        timer_start = false;
        Squence_run = true;
    }

    void Update()
    {
        i++;
        if(Squence_run) Squence(i);
        Move();
        Timer();
        
        //Debug.Log(Squence(i));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "conveyor_dt") transform.position = new Vector3(-4.274f, 1.26f, -1.788f);
        if (other.tag == "conveyor_start") timer_start = true; //오브젝트 출발 확인

    }

    public void Timer() //반응속도 측정 타이머
    {
        count = 0;
        if (timer_start)
        {
            count += Time.deltaTime;
            //Debug.Log(count);
        }
    }

    void Move() //오브젝트 이동 제어
    {
        if(Squence(i) == true)
        {
            Squence_run = false;
            transform.Translate(Vector3.right * object_speed * Time.deltaTime);
        }
    }

    public bool Squence(int num)
    {
        for(int i = 2; i*i<=num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}
