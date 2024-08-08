using RabbitMQ.Client;
using System;
using System.Collections.Generic;

namespace RabbitMQ.Fakes.DotNetStandard
{
    public class FakeConnectionFactory : IConnectionFactory
    {
        #region Properties

        #region IConnectionFactory Implementation

        public ushort RequestedChannelMax { get; set; }

        public string ClientProvidedName { get; set; }

        public Uri Uri { get; set; }

        public string UserName { get; set; }

        public string VirtualHost { get; set; }

        public bool UseBackgroundThreadsForIO { get; set; }

        public TimeSpan RequestedHeartbeat { get; set; }

        public uint RequestedFrameMax { get; set; }

        public TimeSpan HandshakeContinuationTimeout { get; set; }

        public TimeSpan ContinuationTimeout { get; set; }

        public IDictionary<string, object> ClientProperties { get; set; }

        public string Password { get; set; }

        #endregion IConnectionFactory Implementation

        public IConnection Connection { get; private set; }
        public RabbitServer Server { get; private set; }
        public ICredentialsProvider CredentialsProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICredentialsRefresher CredentialsRefresher { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public FakeConnection UnderlyingConnection => (FakeConnection)Connection;
        public List<FakeModel> UnderlyingModel => UnderlyingConnection == null ? null : UnderlyingConnection.Models;

        #endregion Properties

        #region Constructors

        public FakeConnectionFactory() : this(new RabbitServer()) { }

        public FakeConnectionFactory(RabbitServer server) => Server = server;

        #endregion Constructors

        #region Public Methods

        #region IConnectionFactory Implementation

        public IAuthMechanismFactory AuthMechanismFactory(IList<string> mechanismNames)
        {
            throw new NotImplementedException();
        }

        public IConnection CreateConnection(IList<AmqpTcpEndpoint> endpoints, string clientProvidedName) => throw new NotImplementedException();
        public IConnection CreateConnection(IList<AmqpTcpEndpoint> endpoints) => throw new NotImplementedException();
        public IConnection CreateConnection(IList<string> hostnames, string clientProvidedName) => throw new NotImplementedException();
        public IConnection CreateConnection(IList<string> hostnames) => throw new NotImplementedException();
        public IConnection CreateConnection(string clientProvidedName) => throw new NotImplementedException();

        public IConnection CreateConnection()
        {
            if (Connection == null)
                Connection = new FakeConnection(Server);

            return Connection;
        }

        #endregion IConnectionFactory Implementation

        public FakeConnectionFactory WithConnection(IConnection connection)
        {
            Connection = connection;
            return this;
        }

        public FakeConnectionFactory WithRabbitServer(RabbitServer server)
        {
            Server = server;
            return this;
        }

        #endregion Public Methods
    }
}