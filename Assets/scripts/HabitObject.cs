using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitObject
{
    public string habit;
    public int healvalue;
    public int hurtvalue;
    public string lastcared;
    public int timeframe;

    public HabitObject(string habit, int healvalue, int hurtvalue, string lastcared, int timeframe) {
        this.habit = habit;
        this.healvalue = healvalue;
        this.hurtvalue = hurtvalue;
        this.lastcared = lastcared;
        this.timeframe = timeframe;
    }
}
