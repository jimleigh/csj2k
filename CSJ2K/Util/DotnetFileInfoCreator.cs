﻿// Copyright (c) 2007-2016 CSJ2K contributors.
// Licensed under the BSD 3-Clause License.

namespace CSJ2K.Util
{
    public class DotnetFileInfoCreator : IFileInfoCreator
    {

        #region METHODS

        public IFileInfo Create(string fileName)
        {
            return new DotnetFileInfo(fileName);
        }

        public static void Register()
        {
            FileInfoFactory.RegisterCreator(new DotnetFileInfoCreator());
        }

        #endregion
    }
}
