using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameObject GetOther(GameObject myself) {
        GameObject[] agents = GameObject.FindGameObjectsWithTag("Agent");

        for (int i = 0; i < agents.Length; i++) {
            if (agents[i] != myself)
                return agents[i];
        }

        return null;
    }
}
