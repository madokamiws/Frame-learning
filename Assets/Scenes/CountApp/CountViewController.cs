using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountViewController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("btnadd").GetComponent<Button>().onClick.AddListener(() => {

            CounterModel.Count++;
            UpdateView();
        });

        transform.Find("btnsub").GetComponent<Button>().onClick.AddListener(() => {
            CounterModel.Count--;
            UpdateView();

        });
    }


    void UpdateView()
    {
        transform.Find("CountText").GetComponent<Text>().text = CounterModel.Count.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
public static class CounterModel
{
    public static int Count = 0;
}