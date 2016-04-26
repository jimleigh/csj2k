﻿// Copyright (c) 2007-2016 CSJ2K contributors.
// Licensed under the BSD 3-Clause License.

namespace CSJ2K
{
    using CSJ2K.Util;

    public class CSJ2KSetup
    {
        #region PROPERTIES

        public IFileInfoCreator FileInfoCreator { get; set; }

        public IFileStreamCreator FileStreamCreator { get; set; }

        public IBitmapWrapperCreator BitmapWrapperCreator { get; set; }

        public IMsgLogger MsgLogger { get; set; }

        #endregion

        #region METHODS

        public static void RegisterCreators()
        {
#if NETFX_CORE
            StoreMsgLogger.Register();
            StoreFileInfoCreator.Register();
            StoreFileStreamCreator.Register();
            WriteableBitmapWrapperCreator.Register();
#elif SILVERLIGHT
#if WINDOWS_PHONE
            WriteableBitmapWrapperCreator.Register();
#else
            SilverlightMsgLogger.Register();
            SilverlightFileStreamCreator.Register();
            WriteableBitmapWrapperCreator.Register();
#endif
#else
            DotnetMsgLogger.Register();
            DotnetFileInfoCreator.Register();
            DotnetFileStreamCreator.Register();
            WriteableBitmapWrapperCreator.Register();
#endif
        }

        #endregion
    }
}
