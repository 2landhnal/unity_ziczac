using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody theRB;
    public float moveSpeed;
    private bool movingLeft, firstInput = true;
    public static CarController instance;
    private float startingY;

    public GameObject pickUpEffect;

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
            if (transform.position.y < startingY - .05f)
            {
                GameManager.instance.GameOver();
                theRB.velocity = new Vector3(theRB.velocity.x, -Mathf.Abs(theRB.velocity.y), theRB.velocity.z);
            }
            else if (transform.position.y > startingY)
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
        else
        {
            AudioController.instance.playTrack(0);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Diamond")
        {
            Instantiate(pickUpEffect, other.transform.position, other.transform.rotation);
            AudioController.instance.playTrack(1);
            GameManager.instance.gem++;
            Destroy(other.gameObject);
        }
    }
}
