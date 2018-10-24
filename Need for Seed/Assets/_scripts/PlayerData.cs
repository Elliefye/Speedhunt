using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game
{
    public static Game current;
    public string name;
    public bool isNight;

    public bool lost=false;
    public bool checking=false;

    public int heat;
    public int rep;
    public int cash;
    public int dayNr;

    public int mainQuest;
    public int sideQuest1;

    public int carId;
    public int upgrade1;
    public int upgrade2;
    public int upgrade3;
    public int wheelId;
    public Color color;
    public Color wheelcolor;

    public int arrestedCount;
    public int racedCount;
    public bool lastArrested;
}