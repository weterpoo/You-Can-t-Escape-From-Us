using UnityEngine;
using System.Collections;

public class Interactable_Lobby : Interactable
{
    // Make sure OVRPlayerController's RigidBody's Gravity is off
    int tutorialMenu = 0;
    GameObject menu;

    new void Start()
    {
        base.Start();

        menu = GameObject.Find("tv_1");
    }

    new void Update()
    {

        base.Update();

        if (Input.GetButtonDown("Fire1") && tutorialMenu == 0)
        {
            menu.SetActive(false);
            tutorialMenu += 1;
        }
    }
}
