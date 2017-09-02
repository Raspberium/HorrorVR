using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_DataBase : ScriptableObject{


    public AudioClip GetKeyItem;
    public AudioClip GotAllKeyItem;

    [System.Serializable]
    public class FootStepsBaseClass {
        public FootStepsSoundClass[] FootStepsSound;
    }
    [System.Serializable]
    public class FootStepsSoundClass {
        public AudioClip[] FootStepsSound;
    }
    public FootStepsBaseClass FootSteps;

}
