﻿using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sakura.AspNetCore.Authentication;

// ReSharper disable once CheckNamespace

namespace Microsoft.Extensions.DependencyInjection
{
	/// <summary>
	///     Provide helper methods to adding external signing-in service to application. This class is static.
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		///     Add external signing-in manager service for application.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection" /> instance.</param>
		/// <param name="setupOptions">A setup method for configuring identity options.</param>
		public static void AddExternalSignInManager([NotNull] this IServiceCollection services,
			Action<IdentityOptions> setupOptions = null)
		{
			if (services == null)
				throw new ArgumentNullException(nameof(services));
			services.TryAddSingleton<ISecurityStampValidator, ExternalSecurityStampValidator>();
			services.TryAddScoped<ExternalSignInManager>();

			if (setupOptions != null)
				services.Configure(setupOptions);
		}
	}
}