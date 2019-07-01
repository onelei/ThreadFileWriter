using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace ThreadFileWriter
{
    public class ThreadTestFileWriter : ThreadFileWriter
    {
        protected override void Init()
        {
            if (_logFile == null)
            {
                _logFilePath = Application.dataPath + "/../Test.txt";
                OpenFile(_logFilePath);
                WriteFile("\n=========Start ThreadTestFileWriter==========");
            }
        }
    }
}
