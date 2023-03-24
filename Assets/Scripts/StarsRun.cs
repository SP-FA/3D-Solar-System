using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;
using Debug = UnityEngine.Debug;
using System.Collections.Specialized;

class StarInfo {
    public string center;
    public float Rot1, Rot2, y; // 公转速度、自传速度、y轴坐标

    public StarInfo(string c, float r1, float r2, float Y)
    {
        center = c;
        Rot1 = r1;
        Rot2 = r2;
        y = Y;
    }
}

public class StarsRun : MonoBehaviour
{
    private Dictionary<string, StarInfo> StarMap;
    private float cot1, cot2, r, rot1, rot2;
    private Random rand;
    private GameObject Center;

    // Start is called before the first frame update
    void Awake()
    {
        StarMap = new Dictionary<string, StarInfo>();
        StarMap.Add("Sun", new StarInfo("Sun", 0, 0.3F, 0));               StarMap.Add("Mercury", new StarInfo("Sun", 1.6F, 0.01F, 1.633F));
        StarMap.Add("Venus", new StarInfo("Sun", 1.2F, 0.01F, 1.54F));    StarMap.Add("Earth", new StarInfo("Sun", 1F, 1F, 1.453F));
        StarMap.Add("Mars", new StarInfo("Sun", 0.8F, 1F, 1.453F));        StarMap.Add("Jupiter", new StarInfo("Sun", 0.4F, 3.4F, 1F));
        StarMap.Add("Saturn", new StarInfo("Sun", 0.3F, 2.5F, 1.187F));    StarMap.Add("Uranus", new StarInfo("Sun", 0.22F, 1.5F, 1.453F));
        StarMap.Add("Neptune", new StarInfo("Sun", 0.18F, 1.7F, 1.453F));  StarMap.Add("Pluto", new StarInfo("Sun", 0.15F, 0.2F, 1.673F));
        StarMap.Add("Moon", new StarInfo("Earth", 1.5F, 1F, 0.092F));
    }

    void Start()
    {
        rand = new Random();
        String name = gameObject.name;
        rot1 = StarMap[name].Rot1;
        rot2 = StarMap[name].Rot2;
        float y = StarMap[name].y;
        Center = GameObject.Find(StarMap[name].center);
        cot1 = rand.Next(0, 360);
        cot2 = 0;
        r = transform.localPosition.x;

        transform.localPosition = new Vector3(r * Mathf.Sin(cot1), y, r * Mathf.Cos(cot1));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cot2 += 1F;
        transform.rotation = Quaternion.AngleAxis(cot2 * rot2, new Vector3(0, 1, 0));
        transform.RotateAround(Center.transform.position, new Vector3(0, 1, 0), rot1 * Time.deltaTime * 5); //50
    }
}

