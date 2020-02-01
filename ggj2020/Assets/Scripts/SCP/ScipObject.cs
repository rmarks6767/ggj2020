using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScipObject : MonoBehaviour
{
    Sprite sprite;
    public string number;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Resources.Load($"SCPSprites/{number}") as GameObject;
        this.sprite = obj.GetComponent<SpriteRenderer>().sprite;
        this.gameObject.AddComponent<SpriteRenderer>().sprite = this.sprite;
        this.gameObject.transform.localScale = 3 * this.gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
