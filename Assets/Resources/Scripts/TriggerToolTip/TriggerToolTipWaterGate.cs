using UnityEngine;
using System.Collections;

public class TriggerToolTipWaterGate : TriggerTooltip {
    new protected void Start()
    {
        base.Start();

        string[] newTags =
        {
        "interactable",
        "nextState"
        };

        setTags(newTags);
    }

    protected override void hitOptional(RaycastHit hit) {
        base.hitOptional(hit);

        if (hit.transform.gameObject.CompareTag("nextState")) {
            GameObject.Find("OVRPlayerController").SendMessage("nextStep");
            hit.transform.tag = "interactable"; // turn it into a regular interactable object
        }
    }
}
