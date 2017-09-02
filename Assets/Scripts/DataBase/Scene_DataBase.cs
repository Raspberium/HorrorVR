using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Scene_DataBase : ScriptableObject {

    public string TitleSceneName;
    public string GameOverSceneName;

    [System.Serializable]
    public class GameScene {

        public string[] SceneNames;
    }


}
