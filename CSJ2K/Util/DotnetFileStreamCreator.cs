﻿// Copyright (c) 2007-2016 CSJ2K contributors.
// Licensed under the BSD 3-Clause License.

using System;
using System.IO;

namespace CSJ2K.Util
{
    public class DotnetFileStreamCreator : IFileStreamCreator
    {
        #region METHODS

        public Stream Create(string path, string mode)
        {
            if (mode.Equals("rw", StringComparison.OrdinalIgnoreCase)) return new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (mode.Equals("r", StringComparison.OrdinalIgnoreCase)) return new FileStream(path, FileMode.Open, FileAccess.Read);
            throw new ArgumentException(String.Format("File mode: {0} not supported.", mode), "mode");
        }

        public static void Register()
        {
            FileStreamFactory.RegisterCreator(new DotnetFileStreamCreator());
        }

        #endregion
    }
}
