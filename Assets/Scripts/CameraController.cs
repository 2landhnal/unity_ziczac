using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = CarController.instance.moveSpeed / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameStarted == true)
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, moveSpeed * Time.deltaTime);
        }
    }
}
