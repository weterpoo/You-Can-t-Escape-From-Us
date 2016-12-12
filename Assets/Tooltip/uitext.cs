using UnityEngine;
using System.Collections;

public class uitext : MonoBehaviour {
    public string text;
    public string imagePath;
    public float textAnimationTime = 1f;
    public float timeShown = 1f;
    public float fadeTime = 0.5f;

    public bool showOnStart = false;

    GameObject imageRef;
    GameObject textRef;
    GameObject panelRef;

    private float Delay;

    void show()
    {
        StartCoroutine(asyncShow());
    }

    void hide()
    {
        StartCoroutine(asyncHide());
    }

    void setText(string newText)
    {
        textRef.GetComponent<UnityEngine.UI.Text>().text = newText;
        show();
    }

    // Use this for initialization
    void Start () {
        panelRef = transform.FindChild("Panel").gameObject;
        imageRef = panelRef.transform.FindChild("Image").gameObject;
        if (imagePath != "")
            imageRef.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load(imagePath, typeof(Sprite)) as Sprite;
        textRef = panelRef.transform.FindChild("Text").gameObject;
        textRef.GetComponent<UnityEngine.UI.Text>().text = "";

        textRef.GetComponent<UnityEngine.UI.Text>().CrossFadeAlpha(0, 0.0f, false);
        imageRef.GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(0, 0.0f, false);
        panelRef.GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(0, 0.0f, false);

        /* Start as example */
        if (showOnStart)
            show();

    }

    // Update is called once per frame
    void Update () {
	
	}
    
    IEnumerator asyncHide()
    {
        textRef.GetComponent<UnityEngine.UI.Text>().CrossFadeAlpha(1, 0.0f, false);
        imageRef.GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(1, 0.0f, false);
        panelRef.GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(1, 0.0f, false);
        yield return new WaitForSeconds(timeShown);

        textRef.GetComponent<UnityEngine.UI.Text>().CrossFadeAlpha(0, fadeTime, false);
        imageRef.GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(0, fadeTime, false);
        panelRef.GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(0, fadeTime, false);
        yield return new WaitForSeconds(fadeTime);

       // Destroy(this.transform.gameObject);
    }

    IEnumerator asyncShow()
    {
        yield return new WaitForSeconds(fadeTime);

        textRef.GetComponent<UnityEngine.UI.Text>().CrossFadeAlpha(1, fadeTime, false);
        imageRef.GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(1, fadeTime, false);
        panelRef.GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(1, fadeTime, false);
        yield return new WaitForSeconds(fadeTime);

        StartCoroutine(writeText(textRef.GetComponent<UnityEngine.UI.Text>(), text));
    }

    IEnumerator writeText(UnityEngine.UI.Text textUI, string txt)
    {
        // Slight pause before beginning
        Delay = textAnimationTime / txt.Length; 
        yield return new WaitForSeconds(Delay);

        textUI.text = "";

        for (int i = 0; i < txt.Length; i++)

        {
            textUI.text += txt[i];
            panelRef.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(Delay);
        }

        StartCoroutine(asyncHide());
    }
}
