using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class ShowInfo : MonoBehaviour
{
    public GameObject RightInfo, Title;
    private Dictionary<string, string> starsInfo;
    private int count;

    // Start is called before the first frame update
    void Awake()
    {
        count = 0;
        starsInfo = new Dictionary<string, string>();
        starsInfo.Add("Sun", 
            "Sun"
            );
        starsInfo.Add("Mercury",
            "I am the closest planet to the sun! Therefore, my surface temperature is extremely high and can reach up to 430 degrees Celsius! For many years, humans have regarded me as a star because I look shiny. I rotate around the sun every day, with a cycle of only 88 Earth days. So, if you lived on me for a year, it would only be equivalent to living on Earth for 88 days!"
            );
        starsInfo.Add("Venus",
            "I am the second planet in the solar system, and I look very similar to Earth's brother. However, if you look up at the sky, it looks different from Earth because my sky is orange! This is because there is a lot of carbon dioxide in my atmosphere, which makes my sky appear this color. Like my brother Mercury, my surface is also very hot, and it can reach up to 470 degrees Celsius."
            );
        starsInfo.Add("Earth",
            "I am the place where humans live, and the only planet in the solar system known to support life. Look around me, I am blue because my surface is covered with a lot of water. A day on me is 24 hours because I spin very quickly, which is why you can see sunrises and sunsets!"
            );
        starsInfo.Add("Mars",
            "I am the closest neighbor to Earth's brother, and I am known as the \"Red Planet\" because my surface is covered with red rocks and soil, making me appear very red! The temperature here is extremely low and can go as low as minus 120 degrees Celsius. Humans have been searching for signs of life on me because there may have been liquid water here in the past. Who knows, in the future, you may find other forms of life on me!"
            );
        starsInfo.Add("Jupiter",
            "Jupiter"
            );
        starsInfo.Add("Saturn",
            "Saturn"
            );
        starsInfo.Add("Uranus",
            "Uranus"
            );
        starsInfo.Add("Neptune",
            "Neptune"
            );
        starsInfo.Add("Pluto",
            "Pluto"
            );
        starsInfo.Add("Moon",
            "Moon"
            );
    }

    void OnEnable()
    {
        if (count == 0)
        {
            count++;
            return;
        }
        GameObject star = GameObject.Find("Main Camera").GetComponent<MoveCam>().hit.collider.gameObject;
        if (star == null) return;
        string name = star.name;

        // Title = GameObject.Find("StarName");
        // Title.GetComponent<TextMeshProUGUI>().text = name;

        // RightInfo = GameObject.Find("RightInfo");
        // RightInfo.GetComponent<TextMeshProUGUI>().text = starsInfo[name];

        GameObject root = GameObject.Find("StarContainer");
        foreach (string key in starsInfo.Keys)
        {
            string kname1 = key + "_r";
            // string kname2 = key + "_u";
            GameObject star_r = root.transform.Find(kname1).gameObject;
            // GameObject star_u = root.transform.Find(kname2).gameObject;

            if (key == name)
            {
                star_r.SetActive(true);
                // star_u.SetActive(true);
            }
            else
            {
                star_r.SetActive(false);
                // star_u.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
