using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Just flashes the alpha of the text.
[RequireComponent(typeof(Text))]
public class TextAlphaPingPong : MonoBehaviour
{

    public Text text;

    //true is 0 -> 1 and false is 1 -> 0.
    public bool direction;

    public float speed = 10.0f;

    private void Start()
    {
        text = GetComponent<Text>();

        if (text.color.a > 0)
        {
            direction = false;
        }
        else
        {
            direction = true;
        }

    }

    float size;

    // Update is called once per frame
    void Update()
    {
        size += Time.deltaTime;
        float pingPongVal = Mathf.Lerp(0, 1, Mathf.PingPong(size, 1));
        var currentColor = text.color;
        currentColor.a = pingPongVal;
        text.color = currentColor;

    }

}
