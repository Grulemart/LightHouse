using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    //Set this to the "Menu Father"
    public GameObject MenuImage;

    //Amount of money, maybe this should be in another script but you can change later.
    public static int Money = 5;

    //Upgrade Values.
    public static int LightUpgradeNumber = 1;

    //Not Enough Money Image.
    public GameObject NotEnoughMoney;

    //Are you sure Mini-Menu (1 button and 1 text for confirm buy)
    public GameObject EnoughMoney;

    //Confirm buy private values.
    private string NewUpgrade;

    void Start()
    {
        //Makes the Menu doesnt show at the start.
        MenuImage.SetActive(false);
        EnoughMoney.SetActive(false);
        NotEnoughMoney.SetActive(false);

        //Reseting Upgrade Private Value. 
        NewUpgrade = null;
    }


    void Update()
    {

    }


    //Set in Event Trigger / On Click of a button for oppening menu.
    public void ActivateMenu()
    {
        MenuImage.SetActive(true);
        //Pause
        Time.timeScale = 0;
    }

    //Set in Event Trigger / On Click of a button for closing menu.
    public void DisableMenu()
    {
        MenuImage.SetActive(false);
        //Un-Pause
        Time.timeScale = 1;
    }

    //PUBLICS VOIDS FOR ALL BUTTONS IN MENU

    //Example: Buy more lighthouse light radius.
    public void LightUpgrade()
    {
        if(Money >= 10)
        {
            //Set On The Confirm Buy Mini-Menu
            EnoughMoney.SetActive(true);

            //Saves this for confirm in PUBLIC VOID CONFIRMBUY.
            NewUpgrade = "LightUpgrade";
        }
        else
        {
            NotEnoughMoney.SetActive(true);
        }
    }

    //Put a button in confirm buy Mini-Menu with a event trigger that activates this.
    public void ConfirmBuy()
    {
        if(NewUpgrade == "LightUpgrade")
        {
            Money -= 10;
            //Upgrade a value for Light radius etc...
        }

        //Just copy and paste
        else if (NewUpgrade == "Example")
        {
            Money -= 6;
            //Upgrade a value for Light radius etc...
        }
    }



    //You can copy and paste this and change void name and the money values,
    //and NewUpgrade name.
    
    
    /*public void LightUpgrade()
    {
        if (Money >= 10)
        {
            //Set On The Confirm Buy Mini-Menu
            EnoughMoney.SetActive(true);

            //Saves this for confirm in PUBLIC VOID CONFIRMBUY.
            NewUpgrade = "LightUpgrade";
        }
        else
        {
            NotEnoughMoney.SetActive(true);
        }
    }*/
}
