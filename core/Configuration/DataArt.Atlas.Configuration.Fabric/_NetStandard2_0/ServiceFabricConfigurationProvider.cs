﻿#region License
// =================================================================================================
// Copyright 2018 DataArt, Inc.
// -------------------------------------------------------------------------------------------------
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this work except in compliance with the License.
// You may obtain a copy of the License in the LICENSE file, or at:
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =================================================================================================
#endregion
#if NETSTANDARD2_0
using System.Fabric;
using Microsoft.Extensions.Configuration;

namespace DataArt.Atlas.Configuration.Fabric
{
    public class ServiceFabricConfigurationProvider : ConfigurationProvider
    {
        private readonly string packageName;
        private readonly CodePackageActivationContext context;

        public ServiceFabricConfigurationProvider(string packageName)
        {
            this.packageName = packageName;
            context = FabricRuntime.GetActivationContext();
            context.ConfigurationPackageModifiedEvent += (sender, e) =>
            {
                LoadPackage(e.NewPackage, reload: true);

                // Notify the change
                OnReload();
            };
        }

        public override void Load()
        {
            var config = context.GetConfigurationPackageObject(packageName);
            LoadPackage(config);
        }

        private void LoadPackage(ConfigurationPackage config, bool reload = false)
        {
            if (reload)
            {
                // Rememove the old keys on re-load
                Data.Clear();
            }

            foreach (var section in config.Settings.Sections)
            {
                foreach (var param in section.Parameters)
                {
                    Data[$"{section.Name}:{param.Name}"] = param.IsEncrypted ? param.DecryptValue().ConvertToUnsecureString() : param.Value;
                }
            }
        }
    }
}
#endif