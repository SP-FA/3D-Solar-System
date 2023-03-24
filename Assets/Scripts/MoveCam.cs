using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MoveCam : MonoBehaviour
{
    public GameObject star, UI;
    public bool isClick;
    private List<string> starLst = new List<string>();
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        star = null;
        isClick = false;
        starLst.Add("Sun");     starLst.Add("Mercury");
        starLst.Add("Venus");   starLst.Add("Earth");
        starLst.Add("Mars");    starLst.Add("Jupiter");
        starLst.Add("Saturn");  starLst.Add("Uranus");
        starLst.Add("Neptune"); starLst.Add("Pluto");
        starLst.Add("Moon");

        UI = GameObject.Find("StarInfo");
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool res = Physics.Raycast(ray, out hit);
            if (res == true) {
                string name = hit.collider.gameObject.name;
                if (starLst.Exists(t => t == name) == true)
                {
                    star = hit.collider.gameObject;
                    isClick = true;
                }
            }
            else
            {
                star = null;
                isClick = false;
            }
        }
        if (isClick == true)
        {
            GetComponent<Camera>().farClipPlane = 5;
            UI.SetActive(true);
        }
        else
        {
            GetComponent<Camera>().farClipPlane = 50;
            UI.SetActive(false);
        }
    }
}
