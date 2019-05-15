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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataArt.Atlas.EntityFramework.MsSql.EntityFramework
{
    public static class DbContextExtensions
    {
        public static void InitializeContext<TContext>(this IServiceProvider container)
            where TContext : BaseDbContext<TContext>
        {
            using (var scope = container.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<TContext>();
                {
#if !DEBUG
                    context.Database.EnsureCreated();
#else
                    context.Database.Migrate();
#endif
                }
            }
        }
    }
}
#endif