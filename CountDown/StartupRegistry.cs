using System.Windows.Forms;
using Microsoft.Win32;

namespace RC
{
    /// <summary>
    ///     设置/取消开机启动的类
    /// </summary>
    internal class StartupRegistry
    {
        private const string kRegistryAutoRunPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        ///     检测是否已经设置了开机启动
        /// </summary>
        /// <returns>是否已设置开机启动</returns>
        public static bool HasSetStartup(string autoRunKey)
        {
            var isExist = false;

            var runKey = Registry.CurrentUser.OpenSubKey(kRegistryAutoRunPath, true);
            var subkeyNames = runKey.GetValueNames();

            foreach (var keyName in subkeyNames)
            {
                if (keyName == autoRunKey)
                {
                    isExist = true;
                    break;
                }
            }

            runKey.Close();

            return isExist;
        }

        /// <summary>
        ///     设置开机启动
        /// </summary>
        /// <returns>是否设置成功</returns>
        public static bool SetStartup(string autoRunKey)
        {
            if (!HasSetStartup(autoRunKey))
            {
                var hasSucceeded = false;
                var exePath = Application.ExecutablePath;
                var runKey = Registry.CurrentUser.OpenSubKey(kRegistryAutoRunPath, true);

                try
                {
                    runKey.SetValue(autoRunKey, exePath);
                    hasSucceeded = true;
                }
                catch
                {
                    hasSucceeded = false;
                }
                finally
                {
                    runKey.Close();
                }

                return hasSucceeded;
            }
            return true;
        }

        /// <summary>
        ///     取消开机启动
        /// </summary>
        /// <returns>取消是否成功</returns>
        public static bool UnsetStartup(string autoRunKey)
        {
            if (HasSetStartup(autoRunKey))
            {
                var hasSucceeded = false;
                var runKey = Registry.CurrentUser.OpenSubKey(kRegistryAutoRunPath, true);

                try
                {
                    runKey.DeleteValue(autoRunKey);
                    hasSucceeded = true;
                }
                catch
                {
                    hasSucceeded = false;
                }
                finally
                {
                    runKey.Close();
                }

                return hasSucceeded;
            }
            return true;
        }
    }
}