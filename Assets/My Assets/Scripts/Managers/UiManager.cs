using System.Collections;
using System.Collections.Generic;
using GD.Audio;
using UnityEngine;

// code in this script is based off code from this video (Pandemonium (2022). Unity 2D Platformer for Complete Beginners - #14 GAME OVER. YouTube. Available at: https://www.youtube.com/watch?v=3tQSAtaSwvc&list=PLgOEwFbvGm5o8hayFB6skAfa8Z-mw4dPV&index=15 [Accessed 25 Oct. 2023].)
public class UiManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainUi;

    [SerializeField]
    private GameObject exitButton;

    [SerializeField] 
    private GameObject inventoryScreen;

    [SerializeField]
    private GameObject clipBoard1;

    void Awake()
    {
        MainGameOpen();
    }

    public void InventoryOpen()
    {
        inventoryScreen.SetActive(true);
        exitButton.SetActive(true);
        mainUi.SetActive(false);
    }

    public void CB1Open()
    {
        clipBoard1.SetActive(true);
        exitButton.SetActive(true);
        mainUi.SetActive(false);
    }

    public void MainGameOpen()
    {
        mainUi.SetActive(true);
        exitButton.SetActive(false);
        clipBoard1.SetActive(false);
        inventoryScreen.SetActive(false);
    }
}