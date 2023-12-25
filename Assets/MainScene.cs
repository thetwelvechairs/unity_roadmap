using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainScene : MonoBehaviour
{
    private const int TEST_teams = 3;
    private const int TEST_n = 10;

    public const float max_x = 4.0f;
    public const float max_z = 4.0f;
    
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
            temp.targetEnd = Random.Range(2, 16);
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
        plane.layer = 2;


        for (int n = 0; n < 6; n++)
        {
            for (int i = 0; i < epics.Length; i++)
            {
                objects[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                objects[i].transform.localScale = new Vector3(1.0f, 0.3f, epics[i].targetEnd);
                objects[i].transform.position = new Vector3(n * 2, epics[i].team_id, epics[i].targetStart);

                objects[i].name = "Plank " + i;
                objects[i].GetComponent<Renderer>().material.SetColor("_Color", epics[i].customColor);
                ;

                objects[i].AddComponent<Rigidbody>();
                objects[i].GetComponent<Rigidbody>().mass = epics[i].targetEnd / 20.0f;
            }
        }
    }
}
