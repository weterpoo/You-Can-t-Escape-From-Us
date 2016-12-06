using UnityEngine;
using System.Collections;

public class TriggerTooltipLobby : TriggerTooltip
{
    new protected void Start() {
        base.Start();
        string[] newTags = 
        {
            "interactable",
            "caesar",
            "egypt_painting",
            "puzzle_painting"
        };

        setTags(newTags);
    }
}