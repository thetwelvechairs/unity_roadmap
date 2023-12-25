using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainScene : MonoBehaviour
{
    const int TEST_teams = 3;
    const int TEST_n = 10;

    public const float max_x = 10.0f;
    public const float max_z = 10.0f;
    
    Epic[] epics = new Epic[TEST_n];
    
    GameObject[] objects = new GameObject[TEST_n];
    
    // Color customColor = new Color();

    void setupEpics()
    {
        for (int i = 0; i < TEST_n; i++)
        {
            Epic temp = new Epic();
            temp.title = "" + i;
            temp.targetStart = i;
            temp.targetEnd = Random.Range(2, 6);
            temp.team_id = Random.Range(1, TEST_teams + 1);
            temp.customColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);

            epics[i] = temp;
        }
    }
    
    void Start()
    {
        setupEpics();
        
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        plane.transform.localScale = new Vector3(max_x, 0.1f, max_z);
        plane.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        

        for (int i = 0; i < epics.Length; i++)
        {
            objects[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            objects[i].transform.localScale = new Vector3(1.0f, 0.3f, epics[i].targetEnd);
            objects[i].transform.position = new Vector3(0.0f, epics[i].team_id, epics[i].targetStart);
            objects[i].AddComponent<Rigidbody>();
            objects[i].GetComponent<Renderer>().material.SetColor("_Color", epics[i].customColor); ;
        }
    }

    void Update()
    {

    }
}
