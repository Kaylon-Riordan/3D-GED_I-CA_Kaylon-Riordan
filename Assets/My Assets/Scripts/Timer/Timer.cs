using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer = 0f;
    private bool start;

    [SerializeField]
    private TextMeshProUGUI textUi;

    private void Awake()
    {
        // have timer off when start menu appears
        start = false;
    }

    void Update()
    {
        // if timer has started, update by delta time each frame
        if (start)
        {
            timer += Time.deltaTime;
        }
    }

    // return text to ui
    public void setUI()
    {
        // make time into a formated string
        textUi.text = $"Time: {timer:F2} seconds";
    }

    public void startGame()
    {
        // start timer
        start = true;
    }
}
