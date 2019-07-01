using UnityEngine;
using System;
using System.IO;

#if UNITY_EDITOR
using System.Threading;
#endif

namespace ThreadFileWriter
{
    public abstract class ThreadFileWriter
    {
        private volatile object threadLocker = new object();

        protected string _logFilePath;
        protected StreamWriter _logFile;
        protected virtual void Init() { }

        public void OnAwake()
        {
            Init();
        }

        public void OnDestroy()
        {
            CloseFile();
        }

        public void WriteFile(string str)
        {
            lock (threadLocker)
            {
                if (_logFile != null)
                {
//#if UNITY_EDITOR
//                    //打印一下线程ID，用于测试
//                    str = string.Format("Tid: {0}{1}  {2}\n",
//                        Thread.CurrentThread.ManagedThreadId.ToString().PadRight(4),
//                        DateTime.Now.ToString(), str);
//#endif
                    _logFile.Write(str + "\n");
                    _logFile.Flush();
                }
            }
        }

        public void OpenFile(string _LogFilePath)
        {
            lock(threadLocker)
            {
                this._logFilePath = _LogFilePath;
                Debug.Log("_LogFilePath: " + _LogFilePath);

                try
                {
                    _logFile = new StreamWriter(_LogFilePath, true, System.Text.Encoding.UTF8);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        public void CloseFile()
        {
            lock (threadLocker)
            {
                if (_logFile != null)
                {
                    _logFile.Close();
                    _logFile = null;
                }
            }
        }

        public void Log(string str)
        {
            WriteFile(str);
        }
    }
}