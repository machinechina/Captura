﻿using Captura.Properties;
using System;
using System.Collections.Generic;

namespace Captura
{
    /// <summary>
    /// Kind of Dependency Injection
    /// </summary>
    public static class ServiceProvider
    {
        static Dictionary<ServiceName, object> _services = new Dictionary<ServiceName, object>();

        /// <summary>
        /// Get the requested Service.
        /// </summary>
        public static T Get<T>(ServiceName ServiceAction)
        {
            return (T)_services[ServiceAction];
        }

        /// <summary>
        /// Gets the Description of a Service.
        /// </summary>
        public static string GetDescriptionKey(ServiceName ServiceName)
        {
            switch (ServiceName)
            {
                case ServiceName.Recording:
                    return nameof(Resources.StartStopRecording);

                case ServiceName.Pause:
                    return nameof(Resources.PauseResumeRecording);

                case ServiceName.ScreenShot:
                    return nameof(Resources.ScreenShot);

                case ServiceName.ActiveScreenShot:
                    return nameof(Resources.ScreenShotActiveWindow);

                case ServiceName.DesktopScreenShot:
                    return nameof(Resources.ScreenShotDesktop);

                default:
                    return "Unknown";
            }
        }

        /// <summary>
        /// Registers a Service.
        /// </summary>
        public static void Register<T>(ServiceName ServiceAction, T Action)
        {
            _services.Add(ServiceAction, Action);
        }

        /// <summary>
        /// Raises the <see cref="HotKeyPressed"/> event with the Hotkey Id.
        /// </summary>
        public static void RaiseHotKeyPressed(int Id)
        {
            HotKeyPressed?.Invoke(Id);
        }

        /// <summary>
        /// Fired (with ID) when a Hotkey is pressed.
        /// </summary>
        public static event Action<int> HotKeyPressed;
    }
}
