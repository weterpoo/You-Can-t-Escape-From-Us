using UnityEngine;
using System.Collections;

public class TriggerTooltip : MonoBehaviour
{
    public uitext txt;
    GameObject forwardReferencer;
    GameObject forwardPosition;

    public float raycastDist = -1.0f; // Negative if distance should be infinity

    protected string[] validTags =
    {
        "interactable"
    };

    protected void setTags(string[] newTags) {
        validTags = newTags;
    }

    // Use this for initialization
    protected void Start()
    {
        forwardReferencer = GameObject.Find("RightEyeAnchor");
        forwardPosition = GameObject.Find("CenterEyeAnchor");

        if (raycastDist < 0f)
            raycastDist = Mathf.Infinity;

    }

    protected virtual void hitOptional(RaycastHit hit)
    {
        /**
         * Do extra with whatever was hit...
         * 
         */
        foreach (string tag in validTags)
        {
            if (hit.transform.gameObject.CompareTag(tag))
            {
                hit.transform.SendMessage("displayFact");
            }
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        RaycastHit hit;
        RaycastHit looking;
        Vector3 rayStart = forwardPosition.transform.position;
        Vector3 rayEnd = forwardReferencer.transform.forward;
        Ray myRay = new Ray(rayStart, rayEnd);

        // Debug.Log(this.transform.forward);
        if (Physics.SphereCast(myRay, 1.0f, out looking, raycastDist, 1 << LayerMask.NameToLayer("interactable")))
        {
            Debug.Log(looking.transform.gameObject.name);
            foreach (string tag in validTags)
            {
                if (looking.transform.gameObject.CompareTag(tag))
                {
                    looking.transform.SendMessage("showRayCast");
                }
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.SphereCast(myRay, 1.0f, out hit, raycastDist, 1 << LayerMask.NameToLayer("interactable")))
            {
                hitOptional(hit);
            }
        }

    }

}
