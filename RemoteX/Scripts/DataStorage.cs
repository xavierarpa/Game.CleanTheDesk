﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataStorage
{

    // Tutorial 
    public bool tutorial = false;

    // Last Used
    public int indexPower = 0;
    public int indexTokenImg = 0;
    public int indexContainerImg = 1;

    // Score
    public int highScore = 0;


    //Store
    public int[] lastStore;
    public string storeType = "shapes";//shapes, powers, ¿ colors ?


    public DataStorage (DataPass dataPass) 
    {
        tutorial = true;

        indexPower = dataPass.indexPower;
        indexTokenImg = dataPass.indexTokenImg;
        indexContainerImg = dataPass.indexContainerImg;

        highScore = dataPass.highScore;

        lastStore = dataPass.lastStore;
        storeType = dataPass.storeType;

    }
}