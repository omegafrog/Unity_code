using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LoginView;
    public InputField inputField_ID;
    public InputField inputField_PW;
    public Button Button_Login;

    private string id;
    private string password;

    void Start()
    {
        id = "dmlwls";
        password = "1234";
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Login_click()
    {
        if(inputField_ID.text == id && inputField_PW.text == password)
        {
            SceneManager.LoadScene("Main_menu", LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("로그인 실패");
        }
    }
}
