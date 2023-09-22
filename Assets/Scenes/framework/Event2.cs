using System;

namespace FrameworkDesign
{
    public class Event2<T> where T : Event2<T>
    {
        private static Action mOnEventTrigger;

        /// <summary>
        /// ע���¼�
        /// </summary>
        public static void Register(Action onEvent)
        {
            mOnEventTrigger += onEvent;
        }

        /// <summary>
        /// ע���¼�
        /// </summary>
        /// <param name="onEvent"></param>
        public static void UnRegister(Action onEvent)
        {
            mOnEventTrigger -= onEvent;
        }

        /// <summary>
        /// �����¼�
        /// </summary>
        public static void Trigger()
        {
            mOnEventTrigger?.Invoke();
        }
    }
}
