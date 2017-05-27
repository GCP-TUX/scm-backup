﻿using System;
using System.Globalization;
using System.IO;

namespace ScmBackup.Tests.Integration
{
    /// <summary>
    /// helper class to create unique temp directories for integration tests
    /// </summary>
    public class TempDirectoryHelper
    {
        public static string CreateTempDirectory()
        {
            return TempDirectoryHelper.CreateTempDirectory(string.Empty);
        }

        public static string CreateTempDirectory(string suffix)
        {
            string tempDir = Path.GetTempPath();
            string newDir = "scm-backup-temp-" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            if (!string.IsNullOrWhiteSpace(suffix))
            {
                newDir += '-' + suffix;
            }

            string finalDir = Path.Combine(tempDir, newDir);

            if (Directory.CreateDirectory(finalDir) != null)
            {
                return finalDir;
            }

            return string.Empty;
        }
    }
}
