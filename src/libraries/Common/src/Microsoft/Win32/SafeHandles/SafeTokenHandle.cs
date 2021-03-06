// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;

namespace Microsoft.Win32.SafeHandles
{
    internal sealed class SafeTokenHandle : SafeHandle
    {
        public SafeTokenHandle() : base(IntPtr.Zero, true) { }

        // 0 is an Invalid Handle
        internal SafeTokenHandle(IntPtr handle) : base(IntPtr.Zero, true)
        {
            SetHandle(handle);
        }

        internal static SafeTokenHandle InvalidHandle
        {
            get { return new SafeTokenHandle(IntPtr.Zero); }
        }

        public override bool IsInvalid
        {
            get
            { return handle == new IntPtr(0) || handle == new IntPtr(-1); }
        }

        protected override bool ReleaseHandle()
        {
            return Interop.Kernel32.CloseHandle(handle);
        }
    }
}
