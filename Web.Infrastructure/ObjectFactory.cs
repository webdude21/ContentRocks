﻿namespace Web.Infrastructure
{
    using System;

    using Ninject;

    public static class ObjectFactory
    {
        private static IKernel kernel;

        public static T GetInstance<T>()
        {
            return kernel.Get<T>();
        }

        public static object GetInstance(Type type)
        {
            return kernel.Get(type);
        }

        public static void InitializeKernel(IKernel appKernel)
        {
            kernel = appKernel;
        }

        public static T TryGetInstance<T>()
        {
            return kernel.TryGet<T>();
        }

        public static object TryGetInstance(Type type)
        {
            return kernel.TryGet(type);
        }
    }
}