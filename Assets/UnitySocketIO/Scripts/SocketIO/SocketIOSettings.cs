using UnityEngine;
using System.Collections;

namespace UnitySocketIO.SocketIO {
	[System.Serializable]
	public class SocketIOSettings {
		
		public enum URL_TYPE { GLITCH, LOCAL, CUSTOM }

		public URL_TYPE url_type;

		public string url;
		public int port;

		public bool sslEnabled;

		public int reconnectTime;

		public int timeToDropAck;
		
		public int pingTimeout;
		public int pingInterval;

	}
}