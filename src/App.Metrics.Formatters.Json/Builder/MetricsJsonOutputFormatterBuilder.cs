﻿// <copyright file="MetricsJsonOutputFormatterBuilder.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.Formatters.Json;

// ReSharper disable CheckNamespace
namespace App.Metrics
    // ReSharper restore CheckNamespace
{
    /// <summary>
    ///     Builder for configuring metric JSON output formatting using an
    ///     <see cref="IMetricsBuilder" />.
    /// </summary>
    public static class MetricsJsonOutputFormatterBuilder
    {
        /// <summary>
        ///     Add the <see cref="MetricsJsonOutputFormatter" /> allowing metrics to optionally be reported as JSON.
        /// </summary>
        /// <param name="metricFormattingBuilder">
        ///     The <see cref="MetricsOutputFormattingBuilder" /> used to configuring formatting
        ///     options.
        /// </param>
        /// <param name="setupAction">The JSON formatting options to use.</param>
        /// <returns>
        ///     An <see cref="IMetricsBuilder" /> that can be used to further configure the App Metrics.
        /// </returns>
        public static IMetricsBuilder AsJson(
            this MetricsOutputFormattingBuilder metricFormattingBuilder,
            Action<MetricsJsonOptions> setupAction = null)
        {
            if (metricFormattingBuilder == null)
            {
                throw new ArgumentNullException(nameof(metricFormattingBuilder));
            }

            var options = new MetricsJsonOptions();

            setupAction?.Invoke(options);

            var formatter = new MetricsJsonOutputFormatter(options.SerializerSettings);

            return metricFormattingBuilder.Using(formatter);
        }
    }
}