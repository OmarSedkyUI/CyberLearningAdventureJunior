using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public GameData gameData;
    [SerializeField] private Button VirtualGuy;
    [SerializeField] private Button Lotus;
    [SerializeField] private Button Carnage;
    [SerializeField] private Button Metal;
    [SerializeField] private Button Gold;
    [SerializeField] private Button Inv;

    // Start is called before the first frame update
    void Awake()
    {
        VirtualGuy.interactable = true;
        Lotus.interactable = false;
        Carnage.interactable = false;
        Metal.interactable = false;
        Gold.interactable = false;
        Inv.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameData.Lotus)
        {
            Lotus.interactable = true;
        }
        if (gameData.Carnage)
        {
            Carnage.interactable = true;
        }
        if (gameData.Metal)
        {
            Metal.interactable = true;
        }
        if (gameData.Golden)
        {
            Gold.interactable = true;
        }
        if (gameData.Invisible)
        {
            Inv.interactable = true;
        }

        switch (gameData.CurrentSkin)
        {
            case 0:
                VirtualGuy.Select();
                break;
            case 1:
                Carnage.Select();
                break;
            case 3:
                Lotus.Select();
                break;
            case 4:
                Metal.Select();
                break;
            case 5:
                Gold.Select();
                break;
            case 6:
                Inv.Select();
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (string.IsNullOrEmpty(gameData.LastScene))
            {
                gameData.LastScene = "Level1";
            }
            SceneManager.LoadScene(gameData.LastScene);
        }
    }

    public void VirtualClick()
    {
        gameData.CurrentSkin = 0;
    }

    public void LotusClick()
    {
        gameData.CurrentSkin = 3;
    }

    public void CarnageClick()
    {
        gameData.CurrentSkin = 1;
    }

    public void MetalClick()
    {
        gameData.CurrentSkin = 4;
    }

    public void GoldClick()
    {
        gameData.CurrentSkin = 5;
    }

    public void InvClick()
    {
        gameData.CurrentSkin = 6;
    }
}