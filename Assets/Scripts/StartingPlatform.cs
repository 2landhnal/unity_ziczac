using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPlatform : MonoBehaviour
{
    public static StartingPlatform instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void fFall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 3f);
    }
}
