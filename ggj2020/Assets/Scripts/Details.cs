using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Details : MonoBehaviour
{
    private GameObject detailsPanel;
    public List<string> testDetails;
    // Start is called before the first frame update
    void Start()
    {
        detailsPanel = transform.GetChild(0).gameObject;
        detailsPanel.SetActive(false);
        Populate(testDetails);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Populate(List<string> details)
    {
        foreach(string detail in details)
        {
            Debug.Log(detail);
            detailsPanel.transform.GetChild(1).GetComponent<Text>().text += detail + "\n";
        }
        
    }

    private void OnMouseOver()
    {
        detailsPanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        detailsPanel.SetActive(false);
    }
}
