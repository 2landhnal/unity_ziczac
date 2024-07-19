using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody theRB;
    public float moveSpeed;
    private bool movingLeft, firstInput = true;
    public static Test instance;
    private float startingY;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        movingLeft = false;
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            if (Input.GetMouseButtonDown(0))
            {
                Rota();
            }
            if (transform.position.y < startingY - .1f)
            {
                GameManager.instance.GameOver();
            }
            else if(transform.position.y > startingY)
            {
                transform.position = new Vector3(transform.position.x, startingY, transform.position.z);
            }
        }

        if (firstInput)
        {

            firstInput = false;
        }
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void Rota()
    {
        if (firstInput)
        {
            firstInput = false;
            return;
        }
        if (movingLeft)
        {
            theRB.rotation = Quaternion.Euler(0, 180, 0);
            movingLeft = false;
        }
        else
        {
            theRB.rotation = Quaternion.Euler(0, -90, 0);
            movingLeft = true;
        }
    }
}
