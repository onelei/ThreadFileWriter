using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace ThreadFileWriter
{
    public class ThreadLogFileWriter : ThreadFileWriter
    {
        protected override void Init()
        {
            if (_logFile == null)
            {
                _logFilePath = Application.dataPath + "/../Log.txt";
                OpenFile(_logFilePath);
                WriteFile("\n=========Start ThreadLogFileWriter==========");
            }
        }
    }
}
