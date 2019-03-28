using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api
{
    /// <summary>
    /// The class that stores paths used for the application.
    /// </summary>
    public static class ApplicationPaths
    {
        /// <summary>
        /// The endpoint where the JSON file can be found formatted for Swagger.
        /// </summary>
        public const string SwaggerJson = "/swagger/v1/swagger.json";

        /// <summary>
        /// The endpoint where the tokens can be created.
        /// </summary>
        public const string TokenEndpoint = "/connect/token";

        /// <summary>
        /// The endpoint where the user's info can be gathered from a token.
        /// </summary>
        public const string InfoEndpoint = "/api/userinfo";

        /// <summary>
        /// The SignalR URL hub for notification.
        /// </summary>
        public const string NotificationEndpoint = "/notify";

        /// <summary>
        /// The main SQL string used for the database.
        /// </summary>
        public const string MainSqlConnection = "DefaultConnection";
    }
}
