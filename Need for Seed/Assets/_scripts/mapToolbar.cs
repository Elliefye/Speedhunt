using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapToolbar : MonoBehaviour
{

    public Text cash;
    public Text heat;
    public Text days;
    public Text pname;

    void Start()
    {
        pname.text = Game.current.name;
        cash.text += Game.current.cash.ToString() + " $";

        if (Game.current.isNight)
            days.text = "NIGHT ";
        else days.text = "DAY ";
        days.text += Game.current.dayNr.ToString();

        if (Game.current.heat <= 3)
        {
            heat.color = new Color32(58, 231, 109, 255);
            heat.text = "LOW";
        }
        else if (Game.current.heat <= 7)
        {
            heat.color = new Color32(231, 190, 58, 255);
            heat.text = "SUSPICIOUS";
        }
        else
        {
            heat.color = new Color32(231, 58, 58, 255);
            heat.text = "DANGEROUS";
        }
    }
}
