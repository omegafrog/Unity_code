using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor_move : MonoBehaviour
{
    // Start is called before the first frame update
    public static Renderer sr;
    public GameObject ob;
    
    
    public float object_speed;
    public int i;
    public static float count;

    public bool object_tr;
    public static bool timer_start;

    void Start()
    {   
        sr = ob.GetComponent<Renderer>();
        i = 13;
        count = 0;
        object_speed = 5.0f;
        object_tr = false;
        timer_start = false;
    }

    void Update()
    {
        Squence(i);
        Move();
        Timer();
        if(object_tr) Color_cg();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "conveyor_dt")
        {
            transform.position = new Vector3(-4.274f, 1.26f, -1.788f);
            object_tr =true;
            i++;
        }
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
         transform.Translate(Vector3.right * object_speed * Time.deltaTime);
    }

    void Color_cg()
    {
        if (i % 2 == 0) sr.material.color = Color.yellow;
        if (i % 3 == 1) sr.material.color = Color.blue;
        if(Squence(i)) sr.material.color = Color.red;
    }

    public bool Squence(int num)
    {
        for(int i = 2; i*i<=num; i++)
        {
            if (num % i == 0)
            {
                return false;
            } 
        }
        return true;
    }
}
