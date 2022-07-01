using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public GameData gameData;
    [SerializeField] private Button Skin1;
    [SerializeField] private Button Purple;
    [SerializeField] private Button Red;
    [SerializeField] private Button Metal;
    [SerializeField] private Button Gold;
    [SerializeField] private Button Inv;

    // Start is called before the first frame update
    void Awake()
    {
        Skin1.enabled = false;
        Purple.enabled = false;
        Red.enabled = false;
        Metal.enabled = false;
        Gold.enabled = false;
        Inv.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameData.Skin1)
        {
            Skin1.enabled = true;
        }
        if (gameData.Skin2)
        {
            Purple.enabled = true;
        }
        if (gameData.Skin3)
        {
            Red.enabled = true;
        }
        if (gameData.Skin4)
        {
            Metal.enabled = true;
        }
        if (gameData.Skin5)
        {
            Gold.enabled = true;
        }
        if (gameData.Skin6)
        {
            Inv.enabled = true;
        }

        switch (gameData.CurrentSkin)
        {
            case 1:
                Skin1.Select();
                break;
            case 2:
                Purple.Select();
                break;
            case 3:
                Red.Select();
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
    }

    public void Skin1Click()
    {
        gameData.CurrentSkin = 1;
    }

    public void PurpleClick()
    {
        gameData.CurrentSkin = 2;
    }

    public void RedClick()
    {
        gameData.CurrentSkin = 3;
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
