﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Haenyeo : MonoBehaviour
{  
    public static int money, debt, diving_time, moving_speed, farm_number, day, level;

    public static int[] sea_item_number= new int[9]; //보유하고있는 자원 개수

    public enum sea_item_index
    {
        starfish = 0,
        seaweed,
        shell,
        shrimp,
        jellyfish,
        crab,
        octopus,
        abalone,
        turtle

    };


}
