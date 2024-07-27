using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chronomanager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chronotext;
    private float chrono = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chrono += Time.deltaTime;
        chronotext.text = chrono.ToString();
    }
}
 