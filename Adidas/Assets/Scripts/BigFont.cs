using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BigFont : MonoBehaviour
{

    [SerializeField]
    int size = 300;

    Text t;

    void Awake()
    {
        t = GetComponent<Text>();
    }

    void Update()
    {
        t.fontSize = size;
    }
}