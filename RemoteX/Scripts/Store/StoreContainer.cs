﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class StoreContainer : MonoBehaviour
{
    private readonly Data data = new Data();

    public GameObject tokenPrefab;
    public GameObject tokenStore;

    public GameObject[] storeChilds;


    private GameObject[] shapesStore;
    private GameObject[] powersStore;
    private GameObject[] palletesStore;

    public string lastStore;


    private void Awake()
    {
        storeChilds = new GameObject[gameObject.transform.childCount];
        shapesStore = new GameObject[0];
        powersStore = new GameObject[0];
        palletesStore = new GameObject[0];
        lastStore = "shapes";
    }


    /// <summary>
    /// Desactiva las actuales y, dependiendo de la que sea, activa los objetos del respectivo
    /// </summary>
    public void ChangeTo(string type="shapes")//por defecto es shapes
    {
        GameObject[] recipeStore = new GameObject[0]; 


        foreach (var t in data.storeTypes ) 
        {
            bool isActive = t == type;
            //Debug.Log("t: "+ t);
            switch (t)
            {
                case "shapes":
                    recipeStore = shapesStore;
                    break;
                case "powers":
                    recipeStore = powersStore;
                    break;
                case "palletes":
                    recipeStore = palletesStore;
                    break;
                default:
                    Debug.LogError("Error escribiendo..");
                    break;
            }
            if (recipeStore.Length > 0)
            {
                EnableDisableObjects(recipeStore, isActive);
            }
        }

        lastStore = type;
    }




    public void EnableDisableObjects(GameObject[] obj, bool setActive=true)
    {
        foreach (GameObject o in obj)
        {
            o.SetActive(setActive); 
        }

    }


    // Cargado por StoreManager
    public void CreatePrefabs_Shapes(int[] shapes)
    {
        shapesStore = new GameObject[storeChilds.Length]; 

        for (int i = 0; i < storeChilds.Length; i++)
        {
            shapesStore[i] = gameObject.transform.GetChild(i).gameObject;

            GameObject prefab = Instantiate(tokenPrefab, shapesStore[i].transform);

            prefab.name = "Shapes[" + i + "]";

            Image prefImg = prefab.GetComponent<Image>();
            Sprite prefSpr = Resources.Load<Sprite>(data.path_Img + data.pathShapes[shapes[i]]);
            prefImg.sprite = prefSpr;
            //
            storeChilds[i] = prefab;
        }
    }

    public void CreatePrefabs_Powers(int[] powers)
    {
        powersStore = new GameObject[0];
    }

    public void CreatePrefabs_Palletes(int[] palletes)
    {
        palletesStore = new GameObject[0];

    }
}