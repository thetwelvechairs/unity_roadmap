using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainScene : MonoBehaviour
{
    private const int TEST_teams = 10;
    private const int TEST_n = 100;

    public const float max_x = 25.0f;
    public const float max_z = 10.0f;

    private Epic[] epics = new Epic[TEST_n];

    private GameObject[] objects = new GameObject[TEST_n];

    public static GameObject plane;
    public static GameObject plane2;
    public static GameObject plane3;
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

    void setupPlane()
    {
        plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        plane.name = "Plane 1";
        plane.tag = "Planes";
        plane.layer = 2;
        plane.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
        plane.transform.localScale = new Vector3(max_x, 0.5f, max_z);
        plane.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        plane.AddComponent<Rigidbody>();
        plane.GetComponent<Rigidbody>().isKinematic = true;
        plane.GetComponent<Rigidbody>().mass = 100.0f;
        plane.GetComponent<Rigidbody>().useGravity = false;


        plane2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        plane2.name = "Plane 2";
        plane2.tag = "Planes";
        plane2.layer = 2;
        plane2.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
        plane2.transform.localScale = new Vector3(max_x, 0.5f, max_z);
        plane2.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        plane2.AddComponent<Rigidbody>();
        plane2.GetComponent<Rigidbody>().isKinematic = true;
        plane2.GetComponent<Rigidbody>().mass = 100.0f;
        plane2.GetComponent<Rigidbody>().useGravity = false;

        plane3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        plane3.name = "Plane 3";
        plane3.tag = "Planes";
        plane3.layer = 2;
        plane3.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
        plane3.transform.localScale = new Vector3(max_x, 0.5f, max_z);
        plane3.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        plane3.AddComponent<Rigidbody>();
        plane3.GetComponent<Rigidbody>().isKinematic = true;
        plane3.GetComponent<Rigidbody>().mass = 100.0f;
        plane3.GetComponent<Rigidbody>().useGravity = false;

    }

    void setupObjects()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            objects[i].tag = "Balls";
            objects[i].transform.position = new Vector3(0.0f, epics[i].team_id, epics[i].targetStart);
            objects[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            objects[i].name = "Ball " + i;

            objects[i].GetComponent<Renderer>().material.SetColor("_Color", epics[i].customColor);

            objects[i].AddComponent<Rigidbody>();
            objects[i].GetComponent<Rigidbody>().mass = epics[i].targetEnd * 1000.0f;
        }
    }

    void Start()
    {
        setupPlane();
        setupEpics();
        setupObjects();
    }

    void FixedUpdate()
    {
        plane.GetComponent<Rigidbody>().MovePosition(new Vector3(0.0f, 0.0f, -10.0f));
        plane2.GetComponent<Rigidbody>().MovePosition(new Vector3(0.0f, 4.0f, 0.0f));
        plane3.GetComponent<Rigidbody>().MovePosition(new Vector3(0.0f, 8.0f, 10.0f));
        plane.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(100.0f * (Time.time), +0.0f, 0.0f));
        plane2.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(-100.0f * (Time.time), +0.0f, 0.0f));
        plane3.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(100.0f * (Time.time), +0.0f, 0.0f));

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].transform.position.y < Random.Range(-125.0f, -100.0f))
            {
                objects[i].GetComponent<Rigidbody>().MovePosition(new Vector3(0.0f, Random.Range(225.0f, 350.0f), Random.Range(0.0f, 0.5f)));
                objects[i].GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0.0f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(0.0f, 0.1f));
            }
        }
    }
}
