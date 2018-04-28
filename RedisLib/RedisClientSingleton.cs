using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisLib
{
    public class RedisClientSingleton
    {
        private static RedisHelper _redisClinet;
        private RedisClientSingleton() { }
        private static object _lockObj = new object();
        public static RedisHelper GetInstance(IConfigurationRoot config)
        {
            if (_redisClinet == null)
            {
                lock (_lockObj)
                {
                    if (_redisClinet == null)
                    {
                        _redisClinet = new RedisHelper(config);
                    }
                }
            }
            return _redisClinet;
        }
    }
}
