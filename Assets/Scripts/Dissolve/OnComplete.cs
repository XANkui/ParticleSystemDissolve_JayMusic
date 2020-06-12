using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnComplete : MonoBehaviour
{

    public GameObject ps;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        ps = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCompleteEvent() {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ps.SetActive(true);
        ps.GetComponent<ParticleSystem>().Play();
    }
}
