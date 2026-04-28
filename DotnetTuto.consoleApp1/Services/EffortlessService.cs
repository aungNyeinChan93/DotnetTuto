using Effortless.Net.Encryption;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.consoleApp1.Services
{
    public class EffortlessService
    {
        
        private readonly byte[] Key = Encoding.ASCII.GetBytes("ZkzFZk8hZkQ9zQ3y9vQZkzFZk8hZkQ==");

        private readonly byte[] IV = Encoding.ASCII.GetBytes("9kFzZkQ9zQ3y9vQZ");

        public string? Encode(string secret)
        {
            var encodedStr = Strings.Encrypt(secret,key:Key,iv:IV);
            return encodedStr;
        }

        public string? Decode(string secret)
        {
            var result = Strings.Decrypt(secret, key: Key, iv: IV);
            return result;
        }
    }
}
