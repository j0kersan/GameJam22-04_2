using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Players;
    public GameObject TargetPlayer;

    private CameraControls cam;

    
    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControls>();
        cam.trackingTarget = FindFurthestObject(Players);
        TargetPlayer = Players[Random.Range(0, Players.Length -1)];
    }


    GameObject FindFurthestObject(GameObject[] Players)
    {
        float FurthestDistance = 0;
        GameObject FurthestObject = null;

        foreach(GameObject Object in Players)
        {
            float ObjectDistance = Vector3.Distance(-TargetPlayer.transform.position, Object.transform.position);
            if (ObjectDistance > FurthestDistance)
            {
                FurthestObject = Object;
                FurthestDistance = ObjectDistance;
            }
        }
        return FurthestObject;
    }

    // Update is called once per frame
    void Update()
    {

        cam.trackingTarget = FindFurthestObject(Players);
    }
}
