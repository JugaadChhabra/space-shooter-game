using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifecounter : MonoBehaviour
{
    public int startinglives;
    private int livesCounter;
    private Text theText;
    void Start()
    {
        theText = GetComponent<Text>();

        livesCounter = startinglives;
    }

    void Update()
    {
        theText.text = "" + livesCounter;
    }

    public void GiveLife()
    {
        livesCounter++;
    }

    public void TakeLife()
    {
        livesCounter--;
    }
}
