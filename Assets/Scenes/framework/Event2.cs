using System;

namespace FrameworkDesign
{
    public class Event2<T> where T : Event2<T>
    {
        private static Action mOnEventTrigger;

        /// <summary>
        /// 注册事件
        /// </summary>
        public static void Register(Action onEvent)
        {
            mOnEventTrigger += onEvent;
        }

        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="onEvent"></param>
        public static void UnRegister(Action onEvent)
        {
            mOnEventTrigger -= onEvent;
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        public static void Trigger()
        {
            mOnEventTrigger?.Invoke();
        }
    }
}
