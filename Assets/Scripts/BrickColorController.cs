using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickColorController : MonoBehaviour
{
    public Gradient gradient;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = gradient.Evaluate(Random.Range(0f, 1f));
    }

}
