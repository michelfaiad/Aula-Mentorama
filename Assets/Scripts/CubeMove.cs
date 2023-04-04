using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{

    [SerializeField] float speed = 1f;

    int life = 10;

    // Update is called once per frame
    void Update()
    {
        MoveCube();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            life--;
            if (life <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }

    private void MoveCube()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, 0f, -speed * Time.deltaTime);
        }
    }
}
