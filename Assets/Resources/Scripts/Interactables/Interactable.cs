using UnityEngine;
using System.Collections;

public class Interactable: MonoBehaviour {
    // Make sure OVRPlayerController's RigidBody's Gravity is off
    Material oldMaterial;
    Material newMaterial;
    Color colorHighlight;
    Color colorInteractable;
    GameObject player;
    bool greenMaterialSet = false;
    bool orangeMaterialSet = false;
    bool noMaterialSet = true;
    bool playerLooking = false;

    public float detectionDist = 20.0f;


    void displayFact()
    {
        GameObject tt = transform.Find("newtooltip").gameObject;
        tt.SendMessage("show");
    }

    void showRayCast()
    {
        playerLooking = true;
    }
    // Use this for initialization
    protected void Start () {
        // this.GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
        oldMaterial = this.GetComponent<Renderer>().material;
        newMaterial = Instantiate(this.GetComponent<Renderer>().material);
        newMaterial.shader = Shader.Find("Outlined/Silhouetted Bumped Diffuse Orange");

        player = GameObject.Find("CenterEyeAnchor");

        colorHighlight = new Color(.988f, .694f, .184f, 1);
        colorInteractable = new Color(.5647f, .9333f, .5647f, 1);
    }

    // Update is called once per frame
    float calcDistance(Vector3 p1, Vector3 p2)
    {
        Vector3 diff = p1 - p2;
        return diff.sqrMagnitude;
    }

	protected void Update () {
	    if (calcDistance(this.transform.position, player.transform.position) < detectionDist) {
            if ((noMaterialSet || orangeMaterialSet) && !greenMaterialSet && playerLooking)
            {
                newMaterial.SetColor("_OutlineColor", colorInteractable);
                this.GetComponent<Renderer>().material = newMaterial;
                noMaterialSet = false;
                greenMaterialSet = true;
                orangeMaterialSet = false;
            }
            else if ((noMaterialSet || greenMaterialSet) && !orangeMaterialSet && !playerLooking)
            {
                newMaterial.SetColor("_OutlineColor", colorHighlight);
                this.GetComponent<Renderer>().material = newMaterial;
                noMaterialSet = false;
                greenMaterialSet = false;
                orangeMaterialSet = true;
            }
        } else {
            if (greenMaterialSet || orangeMaterialSet && !noMaterialSet)
            {
                this.GetComponent<Renderer>().material = oldMaterial;
                greenMaterialSet = false;
                orangeMaterialSet = false;
                noMaterialSet = true;
            }
        }
        playerLooking = false;
	}
}
