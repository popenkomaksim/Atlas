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
using System;
using DataArt.Atlas.Service.Scheduler.Sdk;
using Microsoft.AspNetCore.Mvc;

namespace DataArt.Atlas.Service.Scheduler.Areas.V1.Controllers
{
    [Route("api/v1/sdkVersion")]
    public class SdkVersionController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public Version GetVersion()
        {
            return typeof(SchedulerClientConfig).Assembly.GetName().Version;
        }
    }
}
#endif