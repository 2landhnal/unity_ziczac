using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public static ColorChange instance;
    public Material mat;
    public float transTime;
    public float timeLeft;
    public Vector2 r, g, b;
    private Color targetColor;
    public Color startColor;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        mat.color = startColor;
        targetColor = new Color(Random.Range(r.x, r.y), Random.Range(g.x, g.y), Random.Range(b.x, b.y));
        //targetColor = Color.HSVToRGB(targetColor.r, targetColor.g, targetColor.b);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pressSpace");
            if(timeLeft <=0 )
                timeLeft = transTime;
        }
        if (timeLeft > 0)
        {
            switchColor();
        }
    }

    public void switchColor()
    {
        if (timeLeft <= Time.deltaTime)
        {
            mat.color = targetColor;
            targetColor = new Color(Random.Range(r.x, r.y), Random.Range(g.x, g.y), Random.Range(b.x, b.y));
            timeLeft = 0;
        }
        else
        {
            timeLeft -= Time.deltaTime;
            mat.color = Color.Lerp(mat.color, targetColor, Time.deltaTime / timeLeft);
        }
    }
}
