using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource[] gameMusics;
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

    public void playTrack(int num)
    {
        gameMusics[num].Stop();
        //gameMusics[num].pitch = Random.Range(0.9f, 1.1f);
        gameMusics[num].Play();
    }
}
