using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class non_tartget : MonoBehaviour
{
    public float object_speed;
    // Start is called before the first frame update
    void Start()
    {
        object_speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.right * object_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "conveyor_dt") transform.position = new Vector3(-4.274f, 1.26f, -1.788f);

    }
}
