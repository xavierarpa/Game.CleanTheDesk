﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class GameManager : MonoBehaviour
//{
//    /*
//        GameManager cumple esto:

//        -Selecciona el game panel y construye las filas y los pisos
//        -Crea el contenedor en el medio de los construido
        
//     */
//    private readonly int rowSize = 3;
//    private readonly int fieldSize = 3;
//    private readonly int containerIndexPos = 4;

//    [Space]
//    [Header("Creación del mapa")]
//    public GameObject mapPanel;
//    public GameObject rowPrefab;
//    public GameObject fieldPrefab;
//    public GameObject groupFieldPrefab;


//    //[Space]
//    //[Header("Size")]
//    [System.NonSerialized]
//    public GameObject[] rows;
//    [System.NonSerialized]
//    public GameObject[] fields;

//    [Space]
//    [Header("BackGround")]
//    public ColorController BackG

//    [Space]
//    [Header("Trash")]
//    public GameObject dragSpace;
//    public GameObject noDragSpace;
//    public GameObject containerPrefab;

//    [Space]
//    [Header("DataPass")]
//    public Color[] dataPallete;

//    private DataPass dataPass;


//    private void Start()
//    {
//        dataPass = FindObjectOfType<DataPass>();
//        dataPallete = dataPass.palette;
//        CreateMap();
//        StartCoroutine(StartGame(1));
//    }

//    IEnumerator StartGame(float time)
//    {
//        yield return new WaitForSeconds(time);
//        GenContainer();

//    }

//    void CreateMap()
//    {

//        //1. Cuento la cantidad de rows y fields
//        rows = new GameObject[rowSize];
//        fields = new GameObject[rowSize * fieldSize];

//        int count = 0;
//        //2. Por cada row le añado una longitud de la matriz y la instancio
//        for (int a = 0; a < rowSize; a++)
//        {

//            rows[a] = Instantiate(rowPrefab, mapPanel.transform);
//            rows[a].name = "Row " + a;

//            //3. por cada unidad del row se le añade el objeto al array
//            for (int j = 0; j < fieldSize; j++)
//            {
//                GameObject newField = Instantiate(fieldPrefab, rows[a].transform);
//                fields[count] = newField;
//                fields[count].name = "[" + a + "]" + " Field " + j;

//                if (count != containerIndexPos)
//                {
//                    GameObject newGroup = Instantiate(groupFieldPrefab, gameObject.transform.position, Quaternion.identity, dragSpace.transform);

//                    Field fild = newField.GetComponent<Field>();
//                    fild.groupField = newGroup;
//                    fild.nameObj = "G" + count;
//                    newGroup.name = fild.nameObj + "-(0)";

//                }
//                else
//                {
//                    fields[count].GetComponent<Collider2D>().enabled = false;
//                }

//                count++;
//            }
//        }
//    }



//    public void GenContainer()
//    {
//        Transform fieldTransform = fields[containerIndexPos].transform;
//        //Vector3 trashPos = fields[containerIndexPos].transform.position;
//        Vector3 trashPos = new Vector3(fieldTransform.position.x, fieldTransform.position.y, noDragSpace.transform.position.z);
//        //GameObject trash = Instantiate(containerPrefab, trashPos, Quaternion.identity, fields[containerIndexPos].transform);

//        GameObject newContainer = Instantiate(containerPrefab, trashPos, Quaternion.identity, noDragSpace.transform);

//        newContainer.GetComponent<Container>().GetFields(fields, containerIndexPos);

//        newContainer.name = "Trash";
//    }
//}