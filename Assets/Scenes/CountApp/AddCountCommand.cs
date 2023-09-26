using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    public class AddCountCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<CounterModel>().Count.Value++;
        }
    }
}