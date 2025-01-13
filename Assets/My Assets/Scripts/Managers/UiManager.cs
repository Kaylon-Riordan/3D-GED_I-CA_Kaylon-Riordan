using System.Collections;
using System.Collections.Generic;
using GD.Audio;
using GD.Types;
using UnityEngine;

// code in this script is based off code from this video (Pandemonium (2022). Unity 2D Platformer for Complete Beginners - #14 GAME OVER. YouTube. Available at: https://www.youtube.com/watch?v=3tQSAtaSwvc&list=PLgOEwFbvGm5o8hayFB6skAfa8Z-mw4dPV&index=15 [Accessed 25 Oct. 2023].)
public class UiManager : MonoBehaviour
{
    // Take in all the pannels of the ui
    [SerializeField]
    private GameObject mainUi;

    [SerializeField]
    private GameObject exitButton;

    [SerializeField] 
    private GameObject inventoryScreen;

    [SerializeField]
    private GameObject clipBoard1;

    [SerializeField]
    private GameObject clipBoard2;

    [SerializeField]
    private GameObject clipBoard3;

    [SerializeField]
    private GameObject clipBoard4;

    [SerializeField]
    private GameObject victory;

    [SerializeField]
    private GameObject startMenu;

    [SerializeField]
    [Tooltip("Sound played when clip board is opened")]
    private AudioClip paperSound;

    /// <summary>
    /// Set only the start menu to show when game launches
    /// </summary>
    void Awake()
    {
        startMenu.SetActive(true);
        mainUi.SetActive(false);
        exitButton.SetActive(false);
        clipBoard1.SetActive(false);
        clipBoard2.SetActive(false);
        clipBoard3.SetActive(false);
        clipBoard4.SetActive(false);
        victory.SetActive(false);
        inventoryScreen.SetActive(false);
    }

    // Opens the matching menu and turns off player controles
    public void InventoryOpen()
    {
        inventoryScreen.SetActive(true);
        exitButton.SetActive(true);
        mainUi.SetActive(false);
    }
    public void CB1Open()
    {
        AudioManager.Instance.PlaySound(paperSound, AudioMixerGroupName.SFX);
        clipBoard1.SetActive(true);
        exitButton.SetActive(true);
        mainUi.SetActive(false);
    }
    public void CB2Open()
    {
        AudioManager.Instance.PlaySound(paperSound, AudioMixerGroupName.SFX);
        clipBoard2.SetActive(true);
        exitButton.SetActive(true);
        mainUi.SetActive(false);
    }
    public void CB3Open()
    {
        AudioManager.Instance.PlaySound(paperSound, AudioMixerGroupName.SFX);
        clipBoard3.SetActive(true);
        exitButton.SetActive(true);
        mainUi.SetActive(false);
    }
    public void CB4Open()
    {
        AudioManager.Instance.PlaySound(paperSound, AudioMixerGroupName.SFX);
        clipBoard4.SetActive(true);
        exitButton.SetActive(true);
        mainUi.SetActive(false);
    }
    public void Victorypen()
    {
        victory.SetActive(true);
        mainUi.SetActive(false);
        exitButton.SetActive(false);
        inventoryScreen.SetActive(false);
    }

    /// <summary>
    /// close all menus except the ui overlay when gameplay is happening
    /// </summary>
    public void MainGameOpen()
    {
        mainUi.SetActive(true);
        exitButton.SetActive(false);
        clipBoard1.SetActive(false);
        clipBoard2.SetActive(false);
        clipBoard3.SetActive(false);
        clipBoard4.SetActive(false);
        victory.SetActive(false);
        startMenu.SetActive(false);
        inventoryScreen.SetActive(false);
    }
}