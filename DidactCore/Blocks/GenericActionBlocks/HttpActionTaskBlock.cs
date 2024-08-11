﻿using DidactCore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DidactCore.Blocks.GenericActionBlocks
{
    public class HttpActionTaskBlock
    {
        private readonly IDidactDependencyInjector _didactDependencyInjector;

        public async Task ExecuteAsync()
        {
            Console.WriteLine("call google.dk");

            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage1 = await client.GetAsync("https://www.google.dk");
            HttpResponseMessage httpResponseMessage = httpResponseMessage1;
            HttpResponseMessage response = httpResponseMessage;
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(content);

            // show raw response to console

            Console.WriteLine("ran HTTP action task block!");
        }

        public HttpActionTaskBlock(IDidactDependencyInjector didactDependencyInjector)
        {
            //ExecuteAsync().Wait();

            //_didactDependencyInjector = didactDependencyInjector;

            //var actionTaskBlock = _didactDependencyInjector.CreateInstance<ActionTaskBlock>();
            //actionTaskBlock
            //    .WithExecutor(async () =>
            //    {
                    
            //    });
        }
    }
}
