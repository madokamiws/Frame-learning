using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,120,50),"��������1"))
        {
            //GameObject go = GameObject.Find("Cube");
            //go.GetComponent<cube>().Write();
            EventCenterManager.Instance.Dispatch("����");
             
        }
        if (GUI.Button(new Rect(150, 0, 120, 50), "��������2"))
        {
            //GameObject go = GameObject.Find("Cube");
            //go.GetComponent<cube>().Write();
            EventCenterManager.Instance.Dispatch("����");

        }
    }

}
public class Image_attribute
{
    public List<TYPE> image_types;

}
public enum TYPE
{
    type1,
    type2,
    type3,
    type4
}