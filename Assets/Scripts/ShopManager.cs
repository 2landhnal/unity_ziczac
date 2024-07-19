using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int gem;
    public static ShopManager instance;
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

    public void UpdateGem()
    {
        if (PlayerPrefs.HasKey("Gem"))
        {
            gem += PlayerPrefs.GetInt("Gem");
            PlayerPrefs.SetInt("Gem", gem);
        }
        else
        {
            PlayerPrefs.SetInt("Gem", gem);
        }
    }
}
