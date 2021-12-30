// <copyright file="MessageMediaClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace MessageMedia.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using MessageMedia.Standard.Authentication;
    using MessageMedia.Standard.Controllers;
    using MessageMedia.Standard.Http.Client;
    using MessageMedia.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class MessageMediaClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Default, "https://api.messagemedia.com/" },
                }
            },
        };

        private readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IHttpClient httpClient;
        private readonly HttpCallBack httpCallBack;
        private readonly BasicAuthManager basicAuthManager;

        private readonly Lazy<MessagesController> messages;
        private readonly Lazy<DeliveryReportsController> deliveryReports;
        private readonly Lazy<RepliesController> replies;
        private readonly Lazy<LookupsController> lookups;
        private readonly Lazy<NumberAuthorisationController> numberAuthorisation;
        private readonly Lazy<DedicatedNumbersController> dedicatedNumbers;
        private readonly Lazy<MessagingReportsController> messagingReports;
        private readonly Lazy<ShortTrackableLinksReportsController> shortTrackableLinksReports;
        private readonly Lazy<WebhooksManagementController> webhooksManagement;
        private readonly Lazy<SignatureKeyManagementController> signatureKeyManagement;
        private readonly Lazy<MobileLandingPagesBetaController> mobileLandingPagesBeta;

        private MessageMediaClient(
            Environment environment,
            string basicAuthUserName,
            string basicAuthPassword,
            IDictionary<string, IAuthManager> authManagers,
            IHttpClient httpClient,
            HttpCallBack httpCallBack,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallBack = httpCallBack;
            this.httpClient = httpClient;
            this.authManagers = (authManagers == null) ? new Dictionary<string, IAuthManager>() : new Dictionary<string, IAuthManager>(authManagers);
            this.HttpClientConfiguration = httpClientConfiguration;

            this.messages = new Lazy<MessagesController>(
                () => new MessagesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.deliveryReports = new Lazy<DeliveryReportsController>(
                () => new DeliveryReportsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.replies = new Lazy<RepliesController>(
                () => new RepliesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.lookups = new Lazy<LookupsController>(
                () => new LookupsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.numberAuthorisation = new Lazy<NumberAuthorisationController>(
                () => new NumberAuthorisationController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.dedicatedNumbers = new Lazy<DedicatedNumbersController>(
                () => new DedicatedNumbersController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.messagingReports = new Lazy<MessagingReportsController>(
                () => new MessagingReportsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.shortTrackableLinksReports = new Lazy<ShortTrackableLinksReportsController>(
                () => new ShortTrackableLinksReportsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.webhooksManagement = new Lazy<WebhooksManagementController>(
                () => new WebhooksManagementController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.signatureKeyManagement = new Lazy<SignatureKeyManagementController>(
                () => new SignatureKeyManagementController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.mobileLandingPagesBeta = new Lazy<MobileLandingPagesBetaController>(
                () => new MobileLandingPagesBetaController(this, this.httpClient, this.authManagers, this.httpCallBack));

            if (this.authManagers.ContainsKey("global"))
            {
                this.basicAuthManager = (BasicAuthManager)this.authManagers["global"];
            }

            if (!this.authManagers.ContainsKey("global")
                || !this.BasicAuthCredentials.Equals(basicAuthUserName, basicAuthPassword))
            {
                this.basicAuthManager = new BasicAuthManager(basicAuthUserName, basicAuthPassword);
                this.authManagers["global"] = this.basicAuthManager;
            }
        }

        /// <summary>
        /// Gets MessagesController controller.
        /// </summary>
        public MessagesController MessagesController => this.messages.Value;

        /// <summary>
        /// Gets DeliveryReportsController controller.
        /// </summary>
        public DeliveryReportsController DeliveryReportsController => this.deliveryReports.Value;

        /// <summary>
        /// Gets RepliesController controller.
        /// </summary>
        public RepliesController RepliesController => this.replies.Value;

        /// <summary>
        /// Gets LookupsController controller.
        /// </summary>
        public LookupsController LookupsController => this.lookups.Value;

        /// <summary>
        /// Gets NumberAuthorisationController controller.
        /// </summary>
        public NumberAuthorisationController NumberAuthorisationController => this.numberAuthorisation.Value;

        /// <summary>
        /// Gets DedicatedNumbersController controller.
        /// </summary>
        public DedicatedNumbersController DedicatedNumbersController => this.dedicatedNumbers.Value;

        /// <summary>
        /// Gets MessagingReportsController controller.
        /// </summary>
        public MessagingReportsController MessagingReportsController => this.messagingReports.Value;

        /// <summary>
        /// Gets ShortTrackableLinksReportsController controller.
        /// </summary>
        public ShortTrackableLinksReportsController ShortTrackableLinksReportsController => this.shortTrackableLinksReports.Value;

        /// <summary>
        /// Gets WebhooksManagementController controller.
        /// </summary>
        public WebhooksManagementController WebhooksManagementController => this.webhooksManagement.Value;

        /// <summary>
        /// Gets SignatureKeyManagementController controller.
        /// </summary>
        public SignatureKeyManagementController SignatureKeyManagementController => this.signatureKeyManagement.Value;

        /// <summary>
        /// Gets MobileLandingPagesBetaController controller.
        /// </summary>
        public MobileLandingPagesBetaController MobileLandingPagesBetaController => this.mobileLandingPagesBeta.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets auth managers.
        /// </summary>
        internal IDictionary<string, IAuthManager> AuthManagers => this.authManagers;

        /// <summary>
        /// Gets http client.
        /// </summary>
        internal IHttpClient HttpClient => this.httpClient;

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the credentials to use with BasicAuth.
        /// </summary>
        public IBasicAuthCredentials BasicAuthCredentials => this.basicAuthManager;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder url = new StringBuilder(EnvironmentsMap[this.Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(url, this.GetBaseUriParameters());

            return url.ToString();
        }

        /// <summary>
        /// Creates an object of the MessageMediaClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .BasicAuthCredentials(this.basicAuthManager.BasicAuthUserName, this.basicAuthManager.BasicAuthPassword)
                .HttpCallBack(this.httpCallBack)
                .HttpClient(this.httpClient)
                .AuthManagers(this.authManagers)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> MessageMediaClient.</returns>
        internal static MessageMediaClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("MESSAGE_MEDIA_STANDARD_ENVIRONMENT");
            string basicAuthUserName = System.Environment.GetEnvironmentVariable("MESSAGE_MEDIA_STANDARD_BASIC_AUTH_USER_NAME");
            string basicAuthPassword = System.Environment.GetEnvironmentVariable("MESSAGE_MEDIA_STANDARD_BASIC_AUTH_PASSWORD");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (basicAuthUserName != null && basicAuthPassword != null)
            {
                builder.BasicAuthCredentials(basicAuthUserName, basicAuthPassword);
            }

            return builder.Build();
        }

        /// <summary>
        /// Makes a list of the BaseURL parameters.
        /// </summary>
        /// <returns>Returns the parameters list.</returns>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = MessageMedia.Standard.Environment.Production;
            private string basicAuthUserName = "";
            private string basicAuthPassword = "";
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private IHttpClient httpClient;
            private HttpCallBack httpCallBack;

            /// <summary>
            /// Sets credentials for BasicAuth.
            /// </summary>
            /// <param name="basicAuthUserName">BasicAuthUserName.</param>
            /// <param name="basicAuthPassword">BasicAuthPassword.</param>
            /// <returns>Builder.</returns>
            public Builder BasicAuthCredentials(string basicAuthUserName, string basicAuthPassword)
            {
                this.basicAuthUserName = basicAuthUserName ?? throw new ArgumentNullException(nameof(basicAuthUserName));
                this.basicAuthPassword = basicAuthPassword ?? throw new ArgumentNullException(nameof(basicAuthPassword));
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

            /// <summary>
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            /// <param name="httpClient"> http client. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            /// <param name="authManagers"> auth managers. </param>
            /// <returns>Builder.</returns>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            /// <param name="httpCallBack"> http callback. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

            /// <summary>
            /// Creates an object of the MessageMediaClient using the values provided for the builder.
            /// </summary>
            /// <returns>MessageMediaClient.</returns>
            public MessageMediaClient Build()
            {
                this.httpClient = new HttpClientWrapper(this.httpClientConfig.Build());

                return new MessageMediaClient(
                    this.environment,
                    this.basicAuthUserName,
                    this.basicAuthPassword,
                    this.authManagers,
                    this.httpClient,
                    this.httpCallBack,
                    this.httpClientConfig.Build());
            }
        }
    }
}
