using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    GameObject LastPart;
    private float Yspawn = 15f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabs[0],Vector3.zero,Quaternion.identity);
        LastPart = Instantiate(prefabs[0],new Vector3(0, Yspawn,0),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (LastPart.transform.position.y <= 0f){
            SpawnePart(Random.Range(1,prefabs.Length));
        }
        
    }
    private void SpawnePart(int index){
        LastPart = Instantiate(prefabs[index],new Vector3(0, Yspawn,0),Quaternion.identity);
    }
}
