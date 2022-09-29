using System;
using Android.App;
using Android.Runtime;
using Common;

namespace Project.Android
{
    [Application]
    public class MyApp : Application
    {
        public MyApp(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }
}

