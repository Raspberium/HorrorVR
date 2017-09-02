using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public string GameSceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void OnRetryButton() {
        SceneManager.LoadScene(GameSceneName);
    }


}
