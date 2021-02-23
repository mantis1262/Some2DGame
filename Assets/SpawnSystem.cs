using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    public List<GameObject> spawnPositon;
    public PlayerMovment[] players;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<4; i++)
        {
            int tempIndex = Random.Range(0, spawnPositon.Count);
            players[i].gameObject.transform.position = spawnPositon[tempIndex].transform.position;
            spawnPositon.RemoveAt(tempIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
