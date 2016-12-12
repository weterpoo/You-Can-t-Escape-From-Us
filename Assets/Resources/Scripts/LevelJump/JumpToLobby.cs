using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class JumpToLobby : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "OVRPlayerController")
        {
            SceneManager.LoadScene("lobby_new", LoadSceneMode.Single);
        }
    }
}
