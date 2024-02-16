using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneManager : MonoBehaviour
{
    public GameObject barTop;
    public GameObject barBottom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CutSceneBarsEnable()
    {
        barTop.SetActive(true);
        barBottom.SetActive(true);
    }

    public void CutSceneBarsDisable()
    {
        barTop.SetActive(false);
        barBottom.SetActive(false);
    }
}
