﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaraSync
{
    class SyncTarget
    {
        public readonly string A;
        public readonly string AConfig;
        public readonly string B;
        public readonly string BConfig;

        public SyncTarget(string a, string b)
        {
            A = a;
            AConfig = Path.Combine(A, Synchronizer.ConfigDirName);
            B = b;
            BConfig = Path.Combine(B, Synchronizer.ConfigDirName);
        }
    }
}