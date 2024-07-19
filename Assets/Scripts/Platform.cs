using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject diamond;

    // Start is called before the first frame update
    void Start()
    {
        int rate = Random.Range(0, 100);
        if(rate < 10)
        {
            Vector3 diamondPos = transform.position;
            diamondPos.y += 2.5f;
            Instantiate(diamond, diamondPos, diamond.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            Invoke("Fall", 1f);
        }
    }
    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 3f);
    }
}
