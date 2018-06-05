﻿using Microsoft.Xrm.Sdk;

namespace JLattimer.D365AppInsights
{
    public class AiConfig
    {
        private const string DefaultAiEndpoint = "https://dc.services.visualstudio.com/v2/track";
        public string InstrumentationKey { get; set; }
        public string AiEndpoint { get; set; }
        public bool DisableTraceTracking { get; set; }
        public bool DisableMetricTracking { get; set; }
        public bool DisableEventTracking { get; set; }
        public bool DisableExceptionTracking { get; set; }
        public bool DisableDependencyTracking { get; set; }
        public bool DisableContextParameterTracking { get; set; }
        public bool EnableDebug { get; set; }

        public AiConfig(string instrumentationKey, string aiEndpoint = DefaultAiEndpoint) { }

        public AiConfig(string aiSetupJson)
        {
            AiSetup aiSetup = SerializationHelper.DeserializeObject<AiSetup>(aiSetupJson);

            var aiEndpoint = aiSetup.AiEndpoint;
            if (string.IsNullOrEmpty(aiEndpoint))
                aiEndpoint = DefaultAiEndpoint;

            var instrumentationKey = aiSetup.InstrumentationKey;
            if (string.IsNullOrEmpty(instrumentationKey))
                throw new InvalidPluginExecutionException("Missing Application Insights instrumentation key");

            InstrumentationKey = instrumentationKey;
            AiEndpoint = aiEndpoint;
            DisableTraceTracking = aiSetup.DisableTraceTracking;
            DisableEventTracking = aiSetup.DisableEventTracking;
            DisableDependencyTracking = aiSetup.DisableDependencyTracking;
            DisableExceptionTracking = aiSetup.DisableExceptionTracking;
            DisableMetricTracking = aiSetup.DisableMetricTracking;
            DisableContextParameterTracking = aiSetup.DisableContextParameterTracking;
            EnableDebug = aiSetup.EnableDebug;
        }
    }
}