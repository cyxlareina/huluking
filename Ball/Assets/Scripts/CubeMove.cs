using UnityEngine;
using System.Collections;
using System;

public class CubeMove : MonoBehaviour
{
    public GameObject Obstacle;
    private float moveSpeed;
    private float angularSpeed;
    private Camera mainCam;

    // Use this for initialization
    void Start()
    {
        mainCam = Camera.main;
        moveSpeed = 1.0f;
        angularSpeed=40;
        generateObstacles();
    }

    private void generateObstacles()
    {
        float minZ=-31,maxZ=45,minX=-21,maxX=21;
       
        for (int i=0;i<15;i++) {
            Instantiate(Obstacle, new Vector3(UnityEngine.Random.Range(minX, maxX),1, UnityEngine.Random.Range(minZ, maxZ) ), Quaternion.identity);


        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime*moveSpeed);
        moveSpeed += 0.01f;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * Time.deltaTime*angularSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime*angularSpeed);
        }
        angularSpeed+=0.1f;
    }
    void LateUpdate()
    {
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, transform.position + new Vector3(0, 1.5f, -5f), Time.deltaTime);
    }
}