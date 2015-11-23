using Microsoft.Win32;
using System.Windows.Forms;

namespace RC
{
    /// <summary>
    /// 设置/取消开机启动的类
    /// </summary>
    class StartupRegistry
    {
        private const string kRegistryAutoRunPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        /// <summary>
        /// 检测是否已经设置了开机启动
        /// </summary>
        /// <returns>是否已设置开机启动</returns>
        public static bool HasSetStartup(string autoRunKey)
        {
            bool isExist = false;

            RegistryKey runKey = Registry.CurrentUser.OpenSubKey(kRegistryAutoRunPath, true);
            string[] subkeyNames = runKey.GetValueNames();

            foreach (string keyName in subkeyNames)
            {
                if (keyName == autoRunKey)
                {
                    isExist = true;
                    break;
                }
            }

            runKey.Close();
            runKey = null;

            return isExist;
        }

        /// <summary>
        /// 设置开机启动
        /// </summary>
        /// <returns>是否设置成功</returns>
        public static bool SetStartup(string autoRunKey)
        {
            if (!HasSetStartup(autoRunKey))
            {
                bool hasSucceeded = false;
                string exePath = Application.ExecutablePath;
                RegistryKey runKey = Registry.CurrentUser.OpenSubKey(kRegistryAutoRunPath, true);

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
                    runKey = null;
                }

                return hasSucceeded;
            }
            else
                return true;
        }

        /// <summary>
        /// 取消开机启动
        /// </summary>
        /// <returns>取消是否成功</returns>
        public static bool UnsetStartup(string autoRunKey)
        {
            if (HasSetStartup(autoRunKey))
            {
                bool hasSucceeded = false;
                RegistryKey runKey = Registry.CurrentUser.OpenSubKey(kRegistryAutoRunPath, true);

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
                    runKey = null;
                }

                return hasSucceeded;
            }
            else
                return true;
        }
    }
}
