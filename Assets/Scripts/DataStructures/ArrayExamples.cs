using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayExamples : MonoBehaviour
{

    public GameObject testPrefab;

    public GameObject[] testArray;
    
    public int[] testIntArrays;

    public GameObject[] array = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        array[0] = Instantiate(testPrefab, transform);
        array[0].transform.position = new Vector2(0, 0);
        
        array[1] = Instantiate(testPrefab, transform);
        array[1].transform.position = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
