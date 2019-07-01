using UnityEngine;
using System.Collections;

namespace ThreadFileWriter
{
    public class ThreadFileWriterSample : MonoBehaviour
    {
        private void Awake()
        {
            ThreadFileWriterManager.Instance.OnAwake();
        }

        private void OnDestroy()
        {
            ThreadFileWriterManager.Instance.OnDestroy();
        }

        private void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                ThreadFileWriterManager.Instance.Log(EThreadFileType.TEST, "" + i);
            }
        }
    }
}
