using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conveyor_button : MonoBehaviour
{
    public float move_speed = 2.0f;
    public float save_time;
    // Start is called before the first frame update
    void Start()
    {
        save_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Conveyor_UI.UI_check == true) Button_press();
    }

    void Button_press()
    {
        if (Input.GetMouseButtonDown(0)) //버튼 입력확인
        {
            save_time += Conveyor_move.count;
            StartCoroutine(buttonpress(1.0f));
            Debug.Log(save_time);
        }
    }
    IEnumerator buttonpress(float delay) //버튼 입력시 효과
    {
        transform.localPosition = new Vector3(0f, 0.4f, 0f);
        while (delay > 0.5f)
        {
            delay -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        transform.localPosition = new Vector3(0f, 0.5f, 0f);
    }
}
