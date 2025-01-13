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
        start = false;
    }

    void Update()
    {
        if (start)
        {
            timer += Time.deltaTime;
        }
    }

    public void setUI()
    {
        textUi.text = $"Time: {timer:F2} seconds";
    }

    public void startGame()
    {
        start = true;
    }
}
