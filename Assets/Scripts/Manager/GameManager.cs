using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public Scene_DataBase Scene;
    public SE_DataBase SE;
    public ItemSpawner ItemSpawnerScript;

    public TMP_Text RemainingKeyItemsText;


    public int RemainingKeyItems;

    public EscapePoint EscapePointScript;


    public AudioSource Source;

    public Scene GameOverScene;

    // Use this for initialization
    void Start () {
        RemainingKeyItemsUpdate(ItemSpawnerScript.ItemObjects.Length);
    }
	
	// Update is called once per frame
	void Update () {
		
	}




    public void RemainingKeyItemsUpdate(int _num) {

        if (_num == -1) {
            RemainingKeyItems--;
        }
        else {
            RemainingKeyItems = _num;
        }

        //When the got all key_items
        if (RemainingKeyItems == 0) {
            if(RemainingKeyItemsText != null)RemainingKeyItemsText.text = "出口ヘ向カエ";
            GotAllKeyItems();
        }
        else {
            if (RemainingKeyItemsText != null) RemainingKeyItemsText.text = "残リ:" + RemainingKeyItems;
        }
    }




    private void GotAllKeyItems() {
        if(Source && SE) Source.PlayOneShot(SE.GotAllKeyItem);
        if(EscapePointScript) EscapePointScript.CanEscapeOn();
    }




    public void SceneChange_GameOver() {
        if(Scene) SceneManager.LoadScene(Scene.GameOverSceneName);
    }

    public void SceneChange_Title() {
        if (Scene) SceneManager.LoadScene(Scene.TitleSceneName);
    }

}
