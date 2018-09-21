using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    //public variables visable in Unity 
    public TextMesh displayText;

    //private variables cant be touched by other scripts 
    private int currentValue = 0;

    //update both the data value AND the visual display 
    public void ChangeValue(int _toChange)
    {
        currentValue = currentValue + _toChange;
        displayText.text = currentValue.ToString();
    }

}


