using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rRun : MonoBehaviour
{
    private float cot2;

    // Start is called before the first frame update
    void Start()
    {
        cot2 = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cot2 += 0.01F;
        transform.rotation = Quaternion.AngleAxis(cot2, new Vector3(0, 1, 0));
    }
}
