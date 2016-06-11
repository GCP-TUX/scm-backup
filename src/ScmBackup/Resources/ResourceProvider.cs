﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace ScmBackup.Resources
{
    /// <summary>
    /// Provides translated string resources
    /// </summary>
    public class ResourceProvider : IResourceProvider
    {
        private bool initialized;
        private CultureInfo culture;

        /// <summary>
        /// temporary list of resources until we have a better solution
        /// </summary>
        private Dictionary<string, string> resources = new Dictionary<string, string>
        {
            { "AppTitle", "SCM Backup" },
            { "BackupFailed", "Backup failed!" },
            { "EndSeconds", "The application will close in {0} seconds!" },
            { "ReadingConfig", "{0}: Reading config" },
            { "StartingBackup", "{0}: Starting backup" },
            { "GithubNameEmpty", "name is empty (GitHub)" },
            { "GithubWrongHoster", "wrong hoster (GitHub): {0}" },
            { "GithubWrongType", "wrong type (GitHub): {0}" },
            { "HosterDoesntExist", "Hoster {0} doesn't exist" },
            { "LocalFolderMissing", "Local folder is missing!" },
            { "NoSourceConfigured", "No source configured!" },
            { "Return", "{0}: Return" },
        };

        public void Initialize(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new InvalidOperationException("Invalid culture!");
            }

            this.culture = culture;
            this.initialized = true;
        }

        public string GetString(string key)
        {
            if (!this.initialized)
            {
                throw new InvalidOperationException("ResourceProvider not initialized!");
            }

            string result;
            this.resources.TryGetValue(key, out result);
            return result;
        }
    }
}