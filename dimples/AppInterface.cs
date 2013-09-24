using System;

namespace dimples
{
	public interface AppInterface
	{
		//function encrypts data stored in some buffer
		//the buffer must be defined by the  implementing class
		string encrypt();
		string getInfo(string request);
		void send(string message, string encryption);
		void read();
	}
}

