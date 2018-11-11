﻿namespace FightCore.Api.Resources.Characters
{
    public class DamageMetricResource
    {
        /// <summary>
        /// Gets or sets the minimum damage the subject can start at
        /// </summary>
        public double StartDamageMin { get; set; }

        /// <summary>
        /// Gets or sets the maximum damage the subject can have to start
        /// </summary>
        public double StartDamageMax { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage that will be done
        /// </summary>
        public double DamageDealt { get; set; }
    }
}