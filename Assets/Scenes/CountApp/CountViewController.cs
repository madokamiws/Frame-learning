using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace FrameworkDesign
{
    public class CountViewController : MonoBehaviour
    {
        private CounterModel mCountModel;
        void Start()
        {
             mCountModel = CounterApp.Get<CounterModel>();

            mCountModel.Count.OnValueChanged += OnCountChanged;

            OnCountChanged(mCountModel.Count.Value);
            transform.Find("btnadd").GetComponent<Button>().onClick.AddListener(() => {

                new AddCountCommand().Execute();
            });

            transform.Find("btnsub").GetComponent<Button>().onClick.AddListener(() => {
                new SubCountCommand().Execute();

            });
        }
        private void OnCountChanged(int newcount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newcount.ToString();
        }
        private void OnDestroy()
        {
            mCountModel.Count.OnValueChanged -= OnCountChanged;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
    public class CounterModel
    {
        //private static int mCount = 0;
        //public static int Count
        //{
        //    get => mCount;
        //    set
        //    {
        //        if (value != mCount)
        //        {
        //            mCount = value;

        //            OnCountChangeEvent.Trigger();

        //        }
        //    }
        //}
        public BindableProperty<int> Count = new BindableProperty<int>()
        {
            Value = 0
        };
    }

}
