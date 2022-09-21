using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class getMyPrefab : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[6];
    private void Start()
    {
        for (int p = 0; p < prefabs.Length; p++)
        {
            prefabs[p] = Resources.Load("Prefabs/Prefab" + p) as GameObject;
        }

        Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
    }
}
