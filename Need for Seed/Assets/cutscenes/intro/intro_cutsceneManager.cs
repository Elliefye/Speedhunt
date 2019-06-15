using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_cutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator[] cars;
    private int whichTake;
    public void playTake()
    {
        if(whichTake == 0)
        {
            cars[0].Play("cutscene1");
        }
        else if(whichTake == 1)
        {
            cars[1].Play("cutscene2");
            cars[0].Play("cutscene2");
        }
        else if(whichTake == 2)
        {
            cars[1].Play("cutscene3");
            cars[0].Play("cutscene3");
            cars[2].Play("cutscene3");
        }
        else if(whichTake == 3)
        {
            cars[1].Play("cutscene4");
            cars[0].Play("cutscene4");
            cars[2].Play("cutscene4");
        }
        whichTake++;
    }
}
