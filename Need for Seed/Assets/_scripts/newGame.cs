using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newGame : MonoBehaviour {

    void Start()
    {

        Game.current = new Game();

        Game.current.isNight = true;
        Game.current.heat = 0;
        Game.current.cash = 200;

        Game.current.mainQuest = 0;

        Game.current.carId = 0;
        Game.current.wheelId = 0;

        Game.current.upgrade1 = 0;
        Game.current.upgrade2 = 0;
        Game.current.upgrade3 = 0;

        Game.current.arrestedCount = 0;
        Game.current.racedCount = 0;
        Game.current.lastArrested = false;
    }
}